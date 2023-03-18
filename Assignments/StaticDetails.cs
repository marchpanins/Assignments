using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    public class StaticDetails
    {
        public static int LoggedInUserId { get; set; }

        public static string ConnectionString { 
            get 
            { 
                return "Server=localhost;Database=assignmentsDb;Uid=root;Pwd=admin;"; 
            } 
        }
    }
}
