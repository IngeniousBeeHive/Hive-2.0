//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hive2._0.Models
{
    using System;
    using System.Collections.Generic;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;


    public partial class User
    {
        public int UserId { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "Required Username...")]                //Validation for login

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required password...")]

        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
