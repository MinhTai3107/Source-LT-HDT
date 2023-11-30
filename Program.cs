using System;
using System.ComponentModel;

public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T value)
        {
            data = value;
            next = null;
        }
}

public class List<T>
    {
        public Node<T> head;

        public List()
        {
            head = null;
        }

        public Node<T> CreateNode(T value)
        {
            Node<T> ret = new Node<T>(value);
            return ret;
        }

        public int Length()
        {
            int ret = 0;
            if (head == null)
                return ret;
            Node<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                ret++;
            }
            return ret + 1;
        }

        public void Add(T value)
        {
            Node<T> ret = CreateNode(value);
            if (head == null)
            {
                head = ret;
            }
            else
            {
                ret.next = head;
                head = ret;
            }
        }

        public Node<T> Find(T value)
        {
            Node<T> ret = head;
            int temp = 1;
            while (!ret.data.Equals(value))
            {
                ret = ret.next;
                temp++;
                if (temp >= Length())
                    return null;
            }
            return ret;
        }

        public void Delete(T value)
        {
            Node<T> ret = head;
            int temp = 1;
            while (!ret.next.data.Equals(value))
            {
                if (head.data.Equals(value))
                {
                    head = head.next;
                    return;
                }
                ret = ret.next;
                temp++;
                if (temp >= Length())
                    return;
            }
            Node<T> tail = ret.next.next;
            ret.next = null;
            ret.next = tail;
        }
    }
public class Diem
{
        public float DiemThi { get; set; }
        public float DiemQuaTrinh { get; set; }
        public float Diemtongket { get; set; }
        public Diem()
        {
            DiemThi = default(float);
            DiemQuaTrinh = default(float);
            Diemtongket = default(float);
        }

    public void AddMark(float diemqt, float diemthi)
    {
        DiemQuaTrinh = diemqt;
        DiemThi = diemthi;
        CalculateDiemTongKet();
    }
    private void CalculateDiemTongKet()
    {
        this.Diemtongket = (this.DiemThi + this.DiemQuaTrinh) / 2; ;
    }

}

public class MonHoc
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }
        public Diem DiemMonHoc { get; set; }

        public MonHoc(string mamon, string tenmon, int stc)
        {
            MaMon = mamon;
            TenMon = tenmon;
            SoTinChi = stc;
            DiemMonHoc = new Diem();
        }

        public MonHoc()
        {
        }
}

public class DsMonHoc : List<MonHoc>
{
    public void AddMonHoc(string mamon, string tenmon, int stc)
    {
        MonHoc newSubject = new MonHoc(mamon, tenmon, stc);
        this.Add(newSubject);
    }

    public Node<MonHoc> Find(string mamon)
    {
        Node<MonHoc> temp = head;
        int count = 1;
        while (temp != null && temp.data.MaMon != mamon)
        {
            temp = temp.next;
            count++;
            if (count > this.Length())
                return null;
        }
        return temp;
    }

    public void AddDiem(string mamon,string tenmon, int stc, float diemqt, float diemthi)
    {
        Node<MonHoc> ret = Find(mamon);
        if(ret != null)
        {
            ret.data.DiemMonHoc.AddMark(diemqt, diemthi);
        }
        else
        {
            this.AddMonHoc(mamon, tenmon, stc);
            Node<MonHoc> temp = Find(mamon);
            temp.data.DiemMonHoc.AddMark(diemqt, diemthi);
        }
    }

    public void ModifyDiem(string mamon, float newdqt , float newdt, float newdtk)
    {
        Node<MonHoc> ret = Find(mamon);
        if(ret != null)
        {
            ret.data.DiemMonHoc.DiemQuaTrinh = newdqt;
            ret.data.DiemMonHoc.DiemThi = newdt;
            ret.data.DiemMonHoc.Diemtongket = newdtk;
        }
    }


    public void DeleteDiem(string mamon)
    {
        Node<MonHoc> ret = Find(mamon);
        if (ret != null)
        {
            ret.data.DiemMonHoc = null;
        }
    }
}

public class SinhVien
{
    public string HoTen { get; set; }
    public string MaSV { get; set; }
    public string GioiTinh { get; set; }
    public DsMonHoc DsMon { get; set; }

    public SinhVien(string hoten, string masv, string gioitinh)
    {
        HoTen = hoten;
        MaSV = masv;
        GioiTinh = gioitinh;
        DsMon = new DsMonHoc();
    }

    public SinhVien()
    {
    }
}

