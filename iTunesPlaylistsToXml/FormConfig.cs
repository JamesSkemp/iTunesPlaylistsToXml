using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace JamesRSkemp.iTunes.PlaylistsToXml {
	public partial class FormConfiguration : Form {

		ConfigData userData = new ConfigData();

		public FormConfiguration() {
			InitializeComponent();
		}

		private void FormConfiguration_Load(object sender, EventArgs e) {
			try {

				checkBoxAutoStart.Checked = userData.GetAutoConnect();

				if (userData.GetUserName() != null) {
					textBoxUserName.Text = userData.GetUserName();
				} else {
					textBoxUserName.Text = String.Empty;
				}

				try {
					XmlTextReader reader = new XmlTextReader("transforms.xml");
					while (reader.Read()) {
						if (reader.NodeType == XmlNodeType.Element && reader.Name == "fileName" && !reader.IsEmptyElement) {
							reader.Read();
							comboBoxTransformation.Items.Add(reader.Value);
						}
					}
				} catch (Exception ex) {
					MessageBox.Show("Unable to access transforms.xml." + System.Environment.NewLine + "Message: " + ex.Message
						+ System.Environment.NewLine + "Using default transforms.");
					// Populate the standard listing of transformation files.
					comboBoxTransformation.Items.Add("iTunesPlaylists2Xml.xslt");
				}

				try {
					comboBoxTransformation.Text = userData.GetTransformation().ToString();
				} catch { }

				// Populate what file name they want to use when saving, if not the default.
				textBoxAlwaysSaveAs.Text = (userData.GetNewFileName() ?? "");

				string compilationArtist = "";
				checkBoxCompilation.Checked = userData.GetArtistReplace(out compilationArtist);
				textBoxCompilationReplace.Text = compilationArtist;

			} catch (Exception ex) {
				MessageBox.Show("Unable to load application configuration file. Please reinstall this application." + System.Environment.NewLine + "Message: " + ex.Message);
			}
		}

		private void buttonSave_Click(object sender, EventArgs e) {
			try {
				bool autoConnectSaved = false;
				bool usersNameSaved = false;
				bool transformSaved = false;
				bool newFileNameSaved = false;
				bool compilationArtistSaved = false;

				autoConnectSaved = userData.SaveAutoConnect(checkBoxAutoStart.Checked);
				usersNameSaved = userData.SaveUserName(textBoxUserName.Text.Trim());
				transformSaved = userData.SaveTransformation(comboBoxTransformation.Text.ToString());
				newFileNameSaved = userData.SaveNewFileName(textBoxAlwaysSaveAs.Text.Trim());
				compilationArtistSaved = userData.SaveArtistReplace(checkBoxCompilation.Checked, textBoxCompilationReplace.Text);

				if (autoConnectSaved && usersNameSaved && transformSaved && newFileNameSaved && compilationArtistSaved) {
					this.DialogResult = DialogResult.OK;
					this.Close();
				} else {
					MessageBox.Show("There was a problem saving this data." + Environment.NewLine
						+ "Auto connect saved: " + autoConnectSaved.ToString() + Environment.NewLine
						+ "Name saved: " + usersNameSaved.ToString() + Environment.NewLine
						+ "Transformation saved: " + transformSaved.ToString() + Environment.NewLine
						+ "File name to use saved: " + newFileNameSaved.ToString() + Environment.NewLine
						+ "Compilation settings saved: " + compilationArtistSaved.ToString() + Environment.NewLine
						+ "Please try again.");
				}
			} catch (Exception ex) {
				MessageBox.Show("Unable to load application configuration file. Please reinstall this application." + System.Environment.NewLine + "Message: " + ex.Message);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void checkBoxCompilation_CheckedChanged(object sender, EventArgs e) {
			labelCompilationReplace.Visible = checkBoxCompilation.Checked;
			textBoxCompilationReplace.Visible = checkBoxCompilation.Checked;
		}
	}
}
