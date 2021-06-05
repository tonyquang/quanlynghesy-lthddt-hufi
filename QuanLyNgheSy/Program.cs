using QuanLyNgheSy.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNgheSy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============== Phan Mem Quan Ly Nghe Sy ===============");
            do
            {
                Console.WriteLine("- Nhap 1 de bat dau");
                Console.WriteLine("- Nhap 0 de ket thuc");
                int choose = -1;
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) { }
    
                switch (choose) {
                    case 1:{

                        NgheSy ns = null;

                        Console.WriteLine("MA SO: ");
                        string maSo = Console.ReadLine();

                        Console.WriteLine("HO VA TEN:");
                        string hoVaTen = Console.ReadLine();

                        Console.WriteLine("GIOI TINH:");
                        string gioiTinh = Console.ReadLine();

                        Console.WriteLine("NAM SINH:");
                        ushort namSinh = Convert.ToUInt16(Console.ReadLine());

                        Console.WriteLine("SO TIET MUC:");
                        ushort soTietMuc = Convert.ToUInt16(Console.ReadLine());

                        bool chonThanhCong = false;
                        bool validArg = true;
                        do
                        {
                            Console.WriteLine("VUI LONG CHON LOAI NGHE SY:");
                            Console.WriteLine("(1) NGHE SY LOAI A");
                            Console.WriteLine("(2) NGHE SY LOAI B");
                            Console.WriteLine("(3) VU DOAN");
                            int loaiNgheSy = -1;
                            try
                            {
                                loaiNgheSy = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception) { }
                            
                            switch (loaiNgheSy) {
                                case 1: 
                                    {
                                    chonThanhCong = true;

                                    Console.WriteLine("SO LAN HOP TAC VOI CONG TY: ");
                                    uint soLanHopTac = Convert.ToUInt32(Console.ReadLine());

                                    Console.WriteLine("SO DANH HIEU DAT DUOC: ");
                                    uint soDanhHieuDatDuoc = Convert.ToUInt32(Console.ReadLine());

                                    Console.WriteLine("THAM NIEN TRONG NGHE: ");
                                    ushort thamNien = Convert.ToUInt16(Console.ReadLine());

                                    try
                                    {
                                        ns = new NgheSyLoaiA(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc, soLanHopTac, soDanhHieuDatDuoc, thamNien);
                                    }
                                    catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        validArg = false;
                                    }

                                    break;
                                    }
                                case 2:
                                    {
                                        chonThanhCong = true;

                                        Console.WriteLine("THE LOAI BIEU DIEN: ");
                                        string theLoai = Console.ReadLine();

                                        try
                                        {
                                            ns = new NgheSyLoaiB(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc, theLoai);
                                        }
                                        catch (Exception e) {
                                            Console.WriteLine(e.Message);
                                            validArg = false;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        chonThanhCong = true;

                                        Console.WriteLine("SO LUONG NGUOI TRONG NHOM: ");
                                        uint soLuongNguoi = Convert.ToUInt32(Console.ReadLine());

                                        Console.WriteLine("CHI PHI CHUAN BI: ");
                                        double chiPhiChuanBi = Convert.ToDouble(Console.ReadLine());
                                        try
                                        {
                                            ns = new VuDoan(maSo, hoVaTen, gioiTinh, namSinh, soTietMuc, soLuongNguoi, chiPhiChuanBi);
                                        }
                                        catch (Exception e) {
                                            Console.WriteLine(e.Message);
                                            validArg = false;
                                        }
                                       
                                        break;
                                    }
                                default: {
                                    Console.WriteLine("CHON LOAI NGHE SY KHONG HOP LE, VUI LONG CHON LAI");
                                    break;
                                }
                            }
                        } while (!chonThanhCong);

                        if (!validArg) {
                            Console.WriteLine("VUI LONG NHAP LAI THONG TIN NGHE SY");
                            break;
                        }

                        bool flagThaoTac = false;
                        do
                        {
                            Console.WriteLine("VUI LONG CHON THAO TAC THUC HIEN: ");
                            Console.WriteLine("(1) IN THONG TIN NGHE SY");
                            Console.WriteLine("(2) TINH TIEN VA IN TONG SO TIEN LUONG DUOC NHAN CUA NGHE SY");
                            Console.WriteLine("(3) BO QUA THAO TAC");
                            int chonThaoTac = -1;
                            try
                            {
                                chonThaoTac = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception) { }

                            switch (chonThaoTac) {
                                case 1: {
                                    ns.xuatThongTinNgheSy();
                                    break;
                                }
                                case 2: {
                                    ns.tinhTienLuong();
                                    Console.WriteLine("TONG SO TIEN NHAN DUOC LA: " + ns.TienLuong);
                                    break;
                                }
                                case 3: {
                                    flagThaoTac = true;
                                    break;
                                }
                                default: {
                                    Console.WriteLine("THAO TAC LUA CHON KHONG HOP LE VUI LONG CHON LAI");
                                    break;
                                }
                            }

                        } while (!flagThaoTac);
                        Console.WriteLine("***************************************");
                        break;
                    }
                    case 0: {
                        Console.WriteLine("Chuong trinh da ket thuc, cam on ban da su dung!");
                        Console.ReadLine();
                        return;
                    }
                    default: {
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai!");
                        Console.WriteLine("***************************************");
                        break;
                    }
                }

            } while (true);
        }
    }
}