public class DsSinhVien : List<SinhVien>
{
    public void AddSinhVien(string hoten, string masv, string gioitinh)
    {
        SinhVien student = new SinhVien(hoten, masv, gioitinh);
        this.Add(student);
    }

    public Node<SinhVien> Find(string masv)
    {
        Node<SinhVien> temp = head;
        int count = 1;
        while (temp != null && temp.data.MaSV != masv)
        {
            temp = temp.next;
            count++;
            if (count > this.Length())
                return null;
        }
        return temp;
    }

    public void ModifyDiemSV(string masv , string mamon, float newdt, float newdqt, float newdtk )
    {
        Node<SinhVien> temp = Find(masv);
        if (temp != null)
        {
            temp.data.DsMon.ModifyDiem(mamon, newdqt, newdt, newdtk);
        }
    }

    public void DeleteDiemSV(string mamon, string masv)
    {
        Node<SinhVien> temp = Find(masv);
        if (temp != null)
            temp.data.DsMon.DeleteDiem(mamon);
    }
}

public class Nganh
{
    public string TenNganh { get; set; }
    public string MaNganh { get; set; }
    public DsSinhVien DsSinhVien { get; set; }

    public Nganh(string ten, string ma)
    {
        TenNganh = ten;
        MaNganh = ma;
        DsSinhVien = new DsSinhVien();
    }

    public Nganh()
    {
        DsSinhVien = new DsSinhVien();
    }
}

public class DsNganh : List<Nganh>
{
    public void AddNganh(string ten, string ma)
    {
        Nganh temp = new Nganh(ten, ma);
        this.Add(temp);
    }

    public Node<Nganh> Find(string maNganh)
    {
        Node<Nganh> temp = head;
        int count = 1;
        while (temp.data.MaNganh != maNganh )
        {
            temp = temp.next;
            count++;
            if (count > this.Length())
                return null;
        }
        return temp;
    }

    public Node<SinhVien> FindSV(string manganh, string masv)
    {
        Node<SinhVien> ret = null;
        Node<Nganh> temp = Find(manganh);
        ret = temp.data.DsSinhVien.Find(masv);
        return ret;
    }

}

public class Khoa
{
    public string TenKhoa { get; set; }
    public string MaKhoa { get; set; }
    public DsNganh DsNganh { get; set; }

    public Khoa(string ten, string ma)
    {
        TenKhoa = ten;
        MaKhoa = ma;
        DsNganh = new DsNganh();
    }

    public Khoa()
    {
        DsNganh = new DsNganh();
    }
}

public class DsKhoa : List<Khoa>
{
    public void AddKhoa(string ten, string ma)
    {
        Khoa temp = new Khoa(ten, ma);
        this.Add(temp);
    }

    public Node<Khoa> Find(string ma)
    {
        Node<Khoa> temp = head;
        int count = 1;
        while (temp.data.MaKhoa != ma)
        {
            temp = temp.next;
            count++;
            if (count > this.Length())
                return null;
        }
        return temp;
    }
    public Node<MonHoc> FindMonSv(string makhoa, string manganh, string masv , string ten , string mamon)
    {
        Node<Khoa> khoa = Find(makhoa);
        Node<Nganh> nganh = khoa.data.DsNganh.Find(manganh);
        Node<SinhVien> sinhvien = nganh.data.DsSinhVien.Find(masv);
        Node<MonHoc> monhoc = sinhvien.data.DsMon.Find(mamon);

        return monhoc;
    }

            /*  Start function Add  */
    public void AddNganh(string makhoa, string tenngang , string  manganh)
    {
        Node<Khoa> temp = Find(makhoa);
        temp.data.DsNganh.AddNganh(tenngang, manganh);
    }

    public void AddSinhVien(string manganh, string makhoa , string ten , string masv , string gioitinh)
    {
        Node<Khoa> khoa = Find(makhoa);
        Node<Nganh> nganh =  khoa.data.DsNganh.Find(manganh);
        nganh.data.DsSinhVien.AddSinhVien(ten,masv,gioitinh);
    }
    /*       Main funtion Add 
     *          Input : ma khoa , ma nganh , ma sinh vien , mamon , ten mon , stc , diem qt, diem thi     
     */
    public void AddDiemSV(string manganh, string makhoa, string masv,string mamon , string tenmon , int stc, float diemqt, float diemthi)
    {
        Node<Khoa> khoa = Find(makhoa);
        if(khoa != null)
        {
            Node<Nganh> nganh = khoa.data.DsNganh.Find(manganh);
            if(nganh != null)
            {
                Node<SinhVien> tempSv = nganh.data.DsSinhVien.Find(masv);
                if(tempSv != null) 
                    tempSv.data.DsMon.AddDiem(mamon, tenmon, stc, diemqt, diemthi);
            }
            
        }
        
    }
    /*       End funtion Add       */

