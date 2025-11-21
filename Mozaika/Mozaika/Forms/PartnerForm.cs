using Mozaika.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mozaika.Forms
{
    public partial class PartnerForm : Form
    {
        private int? partnerId; // null для добавления, число для редактирования
        private bool isEditMode => partnerId.HasValue;

        public PartnerForm()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeForm();
        }
        // Добавь этот конструктор для редактирования
        public PartnerForm(int id) : this()
        {
            partnerId = id;
            LoadPartnerData();
        }

        private void ApplyStyle()
        {
            // Стилизация как в других формах
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
            // Заполняем комбобокс статусов
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboStatus.SelectedIndex = 0;

            // Устанавливаем заголовок формы
            this.Text = isEditMode ? "Редактирование партнера" : "Добавление партнера";
        }

        private void LoadPartnerData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM partners WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", partnerId.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtPartnerName.Text = reader["name"].ToString();
                                txtPartnerINN.Text = reader["inn"].ToString();
                                txtPartnerPhone.Text = reader["phone"].ToString();
                                txtPartnerEmail.Text = reader["email"].ToString();
                                txtContactPerson.Text = reader["contact_person"].ToString();
                                txtAddress.Text = reader["address"].ToString();
                                numDiscount.Value = Convert.ToDecimal(reader["current_discount"]);
                                comboStatus.SelectedItem = reader["status"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка");
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
                        // Редактирование существующего партнера
                        string query = @"
                        UPDATE partners SET 
                            name = @name,
                            inn = @inn,
                            phone = @phone,
                            email = @email,
                            contact_person = @contact_person,
                            address = @address,
                            current_discount = @discount,
                            status = @status
                        WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.Parameters.AddWithValue("@id", partnerId.Value);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Партнер успешно обновлен", "Успех");
                    }
                    else
                    {
                        // Добавление нового партнера
                        string query = @"
                        INSERT INTO partners (
                            name, inn, phone, email, contact_person, 
                            address, current_discount, status, total_sales
                        ) VALUES (
                            @name, @inn, @phone, @email, @contact_person,
                            @address, @discount, @status, 0
                        )";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Партнер успешно добавлен", "Успех");
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
            command.Parameters.AddWithValue("@name", txtPartnerName.Text.Trim());
            command.Parameters.AddWithValue("@inn", txtPartnerINN.Text.Trim());
            command.Parameters.AddWithValue("@phone", txtPartnerPhone.Text.Trim());
            command.Parameters.AddWithValue("@email", txtPartnerEmail.Text.Trim());
            command.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
            command.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
            command.Parameters.AddWithValue("@discount", numDiscount.Value);
            command.Parameters.AddWithValue("@status", comboStatus.SelectedItem.ToString());
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtPartnerName.Text))
            {
                MessageBox.Show("Введите название компании", "Ошибка");
                txtPartnerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPartnerINN.Text))
            {
                MessageBox.Show("Введите ИНН", "Ошибка");
                txtPartnerINN.Focus();
                return false;
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
