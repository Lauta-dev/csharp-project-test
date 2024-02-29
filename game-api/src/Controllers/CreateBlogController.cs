using Microsoft.AspNetCore.Mvc;
using BlogNameSpace;
using DB;

namespace Blogaaaa.Controllers;

public class CreateBlogController: Controller
{
  private readonly IBlogDi _blog;

  public CreateBlogController(IBlogDi blog)
  {
    _blog = blog;
  }

  [HttpGet("blogs")]
  public object Index()
  {
    var blogs =_blog.GetBlogs();
    
    return StatusCode(blogs.GetStatusCode(), blogs.GetData());
  }

  [HttpGet("blogs/get-one/{id}")]
  public object Index(string id)
  {
    var blog = _blog.GetOneBlog(id);

    // TODO: Estudiar como funciona esto
    
    /*var n = blog.GetType()
      .GetProperties()
      .Where(prop => prop.GetValue(blog) != null)
      .ToDictionary(prop => prop.Name, prop => prop.GetValue(blog));*/

    return StatusCode(blog.GetStatusCode(), blog.GetAllData());
  }

  [HttpPost("blog/create")]
  public object Create([FromBody] DB.Blog blog)
  {
    var url = blog.Url;
    var newBlog = _blog.CreateBlog(url);

    return StatusCode(newBlog.GetStatusCode(), newBlog.GetAllData());
  }

  [HttpPatch("blog/update")]
  public object UpdateBlog([FromBody] DB.Blog blog)
  {
    return _blog.UpdateBlog(blog.Id, blog.Url);
  }

  [HttpDelete("blog/delete/{id}")]
  public object DeleteBlog(string id)
  {
    var remove = _blog.RemoveBlog(id);
    return StatusCode(remove.GetStatusCode(), remove.GetAllData());
  }
}

