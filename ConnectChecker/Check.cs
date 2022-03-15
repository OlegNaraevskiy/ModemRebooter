/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using ModemRebooter.ConnectChecker.Classes;
using System.Net.NetworkInformation;

namespace ModemRebooter.ConnectChecker
{
	public class Check
	{
		public static bool PingHost(string nameOrAddress)
		{
			PingResult pingResult = new PingResult();

			bool pingable = false;
			Ping pinger = null;

			try
			{
				pinger = new Ping();
				PingReply reply = pinger.Send(nameOrAddress);
				pingable = reply.Status == IPStatus.Success;
			}
			catch (PingException)
			{
				pingable = false;
			}
			finally
			{
				if (pinger != null)
				{
					pinger.Dispose();
				}
			}

			return pingable;
		}

		//Console.WriteLine(pingReply.RoundtripTime); //время ответа
		//Console.WriteLine(pingReply.Status);        //статус
		//Console.WriteLine(pingReply.Address);       //IP
		//Console.ReadKey(true);
	}
}
