using MyAirport.Pim.Entities;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    abstract public class AbstractDefinition
    {
        public abstract BagageDefinition GetBagage(int idBagage);

        public abstract BagageDefinition GetBagage(string codeIataBagage);

        public abstract bool InsertBagage(string codeIata, bool enContinuation, string ligne, string nomCompagnie, string compagnie, string dateVol, string classeBagage, string itineraire, bool rush, out string message);
    }
}