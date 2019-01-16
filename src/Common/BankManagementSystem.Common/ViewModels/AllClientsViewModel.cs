using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Web.ViewModels
{
    public class AllClientsViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
