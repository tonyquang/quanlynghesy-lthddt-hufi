using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNgheSy.model
{
    class VuDoan : NgheSy, HoTro
    {
        private uint soLuongThanhVien;
        private double chiPhiChuanBi;

        public VuDoan(string maSo, string hoVaTen, string gioiTinh, ushort namSinh, ushort soTietMuc, uint soLuongThanhVien, double chiPhiChuanBi)
            : base(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc)
        {
            this.soLuongThanhVien = soLuongThanhVien;
            this.chiPhiChuanBi = chiPhiChuanBi;
        }
        public override void tinhTienLuong()
        {
            this.tienLuong = this.soTietMuc * donGiaBieuDien * tinhHeSoNgheSy() - tinhPhiQuangCao();
        }

        protected override double tinhHeSoNgheSy()
        {
            return 2.5 + tinhHeSoNhom();
        }

        private double tinhHeSoNhom() {
            if (this.soLuongThanhVien < 3)
                return 2;
            if (this.soLuongThanhVien >= 3 && this.soLuongThanhVien <= 5)
                return 1.8;
            return 2;
        }

        public double tinhTienHoTro()
        {
            if (this.soLuongThanhVien < 10)
                return this.chiPhiChuanBi * 0.5;
            return 300 + this.chiPhiChuanBi * 0.3;
        }
    }
}
