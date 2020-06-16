using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StageData
{
    public class Stage : TableEntity
    {
        private string name;
        private int sifra;

        public string Name { get => name; set => name = value; }
        public int Sifra { get => sifra; set => sifra = value; }

        public Stage()
        {

        }

        public Stage(string name, int sifra)
        {
            this.name = name;
            this.sifra = sifra;
            PartitionKey = "StagesTable";
            RowKey = Sifra.ToString();
        }
    }
}