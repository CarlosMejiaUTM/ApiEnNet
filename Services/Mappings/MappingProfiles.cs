using AutoMapper;
using FLOWFIT;
using flowfitapi.Domain.Dtos;
using Flowfitapi.Domain.Dtos;

namespace Flowfitapi.Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, InstructorDto>()
                .ForMember(
                    dest => dest.añocontratado,
                    opt => opt.MapFrom(src => src.FechaInscripcion.Value.Date.Year)
                );

            CreateMap<Rutina, RutinaDto>()
                .ForMember(
                    dest => dest.creacion,
                    opt => opt.MapFrom(src => src.Fechacreacioon.Value.Date.Year)
                );

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(
                    dest => dest.inscripcion,
                    opt => opt.MapFrom(src => src.Fechainscripcion.Value.Date.Year)
                );

            CreateMap<Proveedor, ProveedorDto>();

            CreateMap<Cliente, ClienteDto>();

            CreateMap<Producto, ProductoDto>();

            CreateMap<Venta, VentaDto>()
                .ForMember(
                    dest => dest.fechaventa,
                    opt => opt.MapFrom(src => src.fecha_venta.Value.Date.Year)
                );

            CreateMap<DetalleVenta, DetalleVentaDto>();

            CreateMap<DevolucionCancelacion, DevolucionCancelacionDto>()
                .ForMember(
                    dest => dest.Fechadev,
                    opt => opt.MapFrom(src => src.fecha.Value.Date.Year)
                );

            CreateMap<Membresia, MembresiaDto>();

            CreateMap<PagoMembresia, PagoMembresiaDto>()
                .ForMember(
                    dest => dest.fechamembresia,
                    opt => opt.MapFrom(src => src.fecha.Value.Date.Year)
                );

        }
    }
}
