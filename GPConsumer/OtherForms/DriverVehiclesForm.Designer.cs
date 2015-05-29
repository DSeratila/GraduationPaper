namespace GPConsumer.OtherForms
{
    partial class DriverVehiclesForm
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
            this.vehiclesListBox = new System.Windows.Forms.ListBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.deleteVehicleButton = new System.Windows.Forms.Button();
            this.editVehicleButton = new System.Windows.Forms.Button();
            this.createVehicleButton = new System.Windows.Forms.Button();
            this.driverNameLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.vehicleCountStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vehiclesListBox
            // 
            this.vehiclesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vehiclesListBox.FormattingEnabled = true;
            this.vehiclesListBox.ItemHeight = 20;
            this.vehiclesListBox.Location = new System.Drawing.Point(13, 39);
            this.vehiclesListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vehiclesListBox.Name = "vehiclesListBox";
            this.vehiclesListBox.Size = new System.Drawing.Size(256, 224);
            this.vehiclesListBox.TabIndex = 0;
            this.vehiclesListBox.DataSourceChanged += new System.EventHandler(this.vehiclesListBox_DataSourceChanged);
            this.vehiclesListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.vehiclesListBox_Format);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(276, 224);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(131, 39);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deleteVehicleButton
            // 
            this.deleteVehicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteVehicleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteVehicleButton.Location = new System.Drawing.Point(276, 137);
            this.deleteVehicleButton.Name = "deleteVehicleButton";
            this.deleteVehicleButton.Size = new System.Drawing.Size(131, 39);
            this.deleteVehicleButton.TabIndex = 10;
            this.deleteVehicleButton.Text = "Удалить";
            this.deleteVehicleButton.UseVisualStyleBackColor = true;
            this.deleteVehicleButton.Click += new System.EventHandler(this.deleteVehicleButton_Click);
            // 
            // editVehicleButton
            // 
            this.editVehicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editVehicleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editVehicleButton.Location = new System.Drawing.Point(276, 88);
            this.editVehicleButton.Name = "editVehicleButton";
            this.editVehicleButton.Size = new System.Drawing.Size(131, 39);
            this.editVehicleButton.TabIndex = 9;
            this.editVehicleButton.Text = "Редактировать";
            this.editVehicleButton.UseVisualStyleBackColor = true;
            this.editVehicleButton.Click += new System.EventHandler(this.editVehicleButton_Click);
            // 
            // createVehicleButton
            // 
            this.createVehicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createVehicleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createVehicleButton.Location = new System.Drawing.Point(276, 39);
            this.createVehicleButton.Name = "createVehicleButton";
            this.createVehicleButton.Size = new System.Drawing.Size(131, 39);
            this.createVehicleButton.TabIndex = 8;
            this.createVehicleButton.Text = "Создать";
            this.createVehicleButton.UseVisualStyleBackColor = true;
            this.createVehicleButton.Click += new System.EventHandler(this.createVehicleButton_Click);
            // 
            // driverNameLabel
            // 
            this.driverNameLabel.AutoSize = true;
            this.driverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driverNameLabel.Location = new System.Drawing.Point(13, 9);
            this.driverNameLabel.Name = "driverNameLabel";
            this.driverNameLabel.Size = new System.Drawing.Size(53, 20);
            this.driverNameLabel.TabIndex = 12;
            this.driverNameLabel.Text = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleCountStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 270);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(412, 25);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // vehicleCountStripStatusLabel
            // 
            this.vehicleCountStripStatusLabel.Name = "vehicleCountStripStatusLabel";
            this.vehicleCountStripStatusLabel.Size = new System.Drawing.Size(151, 20);
            this.vehicleCountStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // DriverVehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 295);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.driverNameLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteVehicleButton);
            this.Controls.Add(this.editVehicleButton);
            this.Controls.Add(this.createVehicleButton);
            this.Controls.Add(this.vehiclesListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverVehiclesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ТС курьера";
            this.Load += new System.EventHandler(this.DriverVehiclesForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox vehiclesListBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteVehicleButton;
        private System.Windows.Forms.Button editVehicleButton;
        private System.Windows.Forms.Button createVehicleButton;
        private System.Windows.Forms.Label driverNameLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel vehicleCountStripStatusLabel;
    }
}