using AutoMapper;

namespace AB12.Services.Application
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) 
            => profile.CreateMap(typeof(T), GetType());
    }
}
