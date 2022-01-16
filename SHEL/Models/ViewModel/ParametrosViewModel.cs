using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace SHEL.Models.ViewModel
{
    public class ParametrosViewModel
    { 

        [Required]
        public string Smtpserver { get; set; }
        
        [Required] 
        public int  Smtppuerto { get; set; }
        
        [Required] 
        [EmailAddress]
        [Display(Name ="Correo Electónico")]
        public string  Correo_sistema { get; set; }
        
        [Required]
        [StringLength(15,ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =4)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Clave_correo { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Clave_correo", ErrorMessage ="Las Claves no son iguales")]
        [DataType(DataType.Password)]
        public string Confirma_Clave_correo { get; set; }

    }
    public class EditParametrosViewModel
    {
        public int Registro_id { get; set; }
        [Required]
        public string Smtpserver { get; set; }

        [Required]
        public int Smtppuerto { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electónico")]
        public string Correo_sistema { get; set; }

     
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Clave_correo { get; set; }


        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Clave_correo", ErrorMessage = "Las Claves no son iguales")]
        [DataType(DataType.Password)]
        public string Confirma_Clave_correo { get; set; }

    }
}