using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using IronPdf;

namespace StudentBD
{
    public partial class Form1 : Form
    {
        short currentTable = 0;
        bool exam = false;

        string contectionString = @"Data Source=KOSTYA\SQLEXPRESS;Initial Catalog=BD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string commandString, str, word, tmp1, tmp2;

        bool edit = false;

        int[] tmp = new int[5];
        int ID;

        public SemaphoreSlim sem = new SemaphoreSlim(0,1);

        SqlConnection sqlConnection;
        SqlCommand command, com;
        SqlDataReader sqlReader, sqlR;

        public Form1()
        {
            InitializeComponent();
        }

        private void FillListBox(ListBox LB, string sqlString)
        {
            sqlReader = null;

            command = new SqlCommand(sqlString, sqlConnection);

            try
            {
                sqlReader = command.ExecuteReader();

                LB.Items.Clear();

                while (sqlReader.Read())
                {
                    LB.Items.Add(Convert.ToString(sqlReader[0]) + " | " +  Convert.ToString(sqlReader[1]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(contectionString);

            await sqlConnection.OpenAsync();
        }

        private async void StudentShow()
        {
            currentTable = 1;
            
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            commandString = "Select * From Student Inner Join Kafedra ON Student.KafedraID = Kafedra.ID";

            sqlReader = null;

            command = new SqlCommand(commandString, sqlConnection);

            DataBase.Columns.Clear();

            DataBase.Columns.Add("Student.ID", "Id");
            DataBase.Columns.Add("Nazvanie", "кафедра");
            DataBase.Columns.Add("Familia", "фамилия");
            DataBase.Columns.Add("Imia", "имя");
            DataBase.Columns.Add("Otchestvo", "отчество");
            DataBase.Columns.Add("GodRojdenia", "год рождения");
            DataBase.Columns.Add("Pol", "пол");
            DataBase.Columns.Add("Adres", "фдрес");
            DataBase.Columns.Add("Gorod", "город");
            DataBase.Columns.Add("StudentTelefon", "телефон");

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    DataBase.Rows.Add(
                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["Nazvanie"]),
                        Convert.ToString(sqlReader["Familia"]),
                        Convert.ToString(sqlReader["Imia"]),
                        Convert.ToString(sqlReader["Otchestvo"]),
                        Convert.ToString(sqlReader["GodRojdenia"]),
                        Convert.ToString(sqlReader["Pol"]),
                        Convert.ToString(sqlReader["Adres"]),
                        Convert.ToString(sqlReader["Gorod"]),
                        Convert.ToString(sqlReader["Telefon"]));
                }

                label1.Visible = true;
                label2.Visible = true; label2.Text = "Фамилия";
                label3.Visible = true; label3.Text = "Имя";
                label4.Visible = true; label4.Text = "Отчество";
                label5.Visible = true; label5.Text = "год рождения";
                label6.Visible = true; label6.Text = "Адрес";
                label7.Visible = true; label7.Text = "Город";
                label8.Visible = true; label8.Text = "Телефон";
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = true; label12.Text = "Пол";
                label13.Visible = true; label13.Text = "Кафедра";
                label14.Visible = false;
                label15.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;

                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox3.Visible = false;
                listBox4.Visible = false;

                dateTimePicker.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            if (listBox1.Visible == true)
            {
                listBox1.Items.Clear();

                listBox1.Items.Add("М");
                listBox1.Items.Add("Ж");
            }
            if (listBox2.Visible == true) FillListBox(listBox2, "Select ID,  Nazvanie From Kafedra");
        }
        private async void PrepodavatelShow()
        {
            currentTable = 2;

            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            commandString = "Select * From Prepodavatel Inner Join Kafedra ON Prepodavatel.KafedraID = Kafedra.ID";

            sqlReader = null;

            command = new SqlCommand(commandString, sqlConnection);

            DataBase.Columns.Clear();

            DataBase.Columns.Add("Prepodavatel.ID", "Id");
            DataBase.Columns.Add("Nazvanie", "кафедра");
            DataBase.Columns.Add("Familia", "фамилия");
            DataBase.Columns.Add("Imia", "Имя");
            DataBase.Columns.Add("Otchestvo", "Отчество");
            DataBase.Columns.Add("GodRojdenia", "год рождения");
            DataBase.Columns.Add("GodPostuplenia", "год поступления");
            DataBase.Columns.Add("Staj", "стаж");
            DataBase.Columns.Add("Doljnost", "должность");
            DataBase.Columns.Add("Pol", "пол");
            DataBase.Columns.Add("Adres", "адрес");
            DataBase.Columns.Add("Gorod", "город");
            DataBase.Columns.Add("Prepodavatel.Telefon", "телефон");

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    DataBase.Rows.Add(
                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["Nazvanie"]),
                        Convert.ToString(sqlReader["Familia"]),
                        Convert.ToString(sqlReader["Imia"]),
                        Convert.ToString(sqlReader["Otchestvo"]),
                        Convert.ToString(sqlReader["GodRojdenia"]),
                        Convert.ToString(sqlReader["GodPostuplenia"]),
                        Convert.ToString(sqlReader["Staj"]),
                        Convert.ToString(sqlReader["Doljnost"]),
                        Convert.ToString(sqlReader["Pol"]),
                        Convert.ToString(sqlReader["Adres"]),
                        Convert.ToString(sqlReader["Gorod"]),
                        Convert.ToString(sqlReader["Telefon"]));
                }

                label1.Visible = true;
                label2.Visible = true; label2.Text = "Фамилия";
                label3.Visible = true; label3.Text = "Имя";
                label4.Visible = true; label4.Text = "Отчество";
                label5.Visible = true; label5.Text = "год рождения";
                label6.Visible = true; label6.Text = "год поступления";
                label7.Visible = true; label7.Text = "стаж";
                label8.Visible = true; label8.Text = "должность";
                label9.Visible = true; label9.Text = "адрес";
                label10.Visible = true; label10.Text = "город";
                label11.Visible = true; label11.Text = "Телефон";
                label12.Visible = true; label12.Text = "Пол";
                label13.Visible = true; label13.Text = "Кафедра";
                label14.Visible = false;
                label15.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;

                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox3.Visible = false;
                listBox4.Visible = false;

                dateTimePicker.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            if (listBox1.Visible == true)
            {
                listBox1.Items.Clear();

                listBox1.Items.Add("М");
                listBox1.Items.Add("Ж");
            }
            if (listBox2.Visible == true) FillListBox(listBox2, "Select ID,  Nazvanie From Kafedra");
        }
        private async void KafedraShow()
        {
            currentTable = 3;

            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            commandString = "Select Kafedra.ID, Familia + ' ' + Imia + ' ' + Otchestvo as FIO,Nazvanie,Fakultet,Nkomnati,Nkorpusa,Kafedra.Telefon,KolvoPrepodavatelei From Kafedra Inner Join Prepodavatel ON Kafedra.ZaveduuhiID = Prepodavatel.ID";

            sqlReader = null;

            command = new SqlCommand(commandString, sqlConnection);

            DataBase.Columns.Clear();

            DataBase.Columns.Add("Kafedra.ID", "Id");
            DataBase.Columns.Add("FIO", "заведующий");
            DataBase.Columns.Add("Nazvanie", "кафедра");
            DataBase.Columns.Add("Fakultet", "факультет");
            DataBase.Columns.Add("Nkomnati", "№ комнаты");
            DataBase.Columns.Add("Nkorpusa", "№ корпуса");
            DataBase.Columns.Add("Kafedra.Telefon", "телефон");
            DataBase.Columns.Add("KolvoPrepodavatelei", "Кол-во преподавателей");

            DataBase.Columns[1].Width = 175;

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    DataBase.Rows.Add(
                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["FIO"]),
                        Convert.ToString(sqlReader["Nazvanie"]),
                        Convert.ToString(sqlReader["Fakultet"]),
                        Convert.ToString(sqlReader["Nkomnati"]),
                        Convert.ToString(sqlReader["Nkorpusa"]),
                        Convert.ToString(sqlReader["Telefon"]),
                        Convert.ToString(sqlReader["KolvoPrepodavatelei"]));
                }

