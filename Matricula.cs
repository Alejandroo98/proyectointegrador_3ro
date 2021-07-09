using System;
using System.Collections.Generic;

namespace ProyectoIntegrador
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public string NumeroMatricula { get;set; }
        public DateTime FechaEmisiónMatricula { get; set; }
        public DateTime FechaCaducidadMatricula { get; set; }
        

        public override string ToString()
        {
            return String.Format($"Numero matricula: { this.NumeroMatricula } - Fecha emision: { this.FechaEmisiónMatricula.ToString("dd-MM-yyyy") } - Fecha caducidad: { this.FechaCaducidadMatricula.ToString("dd-MM-yyyy") }");
        }
        
    }
}