    /*    funtion Modify 
     *      Input : makhoa , ma nganh , ten Sv , ma sv, mamon , diemthi moi , diemquatrinh moi    
     */
    public void ModifyDiem(string makhoa, string manganh, string ten, string masv, string mamon, float? newdiemthi, float? newdiemqt)
    {
        Node<MonHoc> monhoc = FindMonSv(makhoa, manganh, masv, ten, mamon);
        if (monhoc != null)
        {
            if (newdiemqt.HasValue)
                monhoc.data.DiemMonHoc.DiemQuaTrinh = newdiemqt.Value;
            if (newdiemthi.HasValue)
                monhoc.data.DiemMonHoc.DiemThi = newdiemthi.Value;
            monhoc.data.DiemMonHoc.Diemtongket = (monhoc.data.DiemMonHoc.DiemThi + monhoc.data.DiemMonHoc.DiemQuaTrinh) / 2;
        }
    }

    /*  Funtion Delete diem Sinh vien*/
    public void DeleteDiemSinhvien(string makhoa , string manganh , string ten , string masv, string mamon)
    {
        Node<Khoa> khoa = Find(makhoa);
        Node<Nganh> nganh = khoa.data.DsNganh.Find(manganh);
        nganh.data.DsSinhVien.DeleteDiemSV(mamon, masv);
    }
}

public class NienKhoa
{
    public string Nam { get; set; }
    public DsKhoa DsKhoa { get; set; }

    public NienKhoa(string nam)
    {
        Nam = nam;
        DsKhoa = new DsKhoa();
    }

    public NienKhoa()
    {
        DsKhoa = new DsKhoa();
    }
}

public class DsNam : List<NienKhoa>
{
    public void AddNam(string nam)
    {
        NienKhoa temp = new NienKhoa(nam);
        this.Add(temp);
    }

    public Node<NienKhoa> Find(string nam)
    {
        Node<NienKhoa> temp = head;
        int count = 1;
        while (temp.data.Nam != nam)
        {
            temp = temp.next;
            count++;
            if (count > this.Length())
                return null;
        }
        return temp;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DsKhoa newKhoa = new DsKhoa();
        newKhoa.AddKhoa("Điện-điện tử", "DDT");
        newKhoa.AddKhoa("Xây dựng", "XD");
        newKhoa.AddKhoa("công nghệ thông tin", "CNTT");

        newKhoa.AddNganh("DDT", "Cơ điện tử", "CDT");
        newKhoa.AddNganh("DDT", "Hệ thống nhúng", "IOT");
        newKhoa.AddNganh("CNTT", "Công nghệ thông tin", "ATTT");

        newKhoa.AddSinhVien("IOT", "DDT", "Lý Thế Hào", "20142491", "Nam");
        newKhoa.AddSinhVien("IOT", "DDT", "Phan Minh Tài", "20139074", "Nam");
        newKhoa.AddSinhVien("ATTT", "CNTT", "Quách Lộc Nguyên", "20139564", "Nam");

        newKhoa.AddDiemSV("IOT", "DDT", "20142491", "OOP", "Hướng đối tượng", 3, 9, 8.5F);
        newKhoa.AddDiemSV("IOT", "DDT", "20142491", "MMT", "Mạng máy tính", 3, 8, 9);
        newKhoa.AddDiemSV("IOT", "DDT", "20142491", "KHDL", "Khoa học dữ liệu ", 3, 8.8F, 9);

        newKhoa.AddDiemSV("IOT", "DDT", "20139074", "OOP", "Hướng đối tượng", 3, 7, 8.5F);
        newKhoa.AddDiemSV("IOT", "DDT", "20139074", "MMT", "Mạng máy tính", 3, 9, 8);

        newKhoa.AddDiemSV("ATTT", "CNTT", "20139564", "ANM", "An ninh mạng", 3, 8, 8.5F);

        newKhoa.ModifyDiem("DDT", "IOT", "Lý Thế Hào", "20142491", "OOP", 9.5F, 9);
        newKhoa.ModifyDiem("DDT", "IOT", "Phan Minh Tài", "20139074", "OOP", 9.5F,null);

        newKhoa.DeleteDiemSinhvien("DDT", "IOT", "Lý Thế Hào", "20142491", "KHDL");
        newKhoa.DeleteDiemSinhvien("CNTT", "ATTT", "Quách Lộc Nguyên", "20139564", "ANM");

        int a;

    }
}