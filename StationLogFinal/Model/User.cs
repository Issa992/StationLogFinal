using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
   public class User
    {
        public string UId
        {
            get; set;
        }


        public string Name { get; set; }

        public string Email { get; set; }

        public string HashPass { get; set; }

        public string PhoneNumber { get; set; }
        public string PermissionLevel { get; set; }

    }
}
