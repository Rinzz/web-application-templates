namespace AspNetCoreWebApiTemplate.Controllers
{
    using AutoMapper;
    using Common.Mapping;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        public ActionResult Get()
        {
            var test = new Test(1,"ime", "grad", 22);
            var testDto = this._mapper.Map<TestDto>(test);
            return Ok("Works!");
        }

        public class Test : IMapTo<TestDto>
        {
            public Test(int id, string name, string town, int count)
            {
                this.Id = id;
                this.Name = name;
                this.Town = town;
                this.Count = count;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Town { get; set; }
            public int Count { get; set; }
        }

        public class TestDto : IMapFrom<Test>, IHaveCustomMapping
        {
            public int Id { get; set; }
            public string TownName { get; set; }
            public int Count { get; set; }
            public void RegisterMappings(IProfileExpression profile)
            {
                profile.CreateMap<Test, TestDto>()
                    .ForMember(x => x.TownName, opts => opts.MapFrom(x => x.Town + x.Name));
            }
        }
    }
}
