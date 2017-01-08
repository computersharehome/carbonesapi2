using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using CarBones.Models.DbContext;
using CarBones.Models.Contracts;

namespace CarBones.Models.Implementations
{
    public class BreezeRepository : IBreezeRepository
    {
        readonly EFContextProvider<CarBoneEntities> _contextProvider =
            new EFContextProvider<CarBoneEntities>();

        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Car> Cars
        {
            get { return _contextProvider.Context.Cars; }
        }

        public IQueryable<Option> Options
        {
            get { return _contextProvider.Context.Options; }
        }

        public IQueryable<Relation> Relations
        {
            get { return _contextProvider.Context.Relations; }
        }
    }
}