using AutoMapper;
using CommerceTest.Application.Dtos;
using CommerceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ReverseMap()
                .ForMember(dest => dest.Documento, source => source.MapFrom(x => x.Documento.ToString()));

            CreateMap<Pedido, PedidoDto>()
                .ReverseMap()
                .ForMember(dest => dest.Status, source => source.MapFrom(x => x.Status.ToString()))
                .ForMember(dest => dest.Id, source => source.MapFrom(x => x.ClienteId.ToString()));

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
