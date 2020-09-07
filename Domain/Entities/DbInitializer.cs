using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Concrete;
namespace Domain.Entities
{
    public class DbInitializer:DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.Categories.Add(new Category() {NameOfCategory="Гонки"});
            context.Categories.Add(new Category() { NameOfCategory = "RPG" });
            context.Categories.Add(new Category() { NameOfCategory = "MMO" });
            context.Categories.Add(new Category() { NameOfCategory = "Шутер" });
            context.Categories.Add(new Category() { NameOfCategory = "Стратегия" });
            context.Platforms.Add(new Platform() { NameOfPlatform="PC"});
            context.Platforms.Add(new Platform() { NameOfPlatform = "PS4" });
            context.Platforms.Add(new Platform() { NameOfPlatform = "XBOX ONE" });
            context.Characteristics.Add(new Characteristic() {Description="Лучшая гонка дисятелетия, принесшая море фана и радости фанатам.",Name="NFS",Year="2010",SellingPrice=200});

            context.FirstPrices.Add(new Purchase() {Count=10,Price=200});
            
            base.Seed(context);
        }
    }
}
