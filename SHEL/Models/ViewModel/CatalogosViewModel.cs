using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SHEL.Models.ViewModel
{
    public class CatalogosViewModel
    {
        [Required]
        public string  Catalogo { get; set; }
        public bool Estado { get; set; }
        
    }
    public class EditCatalogoViewModel
    {
        public int Registro_id { get; set; }
        [Required]
        public string Catalogo { get; set; }
        public bool Estado { get; set; }

    }
    public class EditAtributosCatalogoViewModel
    {
        public int Registro_id { get; set; }
        [Required]
        public int Catalogo_id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}