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
using System.Xml.Linq;

namespace Mozaika.Forms
{
    public partial class MaterialForm : Form
    {

        private int? materialId; // null для добавления, число для редактирования
        private bool isEditMode => materialId.HasValue;

        public MaterialForm()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeForm();
        }

        public MaterialForm(int id) : this()
        {
            materialId = id;
            LoadMaterialData();
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
            this.Text = isEditMode ? "Редактирование материала" : "Добавление материала";

            // Заполняем комбобокс типов материалов
            LoadMaterialTypes();

            // Заполняем комбобокс единиц измерения
            LoadUnits();

            // Заполняем комбобокс поставщиков
            LoadSuppliers();

            // Заполняем комбобокс статусов
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboStatus.SelectedIndex = 0;
        }

        private void LoadMaterialTypes()
        {
            try
            {
                comboMaterialType.Items.Clear();

                // Реальные типы материалов для производства плитки
                comboMaterialType.Items.AddRange(new string[] {
            "Сырье", "Пигмент", "Краситель", "Клей",
            "Защитное покрытие", "Упаковка", "Вспомогательные материалы"
        });

                if (comboMaterialType.Items.Count > 0)
                    comboMaterialType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов материалов: {ex.Message}", "Ошибка");
            }
        }

        private void LoadUnits()
        {
            try
            {
                comboUnit.Items.Clear();
                comboUnit.Items.AddRange(new string[] {
                    "кг", "л", "м", "м²", "шт", "упак"
                });

                if (comboUnit.Items.Count > 0)
                    comboUnit.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки единиц измерения: {ex.Message}", "Ошибка");
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                comboSupplier.Items.Clear();
                comboSupplier.Items.Add("-- Без поставщика --");

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, name FROM suppliers WHERE status = 'active' ORDER BY name";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboSupplier.Items.Add(new SupplierItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }

                comboSupplier.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}", "Ошибка");
            }
        }

        private void LoadMaterialData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT m.*, s.name as supplier_name 
                        FROM materials m 
                        LEFT JOIN suppliers s ON m.supplier_id = s.id 
                        WHERE m.id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", materialId.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                comboMaterialType.Text = reader["material_type"].ToString();
                                numCurrentStock.Value = Convert.ToDecimal(reader["current_stock"]);
                                numMinStock.Value = Convert.ToDecimal(reader["min_stock"]);
                                comboUnit.Text = reader["unit"].ToString();
                                numPrice.Value = Convert.ToDecimal(reader["price_per_unit"]);
                                comboStatus.Text = reader["status"].ToString();

                                // Устанавливаем поставщика
                                if (!reader.IsDBNull(reader.GetOrdinal("supplier_id")))
                                {
                                    int supplierId = reader.GetInt32(reader.GetOrdinal("supplier_id"));
                                    foreach (var item in comboSupplier.Items)
                                    {
                                        if (item is SupplierItem supplier && supplier.Id == supplierId)
                                        {
                                            comboSupplier.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных материала: {ex.Message}", "Ошибка");
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
                        // Редактирование существующего материала
                        string query = @"
                            UPDATE materials SET 
                                name = @name,
                                material_type = @material_type,
                                current_stock = @current_stock,
                                min_stock = @min_stock,
                                unit = @unit,
                                price_per_unit = @price_per_unit,
                                supplier_id = @supplier_id,
                                status = @status
                            WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.Parameters.AddWithValue("@id", materialId.Value);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Материал успешно обновлен", "Успех");
                    }
                    else
                    {
                        // Добавление нового материала
                        string query = @"
                            INSERT INTO materials (
                                name, material_type, current_stock, min_stock, 
                                unit, price_per_unit, supplier_id, status
                            ) VALUES (
                                @name, @material_type, @current_stock, @min_stock,
                                @unit, @price_per_unit, @supplier_id, @status
                            )";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            SetCommandParameters(command);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Материал успешно добавлен", "Успех");
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
            command.Parameters.AddWithValue("@material_type", comboMaterialType.Text);
            command.Parameters.AddWithValue("@current_stock", numCurrentStock.Value);
            command.Parameters.AddWithValue("@min_stock", numMinStock.Value);
            command.Parameters.AddWithValue("@unit", comboUnit.Text);
            command.Parameters.AddWithValue("@price_per_unit", numPrice.Value);
            command.Parameters.AddWithValue("@status", comboStatus.Text);

            // Обработка поставщика
            if (comboSupplier.SelectedItem is SupplierItem supplier)
            {
                command.Parameters.AddWithValue("@supplier_id", supplier.Id);
            }
            else
            {
                command.Parameters.AddWithValue("@supplier_id", DBNull.Value);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование материала", "Ошибка");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboMaterialType.Text))
            {
                MessageBox.Show("Выберите тип материала", "Ошибка");
                comboMaterialType.Focus();
                return false;
            }

            if (numCurrentStock.Value < 0)
            {
                MessageBox.Show("Текущий запас не может быть отрицательным", "Ошибка");
                numCurrentStock.Focus();
                return false;
            }

            if (numMinStock.Value < 0)
            {
                MessageBox.Show("Минимальный запас не может быть отрицательным", "Ошибка");
                numMinStock.Focus();
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

        // Вспомогательный класс для комбобокса поставщиков
        public class SupplierItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
