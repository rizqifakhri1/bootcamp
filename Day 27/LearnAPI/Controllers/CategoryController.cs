using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


public class CategoryController : ApiBaseController
{
    private readonly CategoryModule _categoryModule;
    public CategoryController(CategoryModule categoryModule) {
        _categoryModule = categoryModule;
    }
    [HttpGet]
    public IActionResult GetCategory(){
        return Ok(_categoryModule.Get());
    }

    [HttpPost]
    public IActionResult PostCategory(Category category){
        bool status = _categoryModule.Create(category);
        if(status) {
            return Ok(category);
        }
        return BadRequest();
    }
}