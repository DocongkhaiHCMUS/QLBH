USE SaleExample
GO

ALTER TABLE dbo.PRODUCT ADD _Photo NVARCHAR(max)

SELECT * FROM dbo.PRODUCT
GO
IF(OBJECT_ID('PRODUCT_Update_New','P')IS NOT NULL)
	DROP PROCEDURE [dbo].[PRODUCT_Insert_New]
GO 
CREATE PROCEDURE [dbo].[PRODUCT_Insert_New]
    @Product_ID        		VARCHAR(20)			   ,
    @Product_Name			NVARCHAR(255)			   ,
    @Product_Type_ID			int		   ,
    @Product_Group_ID			VARCHAR(20)		   ,
    @Provider_ID       			VARCHAR(20)		   ,
    @Barcode					VARCHAR(20)		   ,
    @Unit						NVARCHAR(20)		   ,
    @Photo						NVARCHAR(MAX)		   ,
    @Org_Price         			DECIMAL		   ,
    @Sale_Price					DECIMAL		   ,
    @Retail_Price				DECIMAL		   ,
    @Customer_ID				VARCHAR(20)		   ,
    @Customer_Name     			NVARCHAR(255)		   ,
    @MinStock					INT		   ,
    @UserID						VARCHAR(20)		   ,
    @Active			    BIT
AS
INSERT INTO [PRODUCT] (
    Product_ID,
    Product_Name,
    Product_Type_ID,
    Manufacturer_ID,
    Product_Group_ID,
    Provider_ID,
    Origin,
    Barcode,
    Unit,
    UnitConvert,
    UnitRate,
    Org_Price,
    Sale_Price,
    Retail_Price,
    Quantity,
    CurrentCost,
    AverageCost,
    Warranty,
    VAT_ID,
    ImportTax_ID,
    ExportTax_ID,
    LuxuryTax_ID,
    Customer_ID,
    Customer_Name,
    CostMethod,
    MinStock,
    MaxStock,
    Discount,
    Commission,
    Description,
    Color,
    Expiry,
    LimitOrders,
    ExpiryValue,
    Batch,
    Depth,
    Height,
    Width,
    Thickness,
    Size,
    UserID,
    Active
)
VALUES (
    @Product_ID,
    @Product_Name,
    @Product_Type_ID,
    0,
    @Product_Group_ID,
    @Provider_ID,
    NULL,
    @Barcode,
    @Unit,
    NULL,
    0,
    @Org_Price,
    @Sale_Price,
    @Retail_Price,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    @Customer_ID,
    @Customer_Name,
    0,
    @MinStock,
    0,
    0,
    0,
    '',
    NULL,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    @UserID,
    @Active)
GO
IF(OBJECT_ID('PRODUCT_Update_New','P')IS NOT NULL)
	DROP PROCEDURE [dbo].[PRODUCT_Update_New]
go
CREATE PROCEDURE [dbo].[PRODUCT_Update_New]
    @Product_ID        		VARCHAR(20)			   ,
    @Product_Name			NVARCHAR(255)			   ,
    @Product_Type_ID			int		   ,
    @Product_Group_ID			VARCHAR(20)		   ,
    @Provider_ID       			VARCHAR(20)		   ,
    @Barcode					VARCHAR(20)		   ,
    @Unit						NVARCHAR(20)		   ,
    @Photo						NVARCHAR(MAX)		   ,
    @Org_Price         			DECIMAL		   ,
    @Sale_Price					DECIMAL		   ,
    @Retail_Price				DECIMAL		   ,
    @Customer_ID				VARCHAR(20)		   ,
    @Customer_Name     			NVARCHAR(255)		   ,
    @MinStock					INT		   ,
    @UserID						VARCHAR(20)		   ,
    @Active			    BIT
AS
UPDATE [PRODUCT]
SET 
	Product_Name		=			@Product_Name		  ,
	Product_Type_ID		=			@Product_Type_ID	  ,
	Product_Group_ID	=			@Product_Group_ID	  ,
	Provider_ID     	=			@Provider_ID     	  ,
	Barcode				=			@Barcode			  ,
	Unit				=			@Unit				  ,
	_Photo				=			@Photo				  ,
	Org_Price       	=			@Org_Price       	  ,
	Sale_Price			=			@Sale_Price			  ,
	Retail_Price		=			@Retail_Price		  ,
	Customer_ID			=			@Customer_ID		  ,
	Customer_Name   	=			@Customer_Name   	  ,
	MinStock			=			@MinStock			  ,
	UserID				=			@UserID				  
 Where 
    Product_ID = @Product_ID
GO    
ALTER TABLE STOCK_OUTWARD ADD PTTT VARCHAR(255) 
GO 
--DELETE dbo.STOCK_OUTWARD WHERE ID = 'BHADMIN000005'

SELECT * FROM dbo.STOCK_OUTWARD --WHERE ID ='BHADMIN'
SELECT * FROM dbo.STOCK_OUTWARD_DETAIL WHERE Outward_ID LIKE '%BHADMIN%'
SELECT * FROM dbo.INVENTORY_DETAIL --WHERE Product_ID = 'TBK0022'
SELECT * FROM dbo.INVENTORY WHERE Product_ID LIKE '%TBK0022%'
GO 
EXEC dbo.STOCK_OUTWARD_DETAIL_Get @ID = NULL -- uniqueidentifier

--------------------------------------------------------------------------
-------------------------------------------------------------------------
IF(OBJECT_ID('KSP_SaleProduct_SO_Insert','P')IS NOT NULL)
	DROP PROC KSP_SaleProduct_SO_Insert
