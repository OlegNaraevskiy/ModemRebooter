using System;

namespace ModemRebooter.ConnectChecker.Classes
{
	/// <summary>
	/// Результат операции
	/// </summary>
	public class PingResult
	{
		/// <summary>
		/// Код ошибки (по-умолчанию -1 (неизвестная ошибка))
		/// </summary>
		public int ErrorCode { get; set; }

		/// <summary>
		/// Описание ошибки
		/// </summary>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Описание исключения (если имеется)
		/// </summary>
		public Exception ExceptionInfo { get; set; }

		/// <summary>
		/// Сводка по пингу
		/// </summary>
		public PingInfo pingInfo { get; set; }
	}
}
