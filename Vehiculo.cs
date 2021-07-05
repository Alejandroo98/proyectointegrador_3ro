using System;

namespace ProyectoIntegrador
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public Matricula MatriculaId { get; set; } = new Matricula();

        public override string ToString()
        {
            return String.Format($"Placa: { this.Placa } - { this.MatriculaId }");
        }

        public string getPlacas()
        {
            return Placa;
        }
        
    }

}