                label1.Visible = true;
                label2.Visible = true; label2.Text = "кафедра";
                label3.Visible = true; label3.Text = "факультет";
                label4.Visible = true; label4.Text = "№ комнаты";
                label5.Visible = true; label5.Text = "№ корпуса";
                label6.Visible = true; label6.Text = "телефон";
                label7.Visible = true; label7.Text = "кол-во преподавателей";
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = true; label14.Text = "заведующий";
                label15.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;

                listBox1.Visible = false;
                listBox2.Visible = false;
                listBox3.Visible = true;
                listBox4.Visible = false;

                dateTimePicker.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            if (listBox3.Visible == true) FillListBox(listBox3, "Select ID, Familia + ' ' + Imia + ' ' + Otchestvo From Prepodavatel");
        }
        private async void DisciplinaShow()
        {
            currentTable = 4;

            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            commandString = "Select Disciplina.ID, Kafedra.Nazvanie as kn, Disciplina.Nazvanie as dn, KolvoChasov, Kontrol From Disciplina Inner Join Kafedra ON Disciplina.KafedraID = Kafedra.ID";

            sqlReader = null;

            command = new SqlCommand(commandString, sqlConnection);

            DataBase.Columns.Clear();

            DataBase.Columns.Add("Disciplina.ID", "Id");
            DataBase.Columns.Add("kn", "кафедра");
            DataBase.Columns.Add("dn", "дисциплина");
            DataBase.Columns.Add("KolvoChasov", "кол-во часов");
            DataBase.Columns.Add("Kontrol", "контроль");

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    DataBase.Rows.Add(
                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["kn"]),
                        Convert.ToString(sqlReader["dn"]),
                        Convert.ToString(sqlReader["KolvoChasov"]),
                        Convert.ToString(sqlReader["Kontrol"]));
                }

                label1.Visible = true;
                label2.Visible = true; label2.Text = "дисциплина";
                label3.Visible = true; label3.Text = "кол-во часов";
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = true; label14.Text = "кафедра";
                label15.Visible = true; label15.Text = "контроль";

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;

                listBox1.Visible = false;
                listBox2.Visible = false;
                listBox3.Visible = true;
                listBox4.Visible = true;

                dateTimePicker.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            if (listBox3.Visible == true) FillListBox(listBox3, "Select ID,  Nazvanie From Kafedra");
            if (listBox4.Visible == true)
            {
                listBox4.Items.Clear();

                listBox4.Items.Add("зачет");
                listBox4.Items.Add("экзамен");
            }
        }
        private async void VedomostShow()
        {
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            commandString = "Select YMD, Vedomost.ID, " +
                "Student.Familia + ' ' + Student.Imia + ' ' + Student.Otchestvo as s_FIO, " +
                "Nazvanie," +
                "Prepodavatel.Familia + ' ' + Prepodavatel.Imia + ' ' + Prepodavatel.Otchestvo as p_FIO, " +
                "Ocenka " +
                "From Vedomost Inner Join Student ON Vedomost.StudentID = Student.ID " +
                "INNER JOIN Disciplina ON Vedomost.DisciplinaID = Disciplina.ID " +
                "INNER JOIN Prepodavatel ON Vedomost.PrepodavatelID = Prepodavatel.ID";

            sqlReader = null;

            command = new SqlCommand(commandString, sqlConnection);

            DataBase.Columns.Clear();

            DataBase.Columns.Add("ID", "Id");
            DataBase.Columns.Add("s_FIO", "ФИО студента");
            DataBase.Columns.Add("Nazvanie", "дисциплина");
            DataBase.Columns.Add("p_FIO", "ФИО преподавателя");
            DataBase.Columns.Add("Ocenka", "оценка");
            DataBase.Columns.Add("YMD", "дата");

            DataBase.Columns[1].Width = 175;
            DataBase.Columns[3].Width = 175;

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    DateTime date;
                    DateTime.TryParse(sqlReader["YMD"].ToString(), out date);

                    DataBase.Rows.Add(
                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["s_FIO"]),
                        Convert.ToString(sqlReader["Nazvanie"]),
                        Convert.ToString(sqlReader["p_FIO"]),
                        Convert.ToString(sqlReader["Ocenka"]),
                        date.ToString("yyyy-MM-dd"));
                }

                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = true; label12.Text = "преподаватель";
                label13.Visible = true; label13.Text = "оценка";
                label14.Visible = true; label14.Text = "дисциплина";
                label15.Visible = true; label15.Text = "студент";

                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;

                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox3.Visible = true;
                listBox4.Visible = true;

                dateTimePicker.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            if (listBox1.Visible == true) FillListBox(listBox1, "Select ID, Familia + ' ' + Imia + ' ' + Otchestvo From Prepodavatel");
            if (listBox3.Visible == true) FillListBox(listBox3, "Select ID, Nazvanie From Disciplina");
            if (listBox4.Visible == true) FillListBox(listBox4, "Select ID, Familia + ' ' + Imia + ' ' + Otchestvo From Student");
            listBox2.Items.Clear();

            currentTable = 5;
        }

        private void button1_Click(object sender, EventArgs e)      //student
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;

            button9.Enabled = false;

            ClearInput();
            StudentShow();
        }
        private void button2_Click(object sender, EventArgs e)      //prepodavateli
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;

            button9.Enabled = false;

            ClearInput();
            PrepodavatelShow();
        }
        private void button3_Click(object sender, EventArgs e)      //kafedra
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;

            button9.Enabled = false;

            ClearInput();
            KafedraShow();
        }
        private void button4_Click(object sender, EventArgs e)      //disciplina
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;

            button9.Enabled = false;

            ClearInput();
            DisciplinaShow();
        }
        private void button5_Click(object sender, EventArgs e)      //vedomost
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;

            ClearInput();
            VedomostShow();
        }

        private async void button6_Click(object sender, EventArgs e)      //insert
        {
            switch (currentTable)
            {
                case 1:
                    {
                        str = listBox2.Items[listBox2.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Insert INTO Student (KafedraID, Familia, Imia, Otchestvo, GodRojdenia, Pol, Adres, Gorod, Telefon) " +
                                                            "Values (@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9);";

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", listBox1.Items[listBox1.SelectedIndex].ToString());
                        command.Parameters.AddWithValue("@param7", textBox6.Text);
                        command.Parameters.AddWithValue("@param8", textBox7.Text);
                        command.Parameters.AddWithValue("@param9", textBox8.Text);

                        try
                        {
                            command.ExecuteNonQuery();

                            StudentShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 2:
                    {
                        str = listBox2.Items[listBox2.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Insert INTO Prepodavatel(KafedraID, Familia, Imia, Otchestvo, GodRojdenia, GodPostuplenia, Staj, Doljnost, Pol, Adres, Gorod, Telefon) " +
                                                            "Values (@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12);";

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", textBox6.Text);
                        command.Parameters.AddWithValue("@param7", textBox7.Text);
                        command.Parameters.AddWithValue("@param8", textBox8.Text);
                        command.Parameters.AddWithValue("@param9", listBox1.Items[listBox1.SelectedIndex].ToString());
                        command.Parameters.AddWithValue("@param10", textBox6.Text);
                        command.Parameters.AddWithValue("@param11", textBox7.Text);
                        command.Parameters.AddWithValue("@param12", textBox8.Text);


                        try
                        {
                            command.ExecuteNonQuery();

                            PrepodavatelShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 3:
                    {
                        str = listBox3.Items[listBox3.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"INSERT INTO Kafedra (ZaveduuhiID, Nazvanie, Fakultet, Nkomnati, Nkorpusa, Telefon, KolvoPrepodavatelei) " +
                                                            "Values (@param1,@param2,@param3,@param4,@param5,@param6,@param7);";

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", textBox6.Text);
                        command.Parameters.AddWithValue("@param7", textBox7.Text);


                        try
                        {
                            command.ExecuteNonQuery();

                            KafedraShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 4:
                    {
                        str = listBox3.Items[listBox3.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"INSERT INTO Disciplina (KafedraID, Nazvanie, KolvoChasov,Kontrol) " +
                                                            "Values (@param1,@param2,@param3,@param4);";

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", listBox4.Items[listBox4.SelectedIndex].ToString());

                        try
                        {
                            command.ExecuteNonQuery();

                            DisciplinaShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 5:
                    {                       
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"INSERT INTO Vedomost (StudentID, DisciplinaID, PrepodavatelID, Ocenka, YMD) " +
                                                            "Values (@param1,@param2,@param3,@param4,@param5);";

                        str = listBox4.Items[listBox4.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param1", word);

                        str = listBox3.Items[listBox3.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param2", word);

                        str = listBox1.Items[listBox1.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param3", word);
                        command.Parameters.AddWithValue("@param4", listBox2.Items[listBox2.SelectedIndex].ToString());

                        word = dateTimePicker.Value.ToString("yyyy-MM-dd");
                        command.Parameters.AddWithValue("@param5", word);

                        try
                        {
                            command.ExecuteNonQuery();

                            VedomostShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
            }
        }
        private async void button7_Click(object sender, EventArgs e)      //update
        {
            switch (currentTable)
            {
                case 1:
                    {
                        str = listBox2.Items[listBox2.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Update Student Set KafedraID=@param1, Familia=@param2, Imia=@param3, Otchestvo=@param4, GodRojdenia=@param5, Pol=@param6, Adres=@param7, Gorod=@param8, Telefon=@param9 Where ID = " + textBox1.Text;

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", listBox1.Items[listBox1.SelectedIndex].ToString());
                        command.Parameters.AddWithValue("@param7", textBox6.Text);
                        command.Parameters.AddWithValue("@param8", textBox7.Text);
                        command.Parameters.AddWithValue("@param9", textBox8.Text);

                        try
                        {
                            command.ExecuteNonQuery();

                            StudentShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 2:
                    {
                        str = listBox2.Items[listBox2.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Update Prepodavatel SET KafedraID=@param1, Familia=@param2, Imia=@param3, Otchestvo=@param4, GodRojdenia=@param5, GodPostuplenia=@param6, Staj=@param7, Doljnost=@param8, Pol=@param9, Adres=@param10, Gorod=@param11, Telefon=@param12 Where ID = " + textBox1.Text;

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", textBox6.Text);
                        command.Parameters.AddWithValue("@param7", textBox7.Text);
                        command.Parameters.AddWithValue("@param8", textBox8.Text);
                        command.Parameters.AddWithValue("@param9", listBox1.Items[listBox1.SelectedIndex].ToString());
                        command.Parameters.AddWithValue("@param10", textBox6.Text);
                        command.Parameters.AddWithValue("@param11", textBox7.Text);
                        command.Parameters.AddWithValue("@param12", textBox8.Text);


                        try
                        {
                            command.ExecuteNonQuery();

                            PrepodavatelShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 3:
                    {
                        str = listBox3.Items[listBox3.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"UPDATE Kafedra SET ZaveduuhiID=@param1, Nazvanie=@param2, Fakultet=@param3, Nkomnati=@param4, Nkorpusa=@param5, Telefon=@param6, KolvoPrepodavatelei=@param7 Where ID = " + textBox1.Text;

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", textBox4.Text);
                        command.Parameters.AddWithValue("@param5", textBox5.Text);
                        command.Parameters.AddWithValue("@param6", textBox6.Text);
                        command.Parameters.AddWithValue("@param7", textBox7.Text);


                        try
                        {
                            command.ExecuteNonQuery();

                            KafedraShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 4:
                    {
                        str = listBox2.Items[listBox2.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"UPDATE Disciplina SET KafedraID=@param1, Nazvanie=@param2, KolvoChasov=@param3,Kontrol=@param4 Where ID = " + textBox1.Text;

                        command.Parameters.AddWithValue("@param1", word);
                        command.Parameters.AddWithValue("@param2", textBox2.Text);
                        command.Parameters.AddWithValue("@param3", textBox3.Text);
                        command.Parameters.AddWithValue("@param4", listBox4.Items[listBox4.SelectedIndex].ToString());

                        try
                        {
                            command.ExecuteNonQuery();

                            DisciplinaShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 5:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"UPDATE Vedomost SET StudentID=@param1, DisciplinaID=@param2, PrepodavatelID=@param3, Ocenka=@param4, YMD=@param5 Where ID = " + textBox1.Text;

                        str = listBox4.Items[listBox4.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param1", word);

                        str = listBox3.Items[listBox3.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param2", word);

                        str = listBox1.Items[listBox1.SelectedIndex].ToString();
                        word = str.Substring(0, str.IndexOf('|')).Trim();

                        command.Parameters.AddWithValue("@param3", word);
                        command.Parameters.AddWithValue("@param4", listBox2.Items[listBox2.SelectedIndex].ToString());

                        word = dateTimePicker.Value.ToString("yyyy-MM-dd");
                        command.Parameters.AddWithValue("@param5", word);

                        try
                        {
                            command.ExecuteNonQuery();

                            VedomostShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
            }
        }
        private async void button8_Click(object sender, EventArgs e)      //delete
        {
            switch (currentTable)
            {
                case 1:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Delete FROM Student Where ID = " + textBox1.Text;
                        
                        try
                        {
                            command.ExecuteNonQuery();

                            StudentShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 2:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Delete FROM Prepodavatel Where ID = " + textBox1.Text;

                        try
                        {
                            command.ExecuteNonQuery();

                            PrepodavatelShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 3:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Delete FROM Kafedra Where ID = " + textBox1.Text;

                        try
                        {
                            command.ExecuteNonQuery();

                            KafedraShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 4:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Delete FROM Disciplina Where ID = " + textBox1.Text;

                        try
                        {
                            command.ExecuteNonQuery();

                            DisciplinaShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
                case 5:
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"Delete FROM Vedomost Where ID = " + textBox1.Text;

                        try
                        {
                            command.ExecuteNonQuery();

                            VedomostShow();
                        }
                        catch (SqlException exx)
                        {
                            MessageBox.Show(exx.Message.ToString(), "Error Message");
                        }
                    }
                    break;
            }
        }

        private async void GetPDF()
        {
            HtmlToPdf Renderer = new HtmlToPdf();

            str = listBox3.Items[listBox3.SelectedIndex].ToString();

            commandString = "SELECT Ocenka, COUNT(*) AS count FROM Vedomost WHERE DisciplinaID = " + str.Substring(0, str.IndexOf('|')).Trim() + " GROUP BY Ocenka";

            tmp[0] = 0;
            tmp[1] = 0;
            tmp[2] = 0;
            tmp[3] = 0;

            try
            {
                command = new SqlCommand(commandString, sqlConnection);
                sqlReader = await command.ExecuteReaderAsync();

                if (exam)
                {
                    while (await sqlReader.ReadAsync())
                    {
                        word = sqlReader["Ocenka"].ToString();

                        if (word == "неуд.") tmp[0] = Int16.Parse(sqlReader["count"].ToString());
                        else if (word == "уд.") tmp[1] = Int16.Parse(sqlReader["count"].ToString());
                        else if (word == "хор.") tmp[2] = Int16.Parse(sqlReader["count"].ToString());
                        else if (word == "отл.") tmp[3] = Int16.Parse(sqlReader["count"].ToString());
                    }

                    tmp[4] = tmp[0] + tmp[1] + tmp[2] + tmp[3];

                    if (tmp[4] != 0)
                    {
                        commandString = "<!DOCTYPE html><html> <head> <meta charset='utf-8'> <title></title> <script src='https://www.google.com/jsapi'></script> <script> google.load('visualization', '1', {packages:['corechart']}); google.setOnLoadCallback(drawChart); function drawChart() { var data = google.visualization.arrayToDataTable([ ['s1', 's2'], ['отл', " + Math.Round(tmp[3] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "], ['хор', " + Math.Round(tmp[2] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "], ['уд', " + Math.Round(tmp[1] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "], ['неуд', " + Math.Round(tmp[0] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "] ]); var options = { title: 'Успеваемость по дисциплине ”" + str.Remove(0, str.IndexOf('|') + 1).Trim() + "”', is3D: true, pieResidueSliceLabel: 'неуд' }; var chart = new google.visualization.PieChart(document.getElementById('air')); chart.draw(data, options); } </script> </head> <body> <div id='air' style='width: 1000px; height: 800px;'></div>"; //  </body></html>
                        commandString += "<table border='1' width='100%' cellpadding='5'> <tr> <th>ID</th> <th>ФИО студента</th> <th>Оценка</th> </tr>";

                        sqlReader.Close();
                        command = new SqlCommand("Select Vedomost.ID, Student.Familia + ' ' + Student.Imia + ' ' + Student.Otchestvo as FIO, Ocenka From Vedomost Inner Join Student ON Vedomost.StudentID = Student.ID WHERE DisciplinaID = " + str.Substring(0, str.IndexOf('|')).Trim(), sqlConnection);
                        sqlReader = await command.ExecuteReaderAsync();

                        while (await sqlReader.ReadAsync())
                        {
                            commandString += "<tr><td>"+ sqlReader ["ID"]+ "</td><td>" + sqlReader["FIO"] + "</td><td>" + sqlReader["Ocenka"] + "</td></tr>";
                        }

                        commandString += "</table></body></html>";
                    }
                }
                else
                {
                    while (await sqlReader.ReadAsync())
                    {
                        word = sqlReader["Ocenka"].ToString();

                        if (word == "не зачет") tmp[0] = Int16.Parse(sqlReader["count"].ToString());
                        else if (word == "зачет") tmp[1] = Int16.Parse(sqlReader["count"].ToString());
                    }

                    tmp[4] = tmp[0] + tmp[1];

                    if (tmp[4] != 0)
                    {
                        commandString = "<!DOCTYPE html><html> <head> <meta charset='utf-8'> <title> </title> <script src='https://www.google.com/jsapi'></script> <script> google.load('visualization', '1', {packages:['corechart']}); google.setOnLoadCallback(drawChart); function drawChart() { var data = google.visualization.arrayToDataTable([ ['s1', 's2'], ['зачет', " + Math.Round(tmp[1] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "], ['не зачет', " + Math.Round(tmp[0] * 100f / tmp[4], 2).ToString().Replace(",", ".") + "] ]); var options = { title: 'Успеваемость по дисциплине ”" + str.Remove(0, str.IndexOf('|') + 1).Trim() + "”', is3D: true, pieResidueSliceLabel: 'не зачет' }; var chart = new google.visualization.PieChart(document.getElementById('air')); chart.draw(data, options); } </script> </head> <body> <div id='air' style='width: 1000px; height: 800px;'></div>";
                        commandString += "<table border='1' width='100%' cellpadding='5'> <tr> <th>ID</th> <th>ФИО студента</th> <th>Оценка</th> </tr>";

                        sqlReader.Close();
                        command = new SqlCommand("Select Vedomost.ID, Student.Familia + ' ' + Student.Imia + ' ' + Student.Otchestvo as FIO, Ocenka From Vedomost Inner Join Student ON Vedomost.StudentID = Student.ID WHERE DisciplinaID = " + str.Substring(0, str.IndexOf('|')).Trim(), sqlConnection);
                        sqlReader = await command.ExecuteReaderAsync();

                        while (await sqlReader.ReadAsync())
                        {
                            commandString += "<tr><td>" + sqlReader["ID"] + "</td><td>" + sqlReader["FIO"] + "</td><td>" + sqlReader["Ocenka"] + "</td></tr>";
                        }

                        commandString += "</table></body></html>";
                    }
                }

                if (tmp[4] != 0)
                {
                    Renderer.RenderHtmlAsPdf(commandString).SaveAs("BD.pdf");

                    DialogResult dialogResult = MessageBox.Show("Open?", "PDF is created!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start(@"BD.pdf");
                    }
                }
                else
                {
                    MessageBox.Show("NOPE!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        private void ClearInput()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)      //PDF
        {
            GetPDF();
        }

        private void CheckInput()
        {
            switch (currentTable)
            {
                case 1:
                    {
                        if (listBox1.SelectedIndex >= 0 && listBox2.SelectedIndex >= 0)
                        {
                            button6.Enabled = true;

                            if (textBox1.Text.Length > 0)
                            {
                                button7.Enabled = true;
                            }
                            else
                            {
                                button7.Enabled = false;
                            }
                        }

                        if (textBox1.Text.Length > 0)
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                    }
                        break;
                case 2:
                    {
                        if (listBox1.SelectedIndex >= 0 && listBox2.SelectedIndex >= 0)
                        {
                            button6.Enabled = true;


                            if (textBox1.Text.Length > 0)
                            {
                                button7.Enabled = true;
                            }
                            else
                            {
                                button7.Enabled = false;
                            }
                        }

                        if (textBox1.Text.Length > 0)
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                    }
                    break;
                case 3:
                    {
                        if (listBox3.SelectedIndex >= 0)
                        {
                            button6.Enabled = true;
                            if (textBox1.Text.Length > 0)
                            {
                                button7.Enabled = true;
                                button8.Enabled = true;
                            }
                            else
                            {
                                button7.Enabled = false;
                                button8.Enabled = false;
                            }
                        }

                        if (textBox1.Text.Length > 0)
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                    }
                    break;
                case 4:
                    {
                        if (listBox3.SelectedIndex >= 0 && listBox4.SelectedIndex >= 0)
                        {
                            button6.Enabled = true;
                            if (textBox1.Text.Length > 0)
                            {
                                button7.Enabled = true;
                            }
                            else
                            {
                                button7.Enabled = false;
                            }
                        }

                        if (textBox1.Text.Length > 0)
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                    }
                    break;
                case 5:
                    {
                        if (listBox1.SelectedIndex >= 0 && listBox2.SelectedIndex >= 0 && listBox3.SelectedIndex >= 0 && listBox4.SelectedIndex >= 0)
                        {
                            button6.Enabled = true;

                            if (textBox1.Text.Length > 0)
                            {
                                button7.Enabled = true;
                            }
                            else
                            {
                                button7.Enabled = false;
                            }
                        }

                        if (textBox1.Text.Length > 0)
                        {
                            button8.Enabled = true;
                        }
                        else
                        {
                            button8.Enabled = false;
                        }
                    }
                    break;
            }
        }
        

        //only number
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentTable == 4)
            {
                char c = e.KeyChar;

                if (!Char.IsDigit(c) && c != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentTable == 3)
            {
                char c = e.KeyChar;

                if (!Char.IsDigit(c) && c != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentTable == 1 || currentTable == 2 || currentTable == 3)
            {
                char c = e.KeyChar;

                if (!Char.IsDigit(c) && c != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentTable == 2)
            {
                char c = e.KeyChar;

                if (!Char.IsDigit(c) && c != 8)
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentTable == 2 || currentTable == 3)
            {
                char c = e.KeyChar;

                if (!Char.IsDigit(c) && c != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInput();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private async void DataBase_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Int16.Parse(DataBase[0, DataBase.CurrentRow.Index].Value.ToString());

            switch (currentTable)
            {
                case 1:
                    {
                        commandString = "Select Student.ID as ID, KafedraID, Kafedra.Nazvanie as K_Name, Familia, Imia, Otchestvo, GodRojdenia, Pol, Adres, Gorod, Student.Telefon as Telefon" +
                            " From Student Inner Join Kafedra ON Student.KafedraID = Kafedra.ID WHERE Student.ID = " + ID;
                        sqlReader = null;
                        command = new SqlCommand(commandString, sqlConnection);

                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();

                            textBox1.Text = sqlReader["ID"].ToString();
                            textBox2.Text = sqlReader["Familia"].ToString();
                            textBox3.Text = sqlReader["Imia"].ToString();
                            textBox4.Text = sqlReader["Otchestvo"].ToString();
                            textBox5.Text = sqlReader["GodRojdenia"].ToString();
                            textBox6.Text = sqlReader["Adres"].ToString();
                            textBox7.Text = sqlReader["Gorod"].ToString();
                            textBox8.Text = sqlReader["Telefon"].ToString();

                            listBox1.SelectedIndex = listBox1.FindString(sqlReader["Pol"].ToString());
                            listBox2.SelectedIndex = listBox2.FindString(sqlReader["KafedraID"].ToString() + " | " + sqlReader["K_Name"].ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                        }
                        finally
                        {
                            if (sqlReader != null)
                                sqlReader.Close();
                        }
                    }
                    break;
                case 2:
                    {
                        commandString = "Select Prepodavatel.ID as ID, KafedraID, Kafedra.Nazvanie as K_Name, Familia, Imia, Otchestvo, GodRojdenia, GodPostuplenia, Staj, Doljnost, Pol, Adres, Gorod, Prepodavatel.Telefon as Telefon" +
                            " From Prepodavatel Inner Join Kafedra ON Prepodavatel.KafedraID = Kafedra.ID WHERE Prepodavatel.ID = " + ID;
                        sqlReader = null;
                        command = new SqlCommand(commandString, sqlConnection);

                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();

                            textBox1.Text = sqlReader["ID"].ToString();
                            textBox2.Text = sqlReader["Familia"].ToString();
                            textBox3.Text = sqlReader["Imia"].ToString();
                            textBox4.Text = sqlReader["Otchestvo"].ToString();
                            textBox5.Text = sqlReader["GodRojdenia"].ToString();
                            textBox6.Text = sqlReader["GodPostuplenia"].ToString();
                            textBox7.Text = sqlReader["Staj"].ToString();
                            textBox8.Text = sqlReader["Doljnost"].ToString();
                            textBox9.Text = sqlReader["Adres"].ToString();
                            textBox10.Text = sqlReader["Gorod"].ToString();
                            textBox11.Text = sqlReader["Telefon"].ToString();

                            listBox1.SelectedIndex = listBox1.FindString(sqlReader["Pol"].ToString());
                            listBox2.SelectedIndex = listBox2.FindString(sqlReader["KafedraID"].ToString() + " | " + sqlReader["K_Name"].ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                        }
                        finally
                        {
                            if (sqlReader != null)
                                sqlReader.Close();
                        }
                    }
                    break;
                case 3:
                    {
                        commandString = "Select  Familia + ' ' + Imia + ' ' + Otchestvo as FIO, Kafedra.ID,ZaveduuhiID, Nazvanie, Fakultet, Nkomnati, Nkorpusa, Kafedra.Telefon, KolvoPrepodavatelei" +
                            " From Kafedra Inner Join Prepodavatel ON Prepodavatel.ID = Kafedra.ZaveduuhiID WHERE Kafedra.ID = " + ID;
                        sqlReader = null;
                        command = new SqlCommand(commandString, sqlConnection);

                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();

                            textBox1.Text = sqlReader["ID"].ToString();
                            textBox2.Text = sqlReader["Nazvanie"].ToString();
                            textBox3.Text = sqlReader["Fakultet"].ToString();
                            textBox4.Text = sqlReader["Nkomnati"].ToString();
                            textBox5.Text = sqlReader["Nkorpusa"].ToString();
                            textBox6.Text = sqlReader["Telefon"].ToString();
                            textBox7.Text = sqlReader["KolvoPrepodavatelei"].ToString();

                            listBox3.SelectedIndex = listBox3.FindString(sqlReader["ZaveduuhiID"].ToString() + " | " + sqlReader["FIO"].ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                        }
                        finally
                        {
                            if (sqlReader != null)
                                sqlReader.Close();
                        }
                    }
                    break;
                case 4:
                    {
                        commandString = "Select Disciplina.ID, KafedraID, Kafedra.Nazvanie as KN, Disciplina.Nazvanie as DN, KolvoChasov, Kontrol" +
                            " From Disciplina Inner Join Kafedra ON Disciplina.KafedraID = Kafedra.ID WHERE Disciplina.ID = " + ID;
                        sqlReader = null;
                        command = new SqlCommand(commandString, sqlConnection);

                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();

                            textBox1.Text = sqlReader["ID"].ToString();
                            textBox2.Text = sqlReader["DN"].ToString();
                            textBox3.Text = sqlReader["KolvoChasov"].ToString();

                            listBox3.SelectedIndex = listBox3.FindString(sqlReader["KafedraID"].ToString() + " | " + sqlReader["KN"].ToString());
                            listBox4.SelectedIndex = listBox4.FindString(sqlReader["Kontrol"].ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                        }
                        finally
                        {
                            if (sqlReader != null)
                                sqlReader.Close();
                        }
                    }
                    break;
                case 5:
                    {
                        edit = true;

                        commandString = "Select YMD, Student.Familia + ' ' + Student.Imia + ' ' + Student.Otchestvo as S_FIO, " +
                            "Prepodavatel.Familia + ' ' + Prepodavatel.Imia + ' ' + Prepodavatel.Otchestvo as P_FIO, " +
                            "Vedomost.ID, DisciplinaID, Disciplina.Nazvanie as Disc, StudentID, PrepodavatelID, Ocenka" +
                            " From Vedomost Inner Join Prepodavatel ON Prepodavatel.ID = Vedomost.PrepodavatelID" +
                            " Inner Join Student ON Student.ID = Vedomost.StudentID " +
                            " Inner Join Disciplina ON Disciplina.ID = Vedomost.DisciplinaID WHERE Vedomost.ID = " + ID;

                        command = new SqlCommand(commandString, sqlConnection);

                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();

                            textBox1.Text = sqlReader["ID"].ToString();

                            listBox4.SelectedIndex = listBox4.FindString(sqlReader["StudentID"].ToString() + " | " + sqlReader["S_FIO"].ToString());
                            listBox1.SelectedIndex = listBox1.FindString(sqlReader["PrepodavatelID"].ToString() + " | " + sqlReader["P_FIO"].ToString());

                            tmp1 = sqlReader["DisciplinaID"].ToString() + " | " + sqlReader["Disc"].ToString();
                            tmp2 = sqlReader["Ocenka"].ToString();

                            sqlReader.Close();

                            listBox3.SelectedIndex = listBox3.FindString(tmp1);

                            await sem.WaitAsync();

                            listBox2.SelectedIndex = listBox2.FindString(tmp2);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                        }
                        finally
                        {
                            if (sqlReader != null)
                                sqlReader.Close();
                        }

                        edit = false;
                    }
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlConnection.Close();
        }

        private async void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInput();

            if (currentTable == 5)
            {
                str = listBox3.Items[listBox3.SelectedIndex].ToString();
                word = str.Substring(0, str.IndexOf('|')).Trim();

                com = new SqlCommand("Select Kontrol From Disciplina Where ID = " + word, sqlConnection);

                try
                {
                    sqlR = await com.ExecuteReaderAsync();
                    await sqlR.ReadAsync();

                    if (sqlR[0].ToString() == "зачет")
                    {
                        listBox2.Items.Clear();

                        listBox2.Items.Add("зачет");
                        listBox2.Items.Add("не зачет");

                        exam = false;
                    }
                    else
                    {
                        listBox2.Items.Clear();

                        listBox2.Items.Add("неуд.");
                        listBox2.Items.Add("уд.");
                        listBox2.Items.Add("хор.");
                        listBox2.Items.Add("отл.");

                        exam = true;
                    }

                    button9.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                }
                finally
                {
                    if (sqlR != null)
                        sqlR.Close();
                }
            }

            if (edit) sem.Release();
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInput();
        }
    }
}
