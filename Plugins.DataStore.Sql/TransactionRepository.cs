using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transactions.ToList();
            else
                return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%")).ToList();
        }

        public IEnumerable<Transaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date == date).ToList();
            else
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%")
                && x.TimeStamp.Date == date.Date).ToList();

        }

        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date).ToList();
            else
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%")
                && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date).ToList();
        }

        public void Save(Product product, string cashierName, int qty)
        {
            var transaction = new Transaction
            {
                TimeStamp = DateTime.Now,
                ProductID = product.ProductId,
                ProductName = product.Name,
                CashierName = cashierName.ToLower(),
                Price = product.Price,
                BeforeQty = product.Quantity,
                Qty = qty
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
