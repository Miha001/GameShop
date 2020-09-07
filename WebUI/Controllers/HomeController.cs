using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        EFDbContext EF = new EFDbContext();

        public ActionResult About()
        {
            return View();

        }
        public ActionResult Index()
        {


            IEnumerable<Characteristic> characteristics = EF.Characteristics;
            IEnumerable<Category> categories = EF.Categories;



            ViewBag.Characteristics = characteristics;
            ViewBag.Categories = categories;


            return View();
        }
        public ActionResult Goods()
        {

            //Извлекаем данные из колекций
            IEnumerable<GamesInOrder> games = EF.GamesInOrders;
            IEnumerable<Characteristic> characteristics = EF.Characteristics;
            IEnumerable<Platform> platforms = EF.Platforms;
            IEnumerable<Purchase> firstPrices = EF.FirstPrices;
            IEnumerable<Category> categories = EF.Categories;

            ViewBag.Games = games;
            ViewBag.Characteristics = characteristics;
            ViewBag.Platforms = platforms;
            ViewBag.FirstPrices = firstPrices;

            ViewBag.Categories = categories;

            return View();
        }
        public ActionResult Orders()
        {
            IEnumerable<Orders> orders = EF.Orders;
            IEnumerable<UserData> userdatas = EF.UserDatas;

            ViewBag.Orders = orders;
            ViewBag.UserDatas = userdatas;

            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
    
            return View();
        }
        //    if (game.GameId == 0)
        //        context.Games.Add(game);
        //    else
        //    {
        //        Game dbEntry = context.Games.Find(game.GameId);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Category = game.Category;
        //            dbEntry.Name = game.Name;
        //            dbEntry.Description = game.Description;
        //            dbEntry.Year = game.Year;
        //            dbEntry.Platform = game.Platform;
        //            dbEntry.Price = game.Price;
        //            dbEntry.Count = game.Count;
        //            dbEntry.ImageData = game.ImageData;
        //            dbEntry.ImageMimeType = game.ImageMimeType;
   
        [HttpPost]
       
        public string Edit(GamesInOrder gio, Characteristic ch, Platform pl, Category c,Purchase p)
        {
           
            Characteristic newCh = new Characteristic();
            Purchase newP = new Purchase();
            
                newCh.Name = ch.Name;
            newCh.SellingPrice = ch.SellingPrice;
            newCh.Year = ch.Year;
            newCh.Description = ch.Description;
            newCh.CategoryId = 1;
            if (pl.NameOfPlatform=="PC")
            {
                newCh.PlatformId = 1;
            }else if (pl.NameOfPlatform == "PS4")
            {
                newCh.PlatformId = 2;
            }else if (pl.NameOfPlatform == "XBOX ONE")
            {
                newCh.PlatformId = 3;
            }
            if (c.NameOfCategory == "Гонки")
            {
                newCh.PlatformId = 1;
            }
            else if (c.NameOfCategory == "RPG")
            {
                newCh.PlatformId = 2;
            }
            else if (c.NameOfCategory == "MMO")
            {
                newCh.PlatformId = 3;
            }
            else if (c.NameOfCategory == "Шутер")
            {
                newCh.PlatformId = 4;
            }
            else if (c.NameOfCategory == "Стратегия")
            {
                newCh.PlatformId = 5;
            }
            

            newCh.ImageData = ch.ImageData;
            newCh.ImageMimeType = ch.ImageMimeType;
            newP.Price = p.Price;
            newP.Count = p.Count;
            EF.Characteristics.Add(newCh);
            EF.FirstPrices.Add(newP);
            EF.SaveChanges();
            return $"Игра {ch.Name} сохранена";
        }
        [HttpGet]
        public ActionResult Buy()
        {

            return View();
        }
        [HttpPost]//Purchase 
        public string Buy(Orders o, UserData ud,Characteristic ch,GamesInOrder gio)
        {
            UserData newUD = new UserData();
            Orders newO = new Orders();
            GamesInOrder newGIO = new GamesInOrder();
            Purchase ppp = EF.FirstPrices
              .FirstOrDefault(g => g.PurchaseId == ch.CharacteristicId);
            ppp.Count--;
            newGIO.CharacteristicsId = ch.CharacteristicId;
            newGIO.CountOfSoldGames = 1;
            newGIO.PriceOfSoldGame = 200;
            newUD.Addres = ud.Addres;
            newUD.NameOfUser = ud.NameOfUser;
            newO.UDId = newUD.UDId;
            newO.DateOfOrder = DateTime.Now;
            newO.StatusOfOrder =o.StatusOfOrder ;
            EF.GamesInOrders.Add(newGIO);
            EF.UserDatas.Add(newUD);
            EF.Orders.Add(newO);
            EF.SaveChanges();
            return $"Уважаемый, {ud.NameOfUser}, с вами скоро свяжутся";
        }
        
    } 
}