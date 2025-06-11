using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.DTOs.Account
{
    public class EditEmailDto
    {
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string NewEmail { get; set; }
    }
}
