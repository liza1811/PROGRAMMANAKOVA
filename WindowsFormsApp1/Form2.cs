using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
       
        private SQLiteConnection SQLiteConn;
        public Form2()
        { 

            InitializeComponent();

        }

       
        private void OpenDBFile()
        {
           /* string baseName = @"C:\\Users\\Елизавета\\Desktop\\Учеба\\шарапов\\WindowsFormsApp1\\м.db";
            SQLiteConn = new SQLiteConnection();

            SQLiteConn.ConnectionString = "Data Source = " + baseName;
            string comm = $"insert into  music (Executor, Name, Year, Genre, Put) values ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}'";

            SQLiteConn.Open();
            SQLiteCommand command = new SQLiteCommand(comm, SQLiteConn);
           command.ExecuteReader();*/
            string baseName = @"C:\\Users\\Елизавета\\Desktop\\Учеба\\шарапов\\WindowsFormsApp1\\м.db";
            string comm = $"insert into  music (Executor, Name, Year, Genre, Put) values ('{textBox4.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox5.Text}', '{textBox1.Text}')";

            SQLiteConn = new SQLiteConnection();

            SQLiteConn.ConnectionString = "Data Source = " + baseName;
          
           
            SQLiteConn.Open();
            SQLiteCommand command = SQLiteConn.CreateCommand();

            command.CommandText = comm;
            command.ExecuteNonQuery();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string put;
          
            
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                put = file.FileName;
                textBox1.Text = put.Replace(@"\" , @"\\");
           }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                OpenDBFile();
            else
                MessageBox.Show("Не все поля заполнены");
        }
    }
}
