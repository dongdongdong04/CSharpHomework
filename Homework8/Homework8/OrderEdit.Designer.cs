namespace Homework8
{
    partial class OrderEdit
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveList = new System.Windows.Forms.Button();
            this.btnDeleteList = new System.Windows.Forms.Button();
            this.btnChangeList = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox1.Size = new System.Drawing.Size(1582, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.00255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.99745F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCustomer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.34437F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.65563F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1568, 221);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(244, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 23, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(271, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 25, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "客户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(217, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 26, 7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "下单时间";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtID.Location = new System.Drawing.Point(351, 17);
            this.txtID.Margin = new System.Windows.Forms.Padding(7, 17, 7, 7);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(826, 38);
            this.txtID.TabIndex = 9;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DataSource = this.customerBindingSource;
            this.cmbCustomer.DisplayMember = "name";
            this.cmbCustomer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(351, 90);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(7, 20, 7, 7);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(826, 35);
            this.cmbCustomer.TabIndex = 10;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(OrderServiceAPP.Customer);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTime.Location = new System.Drawing.Point(351, 170);
            this.lblTime.Margin = new System.Windows.Forms.Padding(7, 26, 7, 7);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(152, 44);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "2020-04-10";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.dgvOrderList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 266);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox2.Size = new System.Drawing.Size(1582, 614);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单明细";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveList);
            this.panel1.Controls.Add(this.btnDeleteList);
            this.panel1.Controls.Add(this.btnChangeList);
            this.panel1.Controls.Add(this.btnAddList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(7, 509);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1568, 98);
            this.panel1.TabIndex = 1;
            // 
            // btnSaveList
            // 
            this.btnSaveList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveList.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveList.Location = new System.Drawing.Point(1181, 22);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(355, 56);
            this.btnSaveList.TabIndex = 3;
            this.btnSaveList.Text = "保存订单";
            this.btnSaveList.UseVisualStyleBackColor = false;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // btnDeleteList
            // 
            this.btnDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteList.Location = new System.Drawing.Point(525, 18);
            this.btnDeleteList.Name = "btnDeleteList";
            this.btnDeleteList.Size = new System.Drawing.Size(192, 61);
            this.btnDeleteList.TabIndex = 2;
            this.btnDeleteList.Text = "删除明细";
            this.btnDeleteList.UseVisualStyleBackColor = true;
            this.btnDeleteList.Click += new System.EventHandler(this.btnDeleteList_Click);
            // 
            // btnChangeList
            // 
            this.btnChangeList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeList.Location = new System.Drawing.Point(285, 18);
            this.btnChangeList.Name = "btnChangeList";
            this.btnChangeList.Size = new System.Drawing.Size(192, 61);
            this.btnChangeList.TabIndex = 1;
            this.btnChangeList.Text = "修改明细";
            this.btnChangeList.UseVisualStyleBackColor = true;
            this.btnChangeList.Click += new System.EventHandler(this.btnChangeList_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddList.Location = new System.Drawing.Point(48, 18);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(192, 61);
            this.btnAddList.TabIndex = 0;
            this.btnAddList.Text = "添加明细";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AllowUserToAddRows = false;
            this.dgvOrderList.AutoGenerateColumns = false;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexDataGridViewTextBoxColumn,
            this.goodsNameDataGridViewTextBoxColumn,
            this.goodsQuantityDataGridViewTextBoxColumn,
            this.perPriceDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.dgvOrderList.DataSource = this.listBindingSource;
            this.dgvOrderList.Location = new System.Drawing.Point(12, 37);
            this.dgvOrderList.Margin = new System.Windows.Forms.Padding(7);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.RowTemplate.Height = 23;
            this.dgvOrderList.Size = new System.Drawing.Size(1558, 458);
            this.dgvOrderList.TabIndex = 0;
            this.dgvOrderList.DoubleClick += new System.EventHandler(this.dgvOrderList_DoubleClick);
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "序号";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            // 
            // goodsNameDataGridViewTextBoxColumn
            // 
            this.goodsNameDataGridViewTextBoxColumn.DataPropertyName = "goodsName";
            this.goodsNameDataGridViewTextBoxColumn.HeaderText = "货物";
            this.goodsNameDataGridViewTextBoxColumn.Name = "goodsNameDataGridViewTextBoxColumn";
            this.goodsNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // goodsQuantityDataGridViewTextBoxColumn
            // 
            this.goodsQuantityDataGridViewTextBoxColumn.DataPropertyName = "goodsQuantity";
            this.goodsQuantityDataGridViewTextBoxColumn.HeaderText = "数量";
            this.goodsQuantityDataGridViewTextBoxColumn.Name = "goodsQuantityDataGridViewTextBoxColumn";
            // 
            // perPriceDataGridViewTextBoxColumn
            // 
            this.perPriceDataGridViewTextBoxColumn.DataPropertyName = "perPrice";
            this.perPriceDataGridViewTextBoxColumn.HeaderText = "单价";
            this.perPriceDataGridViewTextBoxColumn.Name = "perPriceDataGridViewTextBoxColumn";
            this.perPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "totalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "总价";
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listBindingSource
            // 
            this.listBindingSource.DataMember = "orderList";
            this.listBindingSource.DataSource = this.orderBindingSource;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(OrderServiceAPP.Order);
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataSource = typeof(OrderServiceAPP.Goods);
            // 
            // OrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 881);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderEdit";
            this.Text = "OrderEdit";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteList;
        private System.Windows.Forms.Button btnChangeList;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnSaveList;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource listBindingSource;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
    }
}