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
