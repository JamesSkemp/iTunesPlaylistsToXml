using System;
using System.Configuration;

namespace JamesRSkemp.iTunes.PlaylistsToXml {
	public class ConfigData {
		Configuration config;

		/// <summary>
		/// Gets the user's name from the configuration file.
		/// </summary>
		/// <returns>Returns either the user's name, or an empty string, if there isn't one. If there's a problem, returns null.</returns>
		public string GetUserName() {
			string returnValue = null;

			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.HasFile && config.AppSettings.Settings["usersName"] != null) {
					// Get the user's name.
					returnValue = ConfigurationManager.AppSettings["usersName"];
				} else {
					// They don't have an application file, so we'll give them a name.
					SaveUserName("");
					returnValue = "";
				}
			} catch {}
			return returnValue;
		}

		/// <summary>
		/// Saves the user's name to the configuration file.
		/// </summary>
		/// <param name="userName">The user's name that should be stored.</param>
		/// <returns>True if the save worked, false if it did not.</returns>
		public bool SaveUserName(string userName) {
			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["usersName"] != null) {
					config.AppSettings.Settings["usersName"].Value = userName.Trim();
				} else {
					config.AppSettings.Settings.Add("usersName", userName.Trim());
				}
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Gets the currently entered/selected transformation location from the config file.
		/// </summary>
		/// <returns>The data from the configuration file, or null if there isn't one.</returns>
		public string GetTransformation() {
			string returnValue = null;

			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.HasFile && config.AppSettings.Settings["xsltFile"] != null) {
					returnValue = config.AppSettings.Settings["xsltFile"].Value;
				} else {
					SaveTransformation("");
					returnValue = "";
				}
			} catch {}
			return returnValue;
		}

		/// <summary>
		/// Saves the transformation entered/selected to the configuration file.
		/// </summary>
		/// <param name="transform">The path/name of the transformation file.</param>
		/// <returns>True if the save worked, false if it did not.</returns>
		public bool SaveTransformation(string transform) {
			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["xsltFile"] != null) {
					config.AppSettings.Settings["xsltFile"].Value = transform.Trim();
				} else {
					config.AppSettings.Settings.Add("xsltFile", transform.Trim());
				}
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Gets from the configuration whether to connect to iTunes when this application starts up.
		/// </summary>
		/// <returns>True if the application should connect to iTunes when starting, or false otherwise.</returns>
		public bool GetAutoConnect() {
			bool returnValue = false;

			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.HasFile && config.AppSettings.Settings["autoConnect"] != null) {
					Boolean.TryParse(config.AppSettings.Settings["autoConnect"].Value, out returnValue);
				} else {
					SaveAutoConnect(false);
				}
			} catch {}

			return returnValue;
		}

		/// <summary>
		/// Saves whether the user wants the application to connect to iTunes when the application starts to the configuration file.
		/// </summary>
		/// <param name="autoConnect">Boolean of whether to connect to iTunes immediately.</param>
		/// <returns>True if the save worked, false if it did not.</returns>
		public bool SaveAutoConnect(bool autoConnect) {
			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["autoConnect"] != null) {
					config.AppSettings.Settings["autoConnect"].Value = autoConnect.ToString();
				} else {
					config.AppSettings.Settings.Add("autoConnect", autoConnect.ToString());
				}
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Gets from the configuration whether the user wants to replace the artist name with something else if the track is part of a compilation.
		/// </summary>
		/// <param name="compilationArtistText">If the user wants to replace the artist, contains the text to use.</param>
		/// <returns>True if the user wants to have compilation track artist names replaced with something else.</returns>
		public bool GetArtistReplace(out string compilationArtistText) {
			bool returnValue = false;
			compilationArtistText = "";

			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.HasFile && config.AppSettings.Settings["compilationReplace"] != null && config.AppSettings.Settings["compilationArtist"] != null) {
					Boolean.TryParse(config.AppSettings.Settings["compilationReplace"].Value, out returnValue);
					compilationArtistText = config.AppSettings.Settings["compilationArtist"].Value;
				} else {
					SaveArtistReplace(false);
				}
			} catch {}

			return returnValue;
		}

		/// <summary>
		/// Saves whether the artist name should be replaced with something else if the track is part of a compilation.
		/// </summary>
		/// <param name="replaceArtist">Whether the artist name should be replaced for compilations.</param>
		/// <returns>True if the save worked, false if it did not.</returns>
		public bool SaveArtistReplace(bool replaceArtist) {
			return SaveArtistReplace(replaceArtist, "");
		}

		/// <summary>
		/// Saves whether the artist name should be replaced with something else if the track is part of a compilation.
		/// </summary>
		/// <param name="replaceArtist">Whether the artist name should be replaced for compilations.</param>
		/// <param name="compilationArtistText">The text to use instead of the artist name, if replaceArtist is true.</param>
		/// <returns>True if the save worked, false if it did not.</returns>
		public bool SaveArtistReplace(bool replaceArtist, string compilationArtistText) {
			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["compilationReplace"] != null) {
					config.AppSettings.Settings["compilationReplace"].Value = replaceArtist.ToString();
				} else {
					config.AppSettings.Settings.Add("compilationReplace", replaceArtist.ToString());
				}
				if (config.AppSettings.Settings["compilationArtist"] != null) {
					config.AppSettings.Settings["compilationArtist"].Value = compilationArtistText;
				} else {
					config.AppSettings.Settings.Add("compilationArtist", compilationArtistText);
				}
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Gets the name of the file that should be used when saving a playlist, if not the default.
		/// </summary>
		/// <returns>Returns the file name that should be used whenever data is exported. If empty or null use the default.</returns>
		public string GetNewFileName() {
			string returnValue = null;

			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.HasFile && config.AppSettings.Settings["newFileName"] != null) {
					returnValue = ConfigurationManager.AppSettings["newFileName"];
				} else {
					// They don't have an application file, or that setting, so we'll make one.
					SaveNewFileName("");
					returnValue = "";
				}

			} catch { }

			return returnValue;
		}

		/// <summary>
		/// Saves the user's choice of what they want their Xml file to be called. To the config file.
		/// </summary>
		/// <param name="newFileName">The file name that they always want to use. Pass empty string to use the default.</param>
		/// <returns>True if the save worked, false otherwise.</returns>
		public bool SaveNewFileName(string newFileName) {
			try {
				config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings["newFileName"] != null) {
					config.AppSettings.Settings["newFileName"].Value = newFileName.Trim();
				} else {
					config.AppSettings.Settings.Add("newFileName", newFileName.Trim());
				}
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
				return true;
			} catch {
				return false;
			}
		}
	}
}