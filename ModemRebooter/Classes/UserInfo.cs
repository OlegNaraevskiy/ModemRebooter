/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using System;

namespace ModemRebooter.Classes
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class UserInfo
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; }

		public UserInfo(string login, string password)
		{
			Login = login ?? throw new ArgumentNullException(nameof(login));
			Password = password ?? throw new ArgumentNullException(nameof(password));
		}
	}
}
