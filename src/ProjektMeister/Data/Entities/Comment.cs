using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMeister.Data.Entities
{
    public class Comment
    {
        public DateTime created
        {
            get;
            set;
        }

        public string author
        {
            get;
            set;
        }

        public string body
        {
            get;
            set;
        }
    }
}
