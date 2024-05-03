using AutoMapper;
using MongoDB.Driver;
using ShopApp.Catalog.Dtos.ProductDtos;
using ShopApp.Catalog.Entities;
using ShopApp.Catalog.Settings;

namespace ShopApp.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Product> productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = mapper.Map<Product>(createProductDto);
            await productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await productCollection.DeleteOneAsync(x=>x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = mapper.Map<Product>(updateProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
    }
}
