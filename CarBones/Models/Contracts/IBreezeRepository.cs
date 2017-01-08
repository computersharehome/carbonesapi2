using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using CarBones.Models.DbContext;

namespace CarBones.Models.Contracts
{
    public interface IBreezeRepository
    {
        string Metadata();
        SaveResult SaveChanges(JObject saveBundle);
        IQueryable<Car> Cars { get; }
        IQueryable<Option> Options { get; }
        IQueryable<Relation> Relations { get; }
    }
}
