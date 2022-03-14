using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);

        public IEnumerable<Transaction> GetByDate(string cashierName, DateTime date);
        public void Save(Product product, string cashierName, int qty);
        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate);
    }
}
