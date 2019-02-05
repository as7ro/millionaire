using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizByRauf
{
    public partial class Form1 : Form
        
    {
        milionaireEntities1 db = new milionaireEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                admin admin = new admin();
                admin.Show();
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter a valid value!");
            }
            else
            {
                
                User user = new User();
                user.Name = textBox1.Text;
                user.Surname = textBox2.Text;
                db.Users.Add(user);
                db.SaveChanges();
                Form2 Question1 = new Form2();
                Question1.ShowDialog();
                textBox1.Text = "";
                textBox2.Text = "";
                //this.Hide();

            }
            




            //Form2 Question1 = new Form2();
            //Question1.Show();
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
