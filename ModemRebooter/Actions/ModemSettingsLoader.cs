using ModemRebooter.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Text;

namespace ModemRebooter.Actions
{
	public static class ModemSettingsLoader
	{
		public static async Task LoadSettings()
		{
			try
			{
				string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ModemRebooter\\" + "modem_data";
				// сохранение данных
				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					List<ModemInfo> modems = new List<ModemInfo>();

					ModemInfo modem = new ModemInfo()
					{ 
						ModemName = "Dlink",
						AdminAccount = new UserInfo("admin", "50na57am63NA"),
						TelnetServer = new TelnetServer("192.168.2.1", 23, 200)
					};

					modems.Add(modem);

					string jsonString = JsonConvert.SerializeObject(modems);

					CryptoActions.EncryptText(jsonString);
					// преобразуем строку в байты
					byte[] array = System.Text.Encoding.Default.GetBytes(jsonString);
					// запись массива байтов в файл
					await fs.WriteAsync(array, 0, array.Length);
				}

				

				//// чтение данных
				//using (FileStream fs = new FileStream("modem_data.json", FileMode.Append))
				//{
				//	Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
				//	Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
				//}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
