using PrimS.Telnet;
using System;
using System.Threading.Tasks;
using ModemRebooter.TelnetAction.Classes;

/// <summary>
/// Взаимодействие с помощью Telnet
/// </summary>
namespace ModemRebooter.TelnetAction
{
	/// <summary>
	/// Действия Telnet
	/// </summary>
	public class TelnetActions
	{
		/// <summary>
		/// Авторизация на сервере
		/// </summary>
		/// <param name="server">Параметры сервера</param>
		/// <param name="user">Данные пользователя</param>
		/// <returns>Результат операции</returns>
		public async Task<Result> Authorization(TelnetServer server, UserInfo user)
		{

			Result result = new Result();

			try
			{
				#region Тестовые данные (удалить после!)
				server = new TelnetServer()
				{
					IpAddress = "192.168.2.1"
				};

				user = new UserInfo("admin", "50na57am63NA");
				#endregion

				using (Client client = new Client(server.IpAddress, server.Port, new System.Threading.CancellationToken()))
				{
					if (client.IsConnected)
					{
						if (!await client.TryLoginAsync(user.Login, user.Password, server.TimeoutMs))
						{
							result.ErrorCode = 0;
							result.ErrorMessage = "Авторизация на сервере удалась.";
						}
						else
						{
							result.ErrorCode = 2;
							result.ErrorMessage = "Не удалась авторизация на сервере. Проверьте правильность логина и пароля.";
							result.ExceptionInfo = new Exception("Не удалась авторизация на сервере. Проверьте правильность логина и пароля.");
						}
					}
					else
					{
						result.ErrorCode = 1;
						result.ErrorMessage = "Отсутствует соединение с сервером.";
						result.ExceptionInfo = new Exception("Отсутствует соединение с сервером.");
					}                    
				}
			}
			catch (Exception ex)
			{
				result.ErrorCode = -1;
				result.ErrorMessage = "Неизвестная ошибка";
				result.ExceptionInfo = ex;
			}

			return result;
		}

		//public async Task<Result> SendCommand()
		//{

		//}
	}
}
