using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StageData
{
    public class Artist : TableEntity
    {
        private string genre;
        private string name;
        private string surname;
        private int sifra;

        public string Genre { get => genre; set => genre = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Sifra { get => sifra; set => sifra = value; }

        public Artist()
        {

        }

        public Artist(string genre, string name, string surname, int sifra)
        {
            this.genre = genre;
            this.name = name;
            this.surname = surname;
            this.sifra = sifra;
            PartitionKey = "ArtistsTable";
            RowKey = sifra.ToString();
        }
    }
}