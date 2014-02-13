using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AirportEntities
{
    [DataContract]
    public class Vol
    {
        [DataMember]
        public int idVol { get; set; }

        [DataMember]
        public string company { get; set; }

        [DataMember]
        public int lineNumber { get; set; }

        [DataMember]
        public DateTime lastTime { get; set; }

        [DataMember]
        public string parking { get; set; }

        [DataMember]
        public string status { get; set; }
    }
}
