namespace Delivery_Check
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exceptedTimeDelivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inCourier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outCourier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDelivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lateness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolBtnCheckUpdatedGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnCheckUpdatedNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.func = new System.Windows.Forms.ToolStripDropDownButton();
            this.createOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.changerUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSucceeded = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLatecomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.filterBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.setDateDialog = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.timeDelivery,
            this.exceptedTimeDelivered,
            this.adress,
            this.inCourier,
            this.outCourier,
            this.timeDelivered,
            this.lateness,
            this.description});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 28);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(579, 359);
            this.grid.TabIndex = 0;
            this.grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Grid_CellBeginEdit);
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellEndEdit);
            this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Grid_UserDeletingRow);
            // 
            // id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.id.DefaultCellStyle = dataGridViewCellStyle1;
            this.id.Frozen = true;
            this.id.HeaderText = "№:";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // timeDelivery
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timeDelivery.DefaultCellStyle = dataGridViewCellStyle2;
            this.timeDelivery.HeaderText = "Время заказа:";
            this.timeDelivery.Name = "timeDelivery";
            this.timeDelivery.ReadOnly = true;
            this.timeDelivery.Width = 50;
            // 
            // exceptedTimeDelivered
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exceptedTimeDelivered.DefaultCellStyle = dataGridViewCellStyle3;
            this.exceptedTimeDelivered.HeaderText = "Шаг:";
            this.exceptedTimeDelivered.Name = "exceptedTimeDelivered";
            this.exceptedTimeDelivered.ReadOnly = true;
            this.exceptedTimeDelivered.Width = 40;
            // 
            // adress
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adress.DefaultCellStyle = dataGridViewCellStyle4;
            this.adress.HeaderText = "Адресс: Телефон:";
            this.adress.Name = "adress";
            this.adress.ReadOnly = true;
            // 
            // inCourier
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "t";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inCourier.DefaultCellStyle = dataGridViewCellStyle5;
            this.inCourier.HeaderText = "Курьрер взял:";
            this.inCourier.Name = "inCourier";
            this.inCourier.Width = 50;
            // 
            // outCourier
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "t";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.outCourier.DefaultCellStyle = dataGridViewCellStyle6;
            this.outCourier.HeaderText = "Курьер отдал:";
            this.outCourier.Name = "outCourier";
            this.outCourier.Width = 50;
            // 
            // timeDelivered
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "t";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timeDelivered.DefaultCellStyle = dataGridViewCellStyle7;
            this.timeDelivered.HeaderText = "Должны привезти:";
            this.timeDelivered.Name = "timeDelivered";
            this.timeDelivered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeDelivered.Width = 50;
            // 
            // lateness
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lateness.DefaultCellStyle = dataGridViewCellStyle8;
            this.lateness.HeaderText = "Опоздание:";
            this.lateness.Name = "lateness";
            this.lateness.ReadOnly = true;
            this.lateness.Width = 50;
            // 
            // description
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.description.DefaultCellStyle = dataGridViewCellStyle9;
            this.description.HeaderText = "Примечание:";
            this.description.Name = "description";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.func,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.filterBox,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(560, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripDropDownButton2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnCheckUpdatedGrid,
            this.toolBtnCheckUpdatedNewOrder});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(93, 22);
            this.toolStripDropDownButton2.Text = "Обновить:";
            // 
            // toolBtnCheckUpdatedGrid
            // 
            this.toolBtnCheckUpdatedGrid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolBtnCheckUpdatedGrid.Name = "toolBtnCheckUpdatedGrid";
            this.toolBtnCheckUpdatedGrid.Size = new System.Drawing.Size(210, 22);
            this.toolBtnCheckUpdatedGrid.Text = "Обновление таблицы";
            this.toolBtnCheckUpdatedGrid.Click += new System.EventHandler(this.ToolBtnCheckUpdatedGrid_Click);
            // 
            // toolBtnCheckUpdatedNewOrder
            // 
            this.toolBtnCheckUpdatedNewOrder.Name = "toolBtnCheckUpdatedNewOrder";
            this.toolBtnCheckUpdatedNewOrder.Size = new System.Drawing.Size(210, 22);
            this.toolBtnCheckUpdatedNewOrder.Text = "Проверка новых заказов";
            this.toolBtnCheckUpdatedNewOrder.Click += new System.EventHandler(this.ToolBtnCheckUpdatedNewOrder_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "1:30";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // func
            // 
            this.func.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.func.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.func.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createOrder,
            this.changerUser});
            this.func.Image = ((System.Drawing.Image)(resources.GetObject("func.Image")));
            this.func.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.func.Name = "func";
            this.func.Size = new System.Drawing.Size(69, 22);
            this.func.Text = "Функции";
            // 
            // createOrder
            // 
            this.createOrder.Name = "createOrder";
            this.createOrder.Size = new System.Drawing.Size(227, 22);
            this.createOrder.Text = "Предзаказ";
            this.createOrder.Click += new System.EventHandler(this.CreateOrder_Click);
            // 
            // changerUser
            // 
            this.changerUser.Name = "changerUser";
            this.changerUser.Size = new System.Drawing.Size(227, 22);
            this.changerUser.Text = "Управление пользователем";
            this.changerUser.Click += new System.EventHandler(this.ChangerPasswordUser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripDropDownButton1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSucceeded,
            this.btnLatecomer});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(71, 22);
            this.toolStripDropDownButton1.Text = "Цвет для:";
            // 
            // btnSucceeded
            // 
            this.btnSucceeded.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSucceeded.Name = "btnSucceeded";
            this.btnSucceeded.Size = new System.Drawing.Size(144, 22);
            this.btnSucceeded.Text = "Успевших";
            this.btnSucceeded.Click += new System.EventHandler(this.BtnSucceeded_Click);
            // 
            // btnLatecomer
            // 
            this.btnLatecomer.Name = "btnLatecomer";
            this.btnLatecomer.Size = new System.Drawing.Size(144, 22);
            this.btnLatecomer.Text = "Опоздавших";
            this.btnLatecomer.Click += new System.EventHandler(this.BtnLatecomer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // filterBox
            // 
            this.filterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.filterBox.Items.AddRange(new object[] {
            "Доставки",
            "Самовывозы",
            "Все"});
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(95, 25);
            this.filterBox.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // setDateDialog
            // 
            this.setDateDialog.Location = new System.Drawing.Point(360, 3);
            this.setDateDialog.Name = "setDateDialog";
            this.setDateDialog.Size = new System.Drawing.Size(33, 20);
            this.setDateDialog.TabIndex = 3;
            this.setDateDialog.ValueChanged += new System.EventHandler(this.SetDateDialog_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 388);
            this.Controls.Add(this.setDateDialog);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Delivery Check";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn exceptedTimeDelivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn inCourier;
        private System.Windows.Forms.DataGridViewTextBoxColumn outCourier;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDelivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn lateness;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnSucceeded;
        private System.Windows.Forms.ToolStripMenuItem btnLatecomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DateTimePicker setDateDialog;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolBtnCheckUpdatedGrid;
        private System.Windows.Forms.ToolStripMenuItem toolBtnCheckUpdatedNewOrder;
        private System.Windows.Forms.ToolStripComboBox filterBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton func;
        private System.Windows.Forms.ToolStripMenuItem createOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem changerUser;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

