using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNgheSy.model
{
    class NgheSyLoaiA : NgheSy, HoTro
    {
        private uint soLanHopTac;
        private uint soLuongDanhHieu;
        private ushort thamNien;

        public NgheSyLoaiA(string maSo, string hoVaTen, string gioiTinh, ushort namSinh, ushort soTietMuc, uint soLanHopTac, uint soLuongDanhHieu, ushort thamNien)
            : base(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc)
        {
            this.soLanHopTac = soLanHopTac;
            this.soLuongDanhHieu = soLuongDanhHieu;
            this.thamNien = thamNien;
        }

        public override void tinhTienLuong()
        {
            this.tienLuong = this.soTietMuc * donGiaBieuDien * tinhHeSoNgheSy() - tinhPhiQuangCao() + tinhTienHoTro();
        }

        protected override double tinhHeSoNgheSy()
        {
            return 3 + tinhHeSoThamNien() + 0.25 * this.soLuongDanhHieu;
        }

        private double tinhHeSoThamNien() {
            if (this.thamNien > 10)
                return this.thamNien * 0.1;
            return 0;
        }

        public double tinhTienHoTro()
        {
            if (this.soLanHopTac >= 5 && this.soLanHopTac <= 10)
                return 600;
            if (this.soLanHopTac > 10)
                return 1000;
            return 100;
        }
    }
}
