using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    dataGridView.DataSource = employeesBindingSource;
                else
                {
                    var query = from o in this.appData.Employees
                                where o.NamaBarang.Contains(txtSearch.Text) || o.HargaBarang == txtSearch.Text || o.KodeBarang == txtSearch.Text || o.JumlahBarang.Contains(txtSearch.Text)
                                select o;
                    dataGridView.DataSource = query.ToList();
                }
            }

        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Kamu yakin mau hapus ini ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    employeesBindingSource.RemoveCurrent();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                employeesBindingSource.EndEdit();
                employeesTableAdapter.Update(this.appData.Employees);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                employeesBindingSource.ResetBindings(false);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtNamaBarang.Focus();
                this.appData.Employees.AddEmployeesRow(this.appData.Employees.NewEmployeesRow());
                employeesBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                employeesBindingSource.ResetBindings(false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtNamaBarang.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kamu yakin mau hapus ini ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                employeesBindingSource.RemoveCurrent();
                employeesBindingSource.EndEdit();
                employeesTableAdapter.Update(this.appData.Employees);
                dataGridView.Refresh();
            }
            else
            {
                employeesBindingSource.EndEdit();
                employeesTableAdapter.Update(this.appData.Employees);
                dataGridView.Refresh();
            }
        }

       

      

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.appData.Employees);
            employeesBindingSource.DataSource = this.appData.Employees;

        }

    }
}