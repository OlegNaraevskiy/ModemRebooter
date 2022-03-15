/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

namespace ModemRebooter.Classes
{
	/// <summary>
	/// Описание маршрутизатора
	/// </summary>
	public class ModemInfo
	{
		/// <summary>
		/// Наименование маршуртизатора
		/// </summary>
		public string ModemName { get; set; }

		/// <summary>
		/// Данные для подключения по Telnet
		/// </summary>
		public TelnetServer TelnetServer { get; set; }

		/// <summary>
		/// Данные администратора
		/// </summary>
		public UserInfo AdminAccount { get; set; }
	}
}
