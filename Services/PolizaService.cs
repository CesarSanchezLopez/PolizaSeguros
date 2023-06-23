using ApiPolizaSeguros.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiPolizaSeguros.Services
{
    public class PolizaService
    {
        private IMongoCollection<Poliza> _polizas;

        public PolizaService(IPolizaSettings settings)
        {

            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _polizas = database.GetCollection<Poliza>(settings.Collection); 
        }

        public List<Poliza> Get()
        {
            return _polizas.Find(d => true).ToList();
        }

        public List<Poliza> GetPlaca(string placa)
        {
            //var foundItems = _polizas.Find(x => criteria.Any(cc => xx.StringList.Contains(cc))).ToList();
             return _polizas.Find(d => d.PlacaAuto==placa).ToList();
        }

        public List<Poliza> GetNoPoliza(int nrPoliza)
        {
            //var foundItems = _polizas.Find(x => criteria.Any(cc => xx.StringList.Contains(cc))).ToList();
            return _polizas.Find(d => d.NrPoliza == nrPoliza).ToList();
        }

        public  Poliza Create(Poliza poliza)
        {
            _polizas.InsertOne(poliza);
            return poliza;
        }
        public void Update(string id, Poliza poliza)
        {
            _polizas.ReplaceOne (poliza=> poliza.Id==id, poliza);
          
        }

        public void Delete(string id)
        {
            _polizas.DeleteOne(d => d.Id == id);
        }
    }
}
