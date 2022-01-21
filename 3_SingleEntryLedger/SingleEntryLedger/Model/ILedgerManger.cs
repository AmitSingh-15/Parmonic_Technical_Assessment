using System;
using System.Collections.Generic;
using System.Text;

namespace SingleEntryLedger.Model
{
    public interface ILedgerManger
    {
        public List<LedgerEntryItem> GetAllTransactions();
        public void AddLedger(LedgerEntryItem item);
        public decimal GetBalance();

    }
}
