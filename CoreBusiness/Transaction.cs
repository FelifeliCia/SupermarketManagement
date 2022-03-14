using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
   public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }//防止产品名称变换
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int Qty { get; set; }
        public string CashierName { get; set; }
    }
}
