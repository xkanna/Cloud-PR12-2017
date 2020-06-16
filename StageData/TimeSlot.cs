using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StageData
{
    public class TimeSlot : TableEntity
    {
        private string description;
        private DateTime from;
        private DateTime to;
        private int sifra;

        public DateTime To { get => to; set => to = value; }
        public string Description { get => description; set => description = value; }
        public DateTime From { get => from; set => from = value; }
        public int Sifra { get => sifra; set => sifra = value; }

        public TimeSlot()
        {

        }

        public TimeSlot(string description, DateTime from, DateTime to, int sifra)
        {
            this.description = description;
            this.from = from;
            this.to = to;
            this.sifra = sifra;
            PartitionKey = "TimeSlotsTable";
            RowKey = Sifra.ToString();
        }
    }
}