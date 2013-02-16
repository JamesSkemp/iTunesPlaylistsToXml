using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTunesLib;
using System.IO;
using System.Configuration;

namespace JamesRSkemp.iTunes.PlaylistsToXml {
	public partial class FormMain : Form {

		private string[] commandParams;

		public FormMain(String[] args) {
			if (args.Length > 0) {
				commandParams = args;
			}
			InitializeComponent();
		}

		iTunesApp iTunes;
		IITSourceCollection sources;

		bool autoConnect;
		string usersName;
		string usersTransform;
		private string newFileName = "";
		bool replaceCompilationArtist;
		string compilationArtistText;
		string programVersion;
		string startingSource = "";
		string startingPlaylist = "";
		bool autoSave;
		bool autoExit;
		string[] selectedOutputs;

		BackgroundWorker bWorker = new BackgroundWorker();

		private void FormMain_Load(object sender, EventArgs e) {
			programVersion = this.ProductVersion;
			this.Text += " - version " + programVersion;
			// First read in what they've set in their settings.
			ReadConfiguration();
			// Next read in what they've passed, as they want that to override any settings.
			CheckPassedParams();
			if (autoConnect) {
				connectToolStripMenuItem.PerformClick();
			} else {
				toolStripStatusLabel.Text = "Select Connect to connect to iTunes.";
			}
		}

		private void CheckPassedParams() {
			if (commandParams != null && commandParams.Length > 0) {
				foreach (string param in commandParams) {
					if (param == "-connect") {
						autoConnect = true;
					} else if (param.StartsWith("-source:") && param.Length > 8) {
						startingSource = param.Remove(0, 8);
						if ((startingSource.StartsWith("\"") && startingSource.EndsWith("\"")) || (startingSource.StartsWith("'") && startingSource.EndsWith("'"))) {
							startingSource = startingSource.Substring(1, startingSource.Length - 1);
						}
					} else if (param.StartsWith("-playlist:") && param.Length > 10) {
						startingPlaylist = param.Remove(0, 10);
						if ((startingPlaylist.StartsWith("\"") && startingPlaylist.EndsWith("\"")) || (startingPlaylist.StartsWith("'") && startingPlaylist.EndsWith("'"))) {
							startingPlaylist = startingPlaylist.Substring(1, startingPlaylist.Length - 1);
						}
					} else if (param.StartsWith("-output:") && param.Length > 8) {
						string outputsPassed = param.Remove(0, 8);
						if ((outputsPassed.StartsWith("\"") && outputsPassed.EndsWith("\"")) || (outputsPassed.StartsWith("'") && outputsPassed.EndsWith("'"))) {
							selectedOutputs = startingPlaylist.Substring(1, startingPlaylist.Length - 1).Split(',');
						} else {
							selectedOutputs = outputsPassed.Split(',');
						}
					} else if (param == "-save") {
						autoSave = true;
					} else if (param == "-exit") {
						autoExit = true;
					}
				}
			}
			if (startingSource.Length == 0 && startingPlaylist.Length > 0) {
				startingPlaylist = "";
			}
			if (autoSave && startingPlaylist == "") {
				autoSave = false;
			}
			if (autoExit && (!autoConnect || !autoSave)) {
				autoExit = false;
			}
		}

		private void ApplicationStartUp() {
			try {
				// Connect to iTunes.
				iTunes = new iTunesAppClass();
				toolStripStatusLabel.Text = "Connected to iTunes. Attempting to get available sources.";

				// Get the available sources.
				sources = iTunes.Sources;
				toolStripStatusLabel.Text = "Available sources retrieved.";
				// Clear whatever is in the list box.
				listBoxSources.Items.Clear();
				// Generate the listing of fields that can be output in the Xml document.
				foreach (IITSource source in sources) {
					if (source.Kind == ITSourceKind.ITSourceKindLibrary || source.Kind == ITSourceKind.ITSourceKindIPod) {
						toolStripStatusLabel.Text = "Source found. Adding to list.";
						listBoxSources.Items.Add(source.Name);
					}
				}
				toolStripStatusLabel.Text = "All available sources added.";
				toolStripStatusLabel.Text = "Attempting to retrieve configuration settings.";
				toolStripStatusLabel.Text = "Application started. Select a source and/or playlist.";
			} catch (Exception ex) {
				MessageBox.Show("Unable to connect to iTunes. Please exit application and verify that iTunes is installed on your machine." + System.Environment.NewLine + "Message: " + ex.Message);
				return;
			}
			// Setup the main background worker.
			bWorker.WorkerSupportsCancellation = true;
			bWorker.WorkerReportsProgress = true;
			bWorker.DoWork += new DoWorkEventHandler(PopulateXmlDataWorker);
			bWorker.ProgressChanged += new ProgressChangedEventHandler(OnGenericWorkerProgressChanged);

			if (listBoxSources.Items.Count > 0) {
				if (startingSource.Length > 0 && listBoxSources.Items.Contains(startingSource)) {
					listBoxSources.SelectedIndex = listBoxSources.Items.IndexOf(startingSource);
				} else {
					listBoxSources.SelectedIndex = 0;
				}
			}
		}

