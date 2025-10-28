using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace URLgrabberTEST
{
    public partial class Form1 : Form
    {
        private WebView2 webView;
        private TextBox urlTextBox;
        private Button goButton;
        private TreeView urlTreeView;
        private string urlsFile = "urls.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeBrowserComponents();
        }

        private async void InitializeBrowserComponents()
        {
            this.Text = "WebView2 Browser with Persistent Links";
            this.Width = 1400;
            this.Height = 800;

            // URL TextBox
            urlTextBox = new TextBox { Left = 10, Top = 10, Width = 1000 };
            urlTextBox.KeyDown += UrlTextBox_KeyDown; // Enter key support
            this.Controls.Add(urlTextBox);

            // Go Button
            goButton = new Button { Text = "Go", Left = 1020, Top = 8, Width = 100 };
            goButton.Click += GoButton_Click;
            this.Controls.Add(goButton);

            // TreeView
            urlTreeView = new TreeView
            {
                Left = 1130,
                Top = 10,
                Width = 250,
                Height = this.ClientSize.Height - 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right
            };
            urlTreeView.NodeMouseDoubleClick += UrlTreeView_NodeMouseDoubleClick;
            this.Controls.Add(urlTreeView);

            // Load URLs from file
            if (System.IO.File.Exists(urlsFile))
            {
                string[] lines = System.IO.File.ReadAllLines(urlsFile);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        urlTreeView.Nodes.Add(line.Trim());
                }
            }

            // WebView2
            webView = new WebView2
            {
                Left = 10,
                Top = 40,
                Width = 1110,
                Height = this.ClientSize.Height - 50,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);

            // Update textbox when navigation starts (e.g., link clicked)
            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            webView.CoreWebView2.Navigate("https://www.ironpdf.com");
            urlTextBox.Text = "https://www.ironpdf.com";

            // Inject JS to capture right-clicked links
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

            // Handle messages from JS
            webView.CoreWebView2.WebMessageReceived += (sender, args) =>
            {
                string linkUrl = args.TryGetWebMessageAsString();
                if (!string.IsNullOrEmpty(linkUrl))
                {
                    urlTreeView.Nodes.Add(linkUrl);
                    SaveUrlsToFile();
                }
            };
        }

        // Update URL textbox when navigation starts
        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            urlTextBox.Text = e.Uri;
        }

        // Go button click
        private void GoButton_Click(object sender, EventArgs e)
        {
            NavigateToUrl();
        }

        // Handle Enter key in URL textbox
        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep
                NavigateToUrl();
            }
        }

        // Navigate to the URL in the textbox
        private void NavigateToUrl()
        {
            string url = urlTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(url))
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }
                webView.CoreWebView2.Navigate(url);
            }
        }

        // Double-click a node in TreeView
        private void UrlTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && !string.IsNullOrEmpty(e.Node.Text))
            {
                webView.CoreWebView2.Navigate(e.Node.Text);
                urlTextBox.Text = e.Node.Text;
            }
        }

        // Save TreeView URLs to file
        private void SaveUrlsToFile()
        {
            using (var writer = new System.IO.StreamWriter(urlsFile))
            {
                foreach (TreeNode node in urlTreeView.Nodes)
                {
                    writer.WriteLine(node.Text);
                }
            }
        }
    }
}
