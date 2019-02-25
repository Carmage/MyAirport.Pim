using MyAirport.Pim.Entities;
using System.Collections.Generic;

namespace MyAirport.Pim.Models
{
    abstract public class AbstractDefinition
    {
        public abstract BagageDefinition GetBagage(int idBagage);

        public abstract List<BagageDefinition> GetBagage(string codeIataBagage);
        
        public abstract bool InsertBagage(BagageDefinition b);
    }
}