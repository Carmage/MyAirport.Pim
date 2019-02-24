namespace ClientPim
{
    public enum PimState
    {
        Deconnecter, // Etat de base
        AttenteBagage, // ? Lorsque l'utilisateur a fait la requête sur un code IATA et qu'il attend la réponse
        SelectionBagage, // Lorsque plusieurs bagages sont retournés
        CreationBagage, // Lorsque l'utilisateur crée un bagage (= code iata non trouvé)
        AffichageBagage // Lorsque la requête utilisateur a donné exactement 1 résultat
    }
}