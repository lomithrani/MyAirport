using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyAirport.Entities
{
    [ServiceContract]
    public interface IMyAirportService
    {

        [OperationContract]
        VolDefinition DetailVol2(int id);

        #region Bagages

        [OperationContract]
        [FaultContract(typeof(MultipleBaggageException))]
        BagageDefinition RechercherBagagesParIata(string iata);

        [OperationContract]
        [FaultContract(typeof(PersoFaultException))]
        int CreerBaggage(BagageDefinition baggage);

        #endregion
    }
}