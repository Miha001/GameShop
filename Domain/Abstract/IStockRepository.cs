using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Abstract
{
    public interface IStockRepository
    {
        IEnumerable<Stock> Stocks { get; }

 

        void SaveStock(Stock stock);

        Stock DeleteStock(int stockId);
    }
}
