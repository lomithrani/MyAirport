using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyAirport.Entities;

namespace MyAirport.Data.ModelEntityFramework
{
    public static class AutoMapperInit
    {
        static AutoMapperInit()
        {
            SetVolToVolDefinition();
            SetBaggageToBaggageDefinition();
        }

        public static void Initialize()
        {
            
        }

        private static void SetVolToVolDefinition()
        {
            Mapper.CreateMap<VOL, VolDefinition>()
                .ForMember(dest => dest.CIE, opt => opt.MapFrom(source => source.COMPAGNIE1.NOM))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(source => source.DHC.Value))
                .ForMember(dest => dest.Ligne, opt => opt.MapFrom(source => source.LIG))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ID_VOL));
        }

        private static void SetBaggageToBaggageDefinition()
        {
            Mapper.CreateMap<BAGAGE, BagageDefinition>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.ID_BAGAGE))
                .ForMember(dest => dest.CodeIATA, opt => opt.ResolveUsing<IataResolver>())
                .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(source => source.DATE_CREATION))
                .ForMember(dest => dest.IdVol, opt => opt.MapFrom(source => source.VOL.ID_VOL));


            Mapper.CreateMap<BagageDefinition, BAGAGE>()
                .ForMember(dest => dest.ID_BAGAGE, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.CODE_IATA, opt => opt.MapFrom(source => source.CodeIATA.ToString()))
                .ForMember(source => source.DATE_CREATION, opt => opt.MapFrom(source => source.DateCreation))
                .ForMember(dest => dest.ID_VOL, opt => opt.MapFrom(source => source.IdVol));
        }

        public class IataResolver : ValueResolver<BAGAGE, long>
        {
            protected override long ResolveCore(BAGAGE source)
            {
                long temp;
                long.TryParse(source.CODE_IATA, out temp);
                return temp;
            }
        }
    }
}
