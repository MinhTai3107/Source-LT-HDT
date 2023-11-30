using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test
{
    public partial class Form1 : Form
    {
        private List<Nganh> dsNganh = new List<Nganh>(); // Assuming 
        public Form1()
        {
            InitializeComponent();
        }
       

        private void lvNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
        if (lvNganh.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvNganh.SelectedItems[0];
                string stt = lv1.SubItems[0].Text;
                string ma = lv1.SubItems[1].Text;
                string ten = lv1.SubItems[2].Text;
                string slsv = lv1.SubItems[3].Text;
                txt1.Text = stt;
                txt2.Text = ma;
                txt3.Text = ten;
                txt4.Text = slsv;

            }

        }

     

        private void Add_Click(object sender, EventArgs e)
        {
            ListViewItem lv1 = new ListViewItem(txt1.Text);
            lv1.SubItems.Add(txt2.Text);
            lv1.SubItems.Add(txt3.Text);
            lv1.SubItems.Add(txt4.Text);
            lvNganh.Items.Add(lv1);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (lvNganh.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvNganh.SelectedItems[0];
                lv1.SubItems[0].Text = txt1.Text;
                lv1.SubItems[1].Text = txt2.Text;
                lv1.SubItems[2].Text = txt3.Text;
                lv1.SubItems[3].Text = txt4.Text;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (lvNganh.SelectedItems.Count > 0)
            {
                lvNganh.Items.RemoveAt(lvNganh.SelectedItems[0].Index);

            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Form2 formMon = new Form2();

            formMon.ShowDialog();
        }
        private void ResetValue()
        {
            // Reset values of your form elements here
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set column widths after the ListView has been loaded
            lvNganh.Columns[0].Width = (int)(lvNganh.Width * 0.25);
            lvNganh.Columns[1].Width = (int)(lvNganh.Width * 0.25);
            lvNganh.Columns[2].Width = (int)(lvNganh.Width * 0.25);
           
            lvNganh.Columns[3].Width = (int)(lvNganh.Width * 0.25);
            lvNganh.FullRowSelect = true;
            lvNganh.GridLines = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
