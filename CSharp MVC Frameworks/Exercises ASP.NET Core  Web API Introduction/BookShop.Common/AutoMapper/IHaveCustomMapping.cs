using AutoMapper;

namespace BookShop.Common.AutoMapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}