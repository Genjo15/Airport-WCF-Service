using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AirportEntities
{
    [DataContract]
    public class Bagage
    {
        [DataMember]
        public int idBagage { get; set; }

        [DataMember]
        public int idVol { get; set; }

        [DataMember]
        public string codeIata { get; set; }

        [DataMember]
        public DateTime dateCreation { get; set; }

        [DataMember]
        public string itineraire { get; set; }

        [DataMember]
        public string compagnie { get; set; }


    }
}
