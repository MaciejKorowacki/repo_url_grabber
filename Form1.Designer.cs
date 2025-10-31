namespace URLgrabberTEST
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TreeView urlTreeView;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem autograbMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem githubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label logoLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.urlTreeView = new System.Windows.Forms.TreeView();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.autograbMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.githubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.logoLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu,
                this.optionsMenu,
                this.helpMenu
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Size = new System.Drawing.Size(1400, 24);

            // File Menu
            this.fileMenu.Text = "File";
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.loadMenuItem, this.saveMenuItem, this.clearMenuItem, this.exitMenuItem
            });
            this.loadMenuItem.Text = "Load";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            this.clearMenuItem.Text = "Clear";
            this.clearMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);

            // Options Menu
            this.optionsMenu.Text = "Options";
            this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.autograbMenuItem
            });
            this.autograbMenuItem.Text = "Autograb";
            this.autograbMenuItem.CheckOnClick = true;
            this.autograbMenuItem.CheckedChanged += new System.EventHandler(this.autograbMenuItem_CheckedChanged);

            // Help Menu
            this.helpMenu.Text = "Help";
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.githubMenuItem, this.aboutMenuItem
            });
            this.githubMenuItem.Text = "Github";
            this.githubMenuItem.Click += new System.EventHandler(this.githubMenuItem_Click);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);

            // Back button
            this.backButton.Location = new System.Drawing.Point(10, 54);
            this.backButton.Size = new System.Drawing.Size(80, 25);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // URL TextBox
            this.urlTextBox.Location = new System.Drawing.Point(100, 54);
            this.urlTextBox.Size = new System.Drawing.Size(900, 23);
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.urlTextBox_KeyDown);

            // Go button
            this.goButton.Location = new System.Drawing.Point(1010, 53);
            this.goButton.Size = new System.Drawing.Size(80, 25);
            this.goButton.Text = "Go";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);

            // Add button
            
            this.addButton = new System.Windows.Forms.Button();
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.addButton.Location = new System.Drawing.Point(1290, 53); // adjust 
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 25);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);


            // SplitContainer
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(10, 84);
            this.splitContainer.Size = new System.Drawing.Size(1380, 650);
            this.splitContainer.SplitterDistance = 1100;
            this.splitContainer.Panel1.Controls.Add(this.webView);
            this.splitContainer.Panel2.Controls.Add(this.urlTreeView);

            // WebView
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;

            // TreeView
            this.urlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTreeView.LabelEdit = true;
            this.urlTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.urlTreeView_MouseUp);
            this.urlTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.urlTreeView_NodeMouseDoubleClick);

            // StatusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 734);
            this.statusStrip.Size = new System.Drawing.Size(1400, 22);
            this.statusLabel.Text = "Ready";

            // Logo
            this.logoPictureBox.Location = new System.Drawing.Point(400, 200);
            this.logoPictureBox.Size = new System.Drawing.Size(200, 200);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoLabel.Location = new System.Drawing.Point(400, 410);
            this.logoLabel.Size = new System.Drawing.Size(600, 50);
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.logoLabel.Text = "URLGrabber";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Form1
            this.ClientSize = new System.Drawing.Size(1400, 756);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.logoLabel);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "URLGrabber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
