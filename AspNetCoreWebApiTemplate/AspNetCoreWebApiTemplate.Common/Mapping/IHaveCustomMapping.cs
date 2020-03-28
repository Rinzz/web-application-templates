namespace AspNetCoreWebApiTemplate.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        public void RegisterMappings(IProfileExpression profile);
    }
}
