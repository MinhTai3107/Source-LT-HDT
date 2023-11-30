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

namespace test
{
    public partial class Form4 : Form
    {
        private List<Diem> dsDiem = new List<Diem>(); // Assuming
         public string MaSV { get; set; }
        public string TenSV { get; set; }
        
        public string MonHoc { get; set; }
        public double DiemQuaTrinh { get; set; }
        public double DiemThi { get; set; }
        public double DiemTong { get; set; }
        public Form4()
        {
            InitializeComponent();
    
        }
     
            private void lvTongKet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInput_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lvSV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            double diemTong = (DiemQuaTrinh + DiemThi) / 2;

            ListViewItem lvItem = new ListViewItem(new string[]
            {
        MaSV,
        TenSV,
        
        MonHoc,
        DiemQuaTrinh.ToString(),
        DiemThi.ToString(),
        diemTong.ToString()
            });

            lvSV.Items.Add(lvItem);
            // Set chiều rộng cho cột "Tên sinh viên"
            lvSV.Columns[0].Width = (int)(lvSV.Width * 0.1);
            lvSV.Columns[1].Width = (int)(lvSV.Width * 0.1);
            lvSV.Columns[2].Width = (int)(lvSV.Width * 0.1);
            lvSV.Columns[3].Width = (int)(lvSV.Width * 0.1);
            lvSV.Columns[4].Width = (int)(lvSV.Width * 0.1);
            lvSV.Columns[5].Width = (int)(lvSV.Width * 0.1);
           
        }
    }
}
