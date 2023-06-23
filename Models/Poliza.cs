using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;

namespace ApiPolizaSeguros.Models
{
    public class Poliza
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nrPoliza")]
        public int? NrPoliza { get; set; }

        [BsonElement("indetificacionCliente")]
        public string? IndetificacionCliente { get; set; }

        [BsonElement("fechaPoliza")]
        public DateTime? FechaPoliza { get; set; }

        [BsonElement("coberturas")]
        public string? Coberturas { get; set; }



        [BsonElement("valorMax")]
        public decimal? ValorMax { get; set; }


        [BsonElement("plan")]
        public string? plan { get; set; }
        [BsonElement("placaAuto")]
        public string? PlacaAuto { get; set; }


        [BsonElement("modeloAuto")]
        public int? ModeloAuto { get; set; }



        [BsonElement("inspeccionAuto")]
        public Boolean? InspeccionAuto { get; set; }

        //Cliente
        [BsonElement("nombreCliente")]
        public string? NombreCliente { get; set; }

        [BsonElement("fechaNacimientoCliente")]
        public DateTime? FechaNacimientoCliente { get; set; }

        [BsonElement("ciudadCliente")]
        public string? CiudadCliente { get; set; }

        [BsonElement("direccionCliente")]
        public string? DireccionCliente { get; set; }

    }
}
