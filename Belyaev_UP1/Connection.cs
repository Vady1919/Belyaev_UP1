using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belyaev_UP1
{
    internal class Connection
    {
        private static UP_1Entities Context;
        public static UP_1Entities GetContext()
        {
            if (Context == null)
            {
                Context = new UP_1Entities();
            }
            return Context;
        }
        public static void SaveContext(UP_1Entities Context)
        {
            Context.SaveChanges();
        }
    }
}