GO    
CREATE PROC KSP_SaleProduct_SO_Insert
@MaBH						VARCHAR(255),
@NgayLap					date,
@MaKH						varchar(255),
@TenKH						nvarchar(255),
@NhanVienBH					varchar(255),
@DiaChi						nvarchar(Max),
@GhiChu						nvarchar(Max),
@DienThoai					varchar(10),
@SoHoaDonVat				varchar(255),
@DieuKhoanThanhToan			varchar(10),
@HinhThucTT					varchar(10),
@HanTT						date,
@NgayGiao					date,
@ThanhTien					decimal,
@ThanhToan					decimal
AS
BEGIN
	DECLARE @SO_PaymentMethod uniqueidentifier = (CASE  WHEN @HinhThucTT = N'Tiền mặt' then cast(cast(0 as varbinary(16)) as uniqueidentifier) ELSE cast(cast(1 as varbinary(16)) as uniqueidentifier) END)
	DECLARE @SO_@TermID VARCHAR(20) = (CASE WHEN @DieuKhoanThanhToan = N'Công nợ' then 'CN' ELSE 'TM' END)

	EXEC dbo.STOCK_OUTWARD_Insert 
		@ID = @MaBH, -- varchar(20)
	    @RefDate = @NgayLap, -- datetime
	    @Ref_OrgNo = N'', -- nvarchar(20)
	    @RefType = 2, -- int
	    @RefStatus = 0, -- int
	    @PaymentMethod = @SO_PaymentMethod, -- uniqueidentifier
	    @TermID = @SO_@TermID, -- nvarchar(20)
	    @PaymentDate = @HanTT, -- datetime
	    @DeliveryDate = @NgayGiao, -- datetime
	    @Barcode = @MaBH, -- varchar(20)
	    @Department_ID = N'', -- nvarchar(20)
	    @Employee_ID = @NhanVienBH, -- varchar(20)
	    @Stock_ID = '', -- varchar(20)
	    @Branch_ID = '', -- varchar(20)
	    @Contract_ID = '', -- varchar(20)
	    @Customer_ID = @MaKH, -- varchar(20)
	    @CustomerName = @TenKH, -- nvarchar(255)
	    @CustomerAddress = @DiaChi, -- nvarchar(255)
	    @Contact = N'', -- nvarchar(100)
	    @Reason = @SoHoaDonVat, -- nvarchar(255)
	    @Payment = 0, -- smallint
	    @Currency_ID = 'VND', -- varchar(3)
	    @ExchangeRate = 1, -- money
	    @Vat = 0, -- int
	    @VatAmount = 0, -- money
	    @Amount = @ThanhToan, -- money
	    @FAmount = @ThanhToan, -- money
	    @DiscountDate = @NgayLap, -- datetime
	    @DiscountRate = 0, -- money
	    @Discount = 0, -- money
	    @OtherDiscount = 0, -- money
	    @Charge = 0, -- money
	    @Cost = 0, -- money
	    @Profit = 0, -- money
	    @User_ID = 'US000001', -- varchar(20)
	    @IsClose = 0, -- bit
	    @Sorted = 0, -- bigint
	    @Description = @GhiChu, -- nvarchar(255)
	    @Active = 1 -- bit
	--UPDATE dbo.INVENTORY SET Quantity = Quantity - (CASE WHEN @SoLuong = NULL THEN 0 ELSE @SoLuong END ) , Amount = Amount - (CASE WHEN @SoLuong = NULL THEN 0 ELSE @SoLuong END ) *(Amount/Quantity) WHERE Product_ID = @MaHH AND Stock_ID = @KhoXuat
	
END 
GO 
IF(OBJECT_ID('KSP_SaleProduct_SOD_Insert','P')IS NOT NULL)
	DROP PROC KSP_SaleProduct_SOD_Insert
GO    
CREATE PROC KSP_SaleProduct_SOD_Insert
@ID							VARCHAR(255),
@MaBH						VARCHAR(255),
@NgayLap					date,
@MaKH						varchar(255),
@TenKH						nvarchar(255),
@NhanVienBH					varchar(255),
@KhoXuat					varchar(255),
@DiaChi						nvarchar(Max),
@GhiChu						nvarchar(Max),
@DienThoai					varchar(10),
@SoHoaDonVat				varchar(255),
@SoPhieuNhapTay				varchar(255),
@DieuKhoanThanhToan			varchar(10),
@HinhThucTT					varchar(10),
@HanTT						date,
@NgayGiao					date,
@MaHH						varchar(255),
@TenHH						nvarchar(255),
@DonVi						varchar(255),
@SoLuong					decimal,
@DonGia						decimal,
@ThanhTien					decimal,
@ChietKhauTiLe				decimal,
@ChietKhau					decimal,
@ThanhToan					decimal
AS
BEGIN
	DECLARE @SOD_ID UNIQUEIDENTIFIER = CAST(cast(@ID as varbinary(16)) as uniqueidentifier)
	DECLARE @SOD_Cost DECIMAL = (SELECT SUM(Amount)/SUM(Quantity) FROM dbo.INVENTORY WHERE Product_ID = @MaHH)
	DECLARE @SOD_Profit DECIMAL

		EXEC dbo.STOCK_OUTWARD_DETAIL_Insert 
		@ID = @SOD_ID, -- uniqueidentifier
	    @Outward_ID = @MaBH, -- varchar(20)
	    @Stock_ID = @KhoXuat, -- varchar(20)
	    @RefType = 2, -- int
	    @Product_ID = @MaHH, -- varchar(20)
	    @ProductName = @TenHH, -- nvarchar(255)
	    @Vat = 0, -- int
	    @VatAmount = 0, -- money
	    @Unit = @DonVi, -- nvarchar(20)
	    @UnitConvert = 1, -- money
	    @CurrentQty = @SoLuong, -- money
	    @Quantity = @SoLuong, -- money
	    @UnitPrice = @DonGia, -- money
	    @Amount = @ThanhToan, -- money
	    @QtyConvert = @SoLuong, -- money
	    @DiscountRate = @ChietKhauTiLe, -- money
	    @Discount = @ChietKhau, -- money
	    @Charge = @ThanhTien, -- money
	    @Cost = @SOD_Cost, -- money
	    @Profit = @SOD_Profit, -- money
	    @Batch = '', -- varchar(50)
	    @Serial = '', -- varchar(50)
	    @ChassyNo = '', -- varchar(50)
	    @IME = '', -- varchar(50)
	    @Width = 0, -- money
	    @Height = 0, -- money
	    @Orgin = N'', -- nvarchar(255)
	    @Size = N'', -- nvarchar(255)
	    @StoreID = 0, -- bigint
	    @Description = @TenKH, -- nvarchar(250)
	    @Sorted = 0, -- bigint
	    @Active = 1 -- bit
	
END 
GO 
--------------------------------------------------------------------------
-------------------------------------------------------------------------
IF(OBJECT_ID('KSP_SaleProduct_Delete','P') IS NOT NULL)
	DROP PROC KSP_SaleProduct_Delete
GO 
CREATE PROC KSP_SaleProduct_Delete
@MaBH VARCHAR(255)
AS
BEGIN
	
	EXEC dbo.STOCK_OUTWARD_Delete @ID = @MaBH -- varchar(20)
	DELETE dbo.DEBT WHERE RefID = @MaBH
	DELETE dbo.TRANS_REF where RefID = @MaBH
