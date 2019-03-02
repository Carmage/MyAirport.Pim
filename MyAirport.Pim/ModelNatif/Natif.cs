using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    public class Natif : AbstractDefinition
    {
        public override BagageDefinition GetBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            throw new NotImplementedException();
        }

        public override string InsertBagage(string codeIata, bool enContinuation, string ligne, string nomCompagnie, string compagnie, string dateVol, string classeBagage, string itineraire, bool rush)
        {
            throw new NotImplementedException();
        }
    }
}