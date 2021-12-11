namespace ModemRebooter.Classes
{
	/// <summary>
	/// Описание сервера
	/// </summary>
	public class TelnetServer
	{
		/// <summary>
		/// IP-адрес сервера
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// Порт сервера (по-умолчанию 23)
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// Timeout запроса (по-умолчанию 200ms)
		/// </summary>
		public int TimeoutMs { get; set; }

		public TelnetServer()
		{
			IpAddress = string.Empty;
			Port = 23;
			TimeoutMs = 200;
		}

		public TelnetServer(string ipAddress, int port, int timeoutMs)
		{
			IpAddress = string.IsNullOrWhiteSpace(ipAddress) ? string.Empty : ipAddress;
			Port = port == 0 ? 23 : port;
			TimeoutMs = timeoutMs == 0 ? 200 : timeoutMs;
		}
	}
}
