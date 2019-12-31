using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CHangHoa
    {
        public string Product_ID			   {get;set;}
        public string Product_Name	        {get;set;}
        public int    Product_Type_ID	   {get;set;}
        public string Product_Group_ID      {get;set;}
        public string Provider_ID		    {get;set;}
        public string Barcode			   {get;set;}
        public string Unit			        {get;set;}
        public string Photo			        {get;set;}
        public float Org_Price			   {get;set;}
        public float Sale_Price		   {get;set;}
        public float Retail_Price          { get; set; }
        public string Customer_ID		   {get;set;}
        public string Customer_Name		   {get;set;}
        public int    MinStock			   {get;set;}
        public string UserID                { get;set;}
        public bool   Active                { get; set; }

        public CHangHoa() 
        {
            UserID = "US000001";
        }

        public CHangHoa
            (
                string _Product_ID          ,
                string _Product_Name        ,
                int    _Product_Type_ID     ,
                string _Product_Group_ID    ,
                string _Provider_ID         ,
                string _Unit                ,
                string _Photo               ,
                float  _Org_Price           ,
                float  _Sale_Price          ,
                float  _Retail_Price        ,
                string _Customer_ID         ,
                string _Customer_Name       ,
                int    _MinStock            ,
                bool   _Active              
            )
        {
            Product_ID        =     _Product_ID         ;
            Product_Name      =     _Product_Name       ;
            Product_Type_ID   =     _Product_Type_ID    ;
            Product_Group_ID  =     _Product_Group_ID   ;
            Provider_ID       =     _Provider_ID        ;
            Barcode           =     _Product_ID            ;
            Unit              =     _Unit               ;
            Photo             =     _Photo              ;
            Org_Price         =     _Org_Price          ;
            Sale_Price        =     _Sale_Price         ;
            Retail_Price      =     _Retail_Price       ;
            Customer_ID       =     _Customer_ID        ;
            Customer_Name     =     _Customer_Name      ;
            MinStock          =     _MinStock           ;
            UserID            =     "US000001"          ;
            Active            =     _Active;
        }
    }
}
