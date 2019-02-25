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

        public override bool InsertBagage(BagageDefinition b)
        {
            throw new NotImplementedException();
        }
    }
}