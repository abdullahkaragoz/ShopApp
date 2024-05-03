using AutoMapper;
using MongoDB.Driver;
using ShopApp.Catalog.Dtos.ProductDetailDtos;
using ShopApp.Catalog.Entities;
using ShopApp.Catalog.Settings;

namespace ShopApp.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> ProductDetailCollection;
        private readonly IMapper mapper;

        public ProductDetailService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            this.ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = mapper.Map<ProductDetail>(createProductDetailDto);
            await ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await ProductDetailCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(values);

        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = mapper.Map<ProductDetail>(updateProductDetailDto);
            await ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }
    }
}
