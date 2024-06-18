class CategoryModule {
    private readonly Database _db;
    public CategoryModule(Database db)
    {
       _db = db;
    }

    public IEnumerable<Category> Get() 
    {
        return _db.Categories.ToList();
    }
    public bool Create(Category category) 
    {
        _db.Categories.Add(category);
        int value = _db.SaveChanges();
        if(value > 0) {
            return true;
        }
        return false;
    }
}