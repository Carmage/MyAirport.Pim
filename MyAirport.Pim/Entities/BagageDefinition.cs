﻿using System;

namespace MyAirport.Pim.Entities
{
    sealed public class BagageDefinition
    {
        // public string IdBagage { get; set; }        // Identifiant bagage en base de données permet l'identification unique d'un bagage

        public string CodeIata { get; set; }        // Numéro du bagage présent sur l'étiquette

        public string NomCompagnie { get; set; }    // Nom complet de la compagnie aérienne

        public string Compagnie { get; set; }       // Code Iata de la compagnie aérienne sur 2 lettres

        public string Ligne { get; set; }           // Numéro de vol 3 ou 4 digits et parfois une lettre a la fin

        public DateTime DateVol { get; set; }       // Jour et heure de depart du vol

        public string Itineraire { get; set; }      // Arrêt où descend le passager pour ce vol

        public string ClasseBagage { get; set; }    // Classe du bagage en fonction de la compagnie

        public bool Prioritaire { get; set; }       // Est-ce que le passager est un passager prioritaire?

        public bool EnContinuation { get; set; }    // Si la destination est différente de l'itineraire, est-ce que le bagage doit être livré au passager au prochain arrêt?

        public bool Rush { get; set; }              // Bagage sans passager (pour les bagages ayant ratés un vol)

        public override string ToString()
        {
            return "Object=Bagage" +
                    // ", ID=" + IdBagage +
                    ", IATA=" + CodeIata +
                    ", ClassBagage=" + ClasseBagage +
                    ", Prioritaire=" + Prioritaire +
                    ", Compagnie=" + Compagnie +
                    ", Ligne=" + Ligne +
                    ", DateVol=" + DateVol +
                    ", Itineraire=" + Itineraire +
                    ", EnContinuation=" + EnContinuation +
                    ", Rush=" + Rush;
        }
    }
}