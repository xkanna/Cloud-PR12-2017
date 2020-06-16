
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageData
{
    public class StageDatabase
    { 
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;

        public StageDatabase()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new
            Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            _table = tableClient.GetTableReference("Stages");
            _table.CreateIfNotExists();
        }

        public IQueryable<Stage> RetrieveAllStages()
        {
            var results = from g in _table.CreateQuery<Stage>()
                          where g.PartitionKey == "StagesTable"
                          select g;
            return results;
        }
        public IQueryable<Artist> RetrieveAllArtists()
        {
            var results = from g in _table.CreateQuery<Artist>()
                          where g.PartitionKey == "ArtistsTable"
                          select g;
            return results;
        }
        public IQueryable<TimeSlot> RetrieveAllTimeSlots()
        {
            var results = from g in _table.CreateQuery<TimeSlot>()
                          where g.PartitionKey == "TimeSlotsTable"
                          select g;
            return results;
        }
        public void AddStage(Stage newStage)
        {
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Insert(newStage);
            _table.Execute(insertOperation);
        }
        public void AddArtist(Artist newArtist)
        {
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Insert(newArtist);
            _table.Execute(insertOperation);
        }
        public void AddTimeSlot(TimeSlot TimeSlot)
        {
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Insert(TimeSlot);
            _table.Execute(insertOperation);
        }
        public void RemoveArtist(int id)
        {
            Artist b = new Artist();
            foreach(Artist a in _table.CreateQuery<Artist>())
            {
                if(a.Sifra == id)
                {
                    b = a;
                }
            }
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Delete(b);
            _table.Execute(insertOperation);
        }
        public void RemoveStage(int id)
        {
            Stage b = new Stage();
            foreach (Stage a in _table.CreateQuery<Stage>())
            {
                if (a.Sifra == id)
                {
                    b = a;
                }
            }
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Delete(b);
            _table.Execute(insertOperation);
        }
        public void RemoveTimeSlot(int id)
        {
            TimeSlot b = new TimeSlot();
            foreach (TimeSlot a in _table.CreateQuery<TimeSlot>())
            {
                if (a.Sifra == id)
                {
                    b = a;
                }
            }
            // Samostalni rad: izmestiti tableName u konfiguraciju servisa.
            TableOperation insertOperation = TableOperation.Delete(b);
            _table.Execute(insertOperation);
        }
        public void UpdateTimeSlot(TimeSlot ts)
        {
            
            foreach (TimeSlot a in _table.CreateQuery<TimeSlot>())
            {
                if (a.Sifra == ts.Sifra)
                {
                    TableOperation insertOperation = TableOperation.InsertOrReplace(ts);
                    _table.Execute(insertOperation);
                }
            }
            
            
        }
        public void UpdateStage(Stage ts)
        {

            foreach (Stage a in _table.CreateQuery<Stage>())
            {
                if (a.Sifra == ts.Sifra)
                {
                    TableOperation insertOperation = TableOperation.InsertOrReplace(ts);
                    _table.Execute(insertOperation);
                }
            }


        }
        public void UpdateArtist(Artist ts)
        {

            foreach (Artist a in _table.CreateQuery<Artist>())
            {
                if (a.Sifra == ts.Sifra)
                {
                    TableOperation insertOperation = TableOperation.InsertOrReplace(ts);
                    _table.Execute(insertOperation);
                }
            }


        }

    }
}
