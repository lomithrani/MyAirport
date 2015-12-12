using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using AutoMapper;
using MyAirport.Entities;

namespace MyAirport.Data.ModelEntityFramework
{
    public class ModelEntity : AbstractModel
    {
        public ModelEntity()
        {
            AutoMapperInit.Initialize();
        }

        public override VolDefinition GetVol(int idVol)
        {
            VolDefinition valueToReturn;
            using (var db = new MyAirportEntities())
            {
                var vol = db.VOLs.Single(v => v.ID_VOL == idVol);
                valueToReturn = Mapper.Map<VolDefinition>(vol);
            }
            return valueToReturn;
        }

        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition valueToReturn;
            using (var db = new MyAirportEntities())
            {
                var baggage = db.BAGAGEs.Single(b => b.ID_BAGAGE == idBagage);
                valueToReturn = Mapper.Map<BagageDefinition>(baggage);
            }
            return valueToReturn;
        }

        public override List<BagageDefinition> GetBagageWithIata(string iata)
        {
            using (var db = new MyAirportEntities())
            {
                return db.BAGAGEs.Where(b => b.CODE_IATA == iata).Select(Mapper.Map<BagageDefinition>).ToList();
            }
        }


      
        public override int SetBaggage(BagageDefinition baggage)
        {
            var returnValue = -1;
            using (var db = new MyAirportEntities())
            {
                var baggageDal = Mapper.Map<BAGAGE>(baggage);
                VOL vol = null;
                try
                {
                    vol = db.VOLs.Single(v => v.ID_VOL == baggageDal.ID_VOL);
                }
                catch (Exception ex)
                {
                    throw new FaultException<PersoFaultException>(new PersoFaultException
                    {
                        Message = "Vol introuvable"
                    });
                }

                baggageDal.COMPAGNIE = vol?.COMPAGNIE1.CODE_IATA;
                baggageDal.LIGNE = vol?.LIG;
                baggageDal.ORIGINE_CREATION = "D";
                db.BAGAGEs.Add(baggageDal);

                try
                {
                    if (db.SaveChanges() >= 0)
                    {
                        returnValue = baggage.Id;
                    }
                }
                catch (Exception ex)
                {
                    throw new FaultException<PersoFaultException>(new PersoFaultException
                    {
                        Message = "Sauvegarde Impossible"
                    });
                }
            }
            return returnValue;
        }


    }
}