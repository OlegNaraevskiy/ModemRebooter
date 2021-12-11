namespace ModemRebooter.ConnectChecker.Classes
{
	/// <summary>
	/// Сводка по пингу
	/// </summary>
	public class PingInfo
	{
		/// <summary>
		/// Задержка в мс
		/// </summary>
		public int Delay { get; set; }

		/// <summary>
		/// Процент потерь
		/// </summary>
		public int PacketLoss { get; set; }
	}
}
