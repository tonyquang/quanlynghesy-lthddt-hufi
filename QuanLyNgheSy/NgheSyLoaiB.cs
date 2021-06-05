using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNgheSy.model
{
    class NgheSyLoaiB : NgheSy
    {
        private string theLoaiBieuDien;
        public NgheSyLoaiB(string maSo, string hoVaTen, string gioiTinh, ushort namSinh, ushort soTietMuc, string thaLoaiBieuDien)
            : base(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc)
        {
            this.theLoaiBieuDien = theLoaiBieuDien;
        }

        public override void tinhTienLuong()
        {
            this.tienLuong = this.soTietMuc * donGiaBieuDien * tinhHeSoNgheSy() - tinhPhiQuangCao();
        }

        protected override double tinhHeSoNgheSy()
        {
            int tuoiHienTai = DateTime.Now.Year - this.namSinh;
            if (tuoiHienTai < 18)
                return 1.5;
            if (this.theLoaiBieuDien.Equals("Nhac tre") || this.theLoaiBieuDien.Equals("bolero"))
                return 1.8;
            return 1.3;
        }
    }
}
