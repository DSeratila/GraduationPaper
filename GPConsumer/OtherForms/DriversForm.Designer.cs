namespace GPConsumer.OtherForms
{
    partial class DriversForm
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
            this.driversListBox = new System.Windows.Forms.ListBox();
            this.createDriverButton = new System.Windows.Forms.Button();
            this.editDriverButton = new System.Windows.Forms.Button();
            this.showDriverRouteButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.driversCountStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteDriverButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.vehiclesButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // driversListBox
            // 
            this.driversListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driversListBox.FormattingEnabled = true;
            this.driversListBox.ItemHeight = 20;
            this.driversListBox.Location = new System.Drawing.Point(12, 37);
            this.driversListBox.Name = "driversListBox";
            this.driversListBox.Size = new System.Drawing.Size(261, 344);
            this.driversListBox.TabIndex = 0;
            this.driversListBox.DataSourceChanged += new System.EventHandler(this.driversListBox_DataSourceChanged);
            // 
            // createDriverButton
            // 
            this.createDriverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createDriverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createDriverButton.Location = new System.Drawing.Point(279, 37);
            this.createDriverButton.Name = "createDriverButton";
            this.createDriverButton.Size = new System.Drawing.Size(167, 43);
            this.createDriverButton.TabIndex = 1;
            this.createDriverButton.Text = "Создать";
            this.createDriverButton.UseVisualStyleBackColor = true;
            this.createDriverButton.Click += new System.EventHandler(this.createDriverButton_Click);
            // 
            // editDriverButton
            // 
            this.editDriverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editDriverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editDriverButton.Location = new System.Drawing.Point(279, 86);
            this.editDriverButton.Name = "editDriverButton";
            this.editDriverButton.Size = new System.Drawing.Size(167, 43);
            this.editDriverButton.TabIndex = 2;
            this.editDriverButton.Text = "Редактировать";
            this.editDriverButton.UseVisualStyleBackColor = true;
            this.editDriverButton.Click += new System.EventHandler(this.editDriverButton_Click);
            // 
            // showDriverRouteButton
            // 
            this.showDriverRouteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showDriverRouteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showDriverRouteButton.Location = new System.Drawing.Point(279, 135);
            this.showDriverRouteButton.Name = "showDriverRouteButton";
            this.showDriverRouteButton.Size = new System.Drawing.Size(167, 43);
            this.showDriverRouteButton.TabIndex = 3;
            this.showDriverRouteButton.Text = "Перемещения";
            this.showDriverRouteButton.UseVisualStyleBackColor = true;
            this.showDriverRouteButton.Click += new System.EventHandler(this.showDriverRouteButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driversCountStatusStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(459, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // driversCountStatusStripLabel
            // 
            this.driversCountStatusStripLabel.Name = "driversCountStatusStripLabel";
            this.driversCountStatusStripLabel.Size = new System.Drawing.Size(174, 20);
            this.driversCountStatusStripLabel.Text = "Количество курьеров: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список курьеров";
            // 
            // deleteDriverButton
            // 
            this.deleteDriverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteDriverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteDriverButton.Location = new System.Drawing.Point(279, 233);
            this.deleteDriverButton.Name = "deleteDriverButton";
            this.deleteDriverButton.Size = new System.Drawing.Size(167, 43);
            this.deleteDriverButton.TabIndex = 6;
            this.deleteDriverButton.Text = "Удалить";
            this.deleteDriverButton.UseVisualStyleBackColor = true;
            this.deleteDriverButton.Click += new System.EventHandler(this.deleteDriverButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(279, 320);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(167, 43);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // vehiclesButton
            // 
            this.vehiclesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vehiclesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vehiclesButton.Location = new System.Drawing.Point(279, 184);
            this.vehiclesButton.Name = "vehiclesButton";
            this.vehiclesButton.Size = new System.Drawing.Size(167, 43);
            this.vehiclesButton.TabIndex = 8;
            this.vehiclesButton.Text = "Транспорт";
            this.vehiclesButton.UseVisualStyleBackColor = true;
            this.vehiclesButton.Click += new System.EventHandler(this.vehiclesButton_Click);
            // 
            // DriversForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 411);
            this.Controls.Add(this.vehiclesButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteDriverButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.showDriverRouteButton);
            this.Controls.Add(this.editDriverButton);
            this.Controls.Add(this.createDriverButton);
            this.Controls.Add(this.driversListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriversForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Водители";
            this.Load += new System.EventHandler(this.DriversFrom_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox driversListBox;
        private System.Windows.Forms.Button createDriverButton;
        private System.Windows.Forms.Button editDriverButton;
        private System.Windows.Forms.Button showDriverRouteButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel driversCountStatusStripLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteDriverButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button vehiclesButton;
    }
}