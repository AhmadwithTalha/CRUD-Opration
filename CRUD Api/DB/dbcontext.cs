using CRUD_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Api.DB
{
    public class dbcontext : DbContext
    {
          public dbcontext(DbContextOptions<dbcontext>options):base(options)
        {

        }
        public DbSet<crudclass> Data {  get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
