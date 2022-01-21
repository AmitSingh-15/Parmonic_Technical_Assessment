using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SingleEntryLedger.Model;
using SingleEntryLedger.BL;

namespace SingleEntryLedger.Test
{
    public class LedgerTest
    {
        [Fact]
        public void Update_Ledger_Balance()
        {

            ILedgerManger _LedgerManger = new LedgerManger();

            // Act
            // (int accountId, DateTime tranDate, TranType type, string description, string notes, decimal amount)
            LedgerEntryItem LE1 = new LedgerEntryItem(1, DateTime.Now, TranType.CREDIT, "Starting Balance", "", 10000);
            LedgerEntryItem LE2 = new LedgerEntryItem(1, DateTime.Now, TranType.CREDIT, "Invoice", "", 10000);
            LedgerEntryItem LE3 = new LedgerEntryItem(1, DateTime.Now, TranType.DEBIT, "Rent", "", 5000);
            _LedgerManger.AddLedger(LE1);
            _LedgerManger.AddLedger(LE2);
            _LedgerManger.AddLedger(LE3);
            decimal finalBalance = _LedgerManger.GetBalance();


            // Assert
            Assert.NotNull(_LedgerManger);
            Assert.Equal(15000, finalBalance);

        }
    }
}
