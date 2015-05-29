namespace GPConsumer.OtherForms
{
    partial class DriverPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverPropertiesForm));
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.driverLicenceLabel = new System.Windows.Forms.Label();
            this.driverLicenctTextBox = new System.Windows.Forms.TextBox();
            this.passportLabel = new System.Windows.Forms.Label();
            this.passportSeriesLabel = new System.Windows.Forms.Label();
            this.passportNumLabel = new System.Windows.Forms.Label();
            this.passportSeriesTextBox = new System.Windows.Forms.TextBox();
            this.passportNumTexbox = new System.Windows.Forms.TextBox();
            this.passportGivenByLabel = new System.Windows.Forms.Label();
            this.passportGivenByTextBox = new System.Windows.Forms.TextBox();
            this.passportGivenDateLabel = new System.Windows.Forms.Label();
            this.passportGivenDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.passportGivenDivisionLabel = new System.Windows.Forms.Label();
            this.passportGivenDivisionTextBox = new System.Windows.Forms.TextBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.declineButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel1
            // 
            this.nameLabel1.AutoSize = true;
            this.nameLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel1.Location = new System.Drawing.Point(42, 11);
            this.nameLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(54, 20);
            this.nameLabel1.TabIndex = 0;
            this.nameLabel1.Text = "ФИО:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(12, 35);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(220, 27);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Text = "Иванов Василий Перович";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneLabel.Location = new System.Drawing.Point(236, 66);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(90, 20);
            this.phoneLabel.TabIndex = 2;
            this.phoneLabel.Text = "Телефон:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneTextBox.Location = new System.Drawing.Point(240, 90);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(155, 27);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.Text = "+7 (777) 777-77-77";
            // 
            // driverLicenceLabel
            // 
            this.driverLicenceLabel.AutoSize = true;
            this.driverLicenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driverLicenceLabel.Location = new System.Drawing.Point(236, 11);
            this.driverLicenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.driverLicenceLabel.Name = "driverLicenceLabel";
            this.driverLicenceLabel.Size = new System.Drawing.Size(159, 20);
            this.driverLicenceLabel.TabIndex = 4;
            this.driverLicenceLabel.Text = "№ удостоверения";
            // 
            // driverLicenctTextBox
            // 
            this.driverLicenctTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.driverLicenctTextBox.Location = new System.Drawing.Point(240, 35);
            this.driverLicenctTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.driverLicenctTextBox.Name = "driverLicenctTextBox";
            this.driverLicenctTextBox.Size = new System.Drawing.Size(155, 27);
            this.driverLicenctTextBox.TabIndex = 5;
            this.driverLicenctTextBox.Text = "XX XX XXXX";
            // 
            // passportLabel
            // 
            this.passportLabel.AutoSize = true;
            this.passportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportLabel.Location = new System.Drawing.Point(7, 139);
            this.passportLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportLabel.Name = "passportLabel";
            this.passportLabel.Size = new System.Drawing.Size(199, 20);
            this.passportLabel.TabIndex = 6;
            this.passportLabel.Text = "Паспортные данные";
            // 
            // passportSeriesLabel
            // 
            this.passportSeriesLabel.AutoSize = true;
            this.passportSeriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportSeriesLabel.Location = new System.Drawing.Point(7, 175);
            this.passportSeriesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportSeriesLabel.Name = "passportSeriesLabel";
            this.passportSeriesLabel.Size = new System.Drawing.Size(66, 20);
            this.passportSeriesLabel.TabIndex = 7;
            this.passportSeriesLabel.Text = "Серия:";
            // 
            // passportNumLabel
            // 
            this.passportNumLabel.AutoSize = true;
            this.passportNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportNumLabel.Location = new System.Drawing.Point(7, 229);
            this.passportNumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportNumLabel.Name = "passportNumLabel";
            this.passportNumLabel.Size = new System.Drawing.Size(69, 20);
            this.passportNumLabel.TabIndex = 8;
            this.passportNumLabel.Text = "Номер:";
            // 
            // passportSeriesTextBox
            // 
            this.passportSeriesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportSeriesTextBox.Location = new System.Drawing.Point(11, 199);
            this.passportSeriesTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passportSeriesTextBox.Name = "passportSeriesTextBox";
            this.passportSeriesTextBox.Size = new System.Drawing.Size(220, 27);
            this.passportSeriesTextBox.TabIndex = 9;
            this.passportSeriesTextBox.Text = "XX XX";
            // 
            // passportNumTexbox
            // 
            this.passportNumTexbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportNumTexbox.Location = new System.Drawing.Point(11, 253);
            this.passportNumTexbox.Margin = new System.Windows.Forms.Padding(4);
            this.passportNumTexbox.Name = "passportNumTexbox";
            this.passportNumTexbox.Size = new System.Drawing.Size(220, 27);
            this.passportNumTexbox.TabIndex = 10;
            this.passportNumTexbox.Text = "YYYYYY";
            // 
            // passportGivenByLabel
            // 
            this.passportGivenByLabel.AutoSize = true;
            this.passportGivenByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportGivenByLabel.Location = new System.Drawing.Point(8, 287);
            this.passportGivenByLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportGivenByLabel.Name = "passportGivenByLabel";
            this.passportGivenByLabel.Size = new System.Drawing.Size(106, 20);
            this.passportGivenByLabel.TabIndex = 11;
            this.passportGivenByLabel.Text = "Кем выдан:";
            // 
            // passportGivenByTextBox
            // 
            this.passportGivenByTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportGivenByTextBox.Location = new System.Drawing.Point(12, 311);
            this.passportGivenByTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passportGivenByTextBox.Name = "passportGivenByTextBox";
            this.passportGivenByTextBox.Size = new System.Drawing.Size(381, 27);
            this.passportGivenByTextBox.TabIndex = 12;
            this.passportGivenByTextBox.Text = "Выдан теми-то";
            // 
            // passportGivenDateLabel
            // 
            this.passportGivenDateLabel.AutoSize = true;
            this.passportGivenDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportGivenDateLabel.Location = new System.Drawing.Point(235, 175);
            this.passportGivenDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportGivenDateLabel.Name = "passportGivenDateLabel";
            this.passportGivenDateLabel.Size = new System.Drawing.Size(126, 20);
            this.passportGivenDateLabel.TabIndex = 13;
            this.passportGivenDateLabel.Text = "Дата выдачи:";
            // 
            // passportGivenDateTimePicker
            // 
            this.passportGivenDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportGivenDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.passportGivenDateTimePicker.Location = new System.Drawing.Point(239, 199);
            this.passportGivenDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.passportGivenDateTimePicker.Name = "passportGivenDateTimePicker";
            this.passportGivenDateTimePicker.Size = new System.Drawing.Size(130, 27);
            this.passportGivenDateTimePicker.TabIndex = 14;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // passportGivenDivisionLabel
            // 
            this.passportGivenDivisionLabel.AutoSize = true;
            this.passportGivenDivisionLabel.Location = new System.Drawing.Point(234, 229);
            this.passportGivenDivisionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passportGivenDivisionLabel.Name = "passportGivenDivisionLabel";
            this.passportGivenDivisionLabel.Size = new System.Drawing.Size(93, 20);
            this.passportGivenDivisionLabel.TabIndex = 15;
            this.passportGivenDivisionLabel.Text = "Код подр.";
            // 
            // passportGivenDivisionTextBox
            // 
            this.passportGivenDivisionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passportGivenDivisionTextBox.Location = new System.Drawing.Point(239, 253);
            this.passportGivenDivisionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passportGivenDivisionTextBox.Name = "passportGivenDivisionTextBox";
            this.passportGivenDivisionTextBox.Size = new System.Drawing.Size(154, 27);
            this.passportGivenDivisionTextBox.TabIndex = 16;
            this.passportGivenDivisionTextBox.Text = "XXX-XXX";
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChangesButton.Location = new System.Drawing.Point(9, 346);
            this.saveChangesButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(223, 42);
            this.saveChangesButton.TabIndex = 17;
            this.saveChangesButton.Text = "Сохранить";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // declineButton
            // 
            this.declineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.declineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.declineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.declineButton.Location = new System.Drawing.Point(238, 346);
            this.declineButton.Margin = new System.Windows.Forms.Padding(4);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(155, 42);
            this.declineButton.TabIndex = 18;
            this.declineButton.Text = "Отмена";
            this.declineButton.UseVisualStyleBackColor = true;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox.Location = new System.Drawing.Point(12, 90);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(220, 27);
            this.emailTextBox.TabIndex = 20;
            this.emailTextBox.Text = "petrovich@gmail.com";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.Location = new System.Drawing.Point(8, 66);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(62, 20);
            this.emailLabel.TabIndex = 19;
            this.emailLabel.Text = "E-mail:";
            // 
            // notesRichTextBox
            // 
            this.notesRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notesRichTextBox.Location = new System.Drawing.Point(403, 33);
            this.notesRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.notesRichTextBox.Name = "notesRichTextBox";
            this.notesRichTextBox.Size = new System.Drawing.Size(243, 355);
            this.notesRichTextBox.TabIndex = 21;
            this.notesRichTextBox.Text = resources.GetString("notesRichTextBox.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(403, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Заметки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            // 
            // DriverPropertiesForm
            // 
            this.AcceptButton = this.saveChangesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.declineButton;
            this.ClientSize = new System.Drawing.Size(658, 397);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notesRichTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.declineButton);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.passportGivenDivisionTextBox);
            this.Controls.Add(this.passportGivenDivisionLabel);
            this.Controls.Add(this.passportGivenDateTimePicker);
            this.Controls.Add(this.passportGivenDateLabel);
            this.Controls.Add(this.passportGivenByTextBox);
            this.Controls.Add(this.passportGivenByLabel);
            this.Controls.Add(this.passportNumTexbox);
            this.Controls.Add(this.passportSeriesTextBox);
            this.Controls.Add(this.passportNumLabel);
            this.Controls.Add(this.passportSeriesLabel);
            this.Controls.Add(this.passportLabel);
            this.Controls.Add(this.driverLicenctTextBox);
            this.Controls.Add(this.driverLicenceLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование данных курьера";
            this.Load += new System.EventHandler(this.DriverPropertiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label driverLicenceLabel;
        private System.Windows.Forms.TextBox driverLicenctTextBox;
        private System.Windows.Forms.Label passportLabel;
        private System.Windows.Forms.Label passportSeriesLabel;
        private System.Windows.Forms.Label passportNumLabel;
        private System.Windows.Forms.TextBox passportSeriesTextBox;
        private System.Windows.Forms.TextBox passportNumTexbox;
        private System.Windows.Forms.Label passportGivenByLabel;
        private System.Windows.Forms.TextBox passportGivenByTextBox;
        private System.Windows.Forms.Label passportGivenDateLabel;
        private System.Windows.Forms.DateTimePicker passportGivenDateTimePicker;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label passportGivenDivisionLabel;
        private System.Windows.Forms.TextBox passportGivenDivisionTextBox;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Button declineButton;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.RichTextBox notesRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}