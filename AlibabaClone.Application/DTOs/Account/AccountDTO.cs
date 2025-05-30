using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.DTOs.Account
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { set; get; }
        public string? Email { get; set; }
        public long? PersonId { get; set; }
        public List<string> Roles { get; set; }
    }
}
