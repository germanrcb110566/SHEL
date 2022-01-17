using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHEL.Models.TableViewModels
{
    public class CatalogosTableViewModels
    {
        public int Registro_id { get; set; }
        public int Catalogo_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        
   
    }
}