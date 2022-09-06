using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataBaseConnection;

namespace Host
{
   public class State
    {
        public DataSet getStates()
        {
            Code c = new Code();
            return c.getState();
        }
    }
}
