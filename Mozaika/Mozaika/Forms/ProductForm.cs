using Mozaika.Models;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Mozaika.Forms
{
    public partial class ProductForm : Form
    {
        private int? productId;
        private bool isEditMode => productId.HasValue;

        public ProductForm()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeForm();
        }

        public ProductForm(int id) : this()
        {
            productId = id;
            LoadProductData();
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
            this.Text = isEditMode ? "Редактирование продукции" : "Добавление продукции";

            // Заполняем типы продукции
            LoadProductTypes();

            // Заполняем единицы измерения
            LoadUnits();

            // Заполняем статусы
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboStatus.SelectedIndex = 0;
        }

        private void LoadProductTypes()
        {
            try
            {
                comboProductType.Items.Clear();

                // Загружаем типы из БД или используем стандартные
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT product_type FROM product_type_coefficients ORDER BY product_type";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboProductType.Items.Add(reader["product_type"].ToString());
                        }
                    }
                }

                // Если в БД нет типов, используем стандартные
                if (comboProductType.Items.Count == 0)
                {
                    comboProductType.Items.AddRange(new string[] {
                        "Напольная плитка", "Настенная плитка", "Декоративная плитка",
                        "Бордюр", "Мозаика", "Ступени"
                    });
                }

                if (comboProductType.Items.Count > 0)
                    comboProductType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов продукции: {ex.Message}", "Ошибка");

                // Резервный вариант
                comboProductType.Items.AddRange(new string[] {
                    "Напольная плитка", "Настенная плитка", "Декоративная плитка",
                    "Бордюр", "Мозаика", "Ступени"
                });
                if (comboProductType.Items.Count > 0)
                    comboProductType.SelectedIndex = 0;
            }
        }

        private void LoadUnits()
        {
            try
            {
                comboUnit.Items.Clear();
                comboUnit.Items.AddRange(new string[] {
                    "шт", "м²", "уп", "комплект"
                });

                if (comboUnit.Items.Count > 0)
                    comboUnit.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки единиц измерения: {ex.Message}", "Ошибка");
            }
        }

        private void LoadProductData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM products WHERE id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", productId.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                comboProductType.Text = reader["product_type"].ToString();
                                numPrice.Value = Convert.ToDecimal(reader["price_per_unit"]);
                                comboStatus.Text = reader["status"].ToString();

                                // Единица измерения
                                if (!reader.IsDBNull(reader.GetOrdinal("unit")))
                                {
                                    comboUnit.Text = reader["unit"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных продукции: {ex.Message}", "Ошибка");
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
                        // Редактирование существующей продукции
                        string query = @"
                            UPDATE products SET 
                                name = @name,
                                product_type = @product_type,
                                price_per_unit = @price_per_unit,
                                unit = @unit,
                                status = @status
                            WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.Parameters.AddWithValue("@id", productId.Value);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Продукция успешно обновлена", "Успех");
                    }
                    else
                    {
                        // Добавление новой продукции
                        string query = @"
                            INSERT INTO products (
                                name, product_type, price_per_unit, unit, status
                            ) VALUES (
                                @name, @product_type, @price_per_unit, @unit, @status
                            )";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Продукция успешно добавлена", "Успех");
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
            command.Parameters.AddWithValue("@product_type", comboProductType.Text);
            command.Parameters.AddWithValue("@price_per_unit", numPrice.Value);
            command.Parameters.AddWithValue("@unit", comboUnit.Text);
            command.Parameters.AddWithValue("@status", comboStatus.Text);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование продукции", "Ошибка");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboProductType.Text))
            {
                MessageBox.Show("Выберите тип продукции", "Ошибка");
                comboProductType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboUnit.Text))
            {
                MessageBox.Show("Выберите единицу измерения", "Ошибка");
                comboUnit.Focus();
                return false;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0", "Ошибка");
                numPrice.Focus();
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