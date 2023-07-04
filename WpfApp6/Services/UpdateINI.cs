using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6.Services
{
	// Code Might Be Bad Never Really Touched INI Files
	public static class UpdateINI
	{
		public static void WriteToConfig(string SectionName, string PathKey, string NewValue)
		{
			string BaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string DataFolder = Path.Combine(BaseFolder, "Eon");
			Directory.CreateDirectory(DataFolder);
			string FilePath = Path.Combine(DataFolder, "Settings.ini");


			FileIniDataParser parser = new FileIniDataParser(); // nEW!

			IniData iniData;
			if (File.Exists(FilePath))
			{
				iniData = parser.ReadFile(FilePath);
			}
			else
			{
				iniData = new IniData();
			}

			// This Updates The Current Values - IG!?!?!?!?!?!??!?!//

			//IniData iniData = parser.ReadFile(FilePath);
			iniData[SectionName][PathKey] = NewValue;
			parser.WriteFile(FilePath, iniData, null);
		}

		public static string ReadValue(string SectionName, string PathKey) // NO T writing !
		{
			string BaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string DataFolder = Path.Combine(BaseFolder, "Eon");
			string FilePath = Path.Combine(DataFolder, "Settings.ini");

			FileIniDataParser parser = new FileIniDataParser();

			if (File.Exists(FilePath))
			{
				IniData iniData = parser.ReadFile(FilePath);

				return iniData[SectionName][PathKey];
			}
			else
			{
				return "NONE";
			}
		}
	}
}
