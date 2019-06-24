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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        practiceEntities practice = new practiceEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = practice.players.ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            player p = new player();
            p.name = textBox1.Text;
            p.surname = textBox2.Text;
            p.age = Convert.ToByte(textBox3.Text);
            practice.players.Add(p);
            practice.SaveChanges();
            MessageBox.Show("Successfully inserted");
            dataGridView1.DataSource = practice.players.ToList();

        }
    }
}
