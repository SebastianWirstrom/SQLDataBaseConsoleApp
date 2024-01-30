using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;

    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.GetSingle(x => x.CategoryName == categoryName);
            if (categoryEntity != null)
            {
                
                return categoryEntity;
            }

            categoryEntity = new CategoryEntity { CategoryName = categoryName };
            return _categoryRepository.Create(categoryEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
     
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _categoryRepository.GetSingle(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepository.GetSingle(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedCategoryEntity;
    }

    public bool DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
        return true;
    }
}
