using MyAirport.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirport.Data
{
    /// <summary>
    /// Cette classe sert de classe mere pour chacun des modeles d'accès aux données que nous devons définir 
    /// </summary>
    public abstract class AbstractModel
    {
        /// <summary>
        /// Retour un vol unique via son identifiant
        /// </summary>
        /// <param name="idVol">Identifiant unique du vol</param>
        /// <returns>VolDefinition correspondant à l'identifiant fournit en paramètre</returns>
        public abstract VolDefinition GetVol(int idVol);
        public abstract List<VolDefinition> GetVols(VolCriteres criteres);

        public abstract BagageDefinition GetBagage(int idBagage);
        public abstract BagageDefinition GetBagageWithIata(string iata);
        public abstract List<BagageDefinition> GetBagages(BagageCriteres criteres);
        public abstract int SetBaggage(BagageDefinition baggage);
        
    }
}
