using AutoMapper;
using Becomex.Robot.Application.Model;
using Becomex.Robot.Domain.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Becomex.Robot.Application.Mapper
{
    public class MapperDomainToViewModel : Profile
    {
        public MapperDomainToViewModel()
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<Arm, ArmModel>().ReverseMap();
            CreateMap<Ancon, AnconModel>().ReverseMap();
            CreateMap<Fist, FistModel>().ReverseMap();
            CreateMap<Head, HeadModel>().ReverseMap();
            CreateMap<Domain.Entities.Robot, RobotModel>().ReverseMap();
        }

    }
}