END 
GO

IF(OBJECT_ID('KSP_SaleProduct_Get','P')IS NOT NULL)
	DROP PROC KSP_SaleProduct_Get
GO
CREATE PROC KSP_SaleProduct_Get
@MaBH VARCHAR(20)
AS
BEGIN
	SELECT so.ID AS MaBH,              
		   so.RefDate AS NgayLap,           
		   so.Customer_ID AS MaKH,              
		   so.CustomerName AS TenKH,             
		   so.Employee_ID AS NhanVienBH,        
		   sod.Stock_ID AS KhoXuat,           
		   so.CustomerAddress AS DiaChi,            
		   sod.Description AS GhiChu,            
		   so.Contact AS DienThoai,         
		   so.Reason AS SoHoaDonVat,       
		   so.Ref_OrgNo AS SoPhieuNhapTay,    
		   (CASE WHEN so.TermID='CN' THEN  N'Công nợ' ELSE N'Thanh toán ngay' END) AS DieuKhoanThanhToan,
		   (CASE WHEN so.PaymentMethod=cast(cast(0 as varbinary(16)) as uniqueidentifier) THEN  N'Chuyển khoản' ELSE N'Tiền mặt' END) AS HinhThucTT,        
		   so.PaymentDate AS HanTT,             
		   so.DeliveryDate AS NgayGiao,          
		   sod.Product_ID AS MaHH,             
		   sod.ProductName AS TenHH,             
		   sod.Unit AS DonVi,             
		   sod.Quantity AS SoLuong,           
		   sod.UnitPrice AS DonGia,            
		   sod.Charge AS ThanhTien,         
		   sod.DiscountRate AS ChietKhauTiLe,     
		   sod.Discount AS ChietKhau,         
		   sod.Amount AS ThanhToan         
	FROM dbo.STOCK_OUTWARD_DETAIL sod JOIN dbo.STOCK_OUTWARD so on so.ID =sod.Outward_ID
	WHERE so.ID = @MaBH
END 
GO 

--------------------------------------------------------------------------
-------------------------------------------------------------------------
EXEC dbo.KSP_SaleProduct_Get @MaBH = 'BHADMIN000005' -- varchar(20)
GO 
--DELETE dbo.STOCK_INWARD WHERE ID ='MHADMIN000004'
SELECT * FROM dbo.STOCK_INWARD --WHERE ID ='BHADMIN'
SELECT * FROM dbo.STOCK_INWARD_DETAIL WHERE Inward_ID LIKE '%MHADMIN%'
SELECT * FROM dbo.INVENTORY_DETAIL --WHERE Product_ID = 'TBK0022'
SELECT * FROM dbo.INVENTORY WHERE Product_ID LIKE '%TBK0022%'

EXEC dbo.STOCK_INWARD_DETAIL_GetList

GO 

--------------------------------------------------------------------------
-------------------------------------------------------------------------

IF(OBJECT_ID('KSP_BuyProduct_Get','P')IS NOT NULL)
	DROP PROC KSP_BuyProduct_Get
GO
CREATE PROC KSP_BuyProduct_Get
@MaMH VARCHAR(20)
AS
BEGIN
	SELECT so.ID AS MaBH,              
		   so.RefDate AS NgayLap,           
		   so.Customer_ID AS MaKH,              
		   so.CustomerName AS TenKH,             
		   so.Employee_ID AS NhanVienBH,        
		   sod.Stock_ID AS KhoXuat,           
		   so.CustomerAddress AS DiaChi,            
		   sod.Description AS GhiChu,            
		   so.Contact AS DienThoai,         
		   so.Reason AS SoHoaDonVat,       
		   so.Ref_OrgNo AS SoPhieuNhapTay,    
		   (CASE WHEN so.TermID='CN' THEN  N'Công nợ' ELSE N'Thanh toán ngay' END) AS DieuKhoanThanhToan,
		   (CASE WHEN so.PaymentMethod=cast(cast(0 as varbinary(16)) as uniqueidentifier) THEN  N'Chuyển khoản' ELSE N'Tiền mặt' END) AS HinhThucTT,        
		   so.PaymentDate AS HanTT,                      
		   sod.Product_ID AS MaHH,             
		   sod.ProductName AS TenHH,             
		   sod.Unit AS DonVi,             
		   sod.Quantity AS SoLuong,           
		   sod.UnitPrice AS DonGia,                   
		   sod.Amount AS ThanhToan         
	FROM dbo.STOCK_INWARD_DETAIL sod JOIN dbo.STOCK_INWARD so on so.ID =sod.Inward_ID
	WHERE so.ID = @MaMH
END 
GO 
EXEC dbo.KSP_BuyProduct_Get @MaMH = 'MHADMIN000003' -- varchar(20)

--------------------------------------------------------------------------
-------------------------------------------------------------------------

IF(OBJECT_ID('KSP_BuyProduct_SI_Insert','P')IS NOT NULL)
	DROP PROC KSP_BuyProduct_SI_Insert
