using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JamesRSkemp.iTunes.PlaylistsToXml {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain(args));
		}
	}
}
