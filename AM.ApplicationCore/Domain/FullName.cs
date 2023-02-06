using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{

    //[Owned] ou fulent api (am context)
    public class FullName
    {
        //[MinLength(3, ErrorMessage = "the min length must be 3"), MaxLength(25, ErrorMessage = "the max length is 25")]
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
