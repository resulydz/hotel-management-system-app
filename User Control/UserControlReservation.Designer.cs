namespace HotelManagementSystem.User_Control
{
    partial class UserControlReservation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlReservation = new System.Windows.Forms.TabControl();
            this.tabPageAddReservation = new System.Windows.Forms.TabPage();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxNo = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSearchReservation = new System.Windows.Forms.TabPage();
            this.dataGridViewReservation = new System.Windows.Forms.DataGridView();
            this.textBoxSearchClientID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageUpdateAndCancelReservation = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerOut1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerIn1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxNo1 = new System.Windows.Forms.ComboBox();
            this.comboBoxType1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxClientID1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControlReservation.SuspendLayout();
            this.tabPageAddReservation.SuspendLayout();
            this.tabPageSearchReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservation)).BeginInit();
            this.tabPageUpdateAndCancelReservation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlReservation
            // 
            this.tabControlReservation.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlReservation.Controls.Add(this.tabPageAddReservation);
            this.tabControlReservation.Controls.Add(this.tabPageSearchReservation);
            this.tabControlReservation.Controls.Add(this.tabPageUpdateAndCancelReservation);
            this.tabControlReservation.Location = new System.Drawing.Point(38, 20);
            this.tabControlReservation.Name = "tabControlReservation";
            this.tabControlReservation.SelectedIndex = 0;
            this.tabControlReservation.Size = new System.Drawing.Size(937, 422);
            this.tabControlReservation.TabIndex = 0;
            // 
            // tabPageAddReservation
            // 
            this.tabPageAddReservation.Controls.Add(this.dateTimePickerOut);
            this.tabPageAddReservation.Controls.Add(this.label6);
            this.tabPageAddReservation.Controls.Add(this.dateTimePickerIn);
            this.tabPageAddReservation.Controls.Add(this.label5);
            this.tabPageAddReservation.Controls.Add(this.comboBoxNo);
            this.tabPageAddReservation.Controls.Add(this.comboBoxType);
            this.tabPageAddReservation.Controls.Add(this.label4);
            this.tabPageAddReservation.Controls.Add(this.textBoxClientID);
            this.tabPageAddReservation.Controls.Add(this.label3);
            this.tabPageAddReservation.Controls.Add(this.label2);
            this.tabPageAddReservation.Controls.Add(this.buttonAdd);
            this.tabPageAddReservation.Controls.Add(this.label1);
            this.tabPageAddReservation.Location = new System.Drawing.Point(4, 4);
            this.tabPageAddReservation.Name = "tabPageAddReservation";
            this.tabPageAddReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddReservation.Size = new System.Drawing.Size(929, 392);
            this.tabPageAddReservation.TabIndex = 0;
            this.tabPageAddReservation.Text = "Rezervasyon Ekle";
            this.tabPageAddReservation.UseVisualStyleBackColor = true;
            this.tabPageAddReservation.Leave += new System.EventHandler(this.tabPageAddReservation_Leave);
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.Location = new System.Drawing.Point(520, 227);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerOut.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(517, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Çıkış:";
            // 
            // dateTimePickerIn
            // 
            this.dateTimePickerIn.Location = new System.Drawing.Point(185, 227);
            this.dateTimePickerIn.Name = "dateTimePickerIn";
            this.dateTimePickerIn.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerIn.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(182, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Başlangıç:";
            // 
            // comboBoxNo
            // 
            this.comboBoxNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNo.FormattingEnabled = true;
            this.comboBoxNo.Location = new System.Drawing.Point(520, 98);
            this.comboBoxNo.Name = "comboBoxNo";
            this.comboBoxNo.Size = new System.Drawing.Size(231, 25);
            this.comboBoxNo.TabIndex = 2;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Tek",
            "Çift",
            "Aile",
            "Suit"});
            this.comboBoxType.Location = new System.Drawing.Point(185, 98);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(231, 25);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Müşteri ID:";
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxClientID.Location = new System.Drawing.Point(185, 162);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(231, 23);
            this.textBoxClientID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(517, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Oda No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Oda Tipi:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(185, 274);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(97, 37);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Ekle";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rezervasyon Ekle:";
            // 
            // tabPageSearchReservation
            // 
            this.tabPageSearchReservation.Controls.Add(this.dataGridViewReservation);
            this.tabPageSearchReservation.Controls.Add(this.textBoxSearchClientID);
            this.tabPageSearchReservation.Controls.Add(this.label7);
            this.tabPageSearchReservation.Controls.Add(this.label8);
            this.tabPageSearchReservation.Location = new System.Drawing.Point(4, 4);
            this.tabPageSearchReservation.Name = "tabPageSearchReservation";
            this.tabPageSearchReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearchReservation.Size = new System.Drawing.Size(929, 392);
            this.tabPageSearchReservation.TabIndex = 1;
            this.tabPageSearchReservation.Text = "Rezervasyon Ara";
            this.tabPageSearchReservation.UseVisualStyleBackColor = true;
            this.tabPageSearchReservation.Enter += new System.EventHandler(this.tabPageSearchReservation_Enter);
            this.tabPageSearchReservation.Leave += new System.EventHandler(this.tabPageSearchReservation_Leave);
            // 
            // dataGridViewReservation
            // 
            this.dataGridViewReservation.AllowUserToAddRows = false;
            this.dataGridViewReservation.AllowUserToDeleteRows = false;
            this.dataGridViewReservation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewReservation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReservation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservation.Location = new System.Drawing.Point(40, 117);
            this.dataGridViewReservation.Name = "dataGridViewReservation";
            this.dataGridViewReservation.ReadOnly = true;
            this.dataGridViewReservation.Size = new System.Drawing.Size(845, 251);
            this.dataGridViewReservation.TabIndex = 0;
            this.dataGridViewReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReservation_CellClick);
            // 
            // textBoxSearchClientID
            // 
            this.textBoxSearchClientID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearchClientID.Location = new System.Drawing.Point(205, 63);
            this.textBoxSearchClientID.Name = "textBoxSearchClientID";
            this.textBoxSearchClientID.Size = new System.Drawing.Size(231, 23);
            this.textBoxSearchClientID.TabIndex = 1;
            this.textBoxSearchClientID.TextChanged += new System.EventHandler(this.textBoxSearchClientID_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(202, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Müşteri ID:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Rezervasyon Ara:";
            // 
            // tabPageUpdateAndCancelReservation
            // 
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.buttonCancel);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.dateTimePickerOut1);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label9);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.dateTimePickerIn1);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label10);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.comboBoxNo1);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.comboBoxType1);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label11);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.textBoxClientID1);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label12);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label13);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.buttonUpdate);
            this.tabPageUpdateAndCancelReservation.Controls.Add(this.label14);
            this.tabPageUpdateAndCancelReservation.Location = new System.Drawing.Point(4, 4);
            this.tabPageUpdateAndCancelReservation.Name = "tabPageUpdateAndCancelReservation";
            this.tabPageUpdateAndCancelReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateAndCancelReservation.Size = new System.Drawing.Size(929, 392);
            this.tabPageUpdateAndCancelReservation.TabIndex = 2;
            this.tabPageUpdateAndCancelReservation.Text = "Rezervasyon Güncelleme ve İptal Etme";
            this.tabPageUpdateAndCancelReservation.UseVisualStyleBackColor = true;
            this.tabPageUpdateAndCancelReservation.Leave += new System.EventHandler(this.tabPageUpdateAndCancelReservation_Leave);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(303, 274);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 37);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePickerOut1
            // 
            this.dateTimePickerOut1.Location = new System.Drawing.Point(520, 227);
            this.dateTimePickerOut1.Name = "dateTimePickerOut1";
            this.dateTimePickerOut1.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerOut1.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(517, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Çıkış:";
            // 
            // dateTimePickerIn1
            // 
            this.dateTimePickerIn1.Location = new System.Drawing.Point(185, 227);
            this.dateTimePickerIn1.Name = "dateTimePickerIn1";
            this.dateTimePickerIn1.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerIn1.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(182, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Başlangıç:";
            // 
            // comboBoxNo1
            // 
            this.comboBoxNo1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxNo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNo1.FormattingEnabled = true;
            this.comboBoxNo1.Location = new System.Drawing.Point(520, 98);
            this.comboBoxNo1.Name = "comboBoxNo1";
            this.comboBoxNo1.Size = new System.Drawing.Size(231, 25);
            this.comboBoxNo1.TabIndex = 2;
            // 
            // comboBoxType1
            // 
            this.comboBoxType1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxType1.FormattingEnabled = true;
            this.comboBoxType1.Items.AddRange(new object[] {
            "Tek",
            "Çift",
            "Aile",
            "Suit"});
            this.comboBoxType1.Location = new System.Drawing.Point(185, 98);
            this.comboBoxType1.Name = "comboBoxType1";
            this.comboBoxType1.Size = new System.Drawing.Size(231, 25);
            this.comboBoxType1.TabIndex = 1;
            this.comboBoxType1.SelectedIndexChanged += new System.EventHandler(this.comboBoxType1_SelectedIndexChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(182, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Müşteri ID:";
            // 
            // textBoxClientID1
            // 
            this.textBoxClientID1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxClientID1.Location = new System.Drawing.Point(185, 162);
            this.textBoxClientID1.Name = "textBoxClientID1";
            this.textBoxClientID1.Size = new System.Drawing.Size(231, 23);
            this.textBoxClientID1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(517, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Oda No:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(182, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Oda Tipi:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(185, 274);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(97, 37);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Güncelle";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(263, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "Rezervasyon Güncelleme ve İptal Etme:";
            // 
            // UserControlReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlReservation);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlReservation";
            this.Size = new System.Drawing.Size(1016, 472);
            this.Load += new System.EventHandler(this.UserControlReservation_Load);
            this.tabControlReservation.ResumeLayout(false);
            this.tabPageAddReservation.ResumeLayout(false);
            this.tabPageAddReservation.PerformLayout();
            this.tabPageSearchReservation.ResumeLayout(false);
            this.tabPageSearchReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservation)).EndInit();
            this.tabPageUpdateAndCancelReservation.ResumeLayout(false);
            this.tabPageUpdateAndCancelReservation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlReservation;
        private System.Windows.Forms.TabPage tabPageAddReservation;
        private System.Windows.Forms.TabPage tabPageSearchReservation;
        private System.Windows.Forms.TabPage tabPageUpdateAndCancelReservation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewReservation;
        private System.Windows.Forms.TextBox textBoxSearchClientID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxNo1;
        private System.Windows.Forms.ComboBox comboBoxType1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxClientID1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonCancel;
    }
}
