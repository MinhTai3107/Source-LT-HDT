using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
        internal class SinhVien
        {
            public string STT { get; set; }
            public string MaSinhVien { get; set; }
            public string TenSinhVien { get; set; }
            public string NamSinh { get; set; }
            public string GioiTinh { get; set; }
            public string MaNganh { get; set; }
            public string MaKhoa { get; set; }
            public string MaMon { get; set; }
            public string DiemQuaTrinh { get; set; }
            public string DiemThi { get; set; }

            public SinhVien(string stt,string maSinhVien, string tenSinhVien, string namsinh, string gioitinh, string manganh,string makhoa ,string mamon,string diemquatrinh, string diemthi)
            {
            this.STT = stt;
                this.MaSinhVien = maSinhVien;
                this.TenSinhVien = tenSinhVien;
                this.NamSinh = namsinh;
            this.GioiTinh = gioitinh;
            this.MaNganh = manganh;
            this.MaKhoa = makhoa;
            this.MaMon = mamon;
            this.DiemQuaTrinh = diemquatrinh;
            this.DiemThi = diemthi;
            }
        }

    }

