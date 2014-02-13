using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AirportModel;
using AirportEntities;
using System.Data.SqlClient;

namespace Airport_WCF_Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private SqlModel sqlModel;

        public Vol GetVol(int idVol)
        {
            sqlModel = new SqlModel();
            return sqlModel.GetVolDetails(idVol);
        }

        public Bagage GetBagage(int idBagage)
        {
            sqlModel = new SqlModel();
            return sqlModel.GetBagageDetails(idBagage);
        }

        public List<Bagage> GetBagagesFromVol(int idVol)
        {
            sqlModel = new SqlModel();
            return sqlModel.GetBagagesFromVol(idVol);
        }
        
    }
}
