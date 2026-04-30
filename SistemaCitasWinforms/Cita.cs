using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCitasWinforms
{
    public class Cita
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoEstudio { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoUltrasonido { get; set; }
    }
}
