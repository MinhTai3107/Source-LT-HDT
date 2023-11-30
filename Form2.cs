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
    public partial class Form2 : Form
    {
        private List<Mon> dsMon = new List<Mon>(); // Assuming 
        public Form2()
        {
            InitializeComponent();
           
        }

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        private void Form2_Load(object sender, EventArgs e)
        {
         
                // Set column widths after the ListView has been loaded
                lvMon.Columns[0].Width = (int)(lvMon.Width * 0.3);
                lvMon.Columns[1].Width = (int)(lvMon.Width * 0.3);
                lvMon.Columns[2].Width = (int)(lvMon.Width * 0.3);

             
                lvMon.FullRowSelect = true;
                lvMon.GridLines = true;
            
        }

        private void lvMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvMon.SelectedItems[0];
                string stt = lv1.SubItems[0].Text;
                string ma = lv1.SubItems[1].Text;
                string ten = lv1.SubItems[2].Text;
               
                txt1.Text = stt;
                txt2.Text = ma;
                txt3.Text = ten;
               

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lv1 = new ListViewItem(txt1.Text);
            lv1.SubItems.Add(txt2.Text);
            lv1.SubItems.Add(txt3.Text);
          
            lvMon.Items.Add(lv1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvMon.SelectedItems[0];
                lv1.SubItems[0].Text = txt1.Text;
                lv1.SubItems[1].Text = txt2.Text;
                lv1.SubItems[2].Text = txt3.Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count > 0)
            {
                lvMon.Items.RemoveAt(lvMon.SelectedItems[0].Index);

            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
        private void ResetValue()
        {
            // Reset values of your form elements here
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Form3 frSV = new Form3();
            frSV.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
