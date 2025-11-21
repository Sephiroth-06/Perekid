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
    public partial class CreateRequestForm : Form
    {
        // Поля класса
        private DataTable selectedProductsTable;
        private decimal currentTotal = 0;
        private decimal discount = 0;
        private decimal finalAmount = 0;

        public CreateRequestForm()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeForm();
        }
        private void ApplyStyle()
        {
            // Стиль формы
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Стиль заголовка
            lblTitle.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(84, 111, 148);

            // Стиль GroupBox
            groupProducts.BackColor = Color.FromArgb(240, 240, 240);
            groupProducts.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);
            groupTotal.BackColor = Color.FromArgb(240, 240, 240);
            groupTotal.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            // Стиль кнопок
            btnCreate.BackColor = Color.FromArgb(84, 111, 148);
            btnCreate.ForeColor = Color.White;
            btnCreate.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnClear.BackColor = Color.FromArgb(171, 207, 206);
            btnClear.Font = new Font("Comic Sans MS", 9);

            btnClear.BackColor = Color.FromArgb(171, 207, 206);
            btnClear.Font = new Font("Comic Sans MS", 9);

            btnAddProduct.BackColor = Color.FromArgb(84, 111, 148);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnRemoveProduct.BackColor = Color.FromArgb(200, 80, 80);
            btnRemoveProduct.ForeColor = Color.White;
            btnRemoveProduct.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            // Стиль ComboBox и TextBox
            comboPartners.BackColor = Color.FromArgb(171, 207, 206);
            comboProducts.BackColor = Color.FromArgb(171, 207, 206);
            txtManager.BackColor = Color.FromArgb(171, 207, 206);
            txtPrice.BackColor = Color.FromArgb(171, 207, 206);
            numQuantity.BackColor = Color.FromArgb(171, 207, 206);
            numDiscount.BackColor = Color.FromArgb(171, 207, 206);

            // Стиль итоговых сумм
            lblTotalAmount.ForeColor = Color.Green;
            lblTotalAmount.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            lblFinalAmount.ForeColor = Color.Green;
            lblFinalAmount.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
        }

        private void InitializeForm()
        {
            // Устанавливаем менеджера
            txtManager.Text = Program.CurrentUserFullName;

            // Инициализируем таблицу для выбранной продукции
            selectedProductsTable = new DataTable();
            selectedProductsTable.Columns.Add("product_id", typeof(int));
            selectedProductsTable.Columns.Add("product_name", typeof(string));
            selectedProductsTable.Columns.Add("quantity", typeof(int));
            selectedProductsTable.Columns.Add("price", typeof(decimal));
            selectedProductsTable.Columns.Add("amount", typeof(decimal));

            gridSelectedProducts.DataSource = selectedProductsTable;
            SetupProductsGrid();

            // Загружаем данные
            LoadFormData();
        }

        private void SetupProductsGrid()
        {
            gridSelectedProducts.AutoGenerateColumns = false;
            gridSelectedProducts.AllowUserToAddRows = false;
            gridSelectedProducts.AllowUserToDeleteRows = false;
            gridSelectedProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Очищаем существующие колонки
            gridSelectedProducts.Columns.Clear();

            // Добавляем колонки
            gridSelectedProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colProductName",
                HeaderText = "Наименование",
                DataPropertyName = "product_name",
                Width = 250,
                ReadOnly = true
            });

            gridSelectedProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colQuantity",
                HeaderText = "Кол-во",
                DataPropertyName = "quantity",
                Width = 80,
                ReadOnly = true
            });

            gridSelectedProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "Цена",
                DataPropertyName = "price",
                Width = 100,
                ReadOnly = true
            });

            gridSelectedProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colAmount",
                HeaderText = "Сумма",
                DataPropertyName = "amount",
                Width = 100,
                ReadOnly = true
            });
        }

        private void LoadFormData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    // Загружаем партнеров
                    comboPartners.Items.Clear();
                    string partnersQuery = "SELECT id, name FROM partners WHERE status = 'active' ORDER BY name";
                    using (var command = new SQLiteCommand(partnersQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboPartners.Items.Add(new PartnerItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }

                    // Загружаем продукцию
                    comboProducts.Items.Clear();
                    string productsQuery = @"
                        SELECT id, name, price_per_unit 
                        FROM products 
                        WHERE status = 'active' 
                        ORDER BY name";
                    using (var command = new SQLiteCommand(productsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboProducts.Items.Add(new ProductItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательные классы
        public class PartnerItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Price:N2} руб.";
            }
        }

        // Методы для обновления сумм
        private void UpdateTotals()
        {
            currentTotal = 0;
            foreach (DataRow row in selectedProductsTable.Rows)
            {
                currentTotal += (decimal)row["amount"];
            }

            discount = numDiscount.Value;
            finalAmount = currentTotal * (1 - discount / 100);

            lblTotalAmount.Text = $"{currentTotal:N2} руб.";
            lblFinalAmount.Text = $"{finalAmount:N2} руб.";
        }

        // Метод для создания заявки
        private bool CreateRequest()
        {
            if (comboPartners.SelectedItem == null)
            {
                MessageBox.Show("Выберите партнера", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (selectedProductsTable.Rows.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну позицию продукции", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var partner = (PartnerItem)comboPartners.SelectedItem;

                            // Генерируем номер заявки
                            string requestNumber = GenerateRequestNumber();

                            // Вставляем заявку
                            string insertRequest = @"
                                INSERT INTO requests (
                                    request_number, partner_id, manager_id, status, 
                                    total_amount, discount, final_amount, created_at
                                ) VALUES (
                                    @number, @partner_id, @manager_id, 'новая',
                                    @total, @discount, @final, CURRENT_TIMESTAMP
                                )";

                            using (var command = new SQLiteCommand(insertRequest, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@number", requestNumber);
                                command.Parameters.AddWithValue("@partner_id", partner.Id);
                                command.Parameters.AddWithValue("@manager_id", Program.CurrentUserId);
                                command.Parameters.AddWithValue("@total", currentTotal);
                                command.Parameters.AddWithValue("@discount", discount);
                                command.Parameters.AddWithValue("@final", finalAmount);

                                command.ExecuteNonQuery();
                            }

                            // Получаем ID созданной заявки
                            string getRequestId = "SELECT id FROM requests WHERE request_number = @number";
                            int requestId;
                            using (var command = new SQLiteCommand(getRequestId, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@number", requestNumber);
                                requestId = Convert.ToInt32(command.ExecuteScalar());
                            }

                            // Вставляем продукцию заявки
                            string insertProducts = @"
                                INSERT INTO request_products (request_id, product_id, quantity, price, amount)
                                VALUES (@request_id, @product_id, @quantity, @price, @amount)";

                            foreach (DataRow row in selectedProductsTable.Rows)
                            {
                                using (var command = new SQLiteCommand(insertProducts, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@request_id", requestId);
                                    command.Parameters.AddWithValue("@product_id", row["product_id"]);
                                    command.Parameters.AddWithValue("@quantity", row["quantity"]);
                                    command.Parameters.AddWithValue("@price", row["price"]);
                                    command.Parameters.AddWithValue("@amount", row["amount"]);

                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            // ДОБАВЬ ЭТО: Обновляем общий объем продаж партнера
                            UpdatePartnerTotalSales(partner.Id);

                            MessageBox.Show(
                                $"Заявка успешно создана!\n\n" +
                                $"Номер: {requestNumber}\n" +
                                $"Партнер: {partner.Name}\n" +
                                $"Сумма: {finalAmount:N2} руб.\n" +
                                $"Скидка: {discount}%",
                                "Успех",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdatePartnerTotalSales(int partnerId)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                UPDATE partners 
                SET total_sales = (
                    SELECT COALESCE(SUM(final_amount), 0) 
                    FROM requests 
                    WHERE partner_id = @partnerId 
                    AND status IN ('оплачена', 'выполнена', 'завершена')
                )
                WHERE id = @partnerId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления total_sales: {ex.Message}");
            }
        }

        private string GenerateRequestNumber()
        {
            return $"S-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }

        private void ClearForm()
        {
            comboPartners.SelectedIndex = -1;
            comboProducts.SelectedIndex = -1;
            numQuantity.Value = 1;
            txtPrice.Clear();
            selectedProductsTable.Rows.Clear();
            numDiscount.Value = 0;
            UpdateTotals();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CreateRequest())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProducts.SelectedItem is ProductItem product)
            {
                // Обновляем цену при выборе продукции
                txtPrice.Text = product.Price.ToString("N2");
            }
            else
            {
                txtPrice.Clear();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (comboProducts.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукцию", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Введите корректное количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = (ProductItem)comboProducts.SelectedItem;
            int quantity = (int)numQuantity.Value;
            decimal amount = product.Price * quantity;

            // Добавляем в таблицу
            selectedProductsTable.Rows.Add(product.Id, product.Name, quantity, product.Price, amount);

            // Обновляем итоги
            UpdateTotals();

            // Сбрасываем поля для следующего добавления
            numQuantity.Value = 1;
            comboProducts.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (gridSelectedProducts.CurrentRow != null && gridSelectedProducts.CurrentRow.Index >= 0)
            {
                int rowIndex = gridSelectedProducts.CurrentRow.Index;
                selectedProductsTable.Rows.RemoveAt(rowIndex);
                UpdateTotals();
            }
            else
            {
                MessageBox.Show("Выберите позицию для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Очистить все данные формы?", "Подтверждение",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }
    }
}
