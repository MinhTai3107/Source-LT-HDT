using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Khoa
    {
        public string STT { get; set; }
        public string maKhoa { get; set; }
        public string tenKhoa { get; set; }
     

        public Khoa(string STT,string maKhoa, string tenKhoa)
        {
            this.STT = STT;
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
           
        }

        public Khoa(string maKhoa)
        {
            this.maKhoa = maKhoa;
        }
    }
}
