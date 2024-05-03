using AutoMapper;
using MongoDB.Driver;
using ShopApp.Catalog.Dtos.CategoryDtos;
using ShopApp.Catalog.Entities;
using ShopApp.Catalog.Settings;

namespace ShopApp.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            this.categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = mapper.Map<Category>(createCategoryDto);
            await categoryCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await categoryCollection.Find(x=> true).ToListAsync();
            return mapper.Map<List<ResultCategoryDto>>(values);

        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = mapper.Map<Category>(updateCategoryDto);
            await categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
        }
    }
}
