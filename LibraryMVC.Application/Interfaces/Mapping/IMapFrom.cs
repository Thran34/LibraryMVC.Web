using AutoMapper;

namespace LibraryMVC.Application.Interfaces.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
