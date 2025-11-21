using System;
using System.Drawing;
using System.Windows.Forms;
using Mozaika.Models;
using System.Data.SQLite;

namespace Mozaika.Forms
{
    public partial class LoginForm : Form
    {
        public int CurrentUserId { get; private set; }
        public string CurrentUserRole { get; private set; }
        public string CurrentUsername { get; private set; }
        public string CurrentUserFullName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            // Стиль формы
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Стиль заголовка
            lblTitle.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(84, 111, 148); // #546F94

            // Стиль текстовых полей
            txtUsername.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE
            txtPassword.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE

            // Стиль кнопки Войти
            btnLogin.BackColor = Color.FromArgb(84, 111, 148); // #546F94
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            // Стиль кнопки Отмена
            btnCancel.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка авторизации
            if (AuthenticateUser(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT u.id, u.username, u.password_hash, u.full_name, r.name as role_name 
                FROM users u 
                INNER JOIN roles r ON u.role_id = r.id 
                WHERE u.username = @username AND u.is_active = 1";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Правильные индексы колонок:
                                // 0 - id, 1 - username, 2 - password_hash, 3 - full_name, 4 - role_name
                                string storedHash = reader.GetString(2); // password_hash
                                string inputHash = DatabaseHelper.HashPassword(password);

                                if (inputHash == storedHash)
                                {
                                    CurrentUserId = reader.GetInt32(0);        // id
                                    CurrentUsername = reader.GetString(1);     // username
                                    CurrentUserFullName = reader.GetString(3);  // full_name
                                    CurrentUserRole = reader.GetString(4);     // role_name
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}\n\nДетали: {ex.StackTrace}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
                                // ВРЕМЕННАЯ ОТЛАДКА
                                //string debugInfo = $"Username: {username}\n" +
                                //                 $"Stored hash: {storedHash}\n" +
                                //                $"Input hash: {inputHash}\n" +
                                //              $"Hashes match: {inputHash == storedHash}";
                                // MessageBox.Show(debugInfo, "Отладка авторизации");