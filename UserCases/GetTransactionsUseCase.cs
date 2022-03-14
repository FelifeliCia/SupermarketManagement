using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository iTransactionRepository;

        public GetTransactionsUseCase(ITransactionRepository iTransactionRepository)
        {
            this.iTransactionRepository = iTransactionRepository;
        }

        public IEnumerable<Transaction> Execute(
            string cashierName,
            DateTime startDate,
            DateTime endDate)
        {
            return iTransactionRepository.GetByDateRange(cashierName, startDate, endDate);
        }
    }
}
