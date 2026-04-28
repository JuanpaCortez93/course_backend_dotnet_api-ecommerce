public class CategoryRepository : ICategoryRepository
{

    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool CategoryExist(int id)
    {
        return _db.Category.Any(category => category.Id == id);
    }

    public bool CategoryExist(string name)
    {
        return _db.Category.Any(category => category.Name.ToLower().Trim() == name.ToLower().Trim());
    }

    public bool CreateCategory(Category category)
    {
        category.CreationDate = DateTime.Now;
        _db.Category.Add(category);
        return Save();
    }

    public bool DeleteCategory(Category category)
    {
        _db.Category.Remove(category);
        return Save();
    }

    public ICollection<Category> GetCategories()
    {
        return _db.Category.OrderBy(c => c.Name).ToList();
    }

    public Category? GetCategory(int id)
    {
        return _db.Category.FirstOrDefault<Category>(category => category.Id == id) ?? throw new InvalidOperationException($"La categoría con el ID {id} no existe");
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }

    public bool UpdateCategory(Category category)
    {
        category.CreationDate = DateTime.Now;
        _db.Category.Update(category);
        return Save();
    }
}