		private void ReadConfiguration() {
			try {
				ConfigData config = new ConfigData();
				autoConnect = config.GetAutoConnect();
				usersName = config.GetUserName();
				usersTransform = config.GetTransformation();
				newFileName = config.GetNewFileName();
				replaceCompilationArtist = config.GetArtistReplace(out compilationArtistText);
				config = null;
			} catch (Exception ex) {
				MessageBox.Show("Unable to load configuration. Please reinstall this application to enable customization." + Environment.NewLine
					+ "Message: " + ex.Message);
				autoConnect = false;
				usersName = "";
				usersTransform = "iTunesPlaylists2Xml.xslt";
				newFileName = "";
				replaceCompilationArtist = false;
			}
		}

		private void CreateOutputList() {
			// Clear whatever is in the checked list box.
			checkedListBoxExportData.Items.Clear();
			checkedListBoxExportData.Items.Add("Album", true);
			checkedListBoxExportData.Items.Add("Artist", true);
			checkedListBoxExportData.Items.Add("Compilation", false);
			checkedListBoxExportData.Items.Add("Date Added", false);
			checkedListBoxExportData.Items.Add("Disc Count", false);
			checkedListBoxExportData.Items.Add("Disc Number", false);
			checkedListBoxExportData.Items.Add("Genre", false);
			checkedListBoxExportData.Items.Add("Name", true);
			checkedListBoxExportData.Items.Add("Played Count", true);
			checkedListBoxExportData.Items.Add("Played Date", false);
			checkedListBoxExportData.Items.Add("Rating", true);
			checkedListBoxExportData.Items.Add("Time", false);
			checkedListBoxExportData.Items.Add("Track Count", false);
			checkedListBoxExportData.Items.Add("Track Number", false);
			checkedListBoxExportData.Items.Add("Year", false);
			//checkedListBoxExportData.Items.Add("", false);
			if (selectedOutputs != null && selectedOutputs.Length > 0) {
				for (int i = 0; i < checkedListBoxExportData.Items.Count; i++) {
					if (Array.IndexOf(selectedOutputs, checkedListBoxExportData.Items[i].ToString()) >= 0) {
						checkedListBoxExportData.SetItemChecked(i, true);
					} else {
						checkedListBoxExportData.SetItemChecked(i, false);
					}
				}
			}

		}

		private void listBoxSources_SelectedIndexChanged(object sender, EventArgs e) {
			textResults.Text = "";
			toolStripStatusLabel.Text = "Searching for playlists.";
			RefreshPlaylistList();
			toolStripStatusLabel.Text = "Source playlists added.";
		}

		private void RefreshPlaylistList() {
			listBoxPlaylists.Items.Clear();
			// Find the selected source in the available sources, then add all of it's playlists, and stop processing further sources.
			string selectedPlaylist = "";
			foreach (IITSource source in sources) {
				if ((source.Kind == ITSourceKind.ITSourceKindLibrary || source.Kind == ITSourceKind.ITSourceKindIPod) && source.Name == listBoxSources.SelectedItem.ToString()) {
					foreach (IITPlaylist playlist in source.Playlists) {
						if (startingPlaylist.Length > 0 && playlist.Name == startingPlaylist) {
							selectedPlaylist = playlist.Name + " (" + playlist.Tracks.Count + ")";
							listBoxPlaylists.Items.Add(selectedPlaylist);
						} else {
							listBoxPlaylists.Items.Add(playlist.Name + " (" + playlist.Tracks.Count + ")");
						}
					}
					listBoxPlaylists.Sorted = true;
					break;
				}
			}
			if (selectedPlaylist.Length > 0) {
				if (!autoExit) {
					startingPlaylist = "";
				}
				listBoxPlaylists.SelectedIndex = listBoxPlaylists.Items.IndexOf(selectedPlaylist);
			}
		}

