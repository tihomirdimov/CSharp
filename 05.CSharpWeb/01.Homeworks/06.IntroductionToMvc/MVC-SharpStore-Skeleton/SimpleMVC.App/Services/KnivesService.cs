using SharpStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.Models;
using SharpStore.ViewModels;

namespace SharpStore.Services
{
    public class KnivesService
    {
        private SharpStoreContext context;

        public KnivesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var knives = this.context.Knives.ToArray();
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (var knife in knives)
            {
                viewModels.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Price = knife.Price,
                    Name = knife.Name,
                    ImageUrl = knife.ImageUrl
                });
            }
            return viewModels;
        }
    }
}
