using projekt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV_Win
{
     
 

    public partial class Form3 : Form
    {
        private StudentManagementSystem studentManager;

        public Form3()
        {
            InitializeComponent();
          
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Student newStudent = new Student
                {
                    Id = textBox4.Text,
                    Name = textBox1.Text,
                    Email = textBox5.Text,
                    PhoneNumber = textBox6.Text,
                    Bday = dateTimePicker1.Value,
                    Gender = checkBox1.Checked,
                    CourseID = textBox3.Text,
                    DepartmentID = textBox8.Text,
                    classIDs = textBox2.Text.Split(',').ToList(),

                };

                studentManager.AddStudent(newStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
