using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMeister.Data.Entities
{
    public class Task
    {
        public string name
        {
            get;
            set;
        }

        public DateTime startdate
        {
            get;
            set;
        }

        public DateTime enddate
        {
            get;
            set;
        }

        public Person responsible
        {
            get;
            set;
        }

        public bool finished
        {
            get;
            set;
        }

        public IList<Remark> comments
        {
            get;
            set;
        }
    }
}
