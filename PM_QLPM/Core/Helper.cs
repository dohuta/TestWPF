using PM_QLPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PM_QLPM.Core
{
    public partial class Helper
    {
        /// <summary>
        /// Get a new ID depends on type of the object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object to be getting a new ID</param>
        /// <returns></returns>
        public static string GetNewID<T>(T obj)
        {
            var ID = "";

            using (var dc = new QLPM_ModelDataContext())
            {
                switch (obj.GetType().Name)
                {
                    case "HOSOBENHNHAN":
                        if (dc.HOSOBENHNHANs.Count() == 0)
                            ID = "P000";
                        else
                            ID = "P" + (int.Parse(dc.HOSOBENHNHANs.ToArray().Last().Ma_BenhNhan.Substring(1)) + 1).ToString("000");
                        break;
                    case "BENH":
                        if (dc.BENHs.Count() == 0)
                            ID = "D000";
                        else
                            ID = "D" + (int.Parse(dc.BENHs.ToArray().Last().Ma_Benh.Substring(1)) + 1).ToString("000");
                        break;
                    case "NHANVIEN":
                        if (dc.NHANVIENs.Count() == 0)
                            ID = "E000";
                        else
                            ID = "E" + (int.Parse(dc.NHANVIENs.ToArray().Last().Ma_NV.Substring(1)) + 1).ToString("000");
                        break;
                    case "HOADON":
                        if (dc.HOADONs.Count() == 0)
                            ID = "B000";
                        else
                            ID = "B" + (int.Parse(dc.HOADONs.ToArray().Last().Ma_HoaDon.Substring(1)) + 1).ToString("000");
                        break;
                    case "PHIEUKHAMBENH":
                        if (dc.PHIEUKHAMBENHs.Count() == 0)
                            ID = "R000";
                        else
                            ID = "R" + (int.Parse(dc.PHIEUKHAMBENHs.ToArray().Last().Ma_PhieuKham.Substring(1)) + 1).ToString("000");
                        break;
                    case "PHIEUNHAP":
                        if (dc.PHIEUNHAPTHUOCs.Count() == 0)
                            ID = "I000";
                        else
                            ID = "I" + (int.Parse(dc.PHIEUNHAPTHUOCs.ToArray().Last().Ma_PhieuNhap.Substring(1)) + 1).ToString("000");
                        break;
                    case "THUOC":
                        if (dc.THUOCs.Count() == 0)
                            ID = "P000";
                        else
                            ID = "P" + (int.Parse(dc.THUOCs.ToArray().Last().Ma_Thuoc.Substring(1)) + 1).ToString("000");
                        break;
                    case "DONVI":
                        if (dc.DONVIs.Count() == 0)
                            ID = "U000";
                        else
                            ID = "U" + (int.Parse(dc.DONVIs.ToArray().Last().Ma_DonVi.Substring(1)) + 1).ToString("000");
                        break;
                    case "CACHDUNG":
                        if (dc.CACHDUNGs.Count() == 0)
                            ID = "T000";
                        else
                            ID = "T" + (int.Parse(dc.CACHDUNGs.ToArray().Last().Ma_CachDung.Substring(1)) + 1).ToString("000");
                        break;
                    default:
                        break;
                }
            }
            
            return ID;
        }

        /// <summary>
        /// Get the limit of patients in a day from db
        /// </summary>
        /// <returns></returns>
        public static int GetMaximumPatientToday()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                return (from ts in dc.THAMSOs
                        select ts.SLBenhNhan).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get the examination fee from db
        /// </summary>
        /// <returns></returns>
        public static decimal GetExaminationFee()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                return (from ts in dc.THAMSOs
                        select ts.TienKham).FirstOrDefault();
            }
        }

        /// <summary>
        /// Add a new benhnhan obj to database
        /// </summary>
        /// <param name="bn">BenhNhan</param>
        public static void AddBenhNhan(BENHNHAN bn)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.HOSOBENHNHANs.InsertOnSubmit((HOSOBENHNHAN)bn);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Remove a benhnhan obj from database
        /// </summary>
        /// <param name="bn"></param>
        public static void RemoveBenhNhan(BENHNHAN bn)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.HOSOBENHNHANs.DeleteOnSubmit((HOSOBENHNHAN)bn);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Create a new PHIEUKHAMBENH after add a BENHNHAN to DSKHAMBENH
        /// </summary>
        /// <param name="bn"></param>
        public static void AddPhieuKham(BENHNHAN bn)
        {
            using(var dc = new QLPM_ModelDataContext())
            {
                var pk          = new PHIEUKHAMBENH();
                pk.Ma_PhieuKham = GetNewID(pk);
                pk.Ma_BenhNhan  = bn.Ma_BenhNhan;
                pk.NgayKham     = DateTime.Today;
                dc.PHIEUKHAMBENHs.InsertOnSubmit(pk);
                dc.SubmitChanges();
            }
        }
        
        /// <summary>
        /// Remove a PHIEUKHAMBENH from DB
        /// </summary>
        /// <param name="bn"></param>
        public static void RemovePhieuKham(BENHNHAN bn)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var phieukham = dc.PHIEUKHAMBENHs.Single(pk => pk.Ma_BenhNhan == bn.Ma_BenhNhan && pk.NgayKham == DateTime.Today);

                dc.CT_PHIEUKHAMBENHs.DeleteAllOnSubmit(dc.CT_PHIEUKHAMBENHs.Where(ctpk => ctpk.Ma_PhieuKham == phieukham.Ma_PhieuKham));
                dc.PHIEUKHAMBENHs.DeleteOnSubmit(phieukham);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Add a HOADON to DB
        /// </summary>
        /// <param name="pk"></param>
        public static void AddHoaDon(PHIEUKHAM pk)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                if(dc.HOADONs.Any(x => x.Ma_PhieuKham == pk.Ma_PhieuKham))
                {
                    var hd = dc.HOADONs.Single(x => x.Ma_PhieuKham == pk.Ma_PhieuKham);

                    if (pk.DONTHUOC.Count > 0)
                    {
                        foreach (var item in pk.DONTHUOC)
                        {
                            hd.TienThuoc += item.SoLuong * item.DonGia;
                        }
                    }
                    
                    dc.SubmitChanges();
                }
                else
                {
                    var hd = new HOADON();
                    hd.Ma_HoaDon = GetNewID(hd);
                    hd.Ma_PhieuKham = pk.Ma_PhieuKham;
                    hd.TienKham = (from ts in dc.THAMSOs
                                   select ts.TienKham).FirstOrDefault();

                    if (pk.DONTHUOC.Count > 0)
                    {
                        foreach (var item in pk.DONTHUOC)
                        {
                            hd.TienThuoc += item.SoLuong * item.DonGia;
                        }
                    }

                    dc.HOADONs.InsertOnSubmit(hd);
                    dc.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// Delete a HOADON
        /// </summary>
        /// <param name="pk"></param>
        public static void RemoveHoaDon(PHIEUKHAM pk)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.HOADONs.DeleteOnSubmit(dc.HOADONs.Single(hd => hd.Ma_PhieuKham == pk.Ma_PhieuKham));
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Add a CT_PHIEUKHAM to DB
        /// </summary>
        /// <param name="ct"></param>
        public static void AddPill(CT_PHIEUKHAMBENH ct)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.CT_PHIEUKHAMBENHs.InsertOnSubmit(ct);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Delete a CT_PHIEUKHAM from DB
        /// </summary>
        /// <param name="ct"></param>
        public static void RemovePill(CT_PHIEUKHAMBENH ct)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.CT_PHIEUKHAMBENHs.DeleteOnSubmit(ct);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Encrype password
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string EncryptPassword(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }
    }
}
