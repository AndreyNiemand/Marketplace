using AutoMapper;
using MariElMarketplace.Contexts;
using MariElMarketplace.Models;
using MariElMarketplace.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MariElMarketplace.Calculators
{
    public class CalculatorService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public CalculatorService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(x => x.Id == id);

        public List<Product> GetByProductType(ProductTypeEnum category) 
            => _context.Products.Where(x => x.ProductType == category).ToList();


        public DetailViewModel GetBestSuggestions(int id)
        {
            var thisProduct = _mapper.Map<ProductWithCarryPrice>(GetProductById(id));
            var subType = thisProduct.SubType;
            var subTypeProducts = GetProductBySubType(subType).Select(x => _mapper.Map<ProductWithCarryPrice>(x)).ToList();
            return new DetailViewModel
            {
                ThisProduct = thisProduct,
                Suggestions = subTypeProducts
            };
        }

        public List<Product> GetProductBySubType(string subType) => _context.Products.Where(x => x.SubType == subType).ToList();

        public Dictionary<string, Product> GetBestProductTypes(List<Product> products)
        {
            var individualProductNames = products.Select(x => x.SubType).Distinct();
            var bestProducts = new Dictionary<string, Product>();
            foreach (var item in products)
            {
                if (!bestProducts.ContainsKey(item.SubType))
                {
                    bestProducts.Add(item.SubType, item);
                }
                else
                {
                    var prodct = bestProducts[item.SubType];
                    if (prodct.Price > item.Price)
                    {
                        bestProducts.Remove(item.SubType);
                        bestProducts.Add(item.SubType, item);
                    }
                }
            }
            return bestProducts;
        }

    }
}
