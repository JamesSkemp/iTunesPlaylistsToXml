namespace JamesRSkemp.iTunes.PlaylistsToXml {
	partial class FormMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.linkLabelContact = new System.Windows.Forms.LinkLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelAppleInc = new System.Windows.Forms.Label();
			this.panelFull = new System.Windows.Forms.Panel();
			this.listBoxPlaylists = new System.Windows.Forms.ListBox();
			this.checkedListBoxExportData = new System.Windows.Forms.CheckedListBox();
			this.labelExportData = new System.Windows.Forms.Label();
			this.labelResults = new System.Windows.Forms.Label();
			this.labelPlaylists = new System.Windows.Forms.Label();
			this.listBoxSources = new System.Windows.Forms.ListBox();
			this.labelSources = new System.Windows.Forms.Label();
			this.textResults = new System.Windows.Forms.TextBox();
			this.statusStripMain.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.panelFull.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
			this.statusStripMain.Location = new System.Drawing.Point(0, 499);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(577, 22);
			this.statusStripMain.TabIndex = 0;
			this.statusStripMain.Text = "statusStripMain";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(460, 17);
			this.toolStripStatusLabel.Spring = true;
			this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// linkLabelContact
			// 
			this.linkLabelContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelContact.AutoSize = true;
			this.linkLabelContact.Location = new System.Drawing.Point(438, 486);
			this.linkLabelContact.Name = "linkLabelContact";
			this.linkLabelContact.Size = new System.Drawing.Size(127, 13);
			this.linkLabelContact.TabIndex = 5;
			this.linkLabelContact.TabStop = true;
			this.linkLabelContact.Text = "Created by James Skemp";
			this.linkLabelContact.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.linkLabelContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContact_LinkClicked);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.xmlToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.cancelProcessingToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(577, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.connectToolStripMenuItem.Text = "Connect";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// actionsToolStripMenuItem
			// 
			this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSourcesToolStripMenuItem});
			this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
			this.actionsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.actionsToolStripMenuItem.Text = "Sources";
			this.actionsToolStripMenuItem.Visible = false;
			// 
			// refreshSourcesToolStripMenuItem
			// 
			this.refreshSourcesToolStripMenuItem.Name = "refreshSourcesToolStripMenuItem";
			this.refreshSourcesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.refreshSourcesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.refreshSourcesToolStripMenuItem.Text = "Refresh sources";
			this.refreshSourcesToolStripMenuItem.Click += new System.EventHandler(this.refreshSourcesToolStripMenuItem_Click);
			// 
			// outputToolStripMenuItem
			// 
			this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem,
            this.resetToolStripMenuItem});
			this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
			this.outputToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.outputToolStripMenuItem.Text = "Output";
			this.outputToolStripMenuItem.Visible = false;
			// 
			// checkAllToolStripMenuItem
			// 
			this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
			this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.checkAllToolStripMenuItem.Text = "Check all";
			this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
			// 
			// uncheckAllToolStripMenuItem
			// 
			this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
			this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.uncheckAllToolStripMenuItem.Text = "Uncheck all";
			this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// xmlToolStripMenuItem
			// 
			this.xmlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsHTMLToolStripMenuItem});
			this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
			this.xmlToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.xmlToolStripMenuItem.Text = "Xml";
			this.xmlToolStripMenuItem.Visible = false;
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsHTMLToolStripMenuItem
			// 
			this.saveAsHTMLToolStripMenuItem.Name = "saveAsHTMLToolStripMenuItem";
			this.saveAsHTMLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.saveAsHTMLToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.saveAsHTMLToolStripMenuItem.Text = "Save as HTML";
			this.saveAsHTMLToolStripMenuItem.Click += new System.EventHandler(this.saveAsHTMLToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.configureToolStripMenuItem.Text = "Configure";
			this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
			// 
			// cancelProcessingToolStripMenuItem
			// 
			this.cancelProcessingToolStripMenuItem.Name = "cancelProcessingToolStripMenuItem";
			this.cancelProcessingToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
			this.cancelProcessingToolStripMenuItem.Text = "Cancel processing";
			this.cancelProcessingToolStripMenuItem.Visible = false;
			this.cancelProcessingToolStripMenuItem.Click += new System.EventHandler(this.cancelProcessingToolStripMenuItem_Click);
			// 
			// labelAppleInc
			// 
			this.labelAppleInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelAppleInc.AutoSize = true;
			this.labelAppleInc.Location = new System.Drawing.Point(12, 486);
			this.labelAppleInc.Name = "labelAppleInc";
			this.labelAppleInc.Size = new System.Drawing.Size(146, 13);
			this.labelAppleInc.TabIndex = 6;
			this.labelAppleInc.Text = "iTunes is copyright Apple Inc.";
			// 
			// panelFull
			// 
			this.panelFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelFull.Controls.Add(this.listBoxPlaylists);
			this.panelFull.Controls.Add(this.checkedListBoxExportData);
			this.panelFull.Controls.Add(this.labelExportData);
			this.panelFull.Controls.Add(this.labelResults);
			this.panelFull.Controls.Add(this.labelPlaylists);
			this.panelFull.Controls.Add(this.listBoxSources);
			this.panelFull.Controls.Add(this.labelSources);
			this.panelFull.Controls.Add(this.textResults);
			this.panelFull.Location = new System.Drawing.Point(12, 27);
			this.panelFull.Name = "panelFull";
			this.panelFull.Size = new System.Drawing.Size(553, 456);
			this.panelFull.TabIndex = 7;
			this.panelFull.Visible = false;
			// 
			// listBoxPlaylists
			// 
			this.listBoxPlaylists.FormattingEnabled = true;
			this.listBoxPlaylists.Location = new System.Drawing.Point(365, 17);
			this.listBoxPlaylists.Name = "listBoxPlaylists";
			this.listBoxPlaylists.Size = new System.Drawing.Size(188, 69);
			this.listBoxPlaylists.TabIndex = 13;
			this.listBoxPlaylists.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylists_SelectedIndexChanged);
			// 
			// checkedListBoxExportData
			// 
			this.checkedListBoxExportData.CheckOnClick = true;
			this.checkedListBoxExportData.FormattingEnabled = true;
			this.checkedListBoxExportData.Location = new System.Drawing.Point(234, 7);
			this.checkedListBoxExportData.Name = "checkedListBoxExportData";
			this.checkedListBoxExportData.Size = new System.Drawing.Size(125, 79);
			this.checkedListBoxExportData.TabIndex = 10;
			// 
			// labelExportData
			// 
			this.labelExportData.AutoSize = true;
			this.labelExportData.Location = new System.Drawing.Point(157, 1);
			this.labelExportData.Name = "labelExportData";
			this.labelExportData.Size = new System.Drawing.Size(75, 13);
			this.labelExportData.TabIndex = 8;
			this.labelExportData.Text = "Data to output";
			// 
			// labelResults
			// 
			this.labelResults.AutoSize = true;
			this.labelResults.Location = new System.Drawing.Point(0, 76);
			this.labelResults.Name = "labelResults";
			this.labelResults.Size = new System.Drawing.Size(59, 13);
			this.labelResults.TabIndex = 7;
			this.labelResults.Text = "Xml Output";
			// 
			// labelPlaylists
			// 
			this.labelPlaylists.AutoSize = true;
			this.labelPlaylists.Location = new System.Drawing.Point(365, 1);
			this.labelPlaylists.Name = "labelPlaylists";
			this.labelPlaylists.Size = new System.Drawing.Size(80, 13);
			this.labelPlaylists.TabIndex = 5;
			this.labelPlaylists.Text = "Source playlists";
			// 
			// listBoxSources
			// 
			this.listBoxSources.FormattingEnabled = true;
			this.listBoxSources.Location = new System.Drawing.Point(0, 17);
			this.listBoxSources.Name = "listBoxSources";
			this.listBoxSources.Size = new System.Drawing.Size(154, 56);
			this.listBoxSources.TabIndex = 9;
			this.listBoxSources.SelectedIndexChanged += new System.EventHandler(this.listBoxSources_SelectedIndexChanged);
			// 
			// labelSources
			// 
			this.labelSources.AutoSize = true;
			this.labelSources.Location = new System.Drawing.Point(0, 1);
			this.labelSources.Name = "labelSources";
			this.labelSources.Size = new System.Drawing.Size(90, 13);
			this.labelSources.TabIndex = 6;
			this.labelSources.Text = "Available sources";
			// 
			// textResults
			// 
			this.textResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textResults.Location = new System.Drawing.Point(0, 92);
			this.textResults.Multiline = true;
			this.textResults.Name = "textResults";
			this.textResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textResults.Size = new System.Drawing.Size(553, 364);
			this.textResults.TabIndex = 12;
			this.textResults.Click += new System.EventHandler(this.textResults_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(577, 521);
			this.Controls.Add(this.labelAppleInc);
			this.Controls.Add(this.linkLabelContact);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.menuStrip);
			this.Controls.Add(this.panelFull);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "iTunes Playlists to Xml";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.panelFull.ResumeLayout(false);
			this.panelFull.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.LinkLabel linkLabelContact;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshSourcesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.Label labelAppleInc;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.Panel panelFull;
		private System.Windows.Forms.CheckedListBox checkedListBoxExportData;
		private System.Windows.Forms.Label labelExportData;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.Label labelPlaylists;
		private System.Windows.Forms.ListBox listBoxSources;
		private System.Windows.Forms.Label labelSources;
		private System.Windows.Forms.TextBox textResults;
		private System.Windows.Forms.ListBox listBoxPlaylists;
		private System.Windows.Forms.ToolStripMenuItem cancelProcessingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsHTMLToolStripMenuItem;
	}
}

