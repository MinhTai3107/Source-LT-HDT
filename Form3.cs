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
    public partial class Form3 : Form
    {
        private List<SinhVien> dsSV = new List<SinhVien>();
        private List<Diem> danhSachDiem = new List<Diem>();
        public string MaKhoa { get; set; }
        public string MaNganh { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void lvSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvSV.SelectedItems[0];
                string stt = lv1.SubItems[0].Text;
                string masv = lv1.SubItems[1].Text;
                string makhoa = lv1.SubItems[2].Text;
                string manganh = lv1.SubItems[3].Text;
                string ten = lv1.SubItems[4].Text;
                string namsinh = lv1.SubItems[5].Text;
                string gioitinh = lv1.SubItems[6].Text;
              
                string mon = lv1.SubItems[7].Text;
                string diemqt = lv1.SubItems[8].Text;
                string diemthi = lv1.SubItems[9].Text;

                txt1.Text = stt;
                txt2.Text = masv;
                txt3.Text = makhoa;
                txt4.Text = manganh;
                txt5.Text = ten;
                txt6.Text = namsinh;
                txt7.Text = gioitinh;
              
                txt8.Text = mon;
                txt9.Text = diemqt;
                txt10.Text = diemthi;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lvSV.Columns[0].Width = (int)(lvSV.Width * 0.20);
            lvSV.Columns[1].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[2].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[3].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[4].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[5].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[6].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[7].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[8].Width = (int)(lvSV.Width * 0.2);
            lvSV.Columns[9].Width = (int)(lvSV.Width * 0.2);
           

            lvSV.FullRowSelect = true;
            lvSV.GridLines = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lv1 = new ListViewItem(txt1.Text);
            lv1.SubItems.Add(txt2.Text);
            lv1.SubItems.Add(txt3.Text);
            lv1.SubItems.Add(txt4.Text);
            lv1.SubItems.Add(txt5.Text);
            lv1.SubItems.Add(txt6.Text);
            lv1.SubItems.Add(txt7.Text);
            lv1.SubItems.Add(txt8.Text);
            lv1.SubItems.Add(txt9.Text);
            lv1.SubItems.Add(txt10.Text);

            lvSV.Items.Add(lv1);

        
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvSV.SelectedItems[0];
                lv1.SubItems[0].Text = txt1.Text;
                lv1.SubItems[1].Text = txt2.Text;
                lv1.SubItems[2].Text = txt3.Text;
                lv1.SubItems[3].Text = txt4.Text;
                lv1.SubItems[4].Text = txt5.Text;
                lv1.SubItems[5].Text = txt6.Text;
                lv1.SubItems[6].Text = txt7.Text;
                lv1.SubItems[7].Text = txt8.Text;
                lv1.SubItems[8].Text = txt9.Text;
                lv1.SubItems[9].Text = txt10.Text;

                // Cập nhật thông tin điểm trong danh sách
                var sinhVien = danhSachDiem.FirstOrDefault(sv => sv.STT == txt1.Text);
                if (sinhVien != null)
                {
                    sinhVien.TenSV = txt5.Text;
                    sinhVien.MaSV = txt2.Text;
                   
                    sinhVien.MonHoc = txt8.Text;
                    double diemQuaTrinh, diemThi;
                    if (double.TryParse(txt9.Text, out diemQuaTrinh) && double.TryParse(txt10.Text, out diemThi))
                    {
                        sinhVien.DiemQuaTrinh = diemQuaTrinh;
                        sinhVien.DiemThi = diemThi;
                        sinhVien.DiemTong = diemQuaTrinh * 0.4 + diemThi * 0.6;
                    }
                }

                ResetValue();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count > 0)
            {
                // Xóa thông tin điểm khỏi danh sách
                var stt = lvSV.SelectedItems[0].SubItems[0].Text;
                danhSachDiem.RemoveAll(sv => sv.STT == stt);

                lvSV.Items.RemoveAt(lvSV.SelectedItems[0].Index);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
           
            ResetValue();

        }

        private void ResetValue()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10.Text = "";
            

        }

        private void Detail_Click(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvSV.SelectedItems[0];

                string maSV = lvItem.SubItems[1].Text;
                string tenSV = lvItem.SubItems[4].Text;
               
                string monHoc = lvItem.SubItems[7].Text;
                double diemQuaTrinh, diemThi;
                if (double.TryParse(lvItem.SubItems[8].Text, out diemQuaTrinh) && double.TryParse(lvItem.SubItems[9].Text, out diemThi))
                {
                    double diemTong = (diemQuaTrinh + diemThi) / 2;

                    Form4 formDiem = new Form4();
                    formDiem.MaSV = maSV;
                    formDiem.TenSV = tenSV;
                   
                    formDiem.MonHoc = monHoc;
                    formDiem.DiemQuaTrinh = diemQuaTrinh;
                    formDiem.DiemThi = diemThi;
                    formDiem.DiemTong = diemTong;
                    formDiem.ShowDialog();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string maKhoa = txt3.Text;
            string maNganh = txt4.Text;

            bool found = true;

            // Duyệt qua các ListViewItem trong ListView
            foreach (ListViewItem item in lvSV.Items)
            {
             
                string makhoa = item.SubItems[2].Text;
                string manganh = item.SubItems[3].Text;

                // Kiểm tra điều kiện tìm kiếm
                if (makhoa == maKhoa && manganh == maNganh)
                {
                    // Hiển thị thông tin sinh viên tìm thấy
                    txt1.Text = item.SubItems[0].Text;
                    txt2.Text = item.SubItems[1].Text;
                    txt3.Text = makhoa;
                    txt4.Text = manganh;
                    txt5.Text = item.SubItems[4].Text;
                    txt6.Text = item.SubItems[5].Text;
                    txt7.Text = item.SubItems[6].Text;
                    txt8.Text = item.SubItems[7].Text;
                    txt9.Text = item.SubItems[8].Text;
                    txt10.Text = item.SubItems[9].Text;

                    found = true;

                    lvSV.SelectedItems.Clear();
                    item.Selected = true;
                    lvSV.Focus();
                }
                else
                {
                    // Xóa các sinh viên không liên quan khỏi ListView
                    lvSV.Items.Remove(item);
                }
            }

            if (!found)
            {
                // Hiển thị thông báo không tìm thấy sinh viên
                MessageBox.Show("Không tìm thấy sinh viên.");
            }
        }



            private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
