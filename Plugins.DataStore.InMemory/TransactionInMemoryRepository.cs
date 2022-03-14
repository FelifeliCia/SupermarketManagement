using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            this.transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transactions;
            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return this.transactions.Where(x => x.TimeStamp.Date == date);
            else
                return transactions.Where(x =>
                x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp.Date == date.Date);

        }

        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return this.transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x =>
                x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
        }

        public void Save(Product product, string cashierName, int qty)
        {
            int maxId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                maxId = this.transactions.Max(x => x.ProductID);

            }
            this.transactions.Add(new Transaction
            {
                TransactionId = maxId + 1,
                TimeStamp = DateTime.Now,
                ProductID = product.ProductId,
                ProductName = product.Name,
                CashierName = cashierName,
                Price = product.Price,
                BeforeQty = product.Quantity,
                Qty = qty
            });
        }
    }
}
