using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

namespace JamesRSkemp.iTunes.PlaylistsToXml {
	class XmlData {

		private void GenerateXml() {
		}

		/// <summary>
		/// Saves a string of XML as an XML and transformed HTML file.
		/// </summary>
		/// <param name="xmlData">String of XML to save.</param>
		/// <param name="xslName">Name of the XSL file to use.</param>
		/// <param name="xmlFileName">The name of the XML file to create.</param>
		/// <param name="htmlFileName">The name of the HTML file to create.</param>
		/// <returns></returns>
		internal static Boolean SaveXmlAndHtml(String xmlData, String xslName, String xmlFileName, String htmlFileName) {
			bool dataSaved = false;

			TextWriter tw = new StreamWriter(xmlFileName);
			tw.Write(xmlData);
			tw.Close();
			// TODO: Verify that it has in fact been written.

			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(xslName);
			xslt.Transform(xmlFileName, htmlFileName);

			dataSaved = true;

			return dataSaved;
		}
	}
}
