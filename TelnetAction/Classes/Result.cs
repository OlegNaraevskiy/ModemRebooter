/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using System;

namespace ModemRebooter.TelnetAction.Classes
{
	/// <summary>
	/// Результат действия
	/// </summary>
	public class Result
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

		public Result()
		{
			ErrorCode = -1;
			ErrorMessage = string.Empty;
			ExceptionInfo = null;
		}

		public Result(int errorCode, string errorMessage, Exception exceptionInfo)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage ?? string.Empty;
			ExceptionInfo = exceptionInfo;
		}
	}
}
