using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos_Ciudades_Guia7_Ejercicio3
{
    internal class Ciudad
    {
        public Ciudad(string nombre, int reclamos, int reparaciones)
        {
            Nombre = nombre;
            Reclamos = reclamos;
            Reparaciones = reparaciones;
        }
        public string Porcentaje()
        {
            double porcentaje = (Reparaciones*100 / Reclamos);
            return porcentaje+"%";
        }
        public int Faltantes()
        {
            return Reclamos-Reparaciones;
        }
        public int Reparaciones { get; set; }
        public string Nombre { get; set; }  
        public int Reclamos { get; set; }   
    }
}
