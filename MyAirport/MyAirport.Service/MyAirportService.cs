using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Threading;
using MyAirport.Entities;
using MyAirport.Factory;

namespace MyAirport.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class MyAirportService : IMyAirportService
    {
        public static int NbInstance;

        public int NbAppel;

        public MyAirportService()
        {
            NbInstance++;
        }

        public VolDefinition DetailVol2(int id)
        {
            return ModelsFactory.Model.GetVol(id);
           
        }

        public BagageDefinition RechercherBagagesParIata(string iata)
        {
            NbAppel++;

            var baggages = ModelsFactory.Model.GetBagageWithIata(iata);

            if (baggages.Count == 1)
            {
                return baggages.First();
            }
            if (baggages.Count > 1)
            {
               var exception = new MultipleBaggageException
                {
                    Message = baggages.Count + " baggages returned",
                    Baggages = baggages
                };

                throw new FaultException<MultipleBaggageException>(exception);
            }

            return null;
        }

        public int CreerBaggage(BagageDefinition baggage)
        {
            NbAppel++;
            return ModelsFactory.Model.SetBaggage(baggage);
        }

      
        ~MyAirportService()
        {
            NbInstance--;
        }
    }
}