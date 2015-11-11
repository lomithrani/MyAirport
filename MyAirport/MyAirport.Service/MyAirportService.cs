using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;
using System.Threading;
using MyAirport.Entities;
using MyAirport.Factory;

namespace MyAirport.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AirportService" à la fois dans le code et le fichier de configuration.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class MyAirportService : IMyAirportService
    {
        public static int NbInstance;

        public int NbAppel;

        public MyAirportService()
        {
            //WindowsPrincipal user = new WindowsPrincipal((WindowsIdentity)Thread.CurrentPrincipal.Identity);
            NbInstance++;
        }

        public int TestFaultException(int v1, int v2)
        {
            var res = 0;
            try
            {
                res = v1 / v2;
            }
            catch (DivideByZeroException)
            {
                var p = new PersoFaultException();
                p.Message = string.Format("Impossible de diviser {0} par {1}", v1, v2);
                p.V1 = v1;
                p.V2 = v2;
                throw new FaultException<PersoFaultException>(p);
            }
            return res;
        }


        public VolDefinition DetailVol2(int id)
        {
            VolDefinition res = null;
            if (Thread.CurrentPrincipal.IsInRole("CEB-CDG1"))
            {
                res = ModelsFactory.Model.GetVol(id);
            }
            else
            {
                res = ModelsFactory.Model.GetVol(id);
                res.CIE = null;
            }
            var user = Thread.CurrentPrincipal.Identity.Name;
            NbAppel++;
            //            return MyAirport.Factory.ModelsFactory.Model.GetVol(id);
            return res;
        }

        public List<VolDefinition> RechercherVolsDeLaCompagnie(string compagnie)
        {
            NbAppel++;
            var c = new VolCriteres();
            c.Compagnies = new List<string>();
            c.Compagnies.Add(compagnie);
            return ModelsFactory.Model.GetVols(c);
        }

        public List<VolDefinition> RechercherVolsParDate(DateTime debut, DateTime fin)
        {
            NbAppel++;
            var c = new VolCriteres();
            c.dateDebut = debut;
            c.dateFin = fin;
            return ModelsFactory.Model.GetVols(c);
        }

        public List<VolDefinition> RechercherVolsDuJour()
        {
            NbAppel++;
            var c = new VolCriteres();
            return ModelsFactory.Model.GetVols(c);
        }

        public List<BagageDefinition> RechercherBagagesDuVol(int idVol)
        {
            NbAppel++;
            var b = new BagageCriteres();
            return ModelsFactory.Model.GetBagages(b);
        }

        public List<BagageDefinition> RechercherBagagesParDate(DateTime debut, DateTime fin)
        {
            NbAppel++;
            var b = new BagageCriteres();
            return ModelsFactory.Model.GetBagages(b);
        }

        public List<BagageDefinition> RechercherBagagesDuJour()
        {
            NbAppel++;
            var b = new BagageCriteres();
            return ModelsFactory.Model.GetBagages(b);
        }

        public BagageDefinition DetailBagage(int id)
        {
            NbAppel++;
            return ModelsFactory.Model.GetBagage(id);
        }

        public BagageDefinition RechercherBagagesParIata(string iata)
        {
            NbAppel++;
            return ModelsFactory.Model.GetBagageWithIata(iata);
        }

        public int CreerBaggage(BagageDefinition baggage)
        {
            NbAppel++;
            return ModelsFactory.Model.SetBaggage(baggage);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "CDG1")]
        public Parametres MesParamatres()
        {
            throw new NotImplementedException();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "CDG1")]
        public void UpdateMesParametres(Parametres parameters)
        {
            throw new NotImplementedException();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "CDG1")]
        public List<Historique> MonHistorique()
        {
            throw new NotImplementedException();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "CEB-CDG1")]
        public void CreateVol(VolDefinition newVol)
        {
        }

        ~MyAirportService()
        {
            NbInstance--;
        }
    }
}