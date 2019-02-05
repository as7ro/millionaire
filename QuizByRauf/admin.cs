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
    public partial class admin : Form
    {
        milionaireEntities1 db = new milionaireEntities1();
        public admin()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text =="" || richTextBox2.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please enter a valid value!");
            }
            else
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox)
                    {
                        var box = item as TextBox;
                        if(textBox5.Text == box.Text && box.Name!=textBox5.Name)
                        {
                                Question question = new Question();
                                question.QuestionCategory = textBox6.Text;
                                question.QuestionAnswer = textBox5.Text;
                                 question.Question1 = richTextBox2.Text;
                                question.Answer1 = textBox1.Text;
                                question.Answer2= textBox2.Text;
                                question.Answer3 = textBox3.Text;
                                question.Answer4 = textBox4.Text;
                                db.Questions.Add(question);
                                db.SaveChanges();
                            MessageBox.Show("add olundu, atam");
                            break;
                            
                        }
                        else if(box.Text != textBox5.Text && box.Text != textBox4.Text && box.Text != textBox3.Text && box.Text != textBox2.Text && box.Text != textBox1.Text)
                        {
                            MessageBox.Show("get dedon gelsin");
                        }
                    }
                }
            }
            //else if(textBox5.Text != textBox1.Text || textBox5.Text != textBox2.Text || textBox5.Text != textBox3.Text || textBox5.Text != textBox4.Text)
            //{
            //    MessageBox.Show("This answer is not found!");
            //}
            //else
            //{
            //    Question question = new Question();
            //    question.QuestionCategory = textBox6.Text;
            //    question.QuestionAnswer = textBox5.Text;
            //    question.Question1 = richTextBox2.Text;
            //    question.Answer1 = textBox1.Text;
            //    question.Answer2= textBox2.Text;
            //    question.Answer3 = textBox3.Text;
            //    question.Answer4 = textBox4.Text;
            //    db.Questions.Add(question);
            //    db.SaveChanges();
            //}
        }
        
    }
}
