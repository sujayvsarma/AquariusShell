using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AquariusShell.ConfigurationManagement
{
    /// <summary>
    /// Manages the passwords required for various portions of the Shell.
    /// </summary>
    internal class PasswordManagement
    {

        /// <summary>
        /// Encrypts and securely stores the provided password
        /// </summary>
        /// <param name="moduleIdentifier">The module that requires or is storing this password</param>
        /// <param name="purposeName">Name of the purpose/setting that would require this password</param>
        /// <param name="password">The password</param>
        public static void StorePassword(PasswordModuleNames moduleIdentifier, PasswordUsagePurposes purposeName, string password)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(password);
            Rfc2898DeriveBytes saltBytes = new(_currentSaltValue, 32, 3, HashAlgorithmName.SHA1);

            Aes crypt = Aes.Create();
            crypt.Key = saltBytes.GetBytes(32);
            crypt.IV = saltBytes.GetBytes(16);

            string hash = string.Empty;
            using (MemoryStream m = new())
            {
                using (CryptoStream cs = new(m, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes,0, clearBytes.Length);
                }

                hash = Convert.ToBase64String(m.ToArray());
            }

            using StreamWriter sw = new($"{_currentSaltValue}:{moduleIdentifier}", append: true, encoding: Encoding.UTF8);
            sw.WriteLine($"{purposeName}|{hash}");
        }

        /// <summary>
        /// Verifies that the provided password is the one that was stored earlier
        /// </summary>
        /// <param name="moduleIdentifier">The module that is storing this password</param>
        /// <param name="purposeName">Name of the purpose/setting that would require this password</param>
        /// <param name="password">The password</param>
        /// <returns>True if the password matches the stored one</returns>
        public static bool VerifyPassword(PasswordModuleNames moduleIdentifier, PasswordUsagePurposes purposeName, string password)
            => RetrievePassword(moduleIdentifier, purposeName).Equals(password);

        /// <summary>
        /// Retrieves the stored password
        /// </summary>
        /// <param name="moduleIdentifier">The module that is storing this password</param>
        /// <param name="purposeName">Name of the purpose/setting that would require this password</param>
        /// <returns>Password stored earlier or Empty string</returns>
        public static string RetrievePassword(PasswordModuleNames moduleIdentifier, PasswordUsagePurposes purposeName)
        {
            string storedPassword = string.Empty;
            using (StreamReader sr = new($"{_currentSaltValue}:{moduleIdentifier}", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
                    if ((!string.IsNullOrWhiteSpace(line)) && line.StartsWith($"{purposeName}|"))
                    {
                        storedPassword = line.Replace($"{purposeName}|", "");

                        // We don't break here, because we want the last ever password stored for this purpose.
                    }
                }
            }

            if (storedPassword == string.Empty)
            {
                return string.Empty;
            }

            byte[] codedBytes = Convert.FromBase64String(storedPassword);
            Rfc2898DeriveBytes saltBytes = new(_currentSaltValue, 32, 3, HashAlgorithmName.SHA1);

            Aes crypt = Aes.Create();
            crypt.Key = saltBytes.GetBytes(32);
            crypt.IV = saltBytes.GetBytes(16);

            string decryptedPassword = string.Empty;
            using (MemoryStream m = new())
            {
                using (CryptoStream cs = new(m, crypt.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(codedBytes, 0, codedBytes.Length);
                }

                decryptedPassword = Encoding.UTF8.GetString(m.ToArray());
            }

            return decryptedPassword;
        }



        /// <summary>
        /// Create/initialise the Salt
        /// </summary>
        static PasswordManagement()
        {
            _passwordPath = Path.Combine(Application.StartupPath, "nanative.dll");

            string saltPath = $"{_passwordPath}:$SALT";
            if (!File.Exists(saltPath))
            {
                _currentSaltValue = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)).Trim('=');
                using StreamWriter sw = new(saltPath, false, Encoding.UTF8);
                sw.WriteLine(_currentSaltValue);
                sw.Flush();
            }
        }

        private static readonly string _passwordPath = string.Empty;
        private static readonly string _currentSaltValue = string.Empty;
    }


    /// <summary>
    /// Names of module identifiers
    /// </summary>
    public enum PasswordModuleNames
    {
        /// <summary>
        /// The shell itself
        /// </summary>
        Shell,
    }

    /// <summary>
    /// Purposes of password usage
    /// </summary>
    public enum PasswordUsagePurposes
    {
        /// <summary>
        /// Launching a password protected app, program or file
        /// </summary>
        LaunchPasswordProtectedApp,

        /// <summary>
        /// Launch a Control Panel applet that is otherwise hidden
        /// </summary>
        LaunchHiddenWindowsControlPanelApplet,

        /// <summary>
        /// Launch settings browser
        /// </summary>
        LaunchSettingsBrowser,
    }

}
