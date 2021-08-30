using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopIdentity.Data.Migrations
{
    public partial class SqlViewsMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"Create View VW_ShopHistory
                  as
                  Select U.Id, U.FirstName,U.LastName,U.Email,O.OrderId,O.OrderDate,P.Name,ORow.Price
                  From [dbo].[AspNetUsers] as U Inner Join [dbo].[Orders] as O
                  On U.Id=O.ApplicationUserId Inner Join [dbo].[OrderRows] as ORow
                  On O.OrderId=ORow.OrderId Inner Join [dbo].[Products] as P
                  On ORow.ProductId=P.ProductID
                 ");

            migrationBuilder.Sql(
                @"CREATE VIEW[dbo].[VW_Stores]
                AS
              	SELECT 
	            s.Id as Id,
	            s.ReceipDate as ReceipDate,
	            s.DocumentTypeId as DocumentTypeId,
	            d.DocumentName as DocumentName
	            FROM [dbo].[Stores] s Inner Join [dbo].[DocumentTypes] d
	            On s.DocumentTypeId=d.Id
                ");

            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[VW_StoreRows]
	            AS 
                SELECT 
            	Isnull(sr.Id,0) as Id,
	            Isnull(sr.StoreId,0) as StoreId,
	            Isnull(sr.Debit,0) as Debit,
	            IsNull(sr.Credit,0)as Credit,
	            p.ProductID as ProductID,
	            p.[Name] as ProductName,
	            p.ProductCategoryID as ProductCategoryID,
	            p.ProductPrice as ProductPrice ,
	            p.PhotoName as PhotoName
	            FROM [dbo].[StoreRows] sr  Right Join [dbo].[Products] p On p.ProductID=sr.ProductId
                ");
            migrationBuilder.Sql(
            @"CREATE VIEW [dbo].[VW_OrderRow]
	            AS 
	            SELECT o.OrderId,o.OrderDate,o.ApplicationUserId,orow.Id as OrderRowId,orow.Price,orow.OrderStateId,os.StateName,orow.ProductId,p.[Name] as ProductName
	            FROM [dbo].[Orders] o  Left Join [dbo].[OrderRows] orow On o.OrderId=orow.OrderId
	            Inner Join [dbo].[Products] p On p.ProductID=orow.ProductId
		        Inner Join  [dbo].[OrderStates] os On orow.OrderStateId=os.Id"
            );
            migrationBuilder.Sql(
            @"CREATE view VW_StoreBalance
                as
                select 
                v.ProductID,
                 v.ProductName,
                 pc.[Name]as CatName,
                v.PhotoName,
                 v.ProductPrice,
                v.sumIn,
                v.sumOut,
                (v.sumIn-v.sumOut) Inventory
                from(
                select productId,ProductName,ProductCategoryID,ProductPrice,PhotoName,sum(debit) sumIn,sum(credit) sumOut
                from [dbo].[VW_StoreRows] 
                group by productId,ProductName,ProductCategoryID,ProductPrice,PhotoName) v Inner Join [dbo].[ProductCategorys] pc on v.ProductCategoryID=pc.ProductCategoryID
                ");
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[VW_UserCity]
	            AS 
	            SELECT
                 u.Id as Id,
                u.UserName as UserName ,
                Isnull(c.Id,0) as Cityid,
	            Isnull(c.CityName,'') as CityName
                FROM [dbo].[AspNetUsers] u  left Join [dbo].[Cties] c on u.CityId=c.Id"
                );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
