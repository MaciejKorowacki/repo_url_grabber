using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Web.WebView2.Core;

namespace URLgrabberTEST
{
    public partial class Form1 : Form
    {
        private bool autoGrabEnabled = false;
        private readonly string urlsFile = "urls.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeWebViewAsync();
            LoadLogo();
            LoadSavedUrls();
            LoadAppIcon(); //  load app/form icon
        }

        //  Load icon for the Form and taskbar
        private void LoadAppIcon()
        {
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo_image.ico");

                // Try loading from EXE directory
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
                else
                {
                    // Fallback to project root if not found
                    string projectIcon = Path.Combine(
                        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName ?? "",
                        "logo_image.ico"
                    );
                    if (File.Exists(projectIcon))
                        this.Icon = new Icon(projectIcon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading app icon: " + ex.Message);
            }
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo_image.png");
                if (File.Exists(logoPath))
                {
                    using (var fs = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
                    {
                        logoPictureBox.Image = Image.FromStream(fs);
                    }
                    logoPictureBox.Visible = true;
                    logoPictureBox.BringToFront();
                }
                else
                {
                    logoPictureBox.Visible = false;
                    logoLabel.Visible = false;
                }
            }
            catch
            {
                logoPictureBox.Visible = false;
                logoLabel.Visible = false;
            }
        }

        private void LoadSavedUrls()
        {
            urlTreeView.Nodes.Clear();
            if (File.Exists(urlsFile))
            {
                string[] savedLinks = File.ReadAllLines(urlsFile);
                foreach (var link in savedLinks)
                    if (!string.IsNullOrWhiteSpace(link))
                        AddLink(link.Trim());
            }
            UpdateStatus();
        }

        private async void InitializeWebViewAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.NavigationStarting += (s, e) => urlTextBox.Text = e.Uri;

            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"
                document.addEventListener('contextmenu', function(e) {
                    let target = e.target;
                    while(target) {
                        if(target.tagName === 'A' && target.href) {
                            e.preventDefault();
                            chrome.webview.postMessage(target.href);
                            break;
                        }
                        target = target.parentElement;
                    }
                });
            ");

            webView.CoreWebView2.WebMessageReceived += (s, ev) =>
            {
                string linkUrl = ev.TryGetWebMessageAsString()?.ToLower();
                if (!string.IsNullOrEmpty(linkUrl))
                {
                    if (autoGrabEnabled)
                        AddLink(linkUrl);
                    else
                    {
                        ContextMenuStrip tempMenu = new ContextMenuStrip();
                        tempMenu.Items.Add("Add link", null, (o, a) => AddLink(linkUrl));
                        tempMenu.Show(Cursor.Position);
                    }
                }
            };
        }

        // --- EVENT HANDLERS ---

        private void goButton_Click(object sender, EventArgs e)
        {
            NavigateToUrl();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (webView.CanGoBack) webView.GoBack();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            PromptAddLink();
        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavigateToUrl();
            }
        }

        private void urlTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && !string.IsNullOrEmpty(e.Node.Name))
                NavigateTo(e.Node.Name);
        }

        private void urlTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = urlTreeView.GetNodeAt(e.X, e.Y);
                treeContextMenu.Items.Clear();

                if (node != null)
                {
                    urlTreeView.SelectedNode = node;
                    treeContextMenu.Items.Add("Remove this link", null, (s, ev) =>
                    {
                        urlTreeView.Nodes.Remove(node);
                        UpdateStatus();
                        SaveUrlsToFile();
                    });
                    treeContextMenu.Items.Add("Rename this link", null, (s, ev) => node.BeginEdit());
                }
                else
                {
                    treeContextMenu.Items.Add("Add a link", null, (s, ev) => PromptAddLink());
                }

                treeContextMenu.Show(urlTreeView, e.Location);
            }
        }

        private void autograbMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            autoGrabEnabled = autograbMenuItem.Checked;
            statusLabel.Text = $"Autograb: {(autoGrabEnabled ? "ON" : "OFF")}";
        }

        private void loadMenuItem_Click(object sender, EventArgs e) => LoadUrlsFromFileDialog();
        private void saveMenuItem_Click(object sender, EventArgs e) => SaveUrlsToFileDialog();
        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            urlTreeView.Nodes.Clear();
            UpdateStatus();
            SaveUrlsToFile();
        }
        private void exitMenuItem_Click(object sender, EventArgs e) => Close();
        private void githubMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/MaciejKorowacki/repo_url_grabber", UseShellExecute = true });
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        // --- LOGIC ---

        private void NavigateToUrl()
        {
            string url = urlTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(url))
                NavigateTo(url);
        }

        private void NavigateTo(string url)
        {
            string lowerUrl = url.ToLower();
            if (!lowerUrl.StartsWith("http://") && !lowerUrl.StartsWith("https://"))
                url = "https://" + url;

            logoPictureBox.Visible = false;
            logoLabel.Visible = false;
            webView.Visible = true;
            splitContainer.Visible = true;
            webView.CoreWebView2.Navigate(url);
        }

        private void PromptAddLink()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the URL:", "Add Link", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                AddLink(input.Trim());
                SaveUrlsToFile();
            }
        }

        private void AddLink(string url)
        {
            if (urlTreeView.Nodes.ContainsKey(url)) return;
            TreeNode node = new TreeNode(url) { Name = url };
            urlTreeView.Nodes.Add(node);
            UpdateStatus();
        }

        private void UpdateStatus() => statusLabel.Text = $"Links: {urlTreeView.Nodes.Count}";
        private void SaveUrlsToFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                    File.WriteAllLines(dlg.FileName, GetLinks());
            }
        }

        private void LoadUrlsFromFileDialog()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    urlTreeView.Nodes.Clear();
                    string[] lines = File.ReadAllLines(dlg.FileName);
                    foreach (var line in lines)
                        if (!string.IsNullOrWhiteSpace(line))
                            AddLink(line.Trim());
                    UpdateStatus();
                }
            }
        }

        private string[] GetLinks()
        {
            string[] links = new string[urlTreeView.Nodes.Count];
            for (int i = 0; i < urlTreeView.Nodes.Count; i++)
                links[i] = urlTreeView.Nodes[i].Name;
            return links;
        }

        private void SaveUrlsToFile() => File.WriteAllLines(urlsFile, GetLinks());

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save URLs before exit?", "Confirm", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes) SaveUrlsToFile();
            else if (result == DialogResult.Cancel) e.Cancel = true;
            base.OnFormClosing(e);
        }
    }
}
