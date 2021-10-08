using ModemRebooter.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace ModemRebooter.Actions
{
	public static class ModemSettingsLoader
	{
		public static async Task LoadSettings()
		{
			try
			{
				// сохранение данных
				using (FileStream fs = new FileStream("modem_data.json", FileMode.OpenOrCreate))
				{
					List<ModemInfo> modems = new List<ModemInfo>();
					
					ModemInfo modem1 = new ModemInfo
					{
						IpAddress = "192.168.2.1",
						Port = 23,
						TimeoutMs = 200,
						AdminAccount = new UserInfo("admin", "50na57am63NA")
					};

					modems.Add(modem1);

					ModemInfo modem2 = new ModemInfo
					{
						IpAddress = "192.168.99.1",
						Port = 23,
						TimeoutMs = 200,
						AdminAccount = new UserInfo("root", "zte9x15")
					};

					modems.Add(modem2);

					string jsonString = JsonConvert.SerializeObject(modems);
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
