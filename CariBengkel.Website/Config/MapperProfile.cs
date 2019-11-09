using AutoMapper;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Models;

namespace CariBengkel.Website.Config {
    public class MapperProfile : Profile {
        public MapperProfile () {
            CreateMap<CredentialViewModel, Credentials> ();
            CreateMap<UserViewModel, User> ();
        }
    }
}