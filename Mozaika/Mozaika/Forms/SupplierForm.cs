using Mozaika.Models;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mozaika.Forms
{
    public partial class SupplierForm : Form
    {
        private int? supplierId;
        private bool isEditMode => supplierId.HasValue;

        public SupplierForm()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeForm();
        }

        public SupplierForm(int id) : this()
        {
            supplierId = id;
            LoadSupplierData();
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Стиль кнопок
            btnSave.BackColor = Color.FromArgb(84, 111, 148);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(171, 207, 206);

            // Стиль полей ввода
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                    textBox.BackColor = Color.FromArgb(171, 207, 206);
                if (control is ComboBox comboBox)
                    comboBox.BackColor = Color.FromArgb(171, 207, 206);
                if (control is NumericUpDown numeric)
                    numeric.BackColor = Color.FromArgb(171, 207, 206);
            }
        }

        private void InitializeForm()
        {
            this.Text = isEditMode ? "Редактирование поставщика" : "Добавление поставщика";

            // Заполняем комбобокс статусов
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboStatus.SelectedIndex = 0;

            // Заполняем рейтинги качества (1-5)
            for (int i = 1; i <= 5; i++)
            {
                comboQualityRating.Items.Add(i);
            }
            comboQualityRating.SelectedIndex = 4; // по умолчанию 5 (лучший рейтинг)
        }

        private void LoadSupplierData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM suppliers WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", supplierId.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                txtContactPerson.Text = reader["contact_person"].ToString();
                                txtPhone.Text = reader["phone"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtAddress.Text = reader["address"].ToString();

                                // Рейтинг качества
                                if (!reader.IsDBNull(reader.GetOrdinal("quality_rating")))
                                {
                                    int rating = reader.GetInt32(reader.GetOrdinal("quality_rating"));
                                    comboQualityRating.SelectedItem = rating;
                                }

                                // Дата начала работы
                                if (!reader.IsDBNull(reader.GetOrdinal("start_date")))
                                {
                                    dateStartDate.Value = Convert.ToDateTime(reader["start_date"]);
                                }

                                // Статус
                                comboStatus.Text = reader["status"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных поставщика: {ex.Message}", "Ошибка");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    if (isEditMode)
                    {
                        // Редактирование существующего поставщика
                        string query = @"
                            UPDATE suppliers SET 
                                name = @name,
                                contact_person = @contact_person,
                                phone = @phone,
                                email = @email,
                                address = @address,
                                quality_rating = @quality_rating,
                                start_date = @start_date,
                                status = @status
                            WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.Parameters.AddWithValue("@id", supplierId.Value);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Поставщик успешно обновлен", "Успех");
                    }
                    else
                    {
                        // Добавление нового поставщика
                        string query = @"
                            INSERT INTO suppliers (
                                name, contact_person, phone, email, address,
                                quality_rating, start_date, status
                            ) VALUES (
                                @name, @contact_person, @phone, @email, @address,
                                @quality_rating, @start_date, @status
                            )";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Поставщик успешно добавлен", "Успех");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка");
            }
        }

        private void SetCommandParameters(SQLiteCommand command)
        {
            command.Parameters.AddWithValue("@name", txtName.Text.Trim());
            command.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
            command.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            command.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            command.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
            command.Parameters.AddWithValue("@quality_rating", comboQualityRating.SelectedItem);
            command.Parameters.AddWithValue("@start_date", dateStartDate.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@status", comboStatus.Text);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название поставщика", "Ошибка");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactPerson.Text))
            {
                MessageBox.Show("Введите контактное лицо", "Ошибка");
                txtContactPerson.Focus();
                return false;
            }

            // Валидация email (если заполнен)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                    if (addr.Address != txtEmail.Text.Trim())
                    {
                        MessageBox.Show("Введите корректный email адрес", "Ошибка");
                        txtEmail.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректный email адрес", "Ошибка");
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}