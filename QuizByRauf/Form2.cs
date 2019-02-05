using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizByRauf
{
    public partial class Form2 : Form
    {
        milionaireEntities1 db = new milionaireEntities1();
        public Form2()
        {
            
           InitializeComponent();
           nextQuestions();
           
        }

        int duzCcavab = 0;
        //KOMEKLER
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
        }


        //Form load olanda
        public void Form2_Load(object sender, EventArgs e)
        {
            var newlist = db.Questions.First(x => x.ID == 1);
            groupBox1.Text = "\r\n";
            groupBox1.Text += newlist.Question1;
            button1.Text = newlist.Answer1;
            button2.Text = newlist.Answer2;
            button3.Text = newlist.Answer3;
            button4.Text = newlist.Answer4;
            


        }


        //duz cavab olanda qazanlina mebleg artmagi
        public void changeLabel()
        {
            var labels = new List<Label> { label15,label14, label13, label12, label11, label10, label9, label8, label7, label6, label5, label4, label3, label2, label1 };
            labels[duzCcavab].BackColor = Color.Green;
            duzCcavab++;
            if (duzCcavab > 13)
            {
                MessageBox.Show("OYUN BITDI", "TEBRIKLER", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }


        //her butona click eventi elave elemek
        public void nextQuestions()
        {

            var buttons = new List<Button> { button1, button2, button3, button4 };

            foreach (var item in buttons)
            {
                item.Click += new EventHandler(ClickedButtons);
            }

        }

        int number = 1;
        //Duz cavabi tapmaq
        public void ClickedButtons(object sender, EventArgs e)
        {
       

            
            var buttonAnswer = sender as Button;
            var newlist = db.Questions.First(x => x.ID == number);


            if (buttonAnswer.Text == newlist.QuestionAnswer)
            {



                //MessageBox.Show("Duzgun cavab " + newlist.QuestionAnswer);
                buttonAnswer.BackColor = Color.Green;

                MessageBox.Show("Duz cavab!");

                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                }
                buttonAnswer.BackColor = Color.DeepSkyBlue;
                groupBox1.Text = "";
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";

                number++;
                changeLabel();
                newlist = db.Questions.First(x => x.ID == number);

                groupBox1.Text = "\r\n";
                groupBox1.Text += newlist.Question1;
                button1.Text = newlist.Answer1;
                button2.Text = newlist.Answer2;
                button3.Text = newlist.Answer3;
                button4.Text = newlist.Answer4;

            }
            else
            {
                buttonAnswer.BackColor = Color.Orange;
                MessageBox.Show("sehv cavab \r\nduzgun cavab " + newlist.QuestionAnswer);
            }


        }
    }
}
