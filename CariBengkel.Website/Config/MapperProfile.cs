using System.Collections.Generic;
using AutoMapper;
using CariBengkel.Repository.Entity.Custom;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Models;

namespace CariBengkel.Website.Config {
    public class MapperProfile : Profile {
        public MapperProfile () {
            CreateMap<CredentialViewModel, Credentials> ();
            CreateMap<UserViewModel, User> ()
                .ForMember (dest => dest.IdCredentialNavigation, opt => opt.MapFrom (src => src.Credential));
            CreateMap<MenuViewModel, Menu> ();
            CreateMap<RoleViewModel, Role> ();
            CreateMap<RoleMapViewModel, RoleMap> ();
            CreateMap<MenuMapViewModel, CustomMenuMap> ()
                .ForMember (dest => dest.MenuRoleMap, opt => opt.MapFrom (src => src.MenuRoleMap));

        }
    }
}