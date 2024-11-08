using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projekt;

namespace oop_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentManagementSystem StudentManager = new StudentManagementSystem();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Student> result = new List<Student>();

            try
            {
                // Kiểm tra nếu trường tìm kiếm không trống
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã tìm kiếm.");
                    return;
                }

                // Tìm kiếm theo các tiêu chí chọn
                if (comboBox2.SelectedItem == "Mã số sinh viên")
                {
                    // Tìm theo Mã số sinh viên, chỉ trả về một sinh viên
                    Student student = StudentManager.FindStudentByID(textBox1.Text);
                    if (student != null)
                    {
                        result.Add(student);  // Thêm sinh viên vào danh sách kết quả
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với mã số này.");
                    }
                }
                else if (comboBox2.SelectedItem == "Mã lớp")
                {
                    // Tìm theo Mã lớp, có thể có nhiều sinh viên
                    result = StudentManager.FindEntitiesByProperty("ClassID", textBox1.Text);
                }
                else if (comboBox2.SelectedItem == "Mã học phần")
                {
                    // Tìm theo Mã học phần, có thể có nhiều sinh viên
                    result = StudentManager.FindEntitiesByProperty("CourseID", textBox1.Text);
                }
                else if (comboBox2.SelectedItem == "Mã khoa")
                {
                    // Tìm theo Mã khoa, có thể có nhiều sinh viên
                    result = StudentManager.FindEntitiesByProperty("DepartmentID", textBox1.Text);
                }

                // Kiểm tra và hiển thị kết quả trên DataGridView
                if (result != null && result.Count > 0)
                {
                    dataGridView1.DataSource = result;  // Hiển thị danh sách sinh viên trong DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.");
                    dataGridView1.DataSource = null; // Xóa dữ liệu cũ nếu không tìm thấy
                }
            }
            catch (StudentNotFoundException ex)
            {
                // Hiển thị thông báo nếu không tìm thấy sinh viên khi tìm theo Mã số sinh viên
                MessageBox.Show(ex.Message, "Lỗi tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;  // Xóa dữ liệu cũ nếu có lỗi
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác nếu có
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;  // Xóa dữ liệu cũ nếu có lỗi
            }
        }





        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}
