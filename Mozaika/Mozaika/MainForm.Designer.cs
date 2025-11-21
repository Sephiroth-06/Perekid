namespace Mozaika
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusAccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.dataGridAlerts = new System.Windows.Forms.DataGridView();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tabPageMaterials = new System.Windows.Forms.TabPage();
            this.btnRefreshMaterials = new System.Windows.Forms.Button();
            this.btnEditMaterial = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.lblMaterialsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridMaterials = new System.Windows.Forms.DataGridView();
            this.tabPageSuppliers = new System.Windows.Forms.TabPage();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtRawMaterial = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnRefreshSuppliers = new System.Windows.Forms.Button();
            this.dataGridSuppliers = new System.Windows.Forms.DataGridView();
            this.colSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQualityRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectedMaterial = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMaterialType = new System.Windows.Forms.ComboBox();
            this.comboProductType = new System.Windows.Forms.ComboBox();
            this.comboMaterials = new System.Windows.Forms.ComboBox();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.lblProductsCount = new System.Windows.Forms.Label();
            this.btnRefreshProducts = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.tabPagePartners = new System.Windows.Forms.TabPage();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblPartnersCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboStatusFiltert = new System.Windows.Forms.ComboBox();
            this.lblSearcht = new System.Windows.Forms.Label();
            this.txtSearcht = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearcht = new System.Windows.Forms.Button();
            this.btnViewPartnerSales = new System.Windows.Forms.Button();
            this.btnRefreshPartners = new System.Windows.Forms.Button();
            this.btnDeletePartner = new System.Windows.Forms.Button();
            this.btnEditPartner = new System.Windows.Forms.Button();
            this.btnAddPartner = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridPartners = new System.Windows.Forms.DataGridView();
            this.colPartnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerINN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerTotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartnerStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageRequests = new System.Windows.Forms.TabPage();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEditStatus = new System.Windows.Forms.Button();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.lblStat = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboStatusFilter = new System.Windows.Forms.ComboBox();
            this.dataGridRequests = new System.Windows.Forms.DataGridView();
            this.colRequestNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlerts)).BeginInit();
            this.tabPageMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaterials)).BeginInit();
            this.tabPageSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuppliers)).BeginInit();
            this.tabPageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.tabPagePartners.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartners)).BeginInit();
            this.tabPageRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit,
            this.menuAbout});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(912, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(53, 20);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(94, 20);
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUser,
            this.statusRole,
            this.statusAccess,
            this.statusTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 510);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(912, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusUser
            // 
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(87, 17);
            this.statusUser.Text = "Пользователь:";
            // 
            // statusRole
            // 
            this.statusRole.Name = "statusRole";
            this.statusRole.Size = new System.Drawing.Size(40, 17);
            this.statusRole.Text = "Роль: ";
            // 
            // statusAccess
            // 
            this.statusAccess.Name = "statusAccess";
            this.statusAccess.Size = new System.Drawing.Size(48, 17);
            this.statusAccess.Text = "Режим:";
            // 
            // statusTime
            // 
            this.statusTime.Name = "statusTime";
            this.statusTime.Size = new System.Drawing.Size(45, 17);
            this.statusTime.Text = "Время:";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPageDashboard);
            this.mainTabControl.Controls.Add(this.tabPageMaterials);
            this.mainTabControl.Controls.Add(this.tabPageSuppliers);
            this.mainTabControl.Controls.Add(this.tabPageProducts);
            this.mainTabControl.Controls.Add(this.tabPagePartners);
            this.mainTabControl.Controls.Add(this.tabPageRequests);
            this.mainTabControl.Location = new System.Drawing.Point(12, 40);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(888, 456);
            this.mainTabControl.TabIndex = 3;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabPageDashboard
            // 
            this.tabPageDashboard.Controls.Add(this.dataGridAlerts);
            this.tabPageDashboard.Controls.Add(this.lblStats);
            this.tabPageDashboard.Controls.Add(this.lblWelcome);
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDashboard.Size = new System.Drawing.Size(880, 430);
            this.tabPageDashboard.TabIndex = 0;
            this.tabPageDashboard.Text = "Дашборд";
            this.tabPageDashboard.UseVisualStyleBackColor = true;
            // 
            // dataGridAlerts
            // 
            this.dataGridAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlerts.Location = new System.Drawing.Point(6, 61);
            this.dataGridAlerts.Name = "dataGridAlerts";
            this.dataGridAlerts.Size = new System.Drawing.Size(868, 363);
            this.dataGridAlerts.TabIndex = 1;
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(377, 45);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(65, 13);
            this.lblStats.TabIndex = 0;
            this.lblStats.Text = "Статистика";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(313, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(209, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Добро пожаловать в систему Мозаика!";
            // 
            // tabPageMaterials
            // 
            this.tabPageMaterials.Controls.Add(this.btnRefreshMaterials);
            this.tabPageMaterials.Controls.Add(this.btnDeleteMaterial);
            this.tabPageMaterials.Controls.Add(this.btnEditMaterial);
            this.tabPageMaterials.Controls.Add(this.btnAddMaterial);
            this.tabPageMaterials.Controls.Add(this.lblMaterialsCount);
            this.tabPageMaterials.Controls.Add(this.label1);
            this.tabPageMaterials.Controls.Add(this.dataGridMaterials);
            this.tabPageMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaterials.Name = "tabPageMaterials";
            this.tabPageMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMaterials.Size = new System.Drawing.Size(880, 430);
            this.tabPageMaterials.TabIndex = 1;
            this.tabPageMaterials.Text = "Материалы";
            this.tabPageMaterials.UseVisualStyleBackColor = true;
            this.tabPageMaterials.Enter += new System.EventHandler(this.tabPageMaterials_Enter);
            // 
            // btnRefreshMaterials
            // 
            this.btnRefreshMaterials.Location = new System.Drawing.Point(718, 65);
            this.btnRefreshMaterials.Name = "btnRefreshMaterials";
            this.btnRefreshMaterials.Size = new System.Drawing.Size(137, 36);
            this.btnRefreshMaterials.TabIndex = 2;
            this.btnRefreshMaterials.Text = "Обновить материал";
            this.btnRefreshMaterials.UseVisualStyleBackColor = true;
            this.btnRefreshMaterials.Click += new System.EventHandler(this.btnRefreshMaterials_Click);
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Location = new System.Drawing.Point(255, 65);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(137, 36);
            this.btnEditMaterial.TabIndex = 2;
            this.btnEditMaterial.Text = "Редактировать материал";
            this.btnEditMaterial.UseVisualStyleBackColor = true;
            this.btnEditMaterial.Click += new System.EventHandler(this.btnEditMaterial_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(20, 65);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(137, 36);
            this.btnAddMaterial.TabIndex = 2;
            this.btnAddMaterial.Text = "Добавить материал";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // lblMaterialsCount
            // 
            this.lblMaterialsCount.AutoSize = true;
            this.lblMaterialsCount.Location = new System.Drawing.Point(399, 21);
            this.lblMaterialsCount.Name = "lblMaterialsCount";
            this.lblMaterialsCount.Size = new System.Drawing.Size(104, 13);
            this.lblMaterialsCount.TabIndex = 1;
            this.lblMaterialsCount.Text = "Всего материалов:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список материалов:";
            // 
            // dataGridMaterials
            // 
            this.dataGridMaterials.AllowUserToAddRows = false;
            this.dataGridMaterials.AllowUserToDeleteRows = false;
            this.dataGridMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMaterials.Location = new System.Drawing.Point(6, 165);
            this.dataGridMaterials.Name = "dataGridMaterials";
            this.dataGridMaterials.ReadOnly = true;
            this.dataGridMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMaterials.Size = new System.Drawing.Size(868, 259);
            this.dataGridMaterials.TabIndex = 0;
            this.dataGridMaterials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMaterials_CellDoubleClick);
            // 
            // tabPageSuppliers
            // 
            this.tabPageSuppliers.Controls.Add(this.txtWidth);
            this.tabPageSuppliers.Controls.Add(this.txtLength);
            this.tabPageSuppliers.Controls.Add(this.txtRawMaterial);
            this.tabPageSuppliers.Controls.Add(this.btnCalculate);
            this.tabPageSuppliers.Controls.Add(this.btnDeleteSupplier);
            this.tabPageSuppliers.Controls.Add(this.btnEditSupplier);
            this.tabPageSuppliers.Controls.Add(this.btnAddSupplier);
            this.tabPageSuppliers.Controls.Add(this.btnRefreshSuppliers);
            this.tabPageSuppliers.Controls.Add(this.dataGridSuppliers);
            this.tabPageSuppliers.Controls.Add(this.lblSelectedMaterial);
            this.tabPageSuppliers.Controls.Add(this.label8);
            this.tabPageSuppliers.Controls.Add(this.label7);
            this.tabPageSuppliers.Controls.Add(this.label6);
            this.tabPageSuppliers.Controls.Add(this.label5);
            this.tabPageSuppliers.Controls.Add(this.label4);
            this.tabPageSuppliers.Controls.Add(this.label2);
            this.tabPageSuppliers.Controls.Add(this.comboMaterialType);
            this.tabPageSuppliers.Controls.Add(this.comboProductType);
            this.tabPageSuppliers.Controls.Add(this.comboMaterials);
            this.tabPageSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabPageSuppliers.Name = "tabPageSuppliers";
            this.tabPageSuppliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuppliers.Size = new System.Drawing.Size(880, 430);
            this.tabPageSuppliers.TabIndex = 2;
            this.tabPageSuppliers.Text = "Поставщики";
            this.tabPageSuppliers.UseVisualStyleBackColor = true;
            this.tabPageSuppliers.Enter += new System.EventHandler(this.TabPageSuppliers_Enter);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(723, 168);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(137, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(723, 129);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(137, 20);
            this.txtLength.TabIndex = 6;
            // 
            // txtRawMaterial
            // 
            this.txtRawMaterial.Location = new System.Drawing.Point(723, 90);
            this.txtRawMaterial.Name = "txtRawMaterial";
            this.txtRawMaterial.Size = new System.Drawing.Size(137, 20);
            this.txtRawMaterial.TabIndex = 6;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(685, 211);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(98, 26);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Расчёт";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Location = new System.Drawing.Point(152, 13);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(106, 35);
            this.btnEditSupplier.TabIndex = 3;
            this.btnEditSupplier.Text = "Отредактировать поставщика";
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(36, 13);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(98, 35);
            this.btnAddSupplier.TabIndex = 3;
            this.btnAddSupplier.Text = "Добавить поставщика";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnRefreshSuppliers
            // 
            this.btnRefreshSuppliers.Location = new System.Drawing.Point(326, 141);
            this.btnRefreshSuppliers.Name = "btnRefreshSuppliers";
            this.btnRefreshSuppliers.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSuppliers.TabIndex = 3;
            this.btnRefreshSuppliers.Text = "Обновить";
            this.btnRefreshSuppliers.UseVisualStyleBackColor = true;
            this.btnRefreshSuppliers.Click += new System.EventHandler(this.btnRefreshSuppliers_Click);
            // 
            // dataGridSuppliers
            // 
            this.dataGridSuppliers.AllowUserToAddRows = false;
            this.dataGridSuppliers.AllowUserToDeleteRows = false;
            this.dataGridSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplierName,
            this.colQualityRating,
            this.colStartDate,
            this.colContact,
            this.colPhone});
            this.dataGridSuppliers.Location = new System.Drawing.Point(31, 199);
            this.dataGridSuppliers.Name = "dataGridSuppliers";
            this.dataGridSuppliers.ReadOnly = true;
            this.dataGridSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSuppliers.Size = new System.Drawing.Size(549, 216);
            this.dataGridSuppliers.TabIndex = 2;
            // 
            // colSupplierName
            // 
            this.colSupplierName.HeaderText = "Название поставщика";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.ReadOnly = true;
            // 
            // colQualityRating
            // 
            this.colQualityRating.HeaderText = "Рейтинг качества";
            this.colQualityRating.Name = "colQualityRating";
            this.colQualityRating.ReadOnly = true;
            // 
            // colStartDate
            // 
            this.colStartDate.HeaderText = "Дата начала работы";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colContact
            // 
            this.colContact.HeaderText = "Контактное лицо";
            this.colContact.Name = "colContact";
            this.colContact.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Телефон";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // lblSelectedMaterial
            // 
            this.lblSelectedMaterial.AutoSize = true;
            this.lblSelectedMaterial.Location = new System.Drawing.Point(33, 178);
            this.lblSelectedMaterial.Name = "lblSelectedMaterial";
            this.lblSelectedMaterial.Size = new System.Drawing.Size(118, 13);
            this.lblSelectedMaterial.TabIndex = 1;
            this.lblSelectedMaterial.Text = "Выбранный материал";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(625, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ширина плитки:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(625, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Длина плитки:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(625, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Кол-во сырья:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Тип материала:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Тип продукции:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выбор материала:";
            // 
            // comboMaterialType
            // 
            this.comboMaterialType.FormattingEnabled = true;
            this.comboMaterialType.Location = new System.Drawing.Point(723, 52);
            this.comboMaterialType.Name = "comboMaterialType";
            this.comboMaterialType.Size = new System.Drawing.Size(137, 21);
            this.comboMaterialType.TabIndex = 0;
            this.comboMaterialType.SelectedIndexChanged += new System.EventHandler(this.comboMaterialType_SelectedIndexChanged);
            // 
            // comboProductType
            // 
            this.comboProductType.FormattingEnabled = true;
            this.comboProductType.Location = new System.Drawing.Point(723, 10);
            this.comboProductType.Name = "comboProductType";
            this.comboProductType.Size = new System.Drawing.Size(137, 21);
            this.comboProductType.TabIndex = 0;
            this.comboProductType.SelectedIndexChanged += new System.EventHandler(this.comboProductType_SelectedIndexChanged);
            // 
            // comboMaterials
            // 
            this.comboMaterials.FormattingEnabled = true;
            this.comboMaterials.Location = new System.Drawing.Point(152, 141);
            this.comboMaterials.Name = "comboMaterials";
            this.comboMaterials.Size = new System.Drawing.Size(137, 21);
            this.comboMaterials.TabIndex = 0;
            this.comboMaterials.SelectedIndexChanged += new System.EventHandler(this.comboMaterials_SelectedIndexChanged);
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.lblProductsCount);
            this.tabPageProducts.Controls.Add(this.btnRefreshProducts);
            this.tabPageProducts.Controls.Add(this.btnDeleteProduct);
            this.tabPageProducts.Controls.Add(this.btnEditProduct);
            this.tabPageProducts.Controls.Add(this.btnAddProduct);
            this.tabPageProducts.Controls.Add(this.dataGridProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 22);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProducts.Size = new System.Drawing.Size(880, 430);
            this.tabPageProducts.TabIndex = 3;
            this.tabPageProducts.Text = "Продукция";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            this.tabPageProducts.Enter += new System.EventHandler(this.tabPageProducts_Enter);
            // 
            // lblProductsCount
            // 
            this.lblProductsCount.AutoSize = true;
            this.lblProductsCount.Location = new System.Drawing.Point(720, 248);
            this.lblProductsCount.Name = "lblProductsCount";
            this.lblProductsCount.Size = new System.Drawing.Size(96, 13);
            this.lblProductsCount.TabIndex = 2;
            this.lblProductsCount.Text = "Всего продукции:";
            // 
            // btnRefreshProducts
            // 
            this.btnRefreshProducts.Location = new System.Drawing.Point(723, 184);
            this.btnRefreshProducts.Name = "btnRefreshProducts";
            this.btnRefreshProducts.Size = new System.Drawing.Size(94, 40);
            this.btnRefreshProducts.TabIndex = 1;
            this.btnRefreshProducts.Text = "Обновить";
            this.btnRefreshProducts.UseVisualStyleBackColor = true;
            this.btnRefreshProducts.Click += new System.EventHandler(this.btnRefreshProducts_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(722, 63);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(94, 40);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "Редактировать продукцию";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(722, 6);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(94, 40);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "Добавить продукцию";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Location = new System.Drawing.Point(6, 6);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.Size = new System.Drawing.Size(641, 418);
            this.dataGridProducts.TabIndex = 0;
            this.dataGridProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellDoubleClick);
            // 
            // tabPagePartners
            // 
            this.tabPagePartners.Controls.Add(this.lblTotalSales);
            this.tabPagePartners.Controls.Add(this.lblPartnersCount);
            this.tabPagePartners.Controls.Add(this.groupBox1);
            this.tabPagePartners.Controls.Add(this.btnViewPartnerSales);
            this.tabPagePartners.Controls.Add(this.btnRefreshPartners);
            this.tabPagePartners.Controls.Add(this.btnDeletePartner);
            this.tabPagePartners.Controls.Add(this.btnEditPartner);
            this.tabPagePartners.Controls.Add(this.btnAddPartner);
            this.tabPagePartners.Controls.Add(this.label9);
            this.tabPagePartners.Controls.Add(this.dataGridPartners);
            this.tabPagePartners.Location = new System.Drawing.Point(4, 22);
            this.tabPagePartners.Name = "tabPagePartners";
            this.tabPagePartners.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePartners.Size = new System.Drawing.Size(880, 430);
            this.tabPagePartners.TabIndex = 4;
            this.tabPagePartners.Text = "Партнёры";
            this.tabPagePartners.UseVisualStyleBackColor = true;
            this.tabPagePartners.Enter += new System.EventHandler(this.tabPagePartners_Enter);
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(11, 256);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(154, 13);
            this.lblTotalSales.TabIndex = 6;
            this.lblTotalSales.Text = "Общий объем продаж: 0 руб.";
            // 
            // lblPartnersCount
            // 
            this.lblPartnersCount.AutoSize = true;
            this.lblPartnersCount.Location = new System.Drawing.Point(11, 223);
            this.lblPartnersCount.Name = "lblPartnersCount";
            this.lblPartnersCount.Size = new System.Drawing.Size(105, 13);
            this.lblPartnersCount.TabIndex = 6;
            this.lblPartnersCount.Text = "Всего партнёров: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboStatusFiltert);
            this.groupBox1.Controls.Add(this.lblSearcht);
            this.groupBox1.Controls.Add(this.txtSearcht);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnSearcht);
            this.groupBox1.Location = new System.Drawing.Point(14, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск и фильтрация";
            // 
            // comboStatusFiltert
            // 
            this.comboStatusFiltert.FormattingEnabled = true;
            this.comboStatusFiltert.Location = new System.Drawing.Point(77, 60);
            this.comboStatusFiltert.Name = "comboStatusFiltert";
            this.comboStatusFiltert.Size = new System.Drawing.Size(129, 21);
            this.comboStatusFiltert.TabIndex = 4;
            this.comboStatusFiltert.SelectedIndexChanged += new System.EventHandler(this.comboStatusFiltert_SelectedIndexChanged);
            // 
            // lblSearcht
            // 
            this.lblSearcht.AutoSize = true;
            this.lblSearcht.Location = new System.Drawing.Point(29, 31);
            this.lblSearcht.Name = "lblSearcht";
            this.lblSearcht.Size = new System.Drawing.Size(42, 13);
            this.lblSearcht.TabIndex = 1;
            this.lblSearcht.Text = "Поиск:";
            // 
            // txtSearcht
            // 
            this.txtSearcht.Location = new System.Drawing.Point(77, 28);
            this.txtSearcht.Name = "txtSearcht";
            this.txtSearcht.Size = new System.Drawing.Size(129, 20);
            this.txtSearcht.TabIndex = 3;
            this.txtSearcht.DoubleClick += new System.EventHandler(this.txtSearcht_DoubleClick);
            this.txtSearcht.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearcht_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Фильтр:";
            // 
            // btnSearcht
            // 
            this.btnSearcht.Location = new System.Drawing.Point(85, 101);
            this.btnSearcht.Name = "btnSearcht";
            this.btnSearcht.Size = new System.Drawing.Size(82, 23);
            this.btnSearcht.TabIndex = 2;
            this.btnSearcht.Text = "Найти";
            this.btnSearcht.UseVisualStyleBackColor = true;
            this.btnSearcht.Click += new System.EventHandler(this.btnSearcht_Click);
            // 
            // btnViewPartnerSales
            // 
            this.btnViewPartnerSales.Location = new System.Drawing.Point(756, 223);
            this.btnViewPartnerSales.Name = "btnViewPartnerSales";
            this.btnViewPartnerSales.Size = new System.Drawing.Size(118, 23);
            this.btnViewPartnerSales.TabIndex = 2;
            this.btnViewPartnerSales.Text = "История продаж";
            this.btnViewPartnerSales.UseVisualStyleBackColor = true;
            this.btnViewPartnerSales.Click += new System.EventHandler(this.btnViewPartnerSales_Click);
            // 
            // btnRefreshPartners
            // 
            this.btnRefreshPartners.Location = new System.Drawing.Point(632, 223);
            this.btnRefreshPartners.Name = "btnRefreshPartners";
            this.btnRefreshPartners.Size = new System.Drawing.Size(118, 23);
            this.btnRefreshPartners.TabIndex = 2;
            this.btnRefreshPartners.Text = "Обновить";
            this.btnRefreshPartners.UseVisualStyleBackColor = true;
            this.btnRefreshPartners.Click += new System.EventHandler(this.btnRefreshPartners_Click);
            // 
            // btnDeletePartner
            // 
            this.btnDeletePartner.Location = new System.Drawing.Point(508, 223);
            this.btnDeletePartner.Name = "btnDeletePartner";
            this.btnDeletePartner.Size = new System.Drawing.Size(118, 23);
            this.btnDeletePartner.TabIndex = 2;
            this.btnDeletePartner.Text = "Удалить партнёра";
            this.btnDeletePartner.UseVisualStyleBackColor = true;
            this.btnDeletePartner.Click += new System.EventHandler(this.btnDeletePartner_Click);
            // 
            // btnEditPartner
            // 
            this.btnEditPartner.Location = new System.Drawing.Point(359, 223);
            this.btnEditPartner.Name = "btnEditPartner";
            this.btnEditPartner.Size = new System.Drawing.Size(143, 23);
            this.btnEditPartner.TabIndex = 2;
            this.btnEditPartner.Text = "Редактировать партнёра";
            this.btnEditPartner.UseVisualStyleBackColor = true;
            this.btnEditPartner.Click += new System.EventHandler(this.btnEditPartner_Click);
            // 
            // btnAddPartner
            // 
            this.btnAddPartner.Location = new System.Drawing.Point(235, 223);
            this.btnAddPartner.Name = "btnAddPartner";
            this.btnAddPartner.Size = new System.Drawing.Size(118, 23);
            this.btnAddPartner.TabIndex = 2;
            this.btnAddPartner.Text = "Добавить партнёра";
            this.btnAddPartner.UseVisualStyleBackColor = true;
            this.btnAddPartner.Click += new System.EventHandler(this.btnAddPartner_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Список партнёров";
            // 
            // dataGridPartners
            // 
            this.dataGridPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPartners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPartnerName,
            this.colPartnerINN,
            this.colPartnerPhone,
            this.colPartnerEmail,
            this.colPartnerDiscount,
            this.colPartnerTotalSales,
            this.colPartnerStatus});
            this.dataGridPartners.Location = new System.Drawing.Point(131, 3);
            this.dataGridPartners.Name = "dataGridPartners";
            this.dataGridPartners.Size = new System.Drawing.Size(746, 211);
            this.dataGridPartners.TabIndex = 0;
            this.dataGridPartners.SelectionChanged += new System.EventHandler(this.dataGridPartners_SelectionChanged);
            // 
            // colPartnerName
            // 
            this.colPartnerName.HeaderText = "Название компании";
            this.colPartnerName.Name = "colPartnerName";
            // 
            // colPartnerINN
            // 
            this.colPartnerINN.HeaderText = "ИНН";
            this.colPartnerINN.Name = "colPartnerINN";
            // 
            // colPartnerPhone
            // 
            this.colPartnerPhone.HeaderText = "Телефон";
            this.colPartnerPhone.Name = "colPartnerPhone";
            // 
            // colPartnerEmail
            // 
            this.colPartnerEmail.HeaderText = "Email";
            this.colPartnerEmail.Name = "colPartnerEmail";
            // 
            // colPartnerDiscount
            // 
            this.colPartnerDiscount.HeaderText = "Скидка %";
            this.colPartnerDiscount.Name = "colPartnerDiscount";
            // 
            // colPartnerTotalSales
            // 
            this.colPartnerTotalSales.HeaderText = "Объем продаж";
            this.colPartnerTotalSales.Name = "colPartnerTotalSales";
            // 
            // colPartnerStatus
            // 
            this.colPartnerStatus.HeaderText = "Статус";
            this.colPartnerStatus.Name = "colPartnerStatus";
            // 
            // tabPageRequests
            // 
            this.tabPageRequests.Controls.Add(this.txtSearch);
            this.tabPageRequests.Controls.Add(this.btnCreateRequest);
            this.tabPageRequests.Controls.Add(this.btnDeleteRequest);
            this.tabPageRequests.Controls.Add(this.btnSearch);
            this.tabPageRequests.Controls.Add(this.btnEditStatus);
            this.tabPageRequests.Controls.Add(this.btnViewRequest);
            this.tabPageRequests.Controls.Add(this.btnRefreshRequests);
            this.tabPageRequests.Controls.Add(this.lblStat);
            this.tabPageRequests.Controls.Add(this.lblSearch);
            this.tabPageRequests.Controls.Add(this.label3);
            this.tabPageRequests.Controls.Add(this.comboStatusFilter);
            this.tabPageRequests.Controls.Add(this.dataGridRequests);
            this.tabPageRequests.Location = new System.Drawing.Point(4, 22);
            this.tabPageRequests.Name = "tabPageRequests";
            this.tabPageRequests.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRequests.Size = new System.Drawing.Size(880, 430);
            this.tabPageRequests.TabIndex = 5;
            this.tabPageRequests.Text = "Заявки";
            this.tabPageRequests.UseVisualStyleBackColor = true;
            this.tabPageRequests.Enter += new System.EventHandler(this.tabPageRequests_Enter);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(324, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(134, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.DoubleClick += new System.EventHandler(this.txtSearch_DoubleClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.Location = new System.Drawing.Point(744, 6);
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(108, 30);
            this.btnCreateRequest.TabIndex = 3;
            this.btnCreateRequest.Text = "Создать заявку";
            this.btnCreateRequest.UseVisualStyleBackColor = true;
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.Location = new System.Drawing.Point(744, 51);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(108, 30);
            this.btnDeleteRequest.TabIndex = 3;
            this.btnDeleteRequest.Text = "Удалить заявку";
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            this.btnDeleteRequest.Click += new System.EventHandler(this.btnDeleteRequest_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(491, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEditStatus
            // 
            this.btnEditStatus.Location = new System.Drawing.Point(135, 6);
            this.btnEditStatus.Name = "btnEditStatus";
            this.btnEditStatus.Size = new System.Drawing.Size(108, 30);
            this.btnEditStatus.TabIndex = 3;
            this.btnEditStatus.Text = "Изменить статус";
            this.btnEditStatus.UseVisualStyleBackColor = true;
            this.btnEditStatus.Click += new System.EventHandler(this.btnEditStatus_Click);
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Location = new System.Drawing.Point(249, 6);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(87, 30);
            this.btnViewRequest.TabIndex = 3;
            this.btnViewRequest.Text = "Просмотреть";
            this.btnViewRequest.UseVisualStyleBackColor = true;
            this.btnViewRequest.Click += new System.EventHandler(this.btnViewRequest_Click);
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.Location = new System.Drawing.Point(42, 6);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(87, 30);
            this.btnRefreshRequests.TabIndex = 3;
            this.btnRefreshRequests.Text = "Обновить";
            this.btnRefreshRequests.UseVisualStyleBackColor = true;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(49, 121);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(70, 13);
            this.lblStat.TabIndex = 2;
            this.lblStat.Text = "Статтистика";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(375, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(39, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Поиск";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Фильтр по статусам";
            // 
            // comboStatusFilter
            // 
            this.comboStatusFilter.FormattingEnabled = true;
            this.comboStatusFilter.Location = new System.Drawing.Point(120, 60);
            this.comboStatusFilter.Name = "comboStatusFilter";
            this.comboStatusFilter.Size = new System.Drawing.Size(134, 21);
            this.comboStatusFilter.TabIndex = 1;
            this.comboStatusFilter.SelectedIndexChanged += new System.EventHandler(this.comboStatusFilter_SelectedIndexChanged);
            // 
            // dataGridRequests
            // 
            this.dataGridRequests.AllowUserToAddRows = false;
            this.dataGridRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRequestNumber,
            this.colPartner,
            this.colManager,
            this.colStatus,
            this.colAmount,
            this.colCreatedDate});
            this.dataGridRequests.Location = new System.Drawing.Point(42, 137);
            this.dataGridRequests.Name = "dataGridRequests";
            this.dataGridRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRequests.Size = new System.Drawing.Size(810, 256);
            this.dataGridRequests.TabIndex = 0;
            this.dataGridRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridRequests_CellFormatting);
            // 
            // colRequestNumber
            // 
            this.colRequestNumber.HeaderText = "Номер";
            this.colRequestNumber.Name = "colRequestNumber";
            // 
            // colPartner
            // 
            this.colPartner.HeaderText = "Партнер";
            this.colPartner.Name = "colPartner";
            // 
            // colManager
            // 
            this.colManager.HeaderText = "Менеджер";
            this.colManager.Name = "colManager";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма";
            this.colAmount.Name = "colAmount";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.HeaderText = "Дата создания";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(481, 65);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(137, 36);
            this.btnDeleteMaterial.TabIndex = 2;
            this.btnDeleteMaterial.Text = "Удалить материал";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Location = new System.Drawing.Point(279, 13);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(106, 35);
            this.btnDeleteSupplier.TabIndex = 3;
            this.btnDeleteSupplier.Text = "Удалить поставщика";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(723, 124);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(94, 40);
            this.btnDeleteProduct.TabIndex = 1;
            this.btnDeleteProduct.Text = "Удалить продукцию";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 532);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.tabPageDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlerts)).EndInit();
            this.tabPageMaterials.ResumeLayout(false);
            this.tabPageMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaterials)).EndInit();
            this.tabPageSuppliers.ResumeLayout(false);
            this.tabPageSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuppliers)).EndInit();
            this.tabPageProducts.ResumeLayout(false);
            this.tabPageProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.tabPagePartners.ResumeLayout(false);
            this.tabPagePartners.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartners)).EndInit();
            this.tabPageRequests.ResumeLayout(false);
            this.tabPageRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusUser;
        private System.Windows.Forms.ToolStripStatusLabel statusRole;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.TabPage tabPageMaterials;
        private System.Windows.Forms.TabPage tabPageSuppliers;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPagePartners;
        private System.Windows.Forms.TabPage tabPageRequests;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripStatusLabel statusAccess;
        private System.Windows.Forms.DataGridView dataGridAlerts;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.ToolStripStatusLabel statusTime;
        private System.Windows.Forms.Button btnRefreshMaterials;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Label lblMaterialsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridMaterials;
        private System.Windows.Forms.DataGridView dataGridSuppliers;
        private System.Windows.Forms.Label lblSelectedMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMaterials;
        private System.Windows.Forms.Button btnRefreshSuppliers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQualityRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtRawMaterial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMaterialType;
        private System.Windows.Forms.ComboBox comboProductType;
        private System.Windows.Forms.Button btnEditStatus;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.Button btnRefreshRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboStatusFilter;
        private System.Windows.Forms.DataGridView dataGridRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCreateRequest;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnViewPartnerSales;
        private System.Windows.Forms.Button btnRefreshPartners;
        private System.Windows.Forms.Button btnDeletePartner;
        private System.Windows.Forms.Button btnEditPartner;
        private System.Windows.Forms.Button btnAddPartner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridPartners;
        private System.Windows.Forms.ComboBox comboStatusFiltert;
        private System.Windows.Forms.TextBox txtSearcht;
        private System.Windows.Forms.Button btnSearcht;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSearcht;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerINN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerTotalSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartnerStatus;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblPartnersCount;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.Label lblProductsCount;
        private System.Windows.Forms.Button btnRefreshProducts;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnDeleteProduct;
    }
}

