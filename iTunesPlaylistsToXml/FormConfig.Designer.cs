namespace JamesRSkemp.iTunes.PlaylistsToXml {
	partial class FormConfiguration {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguration));
			this.labelUserName = new System.Windows.Forms.Label();
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelTransformation = new System.Windows.Forms.Label();
			this.comboBoxTransformation = new System.Windows.Forms.ComboBox();
			this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
			this.checkBoxCompilation = new System.Windows.Forms.CheckBox();
			this.textBoxCompilationReplace = new System.Windows.Forms.TextBox();
			this.labelCompilationReplace = new System.Windows.Forms.Label();
			this.labelAlwaysSaveAs = new System.Windows.Forms.Label();
			this.textBoxAlwaysSaveAs = new System.Windows.Forms.TextBox();
			this.labelAlwaysSaveNote = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelUserName
			// 
			this.labelUserName.AutoSize = true;
			this.labelUserName.Location = new System.Drawing.Point(29, 38);
			this.labelUserName.Name = "labelUserName";
			this.labelUserName.Size = new System.Drawing.Size(58, 13);
			this.labelUserName.TabIndex = 0;
			this.labelUserName.Text = "User name";
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUserName.Location = new System.Drawing.Point(93, 35);
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size(186, 20);
			this.textBoxUserName.TabIndex = 1;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(123, 212);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(204, 212);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelTransformation
			// 
			this.labelTransformation.AutoSize = true;
			this.labelTransformation.Location = new System.Drawing.Point(10, 64);
			this.labelTransformation.Name = "labelTransformation";
			this.labelTransformation.Size = new System.Drawing.Size(77, 13);
			this.labelTransformation.TabIndex = 4;
			this.labelTransformation.Text = "Transformation";
			// 
			// comboBoxTransformation
			// 
			this.comboBoxTransformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTransformation.FormattingEnabled = true;
			this.comboBoxTransformation.Location = new System.Drawing.Point(93, 61);
			this.comboBoxTransformation.Name = "comboBoxTransformation";
			this.comboBoxTransformation.Size = new System.Drawing.Size(186, 21);
			this.comboBoxTransformation.TabIndex = 5;
			// 
			// checkBoxAutoStart
			// 
			this.checkBoxAutoStart.AutoSize = true;
			this.checkBoxAutoStart.Location = new System.Drawing.Point(12, 12);
			this.checkBoxAutoStart.Name = "checkBoxAutoStart";
			this.checkBoxAutoStart.Size = new System.Drawing.Size(227, 17);
			this.checkBoxAutoStart.TabIndex = 7;
			this.checkBoxAutoStart.Text = "Automatically connect to iTunes on startup";
			this.checkBoxAutoStart.UseVisualStyleBackColor = true;
			// 
			// checkBoxCompilation
			// 
			this.checkBoxCompilation.AutoSize = true;
			this.checkBoxCompilation.Location = new System.Drawing.Point(12, 147);
			this.checkBoxCompilation.Name = "checkBoxCompilation";
			this.checkBoxCompilation.Size = new System.Drawing.Size(263, 17);
			this.checkBoxCompilation.TabIndex = 8;
			this.checkBoxCompilation.Text = "Replace artist name if track is part of a compilation";
			this.checkBoxCompilation.UseVisualStyleBackColor = true;
			this.checkBoxCompilation.CheckedChanged += new System.EventHandler(this.checkBoxCompilation_CheckedChanged);
			// 
			// textBoxCompilationReplace
			// 
			this.textBoxCompilationReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCompilationReplace.Location = new System.Drawing.Point(93, 170);
			this.textBoxCompilationReplace.Name = "textBoxCompilationReplace";
			this.textBoxCompilationReplace.Size = new System.Drawing.Size(186, 20);
			this.textBoxCompilationReplace.TabIndex = 9;
			this.textBoxCompilationReplace.Visible = false;
			// 
			// labelCompilationReplace
			// 
			this.labelCompilationReplace.AutoSize = true;
			this.labelCompilationReplace.Location = new System.Drawing.Point(27, 173);
			this.labelCompilationReplace.Name = "labelCompilationReplace";
			this.labelCompilationReplace.Size = new System.Drawing.Size(60, 13);
			this.labelCompilationReplace.TabIndex = 10;
			this.labelCompilationReplace.Text = "Text to use";
			this.labelCompilationReplace.Visible = false;
			// 
			// labelAlwaysSaveAs
			// 
			this.labelAlwaysSaveAs.AutoSize = true;
			this.labelAlwaysSaveAs.Location = new System.Drawing.Point(7, 91);
			this.labelAlwaysSaveAs.Name = "labelAlwaysSaveAs";
			this.labelAlwaysSaveAs.Size = new System.Drawing.Size(80, 13);
			this.labelAlwaysSaveAs.TabIndex = 11;
			this.labelAlwaysSaveAs.Text = "Always save as";
			// 
			// textBoxAlwaysSaveAs
			// 
			this.textBoxAlwaysSaveAs.Location = new System.Drawing.Point(93, 88);
			this.textBoxAlwaysSaveAs.Name = "textBoxAlwaysSaveAs";
			this.textBoxAlwaysSaveAs.Size = new System.Drawing.Size(182, 20);
			this.textBoxAlwaysSaveAs.TabIndex = 12;
			// 
			// labelAlwaysSaveNote
			// 
			this.labelAlwaysSaveNote.AutoSize = true;
			this.labelAlwaysSaveNote.Location = new System.Drawing.Point(39, 111);
			this.labelAlwaysSaveNote.Name = "labelAlwaysSaveNote";
			this.labelAlwaysSaveNote.Size = new System.Drawing.Size(240, 13);
			this.labelAlwaysSaveNote.TabIndex = 13;
			this.labelAlwaysSaveNote.Text = "(Leave empty to use the default naming structure)";
			// 
			// FormConfiguration
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(291, 247);
			this.Controls.Add(this.labelAlwaysSaveNote);
			this.Controls.Add(this.textBoxAlwaysSaveAs);
			this.Controls.Add(this.labelAlwaysSaveAs);
			this.Controls.Add(this.labelCompilationReplace);
			this.Controls.Add(this.textBoxCompilationReplace);
			this.Controls.Add(this.checkBoxCompilation);
			this.Controls.Add(this.checkBoxAutoStart);
			this.Controls.Add(this.comboBoxTransformation);
			this.Controls.Add(this.labelTransformation);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxUserName);
			this.Controls.Add(this.labelUserName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfiguration";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FormConfiguration_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelUserName;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelTransformation;
		private System.Windows.Forms.ComboBox comboBoxTransformation;
		private System.Windows.Forms.CheckBox checkBoxAutoStart;
		private System.Windows.Forms.CheckBox checkBoxCompilation;
		private System.Windows.Forms.TextBox textBoxCompilationReplace;
		private System.Windows.Forms.Label labelCompilationReplace;
		private System.Windows.Forms.Label labelAlwaysSaveAs;
		private System.Windows.Forms.TextBox textBoxAlwaysSaveAs;
		private System.Windows.Forms.Label labelAlwaysSaveNote;
	}
}