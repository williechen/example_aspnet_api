using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TeaTimeDemo.Models.Models;

namespace TeaTimeDemo.DataAccess.Data {
    public class ApplicationDbContext: DbContext{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options){

        }

        public DbSet<Questions> Questions {get; set;}

        

    }
}