namespace GPConsumer
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictionariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусыЗаказаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ourPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.fromMapRadioButton = new System.Windows.Forms.RadioButton();
            this.fromOurPositionRadioButton = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.couriteRadioButton = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.ourCheckBox = new System.Windows.Forms.CheckBox();
            this.ordersCheckBox = new System.Windows.Forms.CheckBox();
            this.driversCheckBox = new System.Windows.Forms.CheckBox();
            this.driversComboBox = new System.Windows.Forms.ComboBox();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveredDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDriverIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDriverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryAdressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDeletedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longtitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDTOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.orderBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.ordersTimer = new System.Windows.Forms.Timer(this.components);
            this.button10 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDTOBindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dictionariesToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1369, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.connectToolStripMenuItem.Text = "Содинение ";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // dictionariesToolStripMenuItem
            // 
            this.dictionariesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driversToolStripMenuItem,
            this.статусыЗаказаToolStripMenuItem});
            this.dictionariesToolStripMenuItem.Name = "dictionariesToolStripMenuItem";
            this.dictionariesToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.dictionariesToolStripMenuItem.Text = "Справочники";
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.driversToolStripMenuItem.Text = "Водители";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // статусыЗаказаToolStripMenuItem
            // 
            this.статусыЗаказаToolStripMenuItem.Name = "статусыЗаказаToolStripMenuItem";
            this.статусыЗаказаToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.статусыЗаказаToolStripMenuItem.Text = "Статусы заказа";
            this.статусыЗаказаToolStripMenuItem.Click += new System.EventHandler(this.статусыЗаказаToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ourPositionToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.optionsToolStripMenuItem.Text = "Опции";
            // 
            // ourPositionToolStripMenuItem
            // 
            this.ourPositionToolStripMenuItem.Name = "ourPositionToolStripMenuItem";
            this.ourPositionToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.ourPositionToolStripMenuItem.Text = "Задать местоположение";
            this.ourPositionToolStripMenuItem.Click += new System.EventHandler(this.ourPositionToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(249, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Показать на карте";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(401, 631);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(149, 44);
            this.button5.TabIndex = 3;
            this.button5.Text = "Сменить статус";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 631);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(132, 44);
            this.button6.TabIndex = 4;
            this.button6.Text = "История заказа";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(162, 631);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(223, 44);
            this.button7.TabIndex = 5;
            this.button7.Text = "Назначить курьера";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(162, 587);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(401, 587);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(149, 24);
            this.comboBox2.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.driversComboBox);
            this.tabPage2.Controls.Add(this.map);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1349, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Карта";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.fromMapRadioButton);
            this.groupBox2.Controls.Add(this.fromOurPositionRadioButton);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.couriteRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 166);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(96, 102);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(93, 52);
            this.button13.TabIndex = 11;
            this.button13.Text = "Очистить";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // fromMapRadioButton
            // 
            this.fromMapRadioButton.AutoSize = true;
            this.fromMapRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromMapRadioButton.Location = new System.Drawing.Point(6, 72);
            this.fromMapRadioButton.Name = "fromMapRadioButton";
            this.fromMapRadioButton.Size = new System.Drawing.Size(104, 24);
            this.fromMapRadioButton.TabIndex = 2;
            this.fromMapRadioButton.Text = "на карте";
            this.fromMapRadioButton.UseVisualStyleBackColor = true;
            // 
            // fromOurPositionRadioButton
            // 
            this.fromOurPositionRadioButton.AutoSize = true;
            this.fromOurPositionRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromOurPositionRadioButton.Location = new System.Drawing.Point(6, 42);
            this.fromOurPositionRadioButton.Name = "fromOurPositionRadioButton";
            this.fromOurPositionRadioButton.Size = new System.Drawing.Size(101, 24);
            this.fromOurPositionRadioButton.TabIndex = 1;
            this.fromOurPositionRadioButton.Text = "текущее";
            this.fromOurPositionRadioButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 52);
            this.button2.TabIndex = 10;
            this.button2.Text = "Маршрут";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // couriteRadioButton
            // 
            this.couriteRadioButton.AutoSize = true;
            this.couriteRadioButton.Checked = true;
            this.couriteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.couriteRadioButton.Location = new System.Drawing.Point(6, 13);
            this.couriteRadioButton.Name = "couriteRadioButton";
            this.couriteRadioButton.Size = new System.Drawing.Size(87, 24);
            this.couriteRadioButton.TabIndex = 0;
            this.couriteRadioButton.TabStop = true;
            this.couriteRadioButton.Text = "курьер";
            this.couriteRadioButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 411);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 52);
            this.button3.TabIndex = 11;
            this.button3.Text = "Показать заказы курьера";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Заказы курьера";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.ourCheckBox);
            this.groupBox1.Controls.Add(this.ordersCheckBox);
            this.groupBox1.Controls.Add(this.driversCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 170);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отображать";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 45);
            this.button4.TabIndex = 12;
            this.button4.Text = "Показать все";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ourCheckBox
            // 
            this.ourCheckBox.AutoSize = true;
            this.ourCheckBox.Location = new System.Drawing.Point(6, 82);
            this.ourCheckBox.Name = "ourCheckBox";
            this.ourCheckBox.Size = new System.Drawing.Size(183, 21);
            this.ourCheckBox.TabIndex = 6;
            this.ourCheckBox.Text = "Наше местоположение";
            this.ourCheckBox.UseVisualStyleBackColor = true;
            this.ourCheckBox.CheckedChanged += new System.EventHandler(this.ourCheckBox_CheckedChanged);
            // 
            // ordersCheckBox
            // 
            this.ordersCheckBox.AutoSize = true;
            this.ordersCheckBox.Checked = true;
            this.ordersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ordersCheckBox.Location = new System.Drawing.Point(6, 28);
            this.ordersCheckBox.Name = "ordersCheckBox";
            this.ordersCheckBox.Size = new System.Drawing.Size(79, 21);
            this.ordersCheckBox.TabIndex = 4;
            this.ordersCheckBox.Text = "Заказы";
            this.ordersCheckBox.UseVisualStyleBackColor = true;
            this.ordersCheckBox.CheckedChanged += new System.EventHandler(this.ordersCheckBox_CheckedChanged);
            // 
            // driversCheckBox
            // 
            this.driversCheckBox.AutoSize = true;
            this.driversCheckBox.Checked = true;
            this.driversCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.driversCheckBox.Location = new System.Drawing.Point(6, 55);
            this.driversCheckBox.Name = "driversCheckBox";
            this.driversCheckBox.Size = new System.Drawing.Size(87, 21);
            this.driversCheckBox.TabIndex = 5;
            this.driversCheckBox.Text = "Курьеры";
            this.driversCheckBox.UseVisualStyleBackColor = true;
            this.driversCheckBox.CheckedChanged += new System.EventHandler(this.driversCheckBox_CheckedChanged);
            // 
            // driversComboBox
            // 
            this.driversComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driversComboBox.FormattingEnabled = true;
            this.driversComboBox.Location = new System.Drawing.Point(12, 372);
            this.driversComboBox.Name = "driversComboBox";
            this.driversComboBox.Size = new System.Drawing.Size(200, 24);
            this.driversComboBox.TabIndex = 7;
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(226, 6);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1123, 504);
            this.map.TabIndex = 3;
            this.map.Zoom = 0D;
            this.map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map_MouseDown);
            this.map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ordersDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1349, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Заказы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AllowUserToAddRows = false;
            this.ordersDataGridView.AllowUserToDeleteRows = false;
            this.ordersDataGridView.AllowUserToResizeColumns = false;
            this.ordersDataGridView.AllowUserToResizeRows = false;
            this.ordersDataGridView.AutoGenerateColumns = false;
            this.ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ordersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn,
            this.createdDtDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.deliveredDtDataGridViewTextBoxColumn,
            this.deliveryDriverIdDataGridViewTextBoxColumn,
            this.deliveryDriverNameDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.deliveryAdressDataGridViewTextBoxColumn,
            this.goodsListDataGridViewTextBoxColumn,
            this.isDeletedDataGridViewCheckBoxColumn,
            this.lastUpdatedDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.longtitudeDataGridViewTextBoxColumn,
            this.orderStatusIdDataGridViewTextBoxColumn,
            this.orderStatusNameDataGridViewTextBoxColumn,
            this.totalCostDataGridViewTextBoxColumn,
            this.updateDtDataGridViewTextBoxColumn});
            this.ordersDataGridView.DataSource = this.orderDTOBindingSource1;
            this.ordersDataGridView.EnableHeadersVisualStyles = false;
            this.ordersDataGridView.Location = new System.Drawing.Point(6, 6);
            this.ordersDataGridView.MultiSelect = false;
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.ReadOnly = true;
            this.ordersDataGridView.RowHeadersVisible = false;
            this.ordersDataGridView.RowTemplate.Height = 24;
            this.ordersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDataGridView.Size = new System.Drawing.Size(1335, 508);
            this.ordersDataGridView.TabIndex = 0;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "Заказ";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIdDataGridViewTextBoxColumn.Width = 72;
            // 
            // createdDtDataGridViewTextBoxColumn
            // 
            this.createdDtDataGridViewTextBoxColumn.DataPropertyName = "CreatedDt";
            this.createdDtDataGridViewTextBoxColumn.HeaderText = "Создан";
            this.createdDtDataGridViewTextBoxColumn.Name = "createdDtDataGridViewTextBoxColumn";
            this.createdDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDtDataGridViewTextBoxColumn.Width = 81;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerNameDataGridViewTextBoxColumn.Width = 81;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneDataGridViewTextBoxColumn.Width = 76;
            // 
            // deliveredDtDataGridViewTextBoxColumn
            // 
            this.deliveredDtDataGridViewTextBoxColumn.DataPropertyName = "DeliveredDt";
            this.deliveredDtDataGridViewTextBoxColumn.HeaderText = "Дата доставки";
            this.deliveredDtDataGridViewTextBoxColumn.Name = "deliveredDtDataGridViewTextBoxColumn";
            this.deliveredDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveredDtDataGridViewTextBoxColumn.Width = 120;
            // 
            // deliveryDriverIdDataGridViewTextBoxColumn
            // 
            this.deliveryDriverIdDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDriverId";
            this.deliveryDriverIdDataGridViewTextBoxColumn.HeaderText = "DeliveryDriverId";
            this.deliveryDriverIdDataGridViewTextBoxColumn.Name = "deliveryDriverIdDataGridViewTextBoxColumn";
            this.deliveryDriverIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryDriverIdDataGridViewTextBoxColumn.Visible = false;
            this.deliveryDriverIdDataGridViewTextBoxColumn.Width = 133;
            // 
            // deliveryDriverNameDataGridViewTextBoxColumn
            // 
            this.deliveryDriverNameDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDriverName";
            this.deliveryDriverNameDataGridViewTextBoxColumn.HeaderText = "Курьер";
            this.deliveryDriverNameDataGridViewTextBoxColumn.Name = "deliveryDriverNameDataGridViewTextBoxColumn";
            this.deliveryDriverNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryDriverNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "Город";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 73;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Width = 99;
            // 
            // deliveryAdressDataGridViewTextBoxColumn
            // 
            this.deliveryAdressDataGridViewTextBoxColumn.DataPropertyName = "DeliveryAdress";
            this.deliveryAdressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.deliveryAdressDataGridViewTextBoxColumn.Name = "deliveryAdressDataGridViewTextBoxColumn";
            this.deliveryAdressDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryAdressDataGridViewTextBoxColumn.Width = 73;
            // 
            // goodsListDataGridViewTextBoxColumn
            // 
            this.goodsListDataGridViewTextBoxColumn.DataPropertyName = "GoodsList";
            this.goodsListDataGridViewTextBoxColumn.HeaderText = "GoodsList";
            this.goodsListDataGridViewTextBoxColumn.Name = "goodsListDataGridViewTextBoxColumn";
            this.goodsListDataGridViewTextBoxColumn.ReadOnly = true;
            this.goodsListDataGridViewTextBoxColumn.Visible = false;
            this.goodsListDataGridViewTextBoxColumn.Width = 97;
            // 
            // isDeletedDataGridViewCheckBoxColumn
            // 
            this.isDeletedDataGridViewCheckBoxColumn.DataPropertyName = "IsDeleted";
            this.isDeletedDataGridViewCheckBoxColumn.HeaderText = "IsDeleted";
            this.isDeletedDataGridViewCheckBoxColumn.Name = "isDeletedDataGridViewCheckBoxColumn";
            this.isDeletedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isDeletedDataGridViewCheckBoxColumn.Visible = false;
            this.isDeletedDataGridViewCheckBoxColumn.Width = 73;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            this.lastUpdatedDataGridViewTextBoxColumn.HeaderText = "LastUpdated";
            this.lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            this.lastUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedDataGridViewTextBoxColumn.Visible = false;
            this.lastUpdatedDataGridViewTextBoxColumn.Width = 114;
            // 
            // latitudeDataGridViewTextBoxColumn
            // 
            this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
            this.latitudeDataGridViewTextBoxColumn.ReadOnly = true;
            this.latitudeDataGridViewTextBoxColumn.Visible = false;
            this.latitudeDataGridViewTextBoxColumn.Width = 84;
            // 
            // longtitudeDataGridViewTextBoxColumn
            // 
            this.longtitudeDataGridViewTextBoxColumn.DataPropertyName = "Longtitude";
            this.longtitudeDataGridViewTextBoxColumn.HeaderText = "Longtitude";
            this.longtitudeDataGridViewTextBoxColumn.Name = "longtitudeDataGridViewTextBoxColumn";
            this.longtitudeDataGridViewTextBoxColumn.ReadOnly = true;
            this.longtitudeDataGridViewTextBoxColumn.Visible = false;
            // 
            // orderStatusIdDataGridViewTextBoxColumn
            // 
            this.orderStatusIdDataGridViewTextBoxColumn.DataPropertyName = "OrderStatusId";
            this.orderStatusIdDataGridViewTextBoxColumn.HeaderText = "OrderStatusId";
            this.orderStatusIdDataGridViewTextBoxColumn.Name = "orderStatusIdDataGridViewTextBoxColumn";
            this.orderStatusIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderStatusIdDataGridViewTextBoxColumn.Visible = false;
            this.orderStatusIdDataGridViewTextBoxColumn.Width = 121;
            // 
            // orderStatusNameDataGridViewTextBoxColumn
            // 
            this.orderStatusNameDataGridViewTextBoxColumn.DataPropertyName = "OrderStatusName";
            this.orderStatusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.orderStatusNameDataGridViewTextBoxColumn.Name = "orderStatusNameDataGridViewTextBoxColumn";
            this.orderStatusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderStatusNameDataGridViewTextBoxColumn.Width = 78;
            // 
            // totalCostDataGridViewTextBoxColumn
            // 
            this.totalCostDataGridViewTextBoxColumn.DataPropertyName = "TotalCost";
            this.totalCostDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.totalCostDataGridViewTextBoxColumn.Name = "totalCostDataGridViewTextBoxColumn";
            this.totalCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalCostDataGridViewTextBoxColumn.Width = 75;
            // 
            // updateDtDataGridViewTextBoxColumn
            // 
            this.updateDtDataGridViewTextBoxColumn.DataPropertyName = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.HeaderText = "UpdateDt";
            this.updateDtDataGridViewTextBoxColumn.Name = "updateDtDataGridViewTextBoxColumn";
            this.updateDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDtDataGridViewTextBoxColumn.Visible = false;
            this.updateDtDataGridViewTextBoxColumn.Width = 93;
            // 
            // orderDTOBindingSource1
            // 
            this.orderDTOBindingSource1.DataSource = typeof(GPConsumer.GPOrderServiceReference.OrderDTO);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1357, 550);
            this.tabControl1.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(556, 631);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(149, 44);
            this.button8.TabIndex = 11;
            this.button8.Text = "Закрыть заказ";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(556, 581);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(149, 44);
            this.button9.TabIndex = 12;
            this.button9.Text = "Статистика за сегодня";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // ordersTimer
            // 
            this.ordersTimer.Interval = 1000;
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(763, 587);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 682);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDTOBindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dictionariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ourPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton fromMapRadioButton;
        private System.Windows.Forms.RadioButton fromOurPositionRadioButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton couriteRadioButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox ourCheckBox;
        private System.Windows.Forms.CheckBox ordersCheckBox;
        private System.Windows.Forms.CheckBox driversCheckBox;
        private System.Windows.Forms.ComboBox driversComboBox;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource orderDTOBindingSource1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.BindingSource orderBindingSource2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveredDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDriverIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDriverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryAdressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDeletedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longtitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem статусыЗаказаToolStripMenuItem;
        private System.Windows.Forms.Timer ordersTimer;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;

    }
}

