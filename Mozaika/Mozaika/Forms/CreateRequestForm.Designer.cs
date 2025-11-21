namespace Mozaika.Forms
{
    partial class CreateRequestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPartner = new System.Windows.Forms.Label();
            this.comboPartners = new System.Windows.Forms.ComboBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.groupProducts = new System.Windows.Forms.GroupBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.gridSelectedProducts = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTotal = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblFinalAmount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectedProducts)).BeginInit();
            this.groupTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(271, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Создание новой заявки";
            // 
            // lblPartner
            // 
            this.lblPartner.AutoSize = true;
            this.lblPartner.Location = new System.Drawing.Point(37, 56);
            this.lblPartner.Name = "lblPartner";
            this.lblPartner.Size = new System.Drawing.Size(90, 13);
            this.lblPartner.TabIndex = 1;
            this.lblPartner.Text = "Выбор партнёра";
            // 
            // comboPartners
            // 
            this.comboPartners.FormattingEnabled = true;
            this.comboPartners.Location = new System.Drawing.Point(146, 53);
            this.comboPartners.Name = "comboPartners";
            this.comboPartners.Size = new System.Drawing.Size(121, 21);
            this.comboPartners.TabIndex = 2;
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(146, 87);
            this.txtManager.Name = "txtManager";
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(121, 20);
            this.txtManager.TabIndex = 3;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(37, 90);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(60, 13);
            this.lblManager.TabIndex = 1;
            this.lblManager.Text = "Менеджер";
            // 
            // groupProducts
            // 
            this.groupProducts.Controls.Add(this.btnRemoveProduct);
            this.groupProducts.Controls.Add(this.btnAddProduct);
            this.groupProducts.Controls.Add(this.numQuantity);
            this.groupProducts.Controls.Add(this.txtPrice);
            this.groupProducts.Controls.Add(this.lblPrice);
            this.groupProducts.Controls.Add(this.lblQuantity);
            this.groupProducts.Controls.Add(this.lblProduct);
            this.groupProducts.Controls.Add(this.comboProducts);
            this.groupProducts.Location = new System.Drawing.Point(468, 53);
            this.groupProducts.Name = "groupProducts";
            this.groupProducts.Size = new System.Drawing.Size(268, 189);
            this.groupProducts.TabIndex = 4;
            this.groupProducts.TabStop = false;
            this.groupProducts.Text = "Добавление продукции";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(21, 34);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(62, 13);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Продукция";
            // 
            // comboProducts
            // 
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(89, 31);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(121, 21);
            this.comboProducts.TabIndex = 2;
            this.comboProducts.SelectedIndexChanged += new System.EventHandler(this.comboProducts_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(21, 66);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(66, 13);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Количество";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(89, 64);
            this.numQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(121, 20);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(21, 98);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Цена";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(89, 95);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(121, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(24, 142);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 4;
            this.btnAddProduct.Text = "Добавить";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(135, 142);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProduct.TabIndex = 4;
            this.btnRemoveProduct.Text = "Удалить";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // gridSelectedProducts
            // 
            this.gridSelectedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSelectedProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colQuantity,
            this.colPrice,
            this.colAmount});
            this.gridSelectedProducts.Location = new System.Drawing.Point(12, 129);
            this.gridSelectedProducts.Name = "gridSelectedProducts";
            this.gridSelectedProducts.Size = new System.Drawing.Size(448, 308);
            this.gridSelectedProducts.TabIndex = 5;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Наименование";
            this.colProductName.Name = "colProductName";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Кол-во";
            this.colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Цена";
            this.colPrice.Name = "colPrice";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма";
            this.colAmount.Name = "colAmount";
            // 
            // groupTotal
            // 
            this.groupTotal.Controls.Add(this.btnClear);
            this.groupTotal.Controls.Add(this.btnCancel);
            this.groupTotal.Controls.Add(this.btnCreate);
            this.groupTotal.Controls.Add(this.numDiscount);
            this.groupTotal.Controls.Add(this.lblPercent);
            this.groupTotal.Controls.Add(this.lblFinalAmount);
            this.groupTotal.Controls.Add(this.lblFinal);
            this.groupTotal.Controls.Add(this.lblDiscount);
            this.groupTotal.Controls.Add(this.lblTotalAmount);
            this.groupTotal.Controls.Add(this.lblTotal);
            this.groupTotal.Location = new System.Drawing.Point(468, 248);
            this.groupTotal.Name = "groupTotal";
            this.groupTotal.Size = new System.Drawing.Size(268, 189);
            this.groupTotal.TabIndex = 4;
            this.groupTotal.TabStop = false;
            this.groupTotal.Text = "Итоговая информация";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(40, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(60, 159);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(111, 24);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Создать заявку";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(21, 62);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(44, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Скидка";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(105, 34);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(48, 13);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.00 руб";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(21, 34);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Общая сумма:";
            // 
            // numDiscount
            // 
            this.numDiscount.DecimalPlaces = 1;
            this.numDiscount.Location = new System.Drawing.Point(89, 60);
            this.numDiscount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(39, 20);
            this.numDiscount.TabIndex = 3;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(132, 62);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 1;
            this.lblPercent.Text = "%";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(21, 92);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(55, 13);
            this.lblFinal.TabIndex = 1;
            this.lblFinal.Text = "К оплате:";
            // 
            // lblFinalAmount
            // 
            this.lblFinalAmount.AutoSize = true;
            this.lblFinalAmount.Location = new System.Drawing.Point(86, 92);
            this.lblFinalAmount.Name = "lblFinalAmount";
            this.lblFinalAmount.Size = new System.Drawing.Size(48, 13);
            this.lblFinalAmount.TabIndex = 1;
            this.lblFinalAmount.Text = "0.00 руб";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(121, 130);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CreateRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 455);
            this.Controls.Add(this.gridSelectedProducts);
            this.Controls.Add(this.groupTotal);
            this.Controls.Add(this.groupProducts);
            this.Controls.Add(this.txtManager);
            this.Controls.Add(this.comboPartners);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblPartner);
            this.Controls.Add(this.lblTitle);
            this.Name = "CreateRequestForm";
            this.Text = "CreateRequestForm";
            this.groupProducts.ResumeLayout(false);
            this.groupProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectedProducts)).EndInit();
            this.groupTotal.ResumeLayout(false);
            this.groupTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPartner;
        private System.Windows.Forms.ComboBox comboPartners;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.GroupBox groupProducts;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView gridSelectedProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.GroupBox groupTotal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblFinalAmount;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Button btnClear;
    }
}