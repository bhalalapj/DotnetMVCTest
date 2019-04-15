using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TestMVCProject.Models;

namespace TestMVCProject.Data
{
    public class TestMVCProjContext : DbContext
    {

        public TestMVCProjContext() : base("TestMVCConnecitonString")
        { }

        public DbSet<JsonElement> JsonElements { get; set; }
        public DbSet<NASAElement> NasaModels { get; set; }


    }
}
