using System.Configuration;
using MyAirport.Data;
using MyAirport.Data.ModelEntityFramework;

namespace MyAirport.Factory
{
    public static class ModelsFactory
    {
        private static AbstractModel singleton;

        public static AbstractModel Model
        {
            get
            {
                if (singleton == null)
                {
                    switch (ConfigurationManager.AppSettings["Factory"])
                    {
                        case "Sql":
                            singleton = new ModelSql();
                            break;
                        case "natif":
                            singleton = new ModelNatif();
                            break;

                        case "EntityFramework":
                            singleton = new ModelEntity();
                            break;
                    }
                }
                return singleton;
            }
        }
    }
}