GO    
CREATE PROC KSP_BuyProduct_SI_Insert
@MaMH						VARCHAR(255),
@NgayLap					date,
@MaNCC						varchar(255),
@TenNCC						nvarchar(255),
@NhanVienMH					varchar(255),
@DiaChi						nvarchar(Max),
@GhiChu						nvarchar(Max),
@DienThoai					varchar(10),
@SoHoaDonVat				varchar(255),
@DieuKhoanThanhToan			varchar(10),
@HinhThucTT					varchar(10),
@HanTT						date,
@NgayGiao					date,
@ThanhTien					decimal,
@ThanhToan					decimal
AS
BEGIN
	DECLARE @SO_PaymentMethod uniqueidentifier = (CASE  WHEN @HinhThucTT = N'Tiền mặt' then cast(cast(0 as varbinary(16)) as uniqueidentifier) ELSE cast(cast(1 as varbinary(16)) as uniqueidentifier) END)
	DECLARE @SO_@TermID VARCHAR(20) = (CASE WHEN @DieuKhoanThanhToan = N'Công nợ' then 'CN' ELSE 'TM' END)

	EXEC dbo.STOCK_INWARD_Insert 
		@ID = @MaMH, -- varchar(20)								   		  @ID = '', -- varchar(20)
	    @RefDate = @NgayLap, -- datetime						   		  @RefDate = '2019-12-22 09:57:12', -- datetime
	    @Ref_OrgNo = N'', -- nvarchar(20)						   		  @Ref_OrgNo = N'', -- nvarchar(20)
	    @RefType = 1, -- int									   		  @RefType = 0, -- int
	    @PaymentMethod = @SO_PaymentMethod, -- uniqueidentifier	   		  @PaymentMethod = NULL, -- uniqueidentifier
	    @TermID = @SO_@TermID, -- nvarchar(20)					   		  @TermID = N'', -- nvarchar(20)
	    @PaymentDate = @HanTT, -- datetime						   		  @PaymentDate = '2019-12-22 09:57:12', -- datetime
	    @DeliveryDate = @NgayGiao, -- datetime					   		  @DeliveryDate = '2019-12-22 09:57:12', -- datetime
	    @Barcode = @MaMH, -- varchar(20)						   		  @Barcode = '', -- varchar(20)
	    @Department_ID = N'', -- nvarchar(20)					   		  @Department_ID = N'', -- nvarchar(20)
	    @Employee_ID = @NhanVienMH, -- varchar(20)				   		  @Employee_ID = '', -- varchar(20)
	    @Stock_ID = '', -- varchar(20)							   		  @Stock_ID = '', -- varchar(20)
	    @Branch_ID = '', -- varchar(20)							   		  @Branch_ID = '', -- varchar(20)
	    @Contract_ID = '', -- varchar(20)						   		  @Contract_ID = '', -- varchar(20)
	    @Customer_ID = @MaNCC, -- varchar(20)					   		  @Customer_ID = '', -- varchar(20)
	    @CustomerName = @TenNCC, -- nvarchar(255)				   		  @CustomerName = N'', -- nvarchar(255)
	    @CustomerAddress = @DiaChi, -- nvarchar(255)			   		  @CustomerAddress = N'', -- nvarchar(255)
	    @Contact = N'', -- nvarchar(100)						   		  @Contact = N'', -- nvarchar(100)
	    @Reason = @SoHoaDonVat, -- nvarchar(255)				   		  @Reason = N'', -- nvarchar(255)
	    @Payment = 0, -- smallint								   		  @Payment = 0, -- smallint
	    @Currency_ID = 'VND', -- varchar(3)						   		  @Currency_ID = '', -- varchar(3)
	    @ExchangeRate = 1, -- money								   		  @ExchangeRate = NULL, -- money
	    @Vat = 0, -- int										   		  @Vat = 0, -- int
	    @VatAmount = 0, -- money								   		  @VatAmount = NULL, -- money
	    @Amount = @ThanhTien, -- money							   		  @Amount = NULL, -- money
	    @FAmount = @ThanhTien, -- money							   		  @FAmount = NULL, -- money
	    @DiscountDate = @NgayLap, -- datetime					   		  @DiscountDate = '2019-12-22 09:57:12', -- datetime
	    @DiscountRate = 0, -- money								   		  @DiscountRate = NULL, -- money
	    @Discount = 0, -- money									   		  @Discount = NULL, -- money
	    @OtherDiscount = 0, -- money							   		  @OtherDiscount = NULL, -- money
	    @Charge = @ThanhTien, -- money									   		  @Charge = NULL, -- money
	    @User_ID = 'US000001', -- varchar(20)					   		  @IsClose = NULL, -- bit
	    @IsClose = 0, -- bit									   		  @Description = N'', -- nvarchar(255)
	    @Sorted = 0, -- bigint									   		  @Sorted = 0, -- bigint
	    @Description = @GhiChu, -- nvarchar(255)				   		  @User_ID = '', -- varchar(20)
	    @Active = 1 -- bit										   		  @Active = NULL -- bit
	
END 
GO 

--EXEC dbo.KSP_BuyProduct_SI_Insert 
--	@MaMH = 'MHADMIN000004', -- varchar(255)
--    @NgayLap = '2019-12-22 09:51:13', -- date
--    @MaNCC = 'NCC000004', -- varchar(255)
--    @TenNCC = N'VŨ TOÀN THIỆN', -- nvarchar(255)
--    @NhanVienMH = 'NV000002', -- varchar(255)
--    @DiaChi = N'', -- nvarchar(max)
--    @GhiChu = N'', -- nvarchar(max)
--    @DienThoai = '', -- varchar(10)
--    @SoHoaDonVat = '', -- varchar(255)
--    @DieuKhoanThanhToan = 'Công nợ', -- varchar(10)
--    @HinhThucTT = 'Tiền mặt', -- varchar(10)
--    @HanTT = '2019-12-22 09:51:13', -- date
--    @NgayGiao = '2019-12-22 09:51:13', -- date
--    @ThanhTien = 17000000, -- decimal
--    @ThanhToan = 17000000 -- decimal


IF(OBJECT_ID('KSP_BuyProduct_SID_Insert','P')IS NOT NULL)
	DROP PROC KSP_BuyProduct_SID_Insert
