using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Purchase> FirstPrices { get; set; }


        public DbSet<Platform> Platforms { get; set; }

        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<GamesInOrder> GamesInOrders { get; set; }



    }
}
