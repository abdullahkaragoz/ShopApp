using AutoMapper;
using MongoDB.Driver;
using ShopApp.Catalog.Dtos.ProductImageDtos;
using ShopApp.Catalog.Entities;
using ShopApp.Catalog.Settings;

namespace ShopApp.Catalog.Services.ProductImageServices
{

    public class ProductImageService : IProductImageService
        {
            private readonly IMongoCollection<ProductImage> ProductImageCollection;
            private readonly IMapper mapper;

            public ProductImageService(IDatabaseSettings databaseSettings, IMapper mapper)
            {
                var client = new MongoClient(databaseSettings.ConnectionString);
                var database = client.GetDatabase(databaseSettings.DatabaseName);
                this.ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
                this.mapper = mapper;
            }

            public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
            {
                var value = mapper.Map<ProductImage>(createProductImageDto);
                await ProductImageCollection.InsertOneAsync(value);
            }

            public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
            {
                var values = await ProductImageCollection.Find(x => true).ToListAsync();
                return mapper.Map<List<ResultProductImageDto>>(values);

            }

            public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
            {
                var values = await ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
                return mapper.Map<GetByIdProductImageDto>(values);
            }

            public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
            {
                var values = mapper.Map<ProductImage>(updateProductImageDto);
                await ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
            }

            public async Task DeleteProductImageAsync(string id)
            {
                await ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
            }
        }
}