GO    
CREATE PROC KSP_BuyProduct_SID_Insert
@ID							VARCHAR(255),
@MaMH						VARCHAR(255),
@NgayLap					date,
@MaNCC						varchar(255),
@TenNCC						nvarchar(255),
@NhanVienMH					varchar(255),
@KhoXuat					varchar(255),
@DiaChi						nvarchar(Max),
@GhiChu						nvarchar(Max),
@DienThoai					varchar(10),
@SoHoaDonVat				varchar(255),
@SoPhieuNhapTay				varchar(255),
@DieuKhoanThanhToan			varchar(10),
@HinhThucTT					varchar(10),
@HanTT						date,
@NgayGiao					date,
@MaHH						varchar(255),
@TenHH						nvarchar(255),
@DonVi						varchar(255),
@SoLuong					decimal,
@DonGia						decimal,
@ThanhTien					decimal,
@ChietKhauTiLe				decimal,
@ChietKhau					decimal,
@ThanhToan					decimal
AS
BEGIN
	DECLARE @SOD_ID UNIQUEIDENTIFIER = CAST(cast(@ID as varbinary(16)) as uniqueidentifier)
	DECLARE @SOD_Cost DECIMAL = (SELECT SUM(Amount)/SUM(Quantity) FROM dbo.INVENTORY WHERE Product_ID = @MaHH)
	DECLARE @SOD_Profit DECIMAL

		EXEC dbo.STOCK_INWARD_DETAIL_Insert 
		@ID = @SOD_ID, -- uniqueidentifier			   @ID = NULL, -- uniqueidentifier
	    @Inward_ID = @MaMH, -- varchar(20)			   @Inward_ID = '', -- varchar(20)
	    @Stock_ID = @KhoXuat, -- varchar(20)		   @Product_ID = '', -- varchar(20)
	    @RefType = 1, -- int						   @ProductName = N'', -- nvarchar(255)
	    @Product_ID = @MaHH, -- varchar(20)			   @RefType = 0, -- int
	    @ProductName = @TenHH, -- nvarchar(255)		   @Stock_ID = '', -- varchar(20)
	    @Vat = 0, -- int							   @Unit = N'', -- nvarchar(20)
	    @VatAmount = 0, -- money					   @UnitConvert = NULL, -- money
	    @Unit = @DonVi, -- nvarchar(20)				   @Vat = 0, -- int
	    @UnitConvert = 1, -- money					   @VatAmount = NULL, -- money
	    @CurrentQty = @SoLuong, -- money			   @CurrentQty = NULL, -- money
	    @Quantity = @SoLuong, -- money				   @Quantity = NULL, -- money
	    @UnitPrice = @DonGia, -- money				   @UnitPrice = NULL, -- money
	    @Amount = @ThanhToan, -- money				   @Amount = NULL, -- money
	    @QtyConvert = @SoLuong, -- money			   @QtyConvert = NULL, -- money
	    @DiscountRate = @ChietKhauTiLe, -- money	   @DiscountRate = NULL, -- money
	    @Discount = @ChietKhau, -- money			   @Discount = NULL, -- money
	    @Charge = @ThanhTien, -- money				   @Charge = NULL, -- money
	    @Limit = @HanTT, -- datet					   @Limit = '2019-12-22 08:39:51', -- datet
	    @Batch = '', -- varchar(50)					   @Height = NULL, -- money
	    @Serial = '', -- varchar(50)				   @Orgin = N'', -- nvarchar(255)
	    @ChassyNo = '', -- varchar(50)				   @Size = N'', -- nvarchar(255)
	    @IME = '', -- varchar(50)					   @Color = '', -- varchar(20)
	    @Width = 0, -- money						   @Batch = '', -- varchar(50)
	    @Height = 0, -- money						   @Serial = '', -- varchar(50)
	    @Orgin = N'', -- nvarchar(255)				   @ChassyNo = '', -- varchar(50)
	    @Size = N'', -- nvarchar(255)				   @IME = '', -- varchar(50)
	    @Color = '', -- varchar(20)
		@StoreID = 0, -- bigint						   @StoreID = 0, -- bigint
	    @Description = @TenNCC, -- nvarchar(250)	   @Description = N'', -- nvarchar(255)
	    @Sorted = 0, -- bigint						   @Sorted = 0, -- bigint
	    @Active = 1 -- bit							   @Active = NULL -- bit
	
END 
GO 

IF(OBJECT_ID('KSP_BuyProduct_Delete','P') IS NOT NULL)
	DROP PROC KSP_BuyProduct_Delete
GO 
CREATE PROC KSP_BuyProduct_Delete
@MaMH VARCHAR(255)
AS
BEGIN
	EXEC dbo.STOCK_INWARD_Delete @ID = @MaMH -- varchar(20)
		DELETE dbo.DEBT WHERE RefID = @MaMH
	DELETE dbo.TRANS_REF where RefID = @MaMH
END 
GO

---------------------------------------------------------------------------------
---------------------------------------------------------------------------------

SELECT * FROM dbo.STOCK_OUTWARD WHERE ID LIKE'%BHADMIN%'
SELECT * FROM dbo.STOCK_OUTWARD_DETAIL WHERE Outward_ID LIKE '%BHADMIN%'
SELECT * FROM dbo.STOCK_INWARD WHERE ID LIKE '%MHADMIN%'
SELECT * FROM dbo.INVENTORY_DETAIL WHERE RefNo LIKE '%BHADMIN%'
SELECT * FROM dbo.INVENTORY WHERE Product_ID LIKE '%TBK0022%'
SELECT * FROM dbo.DEBT WHERE CustomerID LIKE '%KH000203%' 
SELECT * FROM dbo.TRANS_Ref WHERE RefID LIKE 'BHADMIN000005'

SELECT * FROM dbo.PROVIDER_PAYMENT
SELECT * FROM dbo.CUSTOMER_RECEIPT
GO  

SELECT * FROM dbo.STOCK_OUTWARD  
GO 
IF(OBJECT_ID('KSP_PT_Insert','P')IS NOT NULL)
	DROP PROC KSP_PT_Insert
GO    
CREATE PROC KSP_PT_Insert
@MaPT		VARCHAR(50),
@NgayLap	DATETIME,
@MaBH		VARCHAR(50),
@MaKH		VARCHAR(50),
@TenKH		NVARCHAR(255),
@SoTienTra	MONEY,
@TaoBoi		NVARCHAR(255),
@MaNV		VARCHAR(50),
@GhiChu		NVARCHAR(255)
AS
BEGIN
DECLARE @PTID UNIQUEIDENTIFIER = CAST(cast(@MaBH as varbinary(16)) as uniqueidentifier)	
EXEC dbo.CUSTOMER_RECEIPT_Insert 
	@ID = @PTID, -- uniqueidentifier
    @RefID = @MaPT, -- nvarchar(20)
    @RefDate = @NgayLap, -- datetime
    @RefOrgNo = @MaBH, -- nvarchar(20)
    @RefType = 41, -- smallint
    @RefStatus = 0, -- smallint
    @PaymentMethod = '11111111-1111-1111-1111-111111111111', -- uniqueidentifier
    @Barcode = N'', -- nvarchar(20)
    @CurrencyID = N'VND', -- nvarchar(3)
    @ExchangeRate = 1, -- money
    @BranchID = N'', -- nvarchar(20)
    @ContractID = N'', -- nvarchar(20)
    @CustomerID = @MaKH, -- nvarchar(20)
    @CustomerName = @TenKH, -- nvarchar(255)
    @CustomerAddress = N'', -- nvarchar(255)
    @CustomerTax = N'', -- nvarchar(20)
    @ContactName = N'', -- nvarchar(100)
    @Amount = @SoTienTra, -- money
    @FAmount = @SoTienTra, -- money
    @Discount = 0, -- money
    @FDiscount = 0, -- money
    @Reconciled = 0, -- bit
    @IsPublic = 0, -- bit
    @CreatedBy = @TaoBoi, -- nvarchar(20)
    @CreatedDate = @NgayLap, -- datetime
    @ModifiedBy = @TaoBoi, -- nvarchar(20)
    @ModifiedDate = @NgayLap, -- datetime
    @OwnerID = @MaNV, -- nvarchar(20)
    @Description = @GhiChu, -- nvarchar(255)
    @Sorted = 0, -- bigint
    @Active = 1 -- bit

