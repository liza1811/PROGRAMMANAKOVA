using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "админ")
            {
                Form2 f = new Form2();
                f.Show();//тут ты прописываешь , какая форм должна открыться 
            
                
            }
            else
            {
                Form1 f = new Form1();
                f.Show();
             
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
