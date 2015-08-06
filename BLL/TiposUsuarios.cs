using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class TiposUsuarios {

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; }

        public enum Tipos {
            Administrador = 1,
            Productor = 2,
            Cliente = 3
        }
    }
}
