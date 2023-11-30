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
    public partial class FrMain : Form
    {
        private string fixedUsername;
        private List<Khoa> dsKhoa = new List<Khoa>(); // Assuming 
       
        public FrMain()
        {
            InitializeComponent();
           
            LoadListview();
        }

        void LoadListview()
        {
           

            lvKhoa.FullRowSelect = true;
            lvKhoa.GridLines = true;
        }

        public FrMain(string username) : this()
        {
            fixedUsername = username;
            LB_user.Text = fixedUsername;
        }
      
        private void FrMain_Load(object sender, EventArgs e)
        {
            // Set column widths after the ListView has been loaded
            lvKhoa.Columns[0].Width = (int)(lvKhoa.Width * 0.25);
            lvKhoa.Columns[1].Width = (int)(lvKhoa.Width * 0.25);
            lvKhoa.Columns[2].Width = (int)(lvKhoa.Width * 0.25);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            // Implement print functionality if needed
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if(lvKhoa.SelectedItems.Count>0)
            {
                ListViewItem lv1 = lvKhoa.SelectedItems[0];
                lv1.SubItems[0].Text = txt1.Text;
                lv1.SubItems[1].Text = txt2.Text;
                lv1.SubItems[2].Text = txt3.Text;
            }    
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (lvKhoa.SelectedItems.Count>0)
            {
                lvKhoa.Items.RemoveAt(lvKhoa.SelectedItems[0].Index);
               
            }    
        }

        private void Add_Click(object sender, EventArgs e)
        {

         ListViewItem lv1 = new ListViewItem(txt1.Text);
            lv1.SubItems.Add(txt2.Text);
            lv1.SubItems.Add(txt3.Text);
            lvKhoa.Items.Add(lv1);
        }

        private void lvKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvKhoa.SelectedItems.Count>0)
            {
                ListViewItem lv1 = lvKhoa.SelectedItems[0];
                string stt = lv1.SubItems[0].Text;
                string ma = lv1.SubItems[1].Text;
                string ten = lv1.SubItems[2].Text;
                txt1.Text = stt;
                txt2.Text = ma;
                txt3.Text = ten;
                
            }    
           
        }
        private void ResetValue()
        {
            // Reset values of your form elements here
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void STT_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Form1 formNganh = new Form1();

            formNganh.ShowDialog();
        }
    }
}

