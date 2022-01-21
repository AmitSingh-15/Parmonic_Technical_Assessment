using System;
using System.Collections.Generic;
using System.Text;

namespace SingleEntryLedger.Model
{
    public enum TranType
    {
        DEBIT, CREDIT
    }
    public sealed class LedgerEntryItem
    {


        public Guid transactionId { get; private set; }
        public  int accountId { get; private set; }
        public  DateTime tranDate { get; private set; }
        public  string description { get; private set; }
        public  string notes { get; private set; }
        public TranType tranType { get; private set; }
        public  decimal tranAmount { get; private set; }


        public LedgerEntryItem(int accountId, DateTime tranDate, TranType type, string description, string notes, decimal amount)
        {
            this.transactionId = Guid.NewGuid() ;
            this.accountId =  accountId;
            this.tranDate = tranDate;
            this.tranType = type;
            this.description = description;
            this.notes = notes;
            this.tranAmount = amount;

        }

    }
}

