using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection SQLiteConn;
        SoundPlayer player;


        public Form1()
        {
            InitializeComponent();
          
            OpenDBFile();// не забудь здесть вставить все , что тебе нужно делать сразупосле запуска
          
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {


        }
        private void OpenDBFile()
        {
            string baseName = @"C:\\Users\\Елизавета\\Desktop\\Учеба\\шарапов\\WindowsFormsApp1\\м.db";
            SQLiteConn = new SQLiteConnection();

            SQLiteConn.ConnectionString = "Data Source = " + baseName;
            SQLiteCommand command = new SQLiteCommand("select distinct Genre from music  ", SQLiteConn);//собственно это выборка по столбцам (тут типо жанр и тд) ,distinct можно не использовать, это уникальные столбцы
            SQLiteCommand comman = new SQLiteCommand("select distinct Year from music  ", SQLiteConn);
            SQLiteCommand comma = new SQLiteCommand("select distinct Executor from music  ", SQLiteConn);
            SQLiteConn.Open();
            SQLiteDataReader reade = command.ExecuteReader();
            SQLiteDataReader reader = reade;
            SQLiteDataReader readere = comman.ExecuteReader();
            SQLiteDataReader read = readere;
            SQLiteDataReader readerer = comma.ExecuteReader();
            SQLiteDataReader rea = readerer;
            while (read.Read())
            {
                comboBox2.Items.Add((string)read["Year"]);// можешь вообще скопировать и просто вместо комбокса написать лабл.текст, только наверное нужны будут индексы
            }
            while (rea.Read())
            {
                comboBox3.Items.Add((string)rea["Executor"]);
            }
            while (reader.Read())
            {
                comboBox1.Items.Add((string)reader["Genre"]);
            }


        }
        /*private void f()
        {
            string x;
            SQLiteCommand comma = new SQLiteCommand($"update music set[Put] = '{x}'", SQLiteConn);
            SQLiteConn.Open();
            SQLiteDataReader readerer = comma.ExecuteReader();
            SQLiteDataReader rea = readerer;
            while (rea.Read())
            {
                string a = Application.StartupPath;
                string d = a.Replace(@"WindowsFormsApp1\WindowsFormsApp1\bin\Debug", " ");
                x = d + @"music\\" + rea["Put"];
            }

        }*/
        private void LoadImage()
        {
            if (SQLiteConn.State != ConnectionState.Open)
                SQLiteConn.Open();
            SQLiteCommand cmd = SQLiteConn.CreateCommand();
            cmd.CommandText = $"SELECT picture FROM music where Name  = '{listBox1.Text}'"; 

            SQLiteDataReader reader = cmd.ExecuteReader();
            Image img = null;
            while (reader.Read())
            {
                byte[] byteImg = (byte[])reader["picture"];
                using (MemoryStream ms = new MemoryStream(byteImg))
                {
                    img = Image.FromStream(ms);
                }
            }
           
          
        }
        private void playlist ()
        {
            string sq = $"SELECT Name FROM music where (play = '+' )";
            SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
            SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

            SQLiteDataReader reader = sQLiteDataReader;

            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
           
        
            {
                if (SQLiteConn.State != ConnectionState.Open)
                    SQLiteConn.Open();
                string year;
                string g;
                string isp;
                string sq;
                year = comboBox2.Text;
                g = comboBox1.Text;
                isp = comboBox3.Text;

                if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null && comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Ничего не выбрано");
                }
                else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem == null)
                {
                    sq = $"SELECT Name FROM music where  Genre = '{g}' AND Year = '{year}'"; // ну тут логинчо, типа где значения в столбцах совпадают с нужным мне , то и выводится, я дмуаю это можно при сверение результатов использовать , просто где цикл (reader[0].) ставить нужный тебе индекс
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();
                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem == null && comboBox3.SelectedItem != null)
                {
                    sq = $"SELECT Name FROM music where Genre = '{g}' AND Executor = '{isp}'";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();
                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                {
                    sq = $"SELECT Name FROM music where Year = '{year}' AND Executor = '{isp}'";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem == null && comboBox3.SelectedItem == null)
                {
                    sq = $"SELECT Name FROM music where Genre = '{g}'";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem != null && comboBox3.SelectedItem == null)
                {
                    sq = $"SELECT Name FROM music where Year = '{year}'";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null && comboBox3.SelectedItem != null)
                {
                    sq = $"SELECT Name FROM music where Executor = '{isp}'";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
                else
                {
                    sq = $"SELECT Name FROM music where ((Year = '{year}' AND Executor = '{isp}' AND Genre = '{g}' AND Executor = '{isp}') or ( Executor = '{isp}' AND Genre = '{g}' AND Executor = '{isp}') or (Year = '{year}'  AND Genre = '{g}' AND Executor = '{isp}') or (Year = '{year}' AND Executor = '{isp}' AND Genre = '{g}' ))";
                    SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
                    SQLiteDataReader sQLiteDataReader = command.ExecuteReader();

                    SQLiteDataReader reader = sQLiteDataReader;

                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                v();
                string name = $"select Put from music where Name = '{listBox1.Text}'";
                SQLiteCommand command = new SQLiteCommand(name, SQLiteConn);
                SQLiteDataReader sQLiteDataReader = command.ExecuteReader();
                SQLiteDataReader reader = sQLiteDataReader;
                while (reader.Read())
                {
                    player = new SoundPlayer($@"{reader[0]}");
                    player.Play();
                }
            }
            else
            {
                MessageBox.Show("Выберите песню для воспроизведения");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                player.Stop();
            }
            else
            {
                MessageBox.Show("Песня не выбрана");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {

                SQLiteCommand command = SQLiteConn.CreateCommand();
                string name = $"update music set[play] = '+' where Name = '{listBox1.Text}'";// а вот и команда замены, в скобках set пишешь нужный столбец = 'что туда записать' 
                command.CommandText = name;
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Выберите песню для добавления в плейлист");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            playlist();
        }
        private void v ()
        {
            
           string  sq = $"SELECT picture FROM music where Name  = '{listBox1.Text}'";
            SQLiteCommand command = new SQLiteCommand(sq, SQLiteConn);
            SQLiteDataReader sQLiteDataReader = command.ExecuteReader();
            SQLiteDataReader reader = sQLiteDataReader;

            
            while (reader.Read())
            {
              string f = reader[0].ToString() ;
                if (f != "")
                {
                    LoadImage();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                SQLiteCommand command = SQLiteConn.CreateCommand();
            string name = $"update music set[play] = null where Name = '{listBox1.Text}'";
            command.CommandText = name;
            command.ExecuteNonQuery();
            playlist();
        }
             else
            {
                MessageBox.Show("Выберите песню для удаления из плейлиста");
            }
        }
      
    }
    }


