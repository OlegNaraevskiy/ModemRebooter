using System;

namespace TelnetAction.Classes
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
