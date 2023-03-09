using AutoMapper;
using BackendProduct.CQRS.Products.ViewModel;
using BackendProduct.Model;

namespace BackendProduct
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.Price, b => b.MapFrom(c => c.Price))
                .ForMember(a => a.StockCount, b => b.MapFrom(c => c.StockCount));

            CreateMap<ProductViewModel, Product>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.Price, b => b.MapFrom(c => c.Price))
                .ForMember(a => a.StockCount, b => b.MapFrom(c => c.StockCount));
        }
    }
}