UPDATE dbo.DEBT SET Payment = Payment + @SoTienTra,Balance = Amount-(Payment + @SoTienTra),FAmount = Amount-(Payment + @SoTienTra) WHERE RefID = @MaBH
END 

GO 
IF(OBJECT_ID('KSP_PT_Delete','P')IS NOT NULL)
	DROP PROC KSP_PT_Delete
GO    
CREATE PROC KSP_PT_Delete
@MaPT VARCHAR(50)
AS
BEGIN
	DECLARE @SoTienTra MONEY,@MaBH VARCHAR(50)
	SELECT @SoTienTra = Amount, @MaBH = RefOrgNo FROM dbo.CUSTOMER_RECEIPT WHERE RefID = @MaPT
	DELETE dbo.CUSTOMER_RECEIPT WHERE RefID = @MaPT
	UPDATE dbo.DEBT SET Payment = Payment - @SoTienTra,Balance = Amount - (Payment - @SoTienTra),FAmount = Amount-(Payment - @SoTienTra) WHERE RefID = @MaBH
END 
GO 

-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
IF(OBJECT_ID('KSP_PC_Insert','P')IS NOT NULL)
	DROP PROC KSP_PC_Insert
GO    
CREATE PROC KSP_PC_Insert
@MaPC		VARCHAR(50),
@NgayLap	DATETIME,
@MaMH		VARCHAR(50),
@MaNCC		VARCHAR(50),
@TenNCC		NVARCHAR(255),
@SoTienTra	MONEY,
@TaoBoi		NVARCHAR(255),
@MaNV		VARCHAR(50),
@GhiChu		NVARCHAR(255)
AS
BEGIN
DECLARE @PTID UNIQUEIDENTIFIER = CAST(cast(@MaMH as varbinary(16)) as uniqueidentifier)	

EXEC dbo.PROVIDER_PAYMENT_Insert  
	@ID = @PTID, -- uniqueidentifier											  @ID = NULL, -- uniqueidentifier
    @RefID = @MaPC, -- nvarchar(20)												  @RefID = N'', -- nvarchar(20)
    @RefDate = @NgayLap, -- datetime											  @RefDate = '2019-12-29 05:24:51', -- datetime
    @RefOrgNo = @MaMH, -- nvarchar(20)											  @RefOrgNo = N'', -- nvarchar(20)
    @RefType = 41, -- smallint													  @RefType = 0, -- smallint
    @RefStatus = 0, -- smallint													  @RefStatus = 0, -- smallint
    @PaymentMethod = '11111111-1111-1111-1111-111111111111', -- uniqueidentifier  @PaymentMethod = NULL, -- uniqueidentifier
    @Barcode = N'', -- nvarchar(20)												  @Barcode = N'', -- nvarchar(20)
    @CurrencyID = N'VND', -- nvarchar(3)										  @CurrencyID = N'', -- nvarchar(3)
    @ExchangeRate = 1, -- money													  @ExchangeRate = NULL, -- money
    @BranchID = N'', -- nvarchar(20)											  @BranchID = N'', -- nvarchar(20)
    @ContractID = N'', -- nvarchar(20)											  @ContractID = N'', -- nvarchar(20)
    @CustomerID = @MaNCC, -- nvarchar(20)										  @CustomerID = N'', -- nvarchar(20)
    @CustomerName = @TenNCC, -- nvarchar(255)									  @CustomerName = N'', -- nvarchar(255)
    @CustomerAddress = N'', -- nvarchar(255)									  @CustomerAddress = N'', -- nvarchar(255)
    @CustomerTax = N'', -- nvarchar(20)											  @CustomerTax = N'', -- nvarchar(20)
    @ContactName = N'', -- nvarchar(100)										  @ContactName = N'', -- nvarchar(100)
    @Amount = @SoTienTra, -- money												  @Amount = NULL, -- money
    @FAmount = @SoTienTra, -- money												  @FAmount = NULL, -- money
    @Discount = 0, -- money														  @Discount = NULL, -- money
    @FDiscount = 0, -- money													  @FDiscount = NULL, -- money
    @Reconciled = 0, -- bit														  @Reconciled = NULL, -- bit
    @IsPublic = 0, -- bit														  @IsPublic = NULL, -- bit
    @CreatedBy = @TaoBoi, -- nvarchar(20)										  @CreatedBy = N'', -- nvarchar(20)
    @CreatedDate = @NgayLap, -- datetime										  @CreatedDate = '2019-12-29 05:24:51', -- datetime
    @ModifiedBy = @TaoBoi, -- nvarchar(20)										  @ModifiedBy = N'', -- nvarchar(20)
    @ModifiedDate = @NgayLap, -- datetime										  @ModifiedDate = '2019-12-29 05:24:51', -- datetime
    @OwnerID = @MaNV, -- nvarchar(20)											  @OwnerID = N'', -- nvarchar(20)
    @Description = @GhiChu, -- nvarchar(255)									  @Description = N'', -- nvarchar(255)
    @Sorted = 0, -- bigint														  @Sorted = 0, -- bigint
    @Active = 1 -- bit															  @Active = NULL -- bit

UPDATE dbo.DEBT SET Payment = Payment + @SoTienTra,Balance = Amount-(Payment + @SoTienTra),FAmount = Amount-(Payment + @SoTienTra) WHERE RefID = @MaMH
END 

GO 
IF(OBJECT_ID('KSP_PC_Delete','P')IS NOT NULL)
	DROP PROC KSP_PC_Delete
GO    
CREATE PROC KSP_PC_Delete
@MaPC VARCHAR(50)
AS
BEGIN
	DECLARE @SoTienTra MONEY,@MaMH VARCHAR(50)
	SELECT @SoTienTra = Amount, @MaMH = RefOrgNo FROM dbo.PROVIDER_PAYMENT WHERE RefID = @MaPC
	DELETE dbo.PROVIDER_PAYMENT WHERE RefID = @MaPC
	UPDATE dbo.DEBT SET Payment = Payment - @SoTienTra,Balance = Amount - (Payment - @SoTienTra),FAmount = Amount-(Payment - @SoTienTra) WHERE RefID = @MaMH
