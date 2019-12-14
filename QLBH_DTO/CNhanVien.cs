using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CNhanVien
    {
        public string MaNV               {get;set;}
        public string FirtName                  {get;set;}
        public string LastName                  {get;set;}
        public string TenNV             {get;set;}
        public string Alias                     {get;set;}
        public bool GioiTinh                       {get;set;}
        public string DiaChi                   {get;set;}
        public string Country_ID                {get;set;}
        public string H_Tel                     {get;set;}
        public string DienThoai                     {get;set;}
        public string DiDong                    {get;set;}
        public string Fax                       {get;set;}
        public string Email                     {get;set;}
        public DateTime NgaySinh                  {get;set;}
        public int Married                   {get;set;}
        public string Position_ID               {get;set;}
        public string JobTitle_ID               {get;set;}
        public string Branch_ID                 {get;set;}
        public string BoPhan             {get;set;}
        public string Team_ID                   {get;set;}
        public string PersonalTax_ID            {get;set;}
        public string City_ID                   {get;set;}
        public string District_ID               {get;set;}
        public string QuanLy                {get;set;}
        public int EmployeeType              {get;set;}
        public float BasicSalary               {get;set;}
        public float Advance                   {get;set;}
        public float AdvanceOther              {get;set;}
        public float Commission                {get;set;}
        public float Discount                  {get;set;}
        public float ProfitRate                {get;set;}
        public bool IsPublic                  {get;set;}
        public string CreatedBy                 {get;set;}
        public DateTime CreatedDate               {get;set;}
        public string ModifiedBy                {get;set;}
        public DateTime ModifiedDate              {get;set;}
        public string OwnerID                   {get;set;}
        public string ChucVu               {get;set;}
        public int Sorted                    {get;set;}
        public bool ConQL                    { get; set; }

        public CNhanVien()
        {

        }

        public CNhanVien(string _MaNV, 
                        string  _TenNV,   
                        bool    _GioiTinh, 
                        string  _DiaChi, 
                        string  _DienThoai, 
                        string  _DiDong, 
                        DateTime _NgaySinh,
                        string  _BoPhan, 
                        string  _QuanLy, 
                        string  _ChucVu, 
                        string  _Email, 
                        bool    _ConQL)
        {
            MaNV        =     _MaNV          ;
            TenNV       =     _TenNV         ;
            GioiTinh    =     _GioiTinh      ;
            DiaChi      =     _DiaChi        ;
            DienThoai   =     _DienThoai     ;
            DiDong      =     _DiDong        ;
            NgaySinh    =     _NgaySinh      ;
            BoPhan      =     _BoPhan        ;
            QuanLy      =     _QuanLy        ;
            ChucVu      =     _ChucVu        ;
            Email       =     _Email         ;
            ConQL       =     _ConQL         ;
        }

        public void completeObject()
        {
            FirtName = "";
            LastName = "";
            Alias = "";
            Country_ID = "";
            H_Tel = "";
            Fax = "";
            Married = 0;
            Position_ID = "";
            JobTitle_ID = "";
            Branch_ID = "";
            PersonalTax_ID = "";
            City_ID = "";
            District_ID = "";
            EmployeeType = 0;
            BasicSalary = 0;
            Advance = 0;
            AdvanceOther = 0;
            Commission = 0;
            Discount = 0;
            ProfitRate = 0;
            IsPublic = true;
            CreatedBy = "";
            CreatedDate = DateTime.Now;
            ModifiedBy = "";
            ModifiedDate = DateTime.Now;
            OwnerID = "";
            Sorted = 0;
            Team_ID = "";
        }
    }
}
