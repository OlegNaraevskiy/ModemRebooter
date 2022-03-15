using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModemRebooter.Actions
{
	internal struct EncryptData
	{
		public string PassPhrase => "~lNS{FAuXzHnuH@5pzu$a1wz~N1Me4#IQ%JiiJ8mNdF@Unw3Bz";
		public string SaltValue => "NCRW@li8ves@wD7V~xbwEx|9v";
		public string HashAlgorithm => "SHA256";
		public int PasswordIterations => 8;
		public string InitVector => "FZF*g5oK";
		public int KeySize => 256;
	} 

	public static class CryptoActions
	{
		public static string EncryptText(string textToEncrypt)
		{
			string encryptedString = null;

			try
			{
				EncryptData encryptData;

				encryptedString = RijndaelAlgorithm.Encrypt
				(
					textToEncrypt,
					encryptData.PassPhrase,
					encryptData.SaltValue,
					encryptData.HashAlgorithm,
					encryptData.PasswordIterations,
					encryptData.InitVector,
					encryptData.KeySize
				);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"The encryption failed. {ex}");
			}

			return encryptedString;
		}

		public static string DecryptText(string textToDecrypt)
		{
			string decryptedString = null;

			try
			{
				EncryptData encryptData;

				decryptedString = RijndaelAlgorithm.Decrypt
				(
					textToDecrypt,
					encryptData.PassPhrase,
					encryptData.SaltValue,
					encryptData.HashAlgorithm,
					encryptData.PasswordIterations,
					encryptData.InitVector,
					encryptData.KeySize
				);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"The decryption failed. {ex}");
			}

			return decryptedString;
		}
	}

	class RijndaelAlgorithm
	{
		internal static string Encrypt
		(
			string plainText,
			string passPhrase,
			string saltValue,
			string hashAlgorithm,
			int passwordIterations,
			string initVector,
			int keySize
		)
		{
			try
			{
				string cipherText = null;
				//Преобразование строк в байтовые массивы.
				//Предположим, что строки содержат только коды ASCII.
				//Если строки содержат символы Юникода, используйте Юникод, UTF7 или UTF8
				//Кодировки.
				byte[] initVectorBytes = Encoding.Unicode.GetBytes(initVector);
				byte[] saltValueBytes = Encoding.Unicode.GetBytes(saltValue);

				//Преобразование открытого текста в массив байтов.
				byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

				// Во-первых, мы должны создать пароль, из которого будет получен ключ.
				//Этот пароль будет создан из указанной парольной фразы и
				//соли. Пароль будет создан с использованием указанного хэша
				//алгоритма. Создание пароля может выполняться в нескольких итерациях.
				PasswordDeriveBytes password = new PasswordDeriveBytes
				(
					passPhrase,
					saltValueBytes,
					hashAlgorithm,
					passwordIterations
				);

				//Используйте пароль для создания псевдослучайных байтов для шифрования
				//ключа. Укажите размер ключа в байтах (вместо битов).
				byte[] keyBytes = password.GetBytes(keySize / 8);

				//Создать неинициализированный объект шифрования Rijndael.
				RijndaelManaged symmetricKey = new RijndaelManaged();
				symmetricKey.Mode = CipherMode.CBC;

				//Создать шифратор из существующих байтов ключа и инициализации
				//вектор. Размер ключа определяется на основе количества байтов ключа.
				ICryptoTransform encryptor = symmetricKey.CreateEncryptor
				(
					keyBytes,
					initVectorBytes
				);

				//Определите поток памяти, который будет использоваться для хранения зашифрованных данных.
				using (MemoryStream memoryStream = new MemoryStream())
				{
					//Определите криптографический поток (всегда используйте режим записи для шифрования).
					using (CryptoStream cryptoStream = new CryptoStream
					(
						memoryStream,
						encryptor,
						CryptoStreamMode.Write
					))
					{
						//Начните шифровать.
						Task writeTask = Task.Run(() => cryptoStream.WriteAsync(plainTextBytes, 0, plainTextBytes.Length));
						writeTask.Wait();

						if (writeTask.Status == TaskStatus.RanToCompletion)
						{
							//Шифровка конца.
							cryptoStream.FlushFinalBlock();

							if (cryptoStream.HasFlushedFinalBlock)
							{
								//Преобразование зашифрованных данных из потока памяти в массив байтов.
								byte[] cipherTextBytes = memoryStream.ToArray();

								//Преобразование зашифрованных данных в строку в кодировке base64.
								cipherText = Convert.ToBase64String(cipherTextBytes);
							}
						}
					}
				}

				//Возвратите зашифрованную последовательность.
				return cipherText;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		internal static string Decrypt
		(
			string cipherText,
			string passPhrase,
			string saltValue,
			string hashAlgorithm,
			int passwordIterations,
			string initVector,
			int keySize
		)
		{
			try
			{
				string plainText = null;
				//Преобразование строк, определяющих характеристики ключа шифрования, в байтовые массивы.
				byte[] initVectorBytes = Encoding.Unicode.GetBytes(initVector);
				byte[] saltValueBytes = Encoding.Unicode.GetBytes(saltValue);

				//Преобразование нашего зашифрованного текста в массив байтов.
				byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

				//Во-первых, мы должны создать пароль, из которого будет получен ключ
				//Этот пароль будет создан из указанной парольной фразы и значения соли.
				//Пароль будет создан с использованием указанного алгоритма хэша. Создание пароля может выполняться в нескольких итерациях.
				PasswordDeriveBytes password = new PasswordDeriveBytes
				(
					passPhrase,
					saltValueBytes,
					hashAlgorithm,
					passwordIterations
				);

				//Используйте пароль для создания псевдослучайных байтов для шифрования
				//ключа. Укажите размер ключа в байтах (вместо битов).
				byte[] keyBytes = password.GetBytes(keySize / 8);

				//Создать неинициализированный объект шифрования Rijndael.
				RijndaelManaged symmetricKey = new RijndaelManaged();

				//Целесообразно установить режим шифрования "Цепочка блоков шифрования"
				//(CBC). Используйте параметры по умолчанию для других симметричных ключевых параметров.
				symmetricKey.Mode = CipherMode.CBC;

				//Создать дешифратор из существующих байтов ключа и инициализации
				//вектора. Размер ключа определяется на основе номера ключа
				//байты.
				ICryptoTransform decryptor = symmetricKey.CreateDecryptor
				(
					keyBytes,
					initVectorBytes
				);

				using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
				{
					using (CryptoStream cryptoStream = new CryptoStream
					(
						memoryStream,
						decryptor,
						CryptoStreamMode.Read
					))
					{

						byte[] plainTextBytes = new byte[cipherTextBytes.Length];

						//Начните расшифровывать.
						int decryptedByteCount = cryptoStream.Read
						(
							plainTextBytes,
							0,
							plainTextBytes.Length
						);

						//Преобразование расшифрованных данных в строку.
						//Предположим, что исходная строка открытого текста была UTF8-encoded.
						plainText = Encoding.Unicode.GetString
						(
							plainTextBytes,
							0,
							decryptedByteCount
						);
					}
				}

				//Возвратите расшифрованную последовательность.  
				return plainText;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