		private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e) {
			if (!bWorker.IsBusy && listBoxPlaylists.SelectedItems.Count > 0) {
				bWorker.RunWorkerAsync();
			}
		}

		private void textResults_Click(object sender, EventArgs e) {
			textResults.SelectAll();
		}

		private void linkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			// TODO: Automatically pull in the correct version information.
			System.Diagnostics.Process.Start("http://jamesrskemp.com/apps/iTunesPlaylists2Xml/?" + programVersion);
		}

		private void refreshSourcesToolStripMenuItem_Click(object sender, EventArgs e) {
			iTunes = null;
			ApplicationStartUp();
		}

		private void checkAllToolStripMenuItem_Click(object sender, EventArgs e) {
			// Check all the checkboxes for output.
			for (int i = 0; i < checkedListBoxExportData.Items.Count; i++) {
				checkedListBoxExportData.SetItemChecked(i, true);
			}
		}

		private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e) {
			for (int i = 0; i < checkedListBoxExportData.Items.Count; i++) {
				checkedListBoxExportData.SetItemChecked(i, false);
			}
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
			CreateOutputList();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			if (textResults.Text.Trim() != "") {
				string xmlFileName = "playlistXml-" + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".xml";
				if (newFileName != "") {
					xmlFileName = newFileName;
				}
				if (SaveXmlOutput(textResults.Text.Trim(), xmlFileName)) {
					toolStripStatusLabel.Text = "Playlist Xml saved to file.";
					if (autoExit) {
						this.Close();
					} else {
						MessageBox.Show("Playlist Xml saved as " + xmlFileName + ", in the same directory as this application.");
					}
				} else {
					MessageBox.Show("There was a problem saving this playlist.");
				}
			} else {
				MessageBox.Show("To save a playlist, please generate one by selecting a source and playlist.");
			}
		}

		private bool SaveXmlOutput(string playlistData, string fileName) {
			TextWriter tw = new StreamWriter(fileName);
			tw.Write(playlistData);
			tw.Close();
			// TODO: Verify that it has in fact been written.
			return true;
		}

		private void configureToolStripMenuItem_Click(object sender, EventArgs e) {
			FormConfiguration formConfig = new FormConfiguration();
			if (formConfig.ShowDialog() != DialogResult.Cancel) {
				ReadConfiguration();
			}
		}

		private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
			toolStripStatusLabel.Text = "Attempting to connect to iTunes.";
			ApplicationStartUp();
			CreateOutputList();
			if (iTunes != null) {
				actionsToolStripMenuItem.Visible = true;
				outputToolStripMenuItem.Visible = true;
				xmlToolStripMenuItem.Visible = true;
				panelFull.Visible = true;
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			if (iTunes != null) {
				iTunes = null;
			}
		}

		private void PopulateXmlDataWorker(object s, DoWorkEventArgs e) {
			// Determine what data we'll export, if any.
			bool outputTrackTime = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Time"));
			bool outputTrackName = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Name"));
			bool outputTrackArtist = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Artist"));
			bool outputTrackRating = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Rating"));
			bool outputTrackPlayCount = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Played Count"));
			bool outputTrackPlayDate = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Played Date"));
			bool outputTrackAlbum = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Album"));
			bool outputTrackNumber = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Track Number"));
			bool outputTrackCount = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Track Count"));
			bool outputTrackDiscNumber = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Disc Number"));
			bool outputTrackDiscCount = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Disc Count"));
			bool outputTrackYear = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Year"));
			bool outputTrackGenre = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Genre"));
			bool outputTrackDateAdded = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Date Added"));
			bool outputTrackCompilation = checkedListBoxExportData.GetItemChecked(checkedListBoxExportData.FindStringExact("Compilation"));

			BackgroundWorker worker = s as BackgroundWorker;

			cancelProcessingToolStripMenuItem.Visible = true;
			EnableSelections(false);
			textResults.Text = String.Empty;
			toolStripStatusLabel.Text = "Finding playlist tracks.";
			//MessageBox.Show(listBoxPlaylists.SelectedItem.ToString());
			foreach (IITSource source in sources) {
				if (worker.CancellationPending == true) {
					textResults.Text = "Processing cancelled.";
					e.Cancel = true;
					break;
				} else {
					if ((source.Kind == ITSourceKind.ITSourceKindLibrary || source.Kind == ITSourceKind.ITSourceKindIPod) && source.Name == listBoxSources.SelectedItem.ToString()) {
						foreach (IITPlaylist playlist in source.Playlists) {
							if (worker.CancellationPending == true) {
								textResults.Text = "Processing cancelled.";
								e.Cancel = true;
								break;
							} else {
								if ((playlist.Name + " (" + playlist.Tracks.Count + ")") == listBoxPlaylists.SelectedItem.ToString()) {
									StringBuilder playlistResults = new StringBuilder();
									playlistResults.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine);
									playlistResults.Append("<?xml-stylesheet type=\"text/xsl\" href=\"" + usersTransform + "\"?>" + "<!-- Visit http://jamesrskemp.com/apps/iTunesPlaylists2Xml/?xslt for sample transformations and more. -->" + Environment.NewLine);
									playlistResults.Append("<playlist");
									// Schema information
									playlistResults.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"http://media.jamesrskemp.com/xsd/iTunesPlaylistsToXml.xsd\"");
									playlistResults.Append(" name=\"" + System.Security.SecurityElement.Escape(playlist.Name) + "\" time=\"" + playlist.Time + "\" tracks=\"" + playlist.Tracks.Count + "\">" + Environment.NewLine);
									playlistResults.Append("<information>" + Environment.NewLine);
									// Pull the user's name from a configuration setting.
									playlistResults.Append("<name>" + usersName.ToString() + "</name>" + Environment.NewLine);
									DateTime currentTime = DateTime.Now;
									playlistResults.Append("<updated>" + currentTime.ToString("yyyy-MM-ddTHH:mm:ss") + "</updated><!-- " + programVersion + " -->" + Environment.NewLine);
									playlistResults.Append("</information>" + Environment.NewLine);
									int currentTrack = 0;
									toolStripProgressBar.Value = currentTrack;
									toolStripProgressBar.Minimum = 0;
									toolStripProgressBar.Maximum = playlist.Tracks.Count;
									playlistResults.Append("<!-- Listing of tracks. -->" + Environment.NewLine);
									toolStripStatusLabel.Text = "Getting track information.";

									System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

									stopWatch.Start();

									foreach (IITTrack track in playlist.Tracks) {
										if (worker.CancellationPending == true) {
											textResults.Text = "Processing cancelled.";
											e.Cancel = true;
											break;
										} else {
											currentTrack++;
											playlistResults.Append("<track");
											// Track time.
											if (outputTrackTime) {
												playlistResults.Append(" time=\"" + track.Time + "\"");
											}
											playlistResults.Append(">");
											// Output track name.
											if (outputTrackName) {
												playlistResults.Append("<name>" + System.Security.SecurityElement.Escape(track.Name) + "</name>");
											}
											// Output track artist.
											if (outputTrackArtist) {
												playlistResults.Append("<artist>" + ((replaceCompilationArtist && track.Compilation) ? System.Security.SecurityElement.Escape(compilationArtistText) : System.Security.SecurityElement.Escape(track.Artist)) + "</artist>");
											}
											// Track rating.
											if (outputTrackRating) {
												// The actual rating is found by dividing by 20; 100 = 5 stars, 60 = 3 stars, 0 = no rating.
												if (track.Rating <= 0) {
													playlistResults.Append("<rating>0</rating>");
												} else {
													playlistResults.Append("<rating>" + track.Rating / 20 + "</rating>");
												}
											}
											// Track play count.
											if (outputTrackPlayCount) {
												playlistResults.Append("<playCount>" + track.PlayedCount + "</playCount>");
											}
											// Date the track was last played.
											if (outputTrackPlayDate) {
												// If the track has never been played, the date is sent to 1900 or less.
												if (track.PlayedDate.Year > 1900) {
													playlistResults.Append("<lastPlayed>" + track.PlayedDate.ToString("yyyy-MM-ddTHH:mm:ss") + "</lastPlayed>");
												} else {
													playlistResults.Append("<lastPlayed/>");
												}
											}
											// Output track album.
											if (outputTrackAlbum) {
												playlistResults.Append("<album>" + System.Security.SecurityElement.Escape(track.Album) + "</album>");
											}
											// Output whether it's a compilation.
											if (outputTrackCompilation) {
												playlistResults.Append("<compilation>" + System.Security.SecurityElement.Escape(track.Compilation.ToString().ToLower()) + "</compilation>");
											}
											// Track number on the album.
											if (outputTrackNumber) {
												playlistResults.Append("<trackNumber>" + track.TrackNumber + "</trackNumber>");
											}
											// Total number of tracks on the album.
											if (outputTrackCount) {
												playlistResults.Append("<trackCount>" + track.TrackCount + "</trackCount>");
											}
											// Track's disc in the album.
											if (outputTrackDiscNumber) {
												playlistResults.Append("<discNumber>" + track.DiscNumber + "</discNumber>");
											}
											// Total number of discs for the album.
											if (outputTrackDiscCount) {
												playlistResults.Append("<discCount>" + track.DiscCount + "</discCount>");
											}
											// Track year.
											if (outputTrackYear) {
												playlistResults.Append("<year>" + track.Year + "</year>");
											}
											// Track genre.
											if (outputTrackGenre) {
												playlistResults.Append("<genre>" + System.Security.SecurityElement.Escape(track.Genre) + "</genre>");
											}
											// Date the track was added.
											if (outputTrackDateAdded) {
												playlistResults.Append("<dateAdded>" + track.DateAdded.ToString("yyyy-MM-ddTHH:mm:ss") + "</dateAdded>");
											}

											playlistResults.AppendLine("</track>");
											// Update the progress bar. Since we only generate the maximum value at the start, it's possible for the number of tracks to change, causing an error.
											try {
												if (currentTrack <= toolStripProgressBar.Maximum) {
													toolStripProgressBar.Value = currentTrack;
												} else {
													toolStripProgressBar.Maximum = currentTrack;
													toolStripProgressBar.Value = currentTrack;
												}
											} catch {
												// Swallow the error.
											}
										}
									}
									playlistResults.Append("</playlist>");

									stopWatch.Stop();

									currentTrack = 0;
									toolStripProgressBar.Value = 0;
									toolStripStatusLabel.Text = "Outputting Xml.";
									textResults.Text = playlistResults.ToString();
									playlistResults = null;
									toolStripStatusLabel.Text = "Playlist output to Xml.";
									if (autoSave) {
										saveToolStripMenuItem.PerformClick();
									}

									MessageBox.Show(stopWatch.Elapsed.ToString());

									break;
								}
							}
						}
					}
				}
			}
			if (textResults.Text.Trim() == String.Empty) {
				MessageBox.Show("Unable to export playlist. It's possible the playlist has changed. Try selecting the source, then the playlist, once more.");
			}
			cancelProcessingToolStripMenuItem.Visible = false;
			EnableSelections(true);
			worker.Dispose();
		}

		private void EnableSelections(bool enable) {
			listBoxSources.Enabled = enable;
			checkedListBoxExportData.Enabled = enable;
			listBoxPlaylists.Enabled = enable;
		}

		/// <summary>
		/// Generic handler for background workers, that'll update the main progress bar.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGenericWorkerProgressChanged(object sender, ProgressChangedEventArgs e) {
			toolStripProgressBar.Value = e.ProgressPercentage;
		}

		private void cancelProcessingToolStripMenuItem_Click(object sender, EventArgs e) {
			if (bWorker.IsBusy && !bWorker.CancellationPending) {
				bWorker.CancelAsync();
			}
		}

		private void saveAsHTMLToolStripMenuItem_Click(object sender, EventArgs e) {
			if (textResults.Text.Trim() != "") {
				String xmlFileName = "playlistXml-" + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".xml";
				if (newFileName != "") {
					xmlFileName = newFileName;
				}
				// TODO: This should be moved further up, when settings are loaded/saved.
				if (!xmlFileName.EndsWith(".xml")) {
					xmlFileName += ".xml";
				}

				String htmlFileName = xmlFileName.Replace(".xml", ".html");

				if (XmlData.SaveXmlAndHtml(textResults.Text.Trim(), usersTransform, xmlFileName, htmlFileName)) {
					toolStripStatusLabel.Text = "Playlist Xml saved to file.";
					if (autoExit) {
						this.Close();
					} else {
						MessageBox.Show("Playlist saved as " + xmlFileName + " and " + htmlFileName + ", in the same directory as this application.");
					}
				} else {
					MessageBox.Show("There was a problem saving this playlist.");
				}
			} else {
				MessageBox.Show("To save a playlist, please generate one by selecting a source and playlist.");
			}

		}
	}
}