END 
GO 

---------------------------------------------------------------------------------
---------------------------------------------------------------------------------

IF(OBJECT_ID('KSP_CNPT_Load','P')IS NOT NULL)
	DROP PROC KSP_CNPT_Load
GO    
CREATE PROC KSP_CNPT_Load
AS
BEGIN
	SELECT d.RefID AS MaBH, d.RefDate AS NgayLap,
	 d.CustomerID AS MaKH,
	(SELECT CustomerName FROM dbo.CUSTOMER WHERE Customer_ID = d.CustomerID) AS TenKH
	, d.Amount AS SoTienNo, d.Payment AS SoTienTra ,
	 d.FAmount AS SoTienConNo, d.Description AS GhiChu
	FROM dbo.DEBT d WHERE d.RefID LIKE '%BH%'
	AND d.FAmount >0
END 

GO 
IF(OBJECT_ID('KSP_CNPTTraNgay_Load','P')IS NOT NULL)
	DROP PROC KSP_CNPTTraNgay_Load
GO    
CREATE PROC KSP_CNPTTraNgay_Load
AS
BEGIN
	SELECT d.RefID AS MaBH, d.RefDate AS NgayLap,
	N'Thanh toán ngay' AS LoaiPhieu,
	 d.CustomerID AS MaKH,
	(SELECT CustomerName FROM dbo.CUSTOMER WHERE Customer_ID = d.CustomerID) AS TenKH
	, d.Amount AS SoTienNo, d.Payment AS SoTienTra ,
	 d.FAmount AS SoTienConNo, d.Description AS GhiChu
	FROM dbo.DEBT d 
	WHERE d.RefID LIKE '%BH%'
	AND (SELECT d.TermID FROM dbo.STOCK_OUTWARD WHERE ID = d.RefID) = 'TM'
	AND d.FAmount >0
END
GO
IF(OBJECT_ID('KSP_PhieuThu_Load','P')IS NOT NULL)
	DROP PROC KSP_PhieuThu_Load
GO    
CREATE PROC KSP_PhieuThu_Load
AS
BEGIN
	SELECT RefID AS MaPT, RefDate AS NgayLap,RefOrgNo AS MaBH,CustomerID AS MaKH,
	CustomerName AS TenKH,
	Amount AS SoTienTra,Description AS GhiChu
	FROM dbo.CUSTOMER_RECEIPT
END
GO 
---------------------------------------------------------------
---------------------------------------------------------------
IF(OBJECT_ID('KSP_CNPC_Load','P')IS NOT NULL)
	DROP PROC KSP_CNPC_Load
GO    
CREATE PROC KSP_CNPC_Load
AS
BEGIN
	SELECT d.RefID AS MaBH, d.RefDate AS NgayLap,
	 d.CustomerID AS MaNCC,
	(SELECT CustomerName FROM dbo.PROVIDER WHERE Customer_ID = d.CustomerID) AS TenNCC
	, d.Amount AS SoTienNo, d.Payment AS SoTienTra ,
	 d.FAmount AS SoTienConNo, d.Description AS GhiChu
	FROM dbo.DEBT d WHERE d.RefID LIKE '%MH%'
	AND d.FAmount >0
END 

GO 
IF(OBJECT_ID('KSP_CNPCTraNgay_Load','P')IS NOT NULL)
	DROP PROC KSP_CNPCTraNgay_Load
GO    
CREATE PROC KSP_CNPCTraNgay_Load
AS
BEGIN
	SELECT d.RefID AS MaBH, d.RefDate AS NgayLap,
	N'Thanh toán ngay' AS LoaiPhieu,
	 d.CustomerID AS MaNCC,
	(SELECT CustomerName FROM dbo.PROVIDER WHERE Customer_ID = d.CustomerID) AS TenNCC
	, d.Amount AS SoTienNo, d.Payment AS SoTienTra ,
	 d.FAmount AS SoTienConNo, d.Description AS GhiChu
	FROM dbo.DEBT d 
	WHERE d.RefID LIKE '%MH%'
	AND (SELECT d.TermID FROM dbo.STOCK_INWARD WHERE ID = d.RefID) = 'TM'
	AND d.FAmount >0
END
GO
IF(OBJECT_ID('KSP_PhieuChi_Load','P')IS NOT NULL)
	DROP PROC KSP_PhieuChi_Load
GO    
CREATE PROC KSP_PhieuChi_Load
AS
BEGIN
	SELECT RefID AS MaPC, RefDate AS NgayLap,RefOrgNo AS MaMH,CustomerID AS MaNCC,
	CustomerName AS TenNCC,
	Amount AS SoTienTra,Description AS GhiChu
	FROM dbo.PROVIDER_PAYMENT
END

GO 
------------------------------------------------------------------------
------------------------------------------------------------------------

SELECT * FROM dbo.SYS_USER
SELECT * FROM dbo.SYS_RULE
SELECT * FROM dbo.SYS_USER_RULE
ALTER TABLE dbo.SYS_USER DROP CONSTRAINT FK_SYS_USER_SYS_GROUP

--INSERT dbo.SYS_USER
--        ( UserID ,
--          UserName ,
--          Password ,
--          Group_ID ,
--          Description ,
--          PartID ,
--          Active
--        )
--VALUES  ( 'US000003' , -- UserID - varchar(20)
--          N'Nhân viên BH1' , -- UserName - nvarchar(50)
--          '111' , -- Password - varchar(50)
--          'NhanVien' , -- Group_ID - varchar(20)
--          N'' , -- Description - nvarchar(255)
--          '' , -- PartID - varchar(20)
--          1  -- Active - bit
--        )
--UPDATE dbo.SYS_USER SET Password='123' WHERE UserID ='US000002'
----DELETE dbo.SYS_USER WHERE UserID='US000002'
--INSERT dbo.SYS_USER
--        ( UserID ,
--          UserName ,
--          Password ,
--          Group_ID ,
--          Description ,
--          PartID ,
--          Active
--        )
--VALUES  ( 'US000002' , -- UserID - varchar(20)
--          N'Đỗ Công Khải' , -- UserName - nvarchar(50)
--          '123' , -- Password - varchar(50)
--          'admin' , -- Group_ID - varchar(20)
--          N'' , -- Description - nvarchar(255)
--          '' , -- PartID - varchar(20)
--          1  -- Active - bit
--        )
------------------------------------------------------------------------
------------------------------------------------------------------------
SELECT * FROM dbo.SYS_LOG
--DELETE dbo.SYS_LOG WHERE SYS_ID = 80846
EXEC dbo.SYS_LOG_GetList_ByDate @From = '2019-12-31', -- datetime
 @To = '2019-12-31' -- datetime


