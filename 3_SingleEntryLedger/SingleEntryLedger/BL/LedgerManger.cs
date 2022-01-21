using System;
using System.Collections.Generic;
using System.Text;
using SingleEntryLedger.Model;

namespace SingleEntryLedger.BL
{
   public class LedgerEntry : ILedgerManger
    {
        private readonly List<LedgerEntryItem> items = new List<LedgerEntryItem>();

        public List<LedgerEntryItem> GetAllTransactions()
        {
            return this.items;
        }

        public void AddLedger(LedgerEntryItem item)
        {
            this.items.Add(item);
        }

        public decimal GetBalance()
        {
            decimal total = 0;
            foreach (LedgerEntryItem item in this.items)
            {
                if (item.tranType == TranType.DEBIT)
                {
                    total -= item.tranAmount;
                }
                else
                { // item.type() == Type.CREDIT
                    total += item.tranAmount;
                }
            }
            return total;
        }
    }
}
