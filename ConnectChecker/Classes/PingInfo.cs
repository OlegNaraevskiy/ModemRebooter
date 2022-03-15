/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

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
