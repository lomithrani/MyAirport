using System;
using System.Collections.Generic;
using System.ServiceModel;
using MyAirport.Entities;

namespace MyAirport.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAirportService" à la fois dans le code et le fichier de configuration.
    //    [ServiceContract(CallbackContract, ConfigurationName, ProtectionLevel, Name="test", Namespace="http://MyAirport.com/ece/2014/", SessionMode=SessionMode.Allowed]
    [ServiceContract]
    public interface IMyAirportService
    {
        #region Tests

        [FaultContract(typeof(PersoFaultException))]
        [OperationContract]
        int TestFaultException(int v1, int v2);

        #endregion

        [OperationContract]
        Parametres MesParamatres();

        [OperationContract(Action = "TestAction", IsOneWay = true)]
        void UpdateMesParametres(Parametres parameters);

        [OperationContract]
        List<Historique> MonHistorique();

        #region Vols

        [OperationContract]
        void CreateVol(VolDefinition newVol);


        [OperationContract]
        List<VolDefinition> RechercherVolsDeLaCompagnie(string compagnie);

        [OperationContract]
        List<VolDefinition> RechercherVolsParDate(DateTime debut, DateTime fin);

        [OperationContract]
        List<VolDefinition> RechercherVolsDuJour();

        [OperationContract]
        VolDefinition DetailVol2(int id);

        #endregion

        #region Bagages

        [OperationContract]
        List<BagageDefinition> RechercherBagagesDuVol(int idVol);

        [OperationContract]
        List<BagageDefinition> RechercherBagagesParDate(DateTime debut, DateTime fin);

        [OperationContract]
        List<BagageDefinition> RechercherBagagesDuJour();

        [OperationContract]
        BagageDefinition DetailBagage(int id);

        [OperationContract]
        BagageDefinition RechercherBagagesParIata(string iata);

        [OperationContract]
        [FaultContract(typeof(PersoFaultException))]
        int CreerBaggage(BagageDefinition baggage);

        #endregion
    }
}