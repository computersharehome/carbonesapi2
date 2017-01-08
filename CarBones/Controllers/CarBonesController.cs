using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using CarBones.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using CarBones.Models.DbContext;
using CarBones.Models.Contracts;
using CarBones.Models.Implementations;

namespace CarBones.Controllers
{
    [BreezeController]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class CarBonesController : ApiController
    {
        readonly IBreezeRepository repository;

        public CarBonesController()
        {
            repository  = new BreezeRepository();
        }

        [HttpGet]
        public string Metadata()
        {
            return repository.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Car> Cars(JObject options)
        {
            return repository.Cars;
        }

        [HttpGet]
        public IQueryable<Option> Options(JObject options)
        {
            return repository.Options;
        }

        [HttpGet]
        public IQueryable<Relation> Relations(JObject options)
        {
            return repository.Relations;
        }
    }
}