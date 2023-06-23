using ApiPolizaSeguros.Controllers;
using ApiPolizaSeguros.Models;
using ApiPolizaSeguros.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Runtime;

namespace Test
{
    public class PolizaTest
    {
        private readonly PolizaController _controller;
        private readonly PolizaService _Service;
        private readonly IPolizaSettings _Settings;
        //private IMongoCollection<Poliza> _polizas;
        public PolizaTest()
        {
            _Settings = new PolizaSettings();
            _Settings.Server = "mongodb://localhost:27017";
            _Settings.Database = "polizaseguros";
            _Settings.Collection = "poliza";
            
            _Service = new PolizaService(_Settings);
            _controller = new PolizaController(_Service);
        }

        [Fact]
        public void Get_Ok()
        {
            var result =_controller.Get();


         // ActionResult<List<Poliza>> salida = Assert.IsType<ActionResult<List<Poliza>>>(result.Value);
          Assert.True(result.Value.Count > 0);
            //Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetNoPoliza()
        {
            int poliza = 1;
            var result = _controller.GetNoPoliza(poliza);

            Assert.True(result.Value.Count > 0);
        }

        [Fact]
        public void GetPlaca()
        {
            string placa = "hh-22";
            var result = _controller.GetPlaca(placa);

            Assert.True(result.Value.Count > 0);  
        }
    }
}