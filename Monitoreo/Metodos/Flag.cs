using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoreo
{
    class Flag
    {
        //Encapsulamiento de las variables las cuales son para las bases de datos
        public int id_flag { get; set; }
        public int id_PLaza { get; set; }
        public bool conexion { get; set; }
        public bool LSTABINT { get; set; }
        public bool WS { get; set; }
    }
}
