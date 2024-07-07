using AutoMapper;
using TesteTechNation.Web.Models;

namespace TesteTechNation.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<NotaFiscal, NotaFiscalViewModel>().ReverseMap();
            CreateMap<TipoPagamento, TipoPagamentoViewModel>().ReverseMap();
            CreateMap<Pagador, PagadorViewModel>().ReverseMap();
            CreateMap<StatusNotum, StatusNotaViewModel>().ReverseMap();
        }
    }
}