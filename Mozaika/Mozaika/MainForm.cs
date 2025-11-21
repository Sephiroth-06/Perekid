using Mozaika.Forms;
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

namespace Mozaika
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyStyle();
            SetupAccessByRole();
            InitializeDashboard();
            this.dataGridRequests.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridRequests_DataError);
            this.dataGridRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridRequests_CellFormatting);
            FixAllPartnersSalesData();
        }

        private void InitializeDashboard()
        {
            // Запускаем таймер для часов
            timerClock.Interval = 1000; // 1 секунда
            timerClock.Tick += timerClock_Tick;
            timerClock.Start();

            UpdateTime();
            LoadDashboardData();
        }

        private void ApplyStyle()
        {
            // Стиль формы
            this.BackColor = Color.White;
            this.Font = new Font("Comic Sans MS", 9);
            this.Text = "Система управления производством Мозаика";

            // Стиль TabControl
            mainTabControl.Font = new Font("Comic Sans MS", 9);

            // Стиль StatusStrip
            statusStrip.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE
            statusStrip.Font = new Font("Comic Sans MS", 8);

            // Стиль MenuStrip
            mainMenu.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE
            mainMenu.Font = new Font("Comic Sans MS", 9);

            // Стиль для вкладки материалов
            btnAddMaterial.BackColor = Color.FromArgb(84, 111, 148); // #546F94
            btnAddMaterial.ForeColor = Color.White;
            btnAddMaterial.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnEditMaterial.BackColor = Color.FromArgb(84, 111, 148); // #546F94
            btnEditMaterial.ForeColor = Color.White;
            btnEditMaterial.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnRefreshMaterials.BackColor = Color.FromArgb(171, 207, 206); // #ABCFCE

            dataGridMaterials.Font = new Font("Comic Sans MS", 8);

            // Стиль для интерфейса расчета
            comboProductType.Font = new Font("Comic Sans MS", 9);
            comboProductType.BackColor = Color.FromArgb(171, 207, 206);

            comboMaterialType.Font = new Font("Comic Sans MS", 9);
            comboMaterialType.BackColor = Color.FromArgb(171, 207, 206);

            txtRawMaterial.BackColor = Color.FromArgb(171, 207, 206);
            txtLength.BackColor = Color.FromArgb(171, 207, 206);
            txtWidth.BackColor = Color.FromArgb(171, 207, 206);

            btnCalculate.BackColor = Color.FromArgb(84, 111, 148);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            // Стиль для новых кнопок на вкладке заявок
            btnCreateRequest.BackColor = Color.FromArgb(84, 111, 148);
            btnCreateRequest.ForeColor = Color.White;
            btnCreateRequest.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnDeleteRequest.BackColor = Color.FromArgb(200, 80, 80); // Красный для удаления
            btnDeleteRequest.ForeColor = Color.White;
            btnDeleteRequest.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnSearch.BackColor = Color.FromArgb(171, 207, 206);
            btnSearch.Font = new Font("Comic Sans MS", 9);

            txtSearch.BackColor = Color.FromArgb(171, 207, 206);

            btnAddSupplier.BackColor = Color.FromArgb(84, 111, 148);
            btnAddSupplier.ForeColor = Color.White;
            btnAddSupplier.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnEditSupplier.BackColor = Color.FromArgb(84, 111, 148);
            btnEditSupplier.ForeColor = Color.White;
            btnEditSupplier.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnAddProduct.BackColor = Color.FromArgb(84, 111, 148);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnEditProduct.BackColor = Color.FromArgb(84, 111, 148);
            btnEditProduct.ForeColor = Color.White;
            btnEditProduct.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            // Стиль для вкладки партнеров
            btnAddPartner.BackColor = Color.FromArgb(84, 111, 148);
            btnAddPartner.ForeColor = Color.White;
            btnAddPartner.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnEditPartner.BackColor = Color.FromArgb(84, 111, 148);
            btnEditPartner.ForeColor = Color.White;
            btnEditPartner.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnDeletePartner.BackColor = Color.FromArgb(200, 80, 80);
            btnDeletePartner.ForeColor = Color.White;
            btnDeletePartner.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnRefreshPartners.BackColor = Color.FromArgb(171, 207, 206);
            btnViewPartnerSales.BackColor = Color.FromArgb(171, 207, 206);
            btnRefreshProducts.BackColor = Color.FromArgb(171, 207, 206);

            btnSearch.BackColor = Color.FromArgb(171, 207, 206);
            txtSearch.BackColor = Color.FromArgb(171, 207, 206);
            comboStatusFilter.BackColor = Color.FromArgb(171, 207, 206);

            // Стиль для кнопок удаления
            btnDeleteMaterial.BackColor = Color.FromArgb(200, 80, 80); // Красный
            btnDeleteMaterial.ForeColor = Color.White;
            btnDeleteMaterial.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnDeleteSupplier.BackColor = Color.FromArgb(200, 80, 80);
            btnDeleteSupplier.ForeColor = Color.White;
            btnDeleteSupplier.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);

            btnDeleteProduct.BackColor = Color.FromArgb(200, 80, 80);
            btnDeleteProduct.ForeColor = Color.White;
            btnDeleteProduct.Font = new Font("Comic Sans MS", 9, FontStyle.Bold);
        }

        private void SetupAccessByRole()
        {
            string role = Program.CurrentUserRole;
            string username = Program.CurrentUsername;
            string fullName = Program.CurrentUserFullName;

            // Обновляем статус бар
            statusUser.Text = $"Пользователь: {username}";
            statusRole.Text = $"Роль: {role}";

            // Настраиваем доступ по ролям
            switch (role.ToLower())
            {
                case "admin":
                    statusAccess.Text = "Режим: Полный доступ";
                    // Все вкладки доступны - ничего не меняем
                    break;

                case "manager":
                    statusAccess.Text = "Режим: Менеджер";
                    // Менеджеру: Партнеры, Заявки, Продукция (только чтение)
                    mainTabControl.TabPages.Remove(tabPageMaterials);
                    mainTabControl.TabPages.Remove(tabPageSuppliers);
                    // Продукцию оставляем, но сделаем readonly
                    break;

                case "production":
                    statusAccess.Text = "Режим: Мастер производства";
                    // Мастеру: Материалы, Поставщики, Продукция
                    mainTabControl.TabPages.Remove(tabPagePartners);
                    mainTabControl.TabPages.Remove(tabPageRequests);
                    break;

                default:
                    statusAccess.Text = "Режим: Ограниченный доступ";
                    // Оставляем только дашборд
                    for (int i = mainTabControl.TabCount - 1; i > 0; i--)
                    {
                        if (mainTabControl.TabPages[i] != tabPageDashboard)
                            mainTabControl.TabPages.RemoveAt(i);
                    }
                    break;
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из системы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Система управления производством 'Мозаика'\nВерсия 1.0",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных для текущей вкладки
            LoadCurrentTabData();
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При переключении вкладки загружаем данные
            LoadCurrentTabData();
        }

        private void LoadCurrentTabData()
        {
            switch (mainTabControl.SelectedTab.Name)
            {
                case "tabPageDashboard":
                    LoadDashboardData();
                    break;
                case "tabPageMaterials":
                    LoadMaterialsData();
                    break;
                case "tabPageSuppliers":
                    LoadSuppliersData();
                    break;
                case "tabPagePartners":
                    LoadPartnersData(); // ДОБАВИТЬ ЭТУ СТРОЧКУ
                    break;
            }
        }

        private void LoadPartnersData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    id,
                    name,
                    inn,
                    phone,
                    email,
                    current_discount,
                    total_sales,
                    status,
                    contact_person,
                    address
                FROM partners 
                WHERE 1=1";

                    // Фильтр по статусу
                    if (comboStatusFiltert.SelectedIndex > 0)
                    {
                        string status = comboStatusFiltert.SelectedItem.ToString();
                        query += " AND status = @status";
                    }

                    // Поиск
                    if (!string.IsNullOrEmpty(txtSearcht.Text.Trim()))
                    {
                        query += " AND (name LIKE @search OR inn LIKE @search OR contact_person LIKE @search)";
                    }

                    query += " ORDER BY name";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (comboStatusFiltert.SelectedIndex > 0)
                        {
                            command.Parameters.AddWithValue("@status", comboStatusFiltert.SelectedItem.ToString());
                        }

                        if (!string.IsNullOrEmpty(txtSearcht.Text.Trim()))
                        {
                            command.Parameters.AddWithValue("@search", $"%{txtSearcht.Text.Trim()}%");
                        }

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Отключаем авто-генерацию колонок
                            dataGridPartners.AutoGenerateColumns = false;

                            // Устанавливаем данные
                            dataGridPartners.DataSource = dt;

                            // ЯВНО устанавливаем привязки данных для каждой колонки
                            if (dataGridPartners.Columns.Contains("colPartnerName"))
                                dataGridPartners.Columns["colPartnerName"].DataPropertyName = "name";

                            if (dataGridPartners.Columns.Contains("colPartnerINN"))
                                dataGridPartners.Columns["colPartnerINN"].DataPropertyName = "inn";

                            if (dataGridPartners.Columns.Contains("colPartnerPhone"))
                                dataGridPartners.Columns["colPartnerPhone"].DataPropertyName = "phone";

                            if (dataGridPartners.Columns.Contains("colPartnerEmail"))
                                dataGridPartners.Columns["colPartnerEmail"].DataPropertyName = "email";

                            if (dataGridPartners.Columns.Contains("colPartnerDiscount"))
                                dataGridPartners.Columns["colPartnerDiscount"].DataPropertyName = "current_discount";

                            if (dataGridPartners.Columns.Contains("colPartnerTotalSales"))
                                dataGridPartners.Columns["colPartnerTotalSales"].DataPropertyName = "total_sales";

                            if (dataGridPartners.Columns.Contains("colPartnerStatus"))
                                dataGridPartners.Columns["colPartnerStatus"].DataPropertyName = "status";

                            // Обновляем статистику
                            UpdatePartnersStats(dt.Rows.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки партнеров: {ex.Message}", "Ошибка");
            }
        }

        // Обновление статистики
        private void UpdatePartnersStats(int totalPartners)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string statsQuery = @"
                SELECT 
                    COUNT(*) as total_partners,
                    SUM(total_sales) as total_sales
                FROM partners 
                WHERE status = 'active'";

                    using (var command = new SQLiteCommand(statsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int activePartners = reader.GetInt32(0);
                            decimal totalSales = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);

                            lblPartnersCount.Text = $"Всего партнеров: {totalPartners} (Активных: {activePartners})";
                            lblTotalSales.Text = $"Общий объем продаж: {totalSales:N2} руб.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblPartnersCount.Text = $"Всего партнеров: {totalPartners}";
            }
        }

        // Загрузка фильтров статусов
        private void LoadPartnerStatusFilters()
        {
            comboStatusFiltert.Items.Clear();
            comboStatusFiltert.Items.Add("Все статусы");
            comboStatusFiltert.Items.Add("active");
            comboStatusFiltert.Items.Add("inactive");
            comboStatusFiltert.SelectedIndex = 0;
        }

        private void LoadDashboardData()
        {
            try
            {
                // Приветствие с полным именем
                lblWelcome.Text = $"Добро пожаловать, {Program.CurrentUserFullName}!";

                // Статистика
                string stats = $"Статистика системы:\n";
                stats += $"• Пользователь: {Program.CurrentUsername}\n";
                stats += $"• ФИО: {Program.CurrentUserFullName}\n";
                stats += $"• Роль: {Program.CurrentUserRole}\n";
                stats += $"• Дата: {DateTime.Now:dd.MM.yyyy}";

                lblStats.Text = stats;

                // Загружаем уведомления по ролям
                LoadAlertsByRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки дашборда: {ex.Message}");
            }
        }

        private void LoadAlertsByRole()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Тип", typeof(string));
            dt.Columns.Add("Сообщение", typeof(string));
            dt.Columns.Add("Дата", typeof(string));

            string role = Program.CurrentUserRole.ToLower();

            // Общие уведомления для всех
            dt.Rows.Add("ℹ️", "Система запущена", DateTime.Now.ToString("dd.MM.yyyy"));

            // Уведомления по ролям
            switch (role)
            {
                case "admin":
                    dt.Rows.Add("🔧", "Административный доступ", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("⚠️", "Низкий запас материалов", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("💰", "Требуется проверка заявок", DateTime.Now.ToString("dd.MM.yyyy"));
                    break;

                case "manager":
                    dt.Rows.Add("💰", "Новые заявки от партнеров", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("📊", "Статистика продаж готова", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("🤝", "Партнеры ожидают ответа", DateTime.Now.ToString("dd.MM.yyyy"));
                    break;

                case "production":
                    dt.Rows.Add("⚠️", "Низкий запас материалов", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("🏭", "Производственный план", DateTime.Now.ToString("dd.MM.yyyy"));
                    dt.Rows.Add("📦", "Требуется заказ сырья", DateTime.Now.ToString("dd.MM.yyyy"));
                    break;
            }

            dataGridAlerts.DataSource = dt;
        }

        private void LoadAlerts()
        {
            // TODO: Загрузить реальные уведомления из БД
            // Пока заглушка
            DataTable dt = new DataTable();
            dt.Columns.Add("Тип", typeof(string));
            dt.Columns.Add("Сообщение", typeof(string));
            dt.Columns.Add("Дата", typeof(string));

            dt.Rows.Add("⚠️", "Низкий запас материалов", DateTime.Now.ToString("dd.MM.yyyy"));
            dt.Rows.Add("ℹ️", "Система запущена", DateTime.Now.ToString("dd.MM.yyyy"));

            dataGridAlerts.DataSource = dt;
        }

        private string GetCurrentUsername()
        {
            return Program.CurrentUsername; // Теперь используем реальные данные
        }

        private void LoadMaterialsData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    m.name as material_name,
                    m.material_type,
                    m.current_stock,
                    m.min_stock,
                    m.unit,
                    m.price_per_unit,
                    s.name as supplier_name,
                    m.id  -- оставляем ID для связи, но не будем его показывать
                FROM materials m
                LEFT JOIN suppliers s ON m.supplier_id = s.id
                WHERE m.status = 'active'
                ORDER BY m.name";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        // Создаем DataTable вручную БЕЗ ID колонки
                        DataTable dt = new DataTable();
                        dt.Columns.Add("material_name", typeof(string));
                        dt.Columns.Add("material_type", typeof(string));
                        dt.Columns.Add("current_stock", typeof(int));
                        dt.Columns.Add("min_stock", typeof(int));
                        dt.Columns.Add("unit", typeof(string));
                        dt.Columns.Add("price_per_unit", typeof(decimal));
                        dt.Columns.Add("supplier_name", typeof(string));
                        dt.Columns.Add("material_id", typeof(int)); // скрытый ID

                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["material_name"],
                                reader["material_type"],
                                reader["current_stock"],
                                reader["min_stock"],
                                reader["unit"],
                                reader["price_per_unit"],
                                reader["supplier_name"],
                                reader["id"]  // сохраняем ID для связи
                            );
                        }

                        // Отключаем авто-генерацию
                        dataGridMaterials.AutoGenerateColumns = false;

                        // Настраиваем колонки
                        SetupMaterialsGridColumns();

                        // Устанавливаем данные
                        dataGridMaterials.DataSource = dt;

                        // Счетчик
                        lblMaterialsCount.Text = $"Всего материалов: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки материалов: {ex.Message}", "Ошибка");
            }
        }

        private void SetupMaterialsGridColumns()
        {
            // Очищаем существующие колонки
            dataGridMaterials.Columns.Clear();

            // Добавляем ВСЕ колонки которые хотим видеть
            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMaterialName",
                HeaderText = "Наименование",
                DataPropertyName = "material_name",
                Width = 150,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMaterialType",
                HeaderText = "Тип",
                DataPropertyName = "material_type",
                Width = 100,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCurrentStock",
                HeaderText = "Текущий запас",
                DataPropertyName = "current_stock",
                Width = 90,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colMinStock",
                HeaderText = "Мин. запас",
                DataPropertyName = "min_stock",
                Width = 80,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colUnit",
                HeaderText = "Ед. изм.",
                DataPropertyName = "unit",
                Width = 70,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "Цена",
                DataPropertyName = "price_per_unit",
                Width = 80,
                ReadOnly = true
            });

            dataGridMaterials.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSupplier",
                HeaderText = "Поставщик",
                DataPropertyName = "supplier_name",
                Width = 120,
                ReadOnly = true
            });

            // Настройки таблицы
            dataGridMaterials.AllowUserToAddRows = false;
            dataGridMaterials.AllowUserToDeleteRows = false;
            dataGridMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadSuppliersData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    // Очищаем таблицу
                    dataGridSuppliers.Rows.Clear();

                    string query = @"
                SELECT s.name, s.quality_rating, s.start_date, s.contact_person, s.phone
                FROM suppliers s
                WHERE s.status = 'active'";

                    // Фильтрация по материалу
                    if (comboMaterials.SelectedIndex > 0)
                    {
                        var material = (MaterialItem)comboMaterials.SelectedItem;
                        query += @" AND s.id IN (
                    SELECT supplier_id FROM materials 
                    WHERE id = @materialId AND status = 'active'
                )";
                    }

                    query += " ORDER BY s.quality_rating DESC, s.name";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (comboMaterials.SelectedIndex > 0)
                        {
                            var material = (MaterialItem)comboMaterials.SelectedItem;
                            command.Parameters.AddWithValue("@materialId", material.Id);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridSuppliers.Rows.Add(
                                    reader["name"],
                                    reader["quality_rating"],
                                    reader["start_date"] == DBNull.Value ? "Не указана" : Convert.ToDateTime(reader["start_date"]).ToString("dd.MM.yyyy"),
                                    reader["contact_person"],
                                    reader["phone"]
                                );
                            }
                        }
                    }
                }

                // Обновляем заголовок
                if (comboMaterials.SelectedIndex == 0)
                    lblSelectedMaterial.Text = "Все поставщики";
                else
                    lblSelectedMaterial.Text = $"Поставщики материала: {comboMaterials.Text}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}", "Ошибка");
            }
        }

        private void RefreshMaterialComboBox()
        {
            try
            {
                // Сохраняем текущий выбор
                object selectedItem = comboMaterials.SelectedItem;

                comboMaterials.Items.Clear();
                comboMaterials.Items.Add("Все материалы");

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, name FROM materials WHERE status = 'active' ORDER BY name";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboMaterials.Items.Add(new MaterialItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }

                // Восстанавливаем выбор если возможно
                if (selectedItem != null)
                {
                    comboMaterials.SelectedItem = selectedItem;
                }
                else
                {
                    comboMaterials.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления списка материалов: {ex.Message}", "Ошибка");
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            statusTime.Text = $"Время: {DateTime.Now:HH:mm:ss}";
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            using (var form = new MaterialForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMaterialsData(); // обновляем список материалов
                    RefreshMaterialComboBox(); // обновляем комбобокс выбора материалов
                    RefreshMaterialTypesComboBox(); // обновляем комбобокс ТИПОВ материалов в калькуляторе
                }
            }
        }

        private void btnEditMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridMaterials.CurrentRow == null || dataGridMaterials.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите материал для редактирования", "Информация");
                return;
            }

            var selectedRowIndex = dataGridMaterials.CurrentRow.Index;
            var dataTable = (DataTable)dataGridMaterials.DataSource;
            var materialId = Convert.ToInt32(dataTable.Rows[selectedRowIndex]["material_id"]);

            using (var form = new MaterialForm(materialId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMaterialsData(); // обновляем список материалов
                    RefreshMaterialComboBox(); // обновляем комбобокс выбора материалов
                    RefreshMaterialTypesComboBox(); // обновляем комбобокс ТИПОВ материалов в калькуляторе
                }
            }
        }

        private void RefreshMaterialTypesComboBox()
        {
            try
            {
                // Сохраняем текущий выбор
                string currentSelection = comboMaterialType.Text;

                // Очищаем и перезагружаем типы материалов
                comboMaterialType.Items.Clear();

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT material_type FROM materials WHERE status = 'active' ORDER BY material_type";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboMaterialType.Items.Add(reader["material_type"].ToString());
                        }
                    }
                }

                // Восстанавливаем выбор если возможно
                if (!string.IsNullOrEmpty(currentSelection) && comboMaterialType.Items.Contains(currentSelection))
                {
                    comboMaterialType.SelectedItem = currentSelection;
                }
                else if (comboMaterialType.Items.Count > 0)
                {
                    comboMaterialType.SelectedIndex = 0;
                }

                Console.WriteLine($"Обновлен комбобокс типов материалов. Элементов: {comboMaterialType.Items.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления типов материалов: {ex.Message}", "Ошибка");
            }
        }

        private void btnRefreshMaterials_Click(object sender, EventArgs e)
        {
            LoadMaterialsData();
        }

        private void tabPageMaterials_Enter(object sender, EventArgs e)
        {
            LoadMaterialsData();

            // Обновляем комбобокс в поставщиках если он открыт
            if (mainTabControl.SelectedTab == tabPageSuppliers)
            {
                RefreshMaterialComboBox();
            }
        }

        private void dataGridMaterials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем что кликнули не на заголовке и не на пустом месте
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // При двойном клике по строке - редактируем материал
                btnEditMaterial_Click(sender, e);
            }
        }

        private void TabPageSuppliers_Enter(object sender, EventArgs e)
        {
            // Загружаем данные только если они еще не загружены
            if (comboMaterials.Items.Count == 0)
            {
                LoadMaterialsComboBox();
            }

            // Всегда обновляем типы материалов при входе на вкладку
            RefreshMaterialTypesComboBox();

            // Загружаем данные для калькулятора (типы продукции)
            LoadCalculationDataForSuppliers();

            LoadSuppliersData();
        }

        // Новый метод для загрузки данных калькулятора БЕЗ рекурсии
        private void LoadCalculationDataForSuppliers()
        {
            try
            {
                // Загружаем типы продукции если комбобокс пуст
                if (comboProductType.Items.Count == 0)
                {
                    LoadProductTypesComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных для калькулятора: {ex.Message}", "Ошибка");
            }
        }

        private void LoadMaterialsComboBox()
        {
            try
            {
                comboMaterials.Items.Clear();
                comboMaterials.Items.Add("Все материалы");

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, name FROM materials WHERE status = 'active' ORDER BY name";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboMaterials.Items.Add(new MaterialItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }

                comboMaterials.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки материалов: {ex.Message}", "Ошибка");
            }
        }

        // Вспомогательный класс для комбобокса (добавь в конец класса MainForm)
        public class MaterialItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnRefreshSuppliers_Click(object sender, EventArgs e)
        {
            LoadSuppliersData();
        }

        private void comboMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSuppliersData();
        }

        // Загрузка данных для интерфейса расчета
        private void LoadCalculationData()
        {
            LoadProductTypesComboBox();
            LoadMaterialTypesComboBox();
            LoadMaterialsComboBox();
        }

        // Загрузка типов продукции из БД
        private void LoadProductTypesComboBox()
        {
            try
            {
                comboProductType.Items.Clear();

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT product_type FROM products WHERE status = 'active' ORDER BY product_type";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboProductType.Items.Add(reader["product_type"].ToString());
                        }
                    }
                }

                // Если в БД нет типов, добавляем базовые
                if (comboProductType.Items.Count == 0)
                {
                    comboProductType.Items.AddRange(new string[] {
                "Напольная плитка", "Настенная плитка", "Декоративная плитка", "Бордюр"
            });
                }

                if (comboProductType.Items.Count > 0)
                    comboProductType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов продукции: {ex.Message}", "Ошибка");

                // Запасной вариант - базовые типы
                comboProductType.Items.Clear();
                comboProductType.Items.AddRange(new string[] {
            "Напольная плитка", "Настенная плитка", "Декоративная плитка", "Бордюр"
        });
                if (comboProductType.Items.Count > 0)
                    comboProductType.SelectedIndex = 0;
            }
        }

        // Загрузка типов материалов из БД
        private void LoadMaterialTypesComboBox()
        {
            try
            {
                comboMaterialType.Items.Clear();

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT material_type FROM materials WHERE status = 'active' ORDER BY material_type";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboMaterialType.Items.Add(reader["material_type"].ToString());
                        }
                    }
                }

                // Если в БД нет типов, добавляем базовые из MaterialForm
                if (comboMaterialType.Items.Count == 0)
                {
                    comboMaterialType.Items.AddRange(new string[] {
                "Сырье", "Пигмент", "Краситель", "Клей",
                "Защитное покрытие", "Упаковка", "Вспомогательные материалы"
            });
                }

                if (comboMaterialType.Items.Count > 0)
                    comboMaterialType.SelectedIndex = 0;

                Console.WriteLine($"Загружено типов материалов: {comboMaterialType.Items.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов материалов: {ex.Message}", "Ошибка");

                // Запасной вариант - базовые типы
                comboMaterialType.Items.Clear();
                comboMaterialType.Items.AddRange(new string[] {
            "Сырье", "Пигмент", "Краситель", "Клей",
            "Защитное покрытие", "Упаковка", "Вспомогательные материалы"
        });
                if (comboMaterialType.Items.Count > 0)
                    comboMaterialType.SelectedIndex = 0;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateProduction();
        }

        // Основной метод расчета
        private void CalculateProduction()
        {
            try
            {
                // Проверка введенных данных
                if (comboProductType.SelectedItem == null || comboMaterialType.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип продукции и тип материала", "Ошибка");
                    return;
                }

                if (!int.TryParse(txtRawMaterial.Text, out int rawMaterialQuantity) || rawMaterialQuantity <= 0)
                {
                    MessageBox.Show("Введите корректное количество сырья", "Ошибка");
                    return;
                }

                if (!double.TryParse(txtLength.Text, out double length) || length <= 0)
                {
                    MessageBox.Show("Введите корректную длину плитки", "Ошибка");
                    return;
                }

                if (!double.TryParse(txtWidth.Text, out double width) || width <= 0)
                {
                    MessageBox.Show("Введите корректную ширину плитки", "Ошибка");
                    return;
                }

                // Получаем выбранные значения
                string productType = comboProductType.SelectedItem.ToString();
                string materialType = comboMaterialType.SelectedItem.ToString();

                // Выполняем расчет
                var calculator = new ProductionCalculator();
                int result = calculator.CalculateProductQuantity(
                    productType, materialType, rawMaterialQuantity, length, width);

                // Выводим результат
                DisplayCalculationResult(productType, materialType, rawMaterialQuantity, length, width, result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}", "Ошибка");
            }
        }

        // Отображение результата расчета
        private void DisplayCalculationResult(string productType, string materialType,
    int rawMaterialQuantity, double length, double width, int result)
        {
            string message = "";

            if (result > 0)
            {
                // Получаем коэффициенты для детального расчета
                double productCoefficient = GetCoefficientFromDB("product_type_coefficients", "product_type", productType);
                double lossPercentage = GetCoefficientFromDB("material_loss_percentages", "material_type", materialType);

                double area = length * width;
                double rawMaterialPerUnit = area * productCoefficient;
                double effectiveRawMaterial = rawMaterialQuantity * (1 - lossPercentage / 100);

                message = $"🧮 РЕЗУЛЬТАТ РАСЧЕТА\n\n" +
                         $"📦 Исходные данные:\n" +
                         $"• Тип продукции: {productType}\n" +
                         $"• Тип материала: {materialType}\n" +
                         $"• Количество сырья: {rawMaterialQuantity} кг\n" +
                         $"• Размер плитки: {length}м × {width}м\n\n" +

                         $"📊 Детальный расчет:\n" +
                         $"• Площадь плитки: {length}м × {width}м = {area:0.000} м²\n" +
                         $"• Коэффициент типа '{productType}': {productCoefficient}\n" +
                         $"• Сырьё на единицу: {area:0.000} × {productCoefficient} = {rawMaterialPerUnit:0.000} кг\n" +
                         $"• Потери материала '{materialType}': {lossPercentage}%\n" +
                         $"• Эффективное сырьё: {rawMaterialQuantity}кг × (1 - {lossPercentage / 100:0.00}) = {effectiveRawMaterial:0}кг\n" +
                         $"• Расчет: {effectiveRawMaterial:0}кг / {rawMaterialPerUnit:0.000}кг\n\n" +

                         $"✅ ИТОГО: {result} шт. продукции";

                MessageBox.Show(message, "✅ Результат расчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                message = $"❌ ОШИБКА РАСЧЕТА\n\n" +
                         $"Проверьте:\n" +
                         $"• Корректность введенных данных\n" +
                         $"• Наличие коэффициентов в базе данных\n" +
                         $"• Соответствие типов продукции и материалов";

                MessageBox.Show(message, "❌ Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательный метод для получения коэффициентов из БД
        private double GetCoefficientFromDB(string tableName, string columnName, string value)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = $"SELECT coefficient FROM {tableName} WHERE {columnName} = @value";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value", value);
                        var result = command.ExecuteScalar();

                        return result != null ? Convert.ToDouble(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void tabPageRequests_Enter(object sender, EventArgs e)
        {
            LoadRequestsData();
            LoadStatusFilters();
        }

        private void LoadRequestsData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    r.request_number,
                    p.name as partner_name,
                    u.full_name as manager_name,
                    r.status,
                    r.final_amount,
                    r.created_at
                FROM requests r
                LEFT JOIN partners p ON r.partner_id = p.id
                LEFT JOIN users u ON r.manager_id = u.id
                WHERE 1=1";

                    // Применяем фильтр по статусу, если выбран
                    if (comboStatusFilter.SelectedIndex > 0)
                    {
                        string selectedStatus = GetDbStatus(comboStatusFilter.SelectedItem.ToString());
                        query += " AND r.status = @status";
                    }

                    // Применяем поиск, если введен текст
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        query += " AND (r.request_number LIKE @search OR p.name LIKE @search)";
                    }

                    query += " ORDER BY r.created_at DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        if (comboStatusFilter.SelectedIndex > 0)
                        {
                            string selectedStatus = GetDbStatus(comboStatusFilter.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@status", selectedStatus);
                        }

                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            command.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");
                        }

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // ВАЖНО: Отключаем авто-генерацию колонок
                            dataGridRequests.AutoGenerateColumns = false;

                            // Назначаем DataTable как источник данных
                            dataGridRequests.DataSource = dt;

                            // Явно устанавливаем привязки данных для каждой колонки
                            dataGridRequests.Columns["colRequestNumber"].DataPropertyName = "request_number";
                            dataGridRequests.Columns["colPartner"].DataPropertyName = "partner_name";
                            dataGridRequests.Columns["colManager"].DataPropertyName = "manager_name";
                            dataGridRequests.Columns["colStatus"].DataPropertyName = "status";
                            dataGridRequests.Columns["colAmount"].DataPropertyName = "final_amount";
                            dataGridRequests.Columns["colCreatedDate"].DataPropertyName = "created_at";

                            // Преобразуем статусы в красивые русские для отображения
                            foreach (DataGridViewRow row in dataGridRequests.Rows)
                            {
                                if (row.Cells["colStatus"].Value != null)
                                {
                                    string dbStatus = row.Cells["colStatus"].Value.ToString();
                                    row.Cells["colStatus"].Value = GetRussianStatus(dbStatus);
                                }
                            }

                            // Обновляем статистику
                            UpdateRequestsStats(dt.Rows.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка");
            }
        }

        // Метод для обновления статистики
        private void UpdateRequestsStats(int totalRequests)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    // Получаем статистику по статусам
                    string statsQuery = @"
                SELECT 
                    COUNT(*) as total,
                    SUM(CASE WHEN status = 'новая' THEN 1 ELSE 0 END) as new_count,
                    SUM(CASE WHEN status = 'оплачена' THEN 1 ELSE 0 END) as paid_count,
                    SUM(CASE WHEN status = 'выполнена' THEN 1 ELSE 0 END) as completed_count
                FROM requests";

                    using (var command = new SQLiteCommand(statsQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total = reader.GetInt32(0);
                            int newCount = reader.GetInt32(1);
                            int paidCount = reader.GetInt32(2);
                            int completedCount = reader.GetInt32(3);

                            lblStats.Text = $"Статистика: Всего: {total} | Новые: {newCount} | Оплачены: {paidCount} | Завершены: {completedCount}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStats.Text = $"Статистика: Всего заявок: {totalRequests}";
            }
        }

        // Добавьте этот метод для обработки ошибок DataGridView
        private void dataGridRequests_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Игнорируем ошибки форматирования
            if (e.Exception is FormatException)
            {
                e.ThrowException = false;
                return;
            }

            // Для других ошибок показываем сообщение
            MessageBox.Show($"Ошибка в DataGridView: {e.Exception.Message}", "Ошибка данных",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void LoadStatusFilters()
        {
            comboStatusFilter.Items.Clear();
            comboStatusFilter.Items.Add("Все статусы");
            comboStatusFilter.Items.AddRange(new string[] {
        "Новая", "Согласована", "Оплачена", "В производстве", "Завершена", "Отменена"
    });
            comboStatusFilter.SelectedIndex = 0;
        }

        // Обновленный словарь для преобразования статусов
        private Dictionary<string, string> statusMap = new Dictionary<string, string>
{
    {"новая", "Новая"},
    {"оплачена", "Оплачена"},
    {"в обработке", "В обработке"},
    {"в производстве", "В производстве"},
    {"выполнена", "Завершена"},
    {"завершена", "Завершена"}, // Добавляем оба варианта
    {"отменена", "Отменена"},
    {"согласована", "Согласована"}
};

        // Метод для получения русского статуса из БД статуса
        private string GetRussianStatus(string dbStatus)
        {
            // Приводим к нижнему регистру для сравнения
            string lowerStatus = dbStatus.ToLower();
            return statusMap.ContainsKey(lowerStatus) ? statusMap[lowerStatus] : dbStatus;
        }

        // Метод для получения статуса БД из русского
        private string GetDbStatus(string russianStatus)
        {
            var result = statusMap.FirstOrDefault(x => x.Value == russianStatus).Key ?? russianStatus;
            Console.WriteLine($"GetDbStatus: '{russianStatus}' -> '{result}'");
            return result;
        }

        private void btnViewRequest_Click(object sender, EventArgs e)
        {
            if (dataGridRequests.CurrentRow == null || dataGridRequests.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите заявку для просмотра", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var requestNumber = dataGridRequests.CurrentRow.Cells["colRequestNumber"].Value?.ToString();

                if (string.IsNullOrEmpty(requestNumber))
                {
                    MessageBox.Show("Не удалось получить номер заявки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Загружаем детальную информацию о заявке
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    r.*,
                    p.name as partner_name,
                    p.contact_person,
                    p.phone as partner_phone,
                    p.email as partner_email,
                    u.full_name as manager_name
                FROM requests r
                LEFT JOIN partners p ON r.partner_id = p.id
                LEFT JOIN users u ON r.manager_id = u.id
                WHERE r.request_number = @requestNumber";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@requestNumber", requestNumber);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string englishStatus = reader["status"].ToString();
                                string russianStatus = GetRussianStatus(englishStatus);

                                string details = $"📋 ДЕТАЛИ ЗАЯВКИ\n\n" +
                                               $"🔢 Номер: {reader["request_number"]}\n" +
                                               $"🤝 Партнер: {reader["partner_name"]}\n" +
                                               $"👨‍💼 Менеджер: {reader["manager_name"]}\n" +
                                               $"📊 Статус: {russianStatus}\n" +
                                               $"💰 Сумма: {reader["final_amount"]:N2} руб.\n" +
                                               $"📅 Создана: {Convert.ToDateTime(reader["created_at"]):dd.MM.yyyy HH:mm}\n" +
                                               $"✅ Согласована: {(reader["approved_at"] == DBNull.Value ? "нет" : Convert.ToDateTime(reader["approved_at"]).ToString("dd.MM.yyyy HH:mm"))}\n" +
                                               $"💳 Оплачена: {(reader["paid_at"] == DBNull.Value ? "нет" : Convert.ToDateTime(reader["paid_at"]).ToString("dd.MM.yyyy HH:mm"))}\n" +
                                               $"🏁 Завершена: {(reader["completed_at"] == DBNull.Value ? "нет" : Convert.ToDateTime(reader["completed_at"]).ToString("dd.MM.yyyy HH:mm"))}";

                                if (reader["notes"] != DBNull.Value)
                                {
                                    details += $"\n📝 Примечания: {reader["notes"]}";
                                }

                                MessageBox.Show(details, $"Заявка {requestNumber}",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Заявка не найдена", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при просмотре заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditStatus_Click(object sender, EventArgs e)
        {
            if (dataGridRequests.CurrentRow == null || dataGridRequests.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите заявку для изменения статуса", "Информация");
                return;
            }

            try
            {
                var requestNumber = dataGridRequests.CurrentRow.Cells["colRequestNumber"].Value?.ToString();
                var currentDisplayStatus = dataGridRequests.CurrentRow.Cells["colStatus"].Value?.ToString();

                if (string.IsNullOrEmpty(requestNumber))
                {
                    MessageBox.Show("Не удалось получить номер заявки", "Ошибка");
                    return;
                }

                // Упрощенное сопоставление статусов
                Dictionary<string, string> directStatusMap = new Dictionary<string, string>
        {
            {"Новая", "новая"},
            {"Согласована", "согласована"},
            {"Оплачена", "оплачена"},
            {"В обработке", "в обработке"},
            {"В производстве", "в производстве"},
            {"Завершена", "выполнена"},
            {"Отменена", "отменена"}
        };

                // Диалог выбора нового статуса
                using (var statusForm = new Form())
                {
                    statusForm.Text = "Изменение статуса заявки";
                    statusForm.Size = new Size(350, 200);
                    statusForm.StartPosition = FormStartPosition.CenterParent;
                    statusForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    statusForm.MaximizeBox = false;
                    statusForm.MinimizeBox = false;

                    var lblCurrent = new Label()
                    {
                        Text = $"Заявка: {requestNumber}\nТекущий статус: {currentDisplayStatus}",
                        Location = new Point(20, 20),
                        AutoSize = true
                    };
                    var lblNew = new Label() { Text = "Новый статус:", Location = new Point(20, 70), AutoSize = true };
                    var comboNewStatus = new ComboBox() { Location = new Point(120, 67), Width = 150 };
                    var btnOk = new Button() { Text = "Сохранить", Location = new Point(70, 120), DialogResult = DialogResult.OK };
                    var btnCancel = new Button() { Text = "Отмена", Location = new Point(150, 120), DialogResult = DialogResult.Cancel };

                    // Заполняем доступные статусы на русском
                    comboNewStatus.Items.AddRange(directStatusMap.Keys.ToArray());
                    comboNewStatus.SelectedItem = currentDisplayStatus;

                    statusForm.Controls.AddRange(new Control[] { lblCurrent, lblNew, comboNewStatus, btnOk, btnCancel });
                    statusForm.AcceptButton = btnOk;
                    statusForm.CancelButton = btnCancel;

                    if (statusForm.ShowDialog() == DialogResult.OK && comboNewStatus.SelectedItem != null)
                    {
                        string newDisplayStatus = comboNewStatus.SelectedItem.ToString();
                        string newDbStatus = directStatusMap[newDisplayStatus];

                        Console.WriteLine($"Попытка обновления: {requestNumber} -> {newDbStatus}");

                        // ОБНОВЛЯЕМ статус в БД БЕЗ транзакции (упрощаем)
                        var db = new DatabaseHelper();
                        using (var connection = db.GetConnection())
                        {
                            connection.Open();

                            // Простой UPDATE без транзакции
                            string query = "UPDATE requests SET status = @status WHERE request_number = @requestNumber";
                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@status", newDbStatus);
                                command.Parameters.AddWithValue("@requestNumber", requestNumber);

                                int rowsAffected = command.ExecuteNonQuery();
                                Console.WriteLine($"Строк обновлено: {rowsAffected}");

                                if (rowsAffected > 0)
                                {
                                    // Получаем partner_id для обновления продаж
                                    int partnerId = GetPartnerIdFromRequest(requestNumber);
                                    if (partnerId > 0)
                                    {
                                        DatabaseHelper.UpdatePartnerTotalSales(partnerId);
                                    }

                                    MessageBox.Show($"Статус заявки {requestNumber} изменен на '{newDisplayStatus}'", "Успех");
                                    LoadRequestsData();

                                    // Обновляем список партнеров если открыта вкладка
                                    if (mainTabControl.SelectedTab == tabPagePartners)
                                    {
                                        LoadPartnersData();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Заявка не найдена или статус не изменился", "Ошибка");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении статуса: {ex.Message}", "Ошибка");
                Console.WriteLine($"ОШИБКА: {ex.Message}");
                Console.WriteLine($"СТЕК ТРЕЙС: {ex.StackTrace}");
            }
        }

        // Добавь этот вспомогательный метод
        private int GetPartnerIdFromRequest(string requestNumber)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT partner_id FROM requests WHERE request_number = @number";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@number", requestNumber);
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения partner_id: {ex.Message}");
                return -1;
            }
        }

        // Метод для проверки изменения статуса
        private void CheckRequestStatus(string requestNumber, string expectedStatus)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT status FROM requests WHERE request_number = @requestNumber";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@requestNumber", requestNumber);
                        var result = command.ExecuteScalar();

                        Console.WriteLine($"Проверка статуса: Ожидаемый = '{expectedStatus}', Фактический = '{result}'");

                        if (result?.ToString() != expectedStatus)
                        {
                            Console.WriteLine("ВНИМАНИЕ: Статус в БД не соответствует ожидаемому!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при проверке статуса: {ex.Message}");
            }
        }

        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            LoadRequestsData();
        }

        private void comboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequestsData();
        }

        private void dataGridRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridRequests.Columns[e.ColumnIndex].Name == "colAmount" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = $"{amount:N2} руб.";
                    e.FormattingApplied = true;
                }
            }

        }

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            using (var createForm = new CreateRequestForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем список заявок после создания новой
                    LoadRequestsData();
                    MessageBox.Show("Заявка успешно создана!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            if (dataGridRequests.CurrentRow == null)
            {
                MessageBox.Show("Выберите заявку для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var requestNumber = dataGridRequests.CurrentRow.Cells["colRequestNumber"].Value?.ToString();
            var partnerName = dataGridRequests.CurrentRow.Cells["colPartner"].Value?.ToString();

            if (string.IsNullOrEmpty(requestNumber))
            {
                MessageBox.Show("Не удалось получить данные заявки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить заявку?\n\nНомер: {requestNumber}\nПартнер: {partnerName}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var db = new DatabaseHelper();
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();

                        // Сначала получаем partner_id для обновления
                        int partnerId = GetPartnerIdFromRequest(requestNumber);

                        // Удаляем связанные записи сначала
                        string deleteRelatedQuery = @"
                    DELETE FROM request_materials WHERE request_id IN (SELECT id FROM requests WHERE request_number = @number);
                    DELETE FROM request_products WHERE request_id IN (SELECT id FROM requests WHERE request_number = @number);";

                        using (var command = new SQLiteCommand(deleteRelatedQuery, connection))
                        {
                            command.Parameters.AddWithValue("@number", requestNumber);
                            command.ExecuteNonQuery();
                        }

                        // Удаляем саму заявку
                        string deleteRequestQuery = "DELETE FROM requests WHERE request_number = @number";
                        using (var command = new SQLiteCommand(deleteRequestQuery, connection))
                        {
                            command.Parameters.AddWithValue("@number", requestNumber);
                            int affected = command.ExecuteNonQuery();

                            if (affected > 0)
                            {
                                // ОБНОВЛЯЕМ продажи партнера
                                if (partnerId > 0)
                                {
                                    DatabaseHelper.UpdatePartnerTotalSales(partnerId);
                                }

                                MessageBox.Show("Заявка успешно удалена", "Успех");
                                LoadRequestsData();

                                // ОБНОВЛЯЕМ партнеров если открыта вкладка
                                if (mainTabControl.SelectedTab == tabPagePartners)
                                {
                                    LoadPartnersData();
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось удалить заявку", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заявки: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FixAllPartnersSalesData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    // Получаем всех партнеров
                    string query = "SELECT id FROM partners";
                    List<int> partnerIds = new List<int>();

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            partnerIds.Add(reader.GetInt32(0));
                        }
                    }

                    // Обновляем каждого партнера
                    foreach (int partnerId in partnerIds)
                    {
                        DatabaseHelper.UpdatePartnerTotalSales(partnerId);
                    }

                    // Обновляем список
                    LoadPartnersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequestsData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadRequestsData();
                e.Handled = true;
            }
        }

        private void txtSearch_DoubleClick(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadRequestsData();
        }

        private void tabPagePartners_Enter(object sender, EventArgs e)
        {
            LoadPartnersData();
            LoadPartnerStatusFilters();
        }

        private void btnRefreshPartners_Click(object sender, EventArgs e)
        {
            LoadPartnersData();
        }

        private void btnAddPartner_Click(object sender, EventArgs e)
        {
            using (var form = new PartnerForm()) // без ID - добавление
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPartnersData(); // обновляем список
                }
            }
        }

        private void btnEditPartner_Click(object sender, EventArgs e)
        {
            if (dataGridPartners.CurrentRow == null) return;

            var dataTable = (DataTable)dataGridPartners.DataSource;
            int rowIndex = dataGridPartners.CurrentRow.Index;
            var partnerId = dataTable.Rows[rowIndex]["id"];

            using (var form = new PartnerForm(Convert.ToInt32(partnerId)))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPartnersData();
                }
            }
        }

        private void btnDeletePartner_Click(object sender, EventArgs e)
        {
            if (dataGridPartners.CurrentRow == null)
            {
                MessageBox.Show("Выберите партнера для удаления", "Информация");
                return;
            }

            try
            {
                // ФИКС: Правильно получаем данные из DataTable
                var dataTable = (DataTable)dataGridPartners.DataSource;
                int rowIndex = dataGridPartners.CurrentRow.Index;
                var partnerId = dataTable.Rows[rowIndex]["id"];
                var partnerName = dataTable.Rows[rowIndex]["name"].ToString();

                var result = MessageBox.Show($"Удалить партнера: {partnerName}?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var db = new DatabaseHelper();
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE partners SET status = 'inactive' WHERE id = @id";
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", partnerId);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Партнер деактивирован", "Успех");
                    LoadPartnersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
            }
        }

        private void btnViewPartnerSales_Click(object sender, EventArgs e)
        {
            if (dataGridPartners.CurrentRow == null) return;

            var dataTable = (DataTable)dataGridPartners.DataSource;
            int rowIndex = dataGridPartners.CurrentRow.Index;
            var partnerId = dataTable.Rows[rowIndex]["id"];
            var partnerName = dataTable.Rows[rowIndex]["name"].ToString();

            // Быстрый вариант - показать в MessageBox
            ShowPartnerSalesSummary(partnerId, partnerName);
        }

        private void ShowPartnerSalesSummary(object partnerId, string partnerName)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    // ЗАПРОС 1: Общая статистика (все заявки)
                    string totalQuery = @"
                SELECT 
                    COUNT(*) as total_requests,
                    SUM(final_amount) as total_sales_all
                FROM requests 
                WHERE partner_id = @partnerId";

                    // ЗАПРОС 2: Только завершенные/оплаченные заявки
                    string completedQuery = @"
                SELECT 
                    COUNT(*) as completed_requests,
                    SUM(final_amount) as total_sales_completed
                FROM requests 
                WHERE partner_id = @partnerId 
                AND status IN ('оплачена', 'выполнена', 'завершена')";

                    int totalRequests = 0;
                    decimal totalSalesAll = 0;
                    int completedRequests = 0;
                    decimal totalSalesCompleted = 0;

                    // Получаем общую статистику
                    using (var command = new SQLiteCommand(totalQuery, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalRequests = reader.GetInt32(0);
                                totalSalesAll = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            }
                        }
                    }

                    // Получаем статистику по завершенным заявкам
                    using (var command = new SQLiteCommand(completedQuery, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                completedRequests = reader.GetInt32(0);
                                totalSalesCompleted = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            }
                        }
                    }

                    // Получаем детали по заявкам
                    string detailsQuery = @"
                SELECT 
                    request_number,
                    status,
                    final_amount,
                    created_at
                FROM requests 
                WHERE partner_id = @partnerId
                ORDER BY created_at DESC";

                    StringBuilder details = new StringBuilder();
                    using (var command = new SQLiteCommand(detailsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["status"].ToString();
                                string russianStatus = GetRussianStatus(status);
                                details.AppendLine($"• {reader["request_number"]} - {russianStatus} - {Convert.ToDecimal(reader["final_amount"]):N2} руб. - {Convert.ToDateTime(reader["created_at"]):dd.MM.yyyy}");
                            }
                        }
                    }

                    string message = $"📊 История продаж партнера: {partnerName}\n\n" +
                                   $"📋 Всего заявок: {totalRequests}\n" +
                                   $"✅ Завершенных/оплаченных: {completedRequests}\n" +
                                   $"💰 Общий объем всех заявок: {totalSalesAll:N2} руб.\n" +
                                   $"💰 Учтено в продажах: {totalSalesCompleted:N2} руб.\n\n" +
                                   $"📜 Детали заявок:\n{details}";

                    MessageBox.Show(message, "История продаж",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки истории: {ex.Message}", "Ошибка");
            }
        }

        private void btnSearcht_Click(object sender, EventArgs e)
        {
            LoadPartnersData();
        }

        private void comboStatusFiltert_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPartnersData();
        }

        private void dataGridPartners_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void txtSearcht_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadPartnersData();
                e.Handled = true;
            }
        }

        private void txtSearcht_DoubleClick(object sender, EventArgs e)
        {
            txtSearcht.Clear();
            LoadPartnersData();
        }

        // В MainForm добавьте кнопки (если их нет):
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (var form = new SupplierForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliersData(); // обновляем список
                }
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridSuppliers.CurrentRow == null || dataGridSuppliers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите поставщика для редактирования", "Информация");
                return;
            }

            // Получаем ID поставщика (нужно будет добавить скрытый столбец с ID)
            // Пока используем имя для поиска (временное решение)
            string supplierName = dataGridSuppliers.CurrentRow.Cells["colSupplierName"].Value?.ToString();

            if (!string.IsNullOrEmpty(supplierName))
            {
                int supplierId = GetSupplierIdByName(supplierName);
                if (supplierId > 0)
                {
                    using (var form = new SupplierForm(supplierId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadSuppliersData();
                        }
                    }
                }
            }
        }

        // Вспомогательный метод для получения ID поставщика по имени
        private int GetSupplierIdByName(string name)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id FROM suppliers WHERE name = @name";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        // Добавьте эти методы в класс MainForm:

        private void comboMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении типа материала можно обновить расчет
            // или выполнить другие действия если нужно
            Console.WriteLine($"Тип материала изменен: {comboMaterialType.SelectedItem}");
        }

        private void comboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении типа продукции можно обновить расчет
            // или выполнить другие действия если нужно
            Console.WriteLine($"Тип продукции изменен: {comboProductType.SelectedItem}");
        }

        private void tabPageProducts_Enter(object sender, EventArgs e)
        {
            LoadProductsData();
        }

        // === ЗАГРУЗКА ДАННЫХ ПРОДУКЦИИ ===
        private void LoadProductsData()
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    id,
                    name,
                    product_type,
                    price_per_unit,
                    unit,
                    status
                FROM products 
                WHERE status = 'active'
                ORDER BY name";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Настраиваем DataGrid
                        SetupProductsGridColumns();
                        dataGridProducts.DataSource = dt;

                        // Обновляем счетчик
                        lblProductsCount.Text = $"Всего продукции: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продукции: {ex.Message}", "Ошибка");
            }
        }

        // === НАСТРОЙКА КОЛОНОК ТАБЛИЦЫ ===
        private void SetupProductsGridColumns()
        {
            dataGridProducts.AutoGenerateColumns = false;
            dataGridProducts.Columns.Clear();

            dataGridProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colProductName",
                HeaderText = "Наименование",
                DataPropertyName = "name",
                Width = 200,
                ReadOnly = true
            });

            dataGridProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colProductType",
                HeaderText = "Тип",
                DataPropertyName = "product_type",
                Width = 120,
                ReadOnly = true
            });

            dataGridProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                HeaderText = "Цена",
                DataPropertyName = "price_per_unit",
                Width = 80,
                ReadOnly = true
            });

            dataGridProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colUnit",
                HeaderText = "Ед. изм.",
                DataPropertyName = "unit",
                Width = 60,
                ReadOnly = true
            });

            // Скрытый столбец с ID для редактирования
            dataGridProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colProductId",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 50,
                ReadOnly = true,
                Visible = false
            });
        }

        // === ДОБАВЛЕНИЕ ПРОДУКЦИИ ===
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var form = new ProductForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProductsData();
                    RefreshProductTypesComboBox();
                }
            }
        }

        // === РЕДАКТИРОВАНИЕ ПРОДУКЦИИ ===
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null || dataGridProducts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите продукцию для редактирования", "Информация");
                return;
            }

            var selectedRowIndex = dataGridProducts.CurrentRow.Index;
            var dataTable = (DataTable)dataGridProducts.DataSource;
            var productId = Convert.ToInt32(dataTable.Rows[selectedRowIndex]["id"]);

            using (var form = new ProductForm(productId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProductsData();
                    RefreshProductTypesComboBox();
                }
            }
        }

        // === ОБНОВЛЕНИЕ СПИСКА ===
        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            LoadProductsData();
        }

        // === ОБНОВЛЕНИЕ КОМБОБОКСА ТИПОВ ПРОДУКЦИИ В КАЛЬКУЛЯТОРЕ ===
        private void RefreshProductTypesComboBox()
        {
            try
            {
                string currentSelection = comboProductType.Text;

                comboProductType.Items.Clear();

                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT product_type FROM products WHERE status = 'active' ORDER BY product_type";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboProductType.Items.Add(reader["product_type"].ToString());
                        }
                    }
                }

                if (!string.IsNullOrEmpty(currentSelection) && comboProductType.Items.Contains(currentSelection))
                {
                    comboProductType.SelectedItem = currentSelection;
                }
                else if (comboProductType.Items.Count > 0)
                {
                    comboProductType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления типов продукции: {ex.Message}", "Ошибка");
            }
        }

        // === ДВОЙНОЙ КЛИК ПО СТРОКЕ ДЛЯ РЕДАКТИРОВАНИЯ ===
        private void dataGridProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                btnEditProduct_Click(sender, e);
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridMaterials.CurrentRow == null || dataGridMaterials.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите материал для удаления", "Информация");
                return;
            }

            try
            {
                // Получаем ID материала
                var selectedRowIndex = dataGridMaterials.CurrentRow.Index;
                var dataTable = (DataTable)dataGridMaterials.DataSource;
                var materialId = Convert.ToInt32(dataTable.Rows[selectedRowIndex]["material_id"]);
                var materialName = dataTable.Rows[selectedRowIndex]["material_name"].ToString();

                var result = MessageBox.Show($"Удалить материал: {materialName}?\n\nМатериал будет помечен как неактивный и скрыт из списка.",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var db = new DatabaseHelper();
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE materials SET status = 'inactive' WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", materialId);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Материал успешно удален", "Успех");
                    LoadMaterialsData(); // Обновляем список
                    RefreshMaterialComboBox(); // Обновляем комбобокс в поставщиках
                    RefreshMaterialTypesComboBox(); // Обновляем комбобокс типов материалов
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении материала: {ex.Message}", "Ошибка");
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridSuppliers.CurrentRow == null || dataGridSuppliers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите поставщика для удаления", "Информация");
                return;
            }

            try
            {
                // Получаем имя поставщика (так как ID нет в DataGrid)
                string supplierName = dataGridSuppliers.CurrentRow.Cells["colSupplierName"].Value?.ToString();

                if (string.IsNullOrEmpty(supplierName))
                {
                    MessageBox.Show("Не удалось получить данные поставщика", "Ошибка");
                    return;
                }

                var result = MessageBox.Show($"Удалить поставщика: {supplierName}?\n\nПоставщик будет помечен как неактивный и скрыт из списка.",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var db = new DatabaseHelper();
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE suppliers SET status = 'inactive' WHERE name = @name";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@name", supplierName);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Поставщик успешно удален", "Успех");
                                LoadSuppliersData(); // Обновляем список

                                // Обновляем комбобокс поставщиков в форме материалов
                                if (mainTabControl.SelectedTab == tabPageMaterials)
                                {
                                    // Можно вызвать метод обновления если он есть
                                }
                            }
                            else
                            {
                                MessageBox.Show("Поставщик не найден", "Ошибка");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении поставщика: {ex.Message}", "Ошибка");
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null || dataGridProducts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите продукцию для удаления", "Информация");
                return;
            }

            try
            {
                // Получаем ID продукции
                var selectedRowIndex = dataGridProducts.CurrentRow.Index;
                var dataTable = (DataTable)dataGridProducts.DataSource;
                var productId = Convert.ToInt32(dataTable.Rows[selectedRowIndex]["id"]);
                var productName = dataTable.Rows[selectedRowIndex]["name"].ToString();

                var result = MessageBox.Show($"Удалить продукцию: {productName}?\n\nПродукция будет помечена как неактивная и скрыта из списка.",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var db = new DatabaseHelper();
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE products SET status = 'inactive' WHERE id = @id";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", productId);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Продукция успешно удалена", "Успех");
                    LoadProductsData(); // Обновляем список
                    RefreshProductTypesComboBox(); // Обновляем комбобокс в калькуляторе
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении продукции: {ex.Message}", "Ошибка");
            }
        }
    }
}
