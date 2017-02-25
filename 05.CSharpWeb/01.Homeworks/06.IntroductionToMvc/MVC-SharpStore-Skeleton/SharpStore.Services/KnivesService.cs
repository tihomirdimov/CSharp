using SharpStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.Models;

namespace SharpStore.Services
{
    public class KnivesService
    {
        private SharpStoreContext context;

        public KnivesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Knife> Knives
        {
            get { return this.context.Knives.AsEnumerable(); }
        }
    }
}
