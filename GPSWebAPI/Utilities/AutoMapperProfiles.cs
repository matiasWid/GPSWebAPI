﻿using AutoMapper;
using GPSWebAPI.DTOs;
using GPSWebAPI.Models;

namespace GPSWebAPI.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<Device, DeviceDTO>();
            CreateMap<VehicleCreationDTO, Vehicle>();
            CreateMap<DeviceCreationDTO, Device>();

            //CreateMap<Device, DeviceVehicleDTO>()
            //    .ForMember(x => x.VehiclePlate, x => x.MapFrom(y => y.Vehicle.PlateNumber))
            //    .ForMember(x => x.DeviceSerial, x => x.MapFrom(y => y.Serial))
            //    .ForMember(x => x.DeviceId, x => x.MapFrom( y=> y.Id));
        }
    }
}
