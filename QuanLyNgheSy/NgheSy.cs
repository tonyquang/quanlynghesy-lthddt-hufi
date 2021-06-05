using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNgheSy.model
{
    abstract class NgheSy
    {
        protected string maSo;
        protected string hoVaTen;
        protected ushort namSinh;
        protected string gioiTinh;
        protected ushort soTietMuc;
        protected double tienLuong;

        protected const short donGiaBieuDien = 500;

        public NgheSy() {
            this.maSo = "NS1234BD";
            this.hoVaTen = "Trần Thế Thắng";
            this.gioiTinh = "nam";
            this.namSinh = 2010;
            this.soTietMuc = 2;
        }

        public NgheSy(string maSo, string hoVaTen)
        {
            this.maSo = maSo;
            this.hoVaTen = hoVaTen;
            this.gioiTinh = "nam";
            this.namSinh = (ushort)(DateTime.Now.Year - 18);
            this.soTietMuc = 2;
        }

        public NgheSy(string maSo, string hoVaTen, string gioiTinh, ushort namSinh, ushort soTietMuc) {
            this.MaSo = maSo;
            this.hoVaTen = hoVaTen;
            this.gioiTinh = gioiTinh;
            this.namSinh = namSinh;
            this.SoTietMuc = soTietMuc;
        }

        public ushort SoTietMuc
        {
            get { return soTietMuc; }
            set {
                if (value < 0 || value > 3) {
                    throw new ArgumentException("So tiet muc bieu dien khong duoc am va khong vuot qua 3 tiet muc");
                }
                soTietMuc = value;
            }
        }

        public string MaSo { 
            get { return maSo ;} 
            set { 
                string ms = value.Trim();
                if (!ms.StartsWith("NS") || ms.Length != 8) {
                    throw new ArgumentException("Ma so nghe sy phai bat dau bang \"NS\" va co dung 8 ky tu");
                }
                maSo = ms;
            } 
        }

        public double TienLuong
        {
            get { return tienLuong; }
        }

        public void xuatThongTinNgheSy()
        {
            Console.WriteLine(String.Format("[NgheSy] MA SO: {0} | HO VA TEN: {1} | GIOI TINH: {2} | SO TIET MUC BIEU DIEN: {3}.", this.maSo, this.hoVaTen, this.gioiTinh, this.soTietMuc));
        }

        protected double tinhPhiQuangCao() {
            double phiQuangCaoMoiTietMuc = 30;
            if (this.soTietMuc > 3) {
                phiQuangCaoMoiTietMuc = phiQuangCaoMoiTietMuc * 0.3;
            }
            return phiQuangCaoMoiTietMuc * this.soTietMuc;
        }

        public abstract void tinhTienLuong();
        protected abstract double tinhHeSoNgheSy();
    }
}
