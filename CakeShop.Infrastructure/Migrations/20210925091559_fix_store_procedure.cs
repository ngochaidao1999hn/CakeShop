using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShop.Infrastructure.Migrations
{
    public partial class fix_store_procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"               
                    CREATE PROCEDURE getCountProductbyCategories 
     
                    AS 
                    select Categories.Cate_Name,Categories.Cate_Id,quantity
                    from
                    (
                    select Pro_Category as cate_id,Count(*) as quantity
                    from Products
                    group by Pro_Category) as list
                    join Categories on Categories.Cate_Id = list.cate_id
            ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
