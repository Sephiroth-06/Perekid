using System;
using System.Windows.Forms;
using Mozaika.Forms;

namespace Mozaika
{
    internal static class Program
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUserRole { get; set; }
        public static string CurrentUsername { get; set; }
        public static string CurrentUserFullName { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем данные пользователя
                    CurrentUserId = loginForm.CurrentUserId;
                    CurrentUserRole = loginForm.CurrentUserRole;
                    CurrentUsername = loginForm.CurrentUsername;
                    CurrentUserFullName = loginForm.CurrentUserFullName;

                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}