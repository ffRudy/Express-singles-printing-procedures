using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.NewFolder1
{
    class RootObject
    {
        public string EBusinessID { get; set; }
        public string State{ get; set; }
        public List<Shipper> Shippers { get; set; }
        public List<Trace> Traces { get; set; }
    }
}