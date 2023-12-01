using AutoMapper;
using FLOWFIT;
using flowfitapi.Domain.Dtos;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Library.Domain.Dtos;

namespace Flowfitapi.Services.Mappings
{
    public class CreateMappingProfiles : Profile
    {
        public CreateMappingProfiles()
        {
            CreateMap<InstructorCreateDto, Instructor>()
                .AfterMap((src, dest) => 
                {
                    dest.FechaInscripcion = DateTime.Now;
                });

            CreateMap<RutinaCreateDto, Rutina>()
                .AfterMap((src, dest) => 
                {
                    dest.Fechacreacioon = DateTime.Now;
                });

            CreateMap<UsuarioCreateDto, Usuario>()
                .AfterMap((src, dest) => 
                {
                    dest.Fechainscripcion = DateTime.Now;
                });

            CreateMap<ProveedorCreateDto, Proveedor>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ProductoCreateDto, Producto>();

            CreateMap<VentaCreateDto, Venta>()
                .AfterMap((src, dest) => 
                {
                    dest.fecha_venta = DateTime.Now;
                });

            CreateMap<DetalleVentaCreateDto, DetalleVenta>();

            CreateMap<DevolucionCancelacionCreateDto, DevolucionCancelacion>()
                .AfterMap((src, dest) => 
                {
                    dest.fecha = DateTime.Now;
                });
            
            CreateMap<MembresiaCreateDto, Membresia>();
            
            CreateMap<PagoMembresiaCreateDto, PagoMembresia>()
                .AfterMap((src, dest) => 
                {
                    dest.fecha = DateTime.Now;
                });
        }
    }
}
