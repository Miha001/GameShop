using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Abstract;
namespace Domain.Concrete
{
    public class EFStockRepository:IStockRepository
    {
         EFDbContext context = new EFDbContext();


        public IEnumerable<Stock> Stocks
        {
            get { return context.Stocks;
            }
        }

        public void SaveStock(Stock stock)
        {
            if (stock.StockId == 0)
                context.Stocks.Add(stock);
            else
            {
               

                Stock dbStock = context.Stocks.Find(stock.StockId);

                if (dbStock != null)
                {
                    dbStock.NameOfGame = stock.NameOfGame;
                    dbStock.Count = stock.Count;
                }
            }
            context.SaveChanges();
        }
        public Stock DeleteStock(int stockId)
        {
            
            Stock dbStock = context.Stocks.Find(stockId);
            if (dbStock != null)
            {
        
                context.Stocks.Remove(dbStock);
                context.SaveChanges();
            }
            return dbStock;
        }
    }
}
