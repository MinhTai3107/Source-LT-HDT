using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
    internal class Diem
    {
        public string STT { get; set; }
 public string MaSV { get; set; }
        public string TenSV { get; set; }
       
       
        public string MonHoc { get; set; }
        public double DiemQuaTrinh { get; set; }
        public double DiemThi { get; set; }
        public double DiemTong { get; set; }

        // Hàm khởi tạo
        public Diem(string stt, string tenSV, string maSV, string nganhHoc, string monHoc, double diemQuaTrinh, double diemThi)
        {
            STT = stt;
            MaSV = maSV;
            TenSV = tenSV;
            
          
            MonHoc = monHoc;
            DiemQuaTrinh = diemQuaTrinh;
            DiemThi = diemThi;
           
            DiemTong = (diemQuaTrinh + diemThi)/2;
        }
      

    }
}
