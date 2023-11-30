using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
    internal class Nganh 
    {
        public string maNganh { get; set; }
        public string tenNganh { get; set; }

        public string makhoa { get; set; }

        public Nganh(string maNganh, string tenNganh,string makhoa)
        {
            this.maNganh = maNganh;
            this.tenNganh = tenNganh;
           this.makhoa = makhoa;
        }

        public class KhoaNganh
        {
            public string MaKhoa { get; set; }
            public string MaNganh { get; set; }
        }
    }
}