IF(OBJECT_ID('','P') IS NOT NULL)
	DROP PROC KSP_ThemNhatKy
GO
CREATE PROCEDURE [dbo].KSP_ThemNhatKy
    @MChine nvarchar(200),
    @IP varchar(20),
    @UserID varchar(20),
    @Created datetime,
    @Module nvarchar(200),
    @Action int,
    @Action_Name nvarchar(50),
    @Reference varchar(20),
    @Description nvarchar(255),
    @Active bit
AS
INSERT INTO [SYS_LOG] (
    MChine,
    IP,
    UserID,
    Created,
    Module,
    Action,
    Action_Name,
    Reference,
    Description,
    Active
)
VALUES (
    @MChine,
    @IP,
    @UserID,
    @Created,
    @Module,
    @Action,
    @Action_Name,
    @Reference,
    @Description,
    @Active)
GO

-----------------------------------------------------------
-----------------------------------------------------------
IF(OBJECT_ID('K_PERMISION','TT') IS NOT NULL)
CREATE TABLE [dbo].K_PERMISION
(
	ID			varchar(20),
	Name		nvarchar(255),
	Description nvarchar(255),
	ACTIVE		bit
    
	Primary key(ID)
)

GO 
IF(OBJECT_ID('K_Permision_Detail','TT') IS NOT NULL)
Create table K_Permision_Detail
(
	PER_ID			varchar(20),
	Object_ID		varchar(255),
	AllowView		BIT,
	AllowAdd		bit,
	AllowDelete		bit,
	AllowEdit		bit,
	Active			bit

	Primary Key(PER_ID,Object_ID)
)

-----------------------------------------------------------
-----------------------------------------------------------
select * from SYS_USER
select * from K_Permision
--INSERT dbo.K_PERMISION( ID, Name, Description, ACTIVE )VALUES  ( '',N'',N'',NULL)
--INSERT dbo.SYS_USER( UserID ,UserName ,Password ,Group_ID ,Description ,PartID ,Active)
--VALUES  ( '' ,N'' ,'' ,'' ,N'' ,'' ,NULL)
--UPDATE dbo.SYS_USER SET Group_ID ='',Description='',PartID='',Active='' WHERE UserID=''
--UPDATE dbo.K_PERMISION SET Name ='', Description='',ACTIVE=''WHERE ID=''
--UPDATE dbo.K_Permision_Detail SET AllowAdd='',AllowDelete='',AllowEdit='',AllowView='',Active=''WHERE PER_ID=''AND Object_ID=''
select * from K_Permision_Detail WHERE PER_ID='VT000001'

--INSERT dbo.K_Permision_Detail( PER_ID ,Object_ID ,AllowAdd ,AllowDelete ,AllowEdit ,Active ,AllowView)
--VALUES  ( '' ,'' ,NULL ,NULL ,NULL ,NULL ,NULL)

--INSERT dbo.K_PERMISION
--        ( ID, Name, Description )
--VALUES  ( 'admin', -- ID - varchar(20)
--          N'admin', -- Name - nvarchar(255)
--          N'Quản trị hệ thống'  -- Description - nvarchar(255)
--          ),
--		  ( 'QuanLy', -- ID - varchar(20)
--          N'Quản Lý', -- Name - nvarchar(255)
--          N'Quản Lý nhân viên'  -- Description - nvarchar(255)
--          ),
--		  ( 'NhanVien', -- ID - varchar(20)
--          N'Nhân Viên', -- Name - nvarchar(255)
--          N'Nhân Viên công ty'  -- Description - nvarchar(255)
--          )

--INSERT dbo.K_Permision_Detail
--        ( PER_ID ,
--          Object_ID ,
--		  AllowView,
--          AllowAdd ,
--          AllowDelete ,
--          AllowEdit ,
--          Active
--        )
--VALUES  
--( 'NhanVien' ,'btnThongTin'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnDoiMatKhau'		,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnNhatKyHeThong'	,0 ,0 ,0 ,0 ,0),
--( 'NhanVien' ,'btnVaiTro'			,0 ,0 ,0 ,0 ,0),
--( 'NhanVien' ,'btnKhuVuc'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnKhachHang'		,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnNhaPhanPhoi'		,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnKho'				,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnDonViTinh'		,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnNhomHang'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnHangHoa'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnTyGia'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnBoPhan'			,1 ,0 ,0 ,0 ,1),
--( 'NhanVien' ,'btnNhanVien'			,1 ,0 ,0 ,0 ,1),
--( 'NhanVien' ,'btnMuaHang'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnBanHang'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnTonKho'			,1 ,0 ,0 ,0 ,1),
--( 'NhanVien' ,'btnThuTien'			,1 ,1 ,1 ,1 ,1),
--( 'NhanVien' ,'btnTraTien'			,1 ,1 ,1 ,1 ,1)

--Insert into [dbo].[SYS_USER] ([UserID],[UserName],[Password],[Group_ID],[Description],[PartID],[Active]) 
--SELECT 'US000004',
--CONVERT(nvarchar(50),0x610064006d0069006e00)
--,CONVERT(varchar(50),0x4344303042384232334532463439323732324437364236323941393732433746) COLLATE DATABASE_DEFAULT
--,CONVERT(varchar(20),0x61646d696e) COLLATE DATABASE_DEFAULT,
--N''
--,''
--,1

--Insert into [dbo].[SYS_USER] ([UserID],[UserName],[Password],[Group_ID],[Description],[PartID],[Active]) 
--SELECT 'US000005',
--CONVERT(nvarchar(50),0x6b0061006900),
--CONVERT(varchar(50),0x6537396662373438633363386162353332613866636632646135336165353464) COLLATE DATABASE_DEFAULT,
--CONVERT(varchar(20),0x61646d696e) COLLATE DATABASE_DEFAULT,
--N'',
--'',
--1
--SELECT * FROM dbo.STOCK_INWARD_DETAIL
--SELECT * FROM dbo.STOCK_INWARD
