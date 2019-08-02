namespace StudentBD
{
    partial class Form1
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
            this.DataBase = new System.Windows.Forms.DataGridView();
            this.vedomostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bDDataSet = new StudentBD.BDDataSet();
            this.vedomostTableAdapter = new StudentBD.BDDataSetTableAdapters.VedomostTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vedomostBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBase
            // 
            this.DataBase.AllowUserToAddRows = false;
            this.DataBase.AllowUserToDeleteRows = false;
            this.DataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBase.Location = new System.Drawing.Point(12, 47);
            this.DataBase.Name = "DataBase";
            this.DataBase.ReadOnly = true;
            this.DataBase.RowHeadersWidth = 35;
            this.DataBase.RowTemplate.ReadOnly = true;
            this.DataBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataBase.Size = new System.Drawing.Size(571, 553);
            this.DataBase.TabIndex = 0;
            this.DataBase.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataBase_RowHeaderMouseClick);
            // 
            // vedomostBindingSource
            // 
            this.vedomostBindingSource.DataMember = "Vedomost";
            this.vedomostBindingSource.DataSource = this.bDDataSet;
            // 
            // bDDataSet
            // 
            this.bDDataSet.DataSetName = "BDDataSet";
            this.bDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vedomostTableAdapter
            // 
            this.vedomostTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "студенты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "преподаватели";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(275, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "кафедра";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(356, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "дисциплина";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(437, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "ведомость";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(611, 509);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "insert";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(692, 509);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "update";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(652, 539);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "delete";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(652, 576);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "PDF";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(673, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(673, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(589, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(673, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Visible = false;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(589, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(673, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(115, 20);
            this.textBox4.TabIndex = 17;
            this.textBox4.Visible = false;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(589, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(673, 118);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(115, 20);
            this.textBox5.TabIndex = 19;
            this.textBox5.Visible = false;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(589, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(673, 144);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(115, 20);
            this.textBox6.TabIndex = 21;
            this.textBox6.Visible = false;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(589, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(673, 170);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 20);
            this.textBox7.TabIndex = 23;
            this.textBox7.Visible = false;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(589, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label7.Visible = false;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(673, 196);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(115, 20);
            this.textBox8.TabIndex = 25;
            this.textBox8.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(592, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label8.Visible = false;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(673, 222);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(115, 20);
            this.textBox9.TabIndex = 27;
            this.textBox9.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(592, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "ID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label9.Visible = false;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(673, 248);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(115, 20);
            this.textBox10.TabIndex = 29;
            this.textBox10.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(592, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label10.Visible = false;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(673, 274);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(115, 20);
            this.textBox11.TabIndex = 31;
            this.textBox11.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(592, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "ID";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label11.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(589, 313);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 82);
            this.listBox1.TabIndex = 32;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(590, 499);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 4);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(589, 566);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 4);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(589, 413);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(199, 82);
            this.listBox2.TabIndex = 35;
            this.listBox2.Visible = false;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(589, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "ID";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(590, 398);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(589, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(199, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "ID";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.HorizontalScrollbar = true;
            this.listBox3.Location = new System.Drawing.Point(589, 212);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(200, 82);
            this.listBox3.TabIndex = 38;
            this.listBox3.Visible = false;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(589, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(199, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "ID";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Visible = false;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.HorizontalScrollbar = true;
            this.listBox4.Location = new System.Drawing.Point(589, 111);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(200, 82);
            this.listBox4.TabIndex = 40;
            this.listBox4.Visible = false;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Location = new System.Drawing.Point(589, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 4);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(589, 62);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 42;
            this.dateTimePicker.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataBase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vedomostBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataBase;
        private BDDataSet bDDataSet;
        private System.Windows.Forms.BindingSource vedomostBindingSource;
        private BDDataSetTableAdapters.VedomostTableAdapter vedomostTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

