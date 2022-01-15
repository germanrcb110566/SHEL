using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SHEL.Models.ViewModel
{
    public class ParametrosViewModel
    {
        [Required]
        public string smtpserver { set; get; }
        [Required] 
        public int  smtppuerto { set; get; }
        [Required] 
        [EmailAddress]
        [Display(Name ="Correo Electónico")]
        public string  correo_sistema { set; get; }
        [Required]
        [StringLength(5,ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =4)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string  clave_correo { set; get; }
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("",ErrorMessage ="Las contraseñas no son iguales")]
        public string  confirmar_clave_correo { set; get; }
    }
}