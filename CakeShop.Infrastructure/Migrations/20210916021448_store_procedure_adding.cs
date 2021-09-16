using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShop.Infrastructure.Migrations
{
    public partial class store_procedure_adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"create procedure getTop5BestSeller 
as
 select * from Products
	where Pro_Id in (
	Select top 5 OrderDetails.Detail_Product
	from OrderDetails
	group by Detail_Product
	order by SUM(Detail_Quantity) DESC	
	)   ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
