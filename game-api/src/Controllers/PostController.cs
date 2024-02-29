using Microsoft.AspNetCore.Mvc;
using PostDependencyInjection;
using DB;
using PostSendError;
using Pagination;

namespace Posta.Controllers;

public class Posta: Controller
{
  private readonly IPostDi _post;

  public Posta(IPostDi post)
  {
    _post = post;
  }

  [HttpGet("posts")]
  public object Index([FromQuery] QueryTemplate queryParams)
  {
    var post = _post.GetPosts(queryParams.Take, queryParams.Skip);
    return StatusCode(post.GetStatusCode(), post.GetData());
  }

  [HttpGet("post/{id}")]
  public object GetOnePost(string id)
  {
    var post = _post.GetByPostId(id);
    return StatusCode(post.GetStatusCode(), post.GetData());
  }

  [HttpPost("post/create")]
  public object CreatePost([FromBody] DB.Post post)
  {
    var title = post.Title;
    var content = post.Content;

    if (title is null)
      return BadRequest(ErrorClass.Error("Falta el parámetro del titulo"));
    
    if (content is null)
      return BadRequest(ErrorClass.Error("Falta el parámetro del contenido"));
    
    if (title.Length <= 5)
      return BadRequest(ErrorClass.Error("El titulo debe tener más de 5 caracteres"));
    
    if (content.Length <= 10)
      return BadRequest(ErrorClass.Error("El contenido debe tener más de 10 caracteres"));

    var postId = _post.CreatePost(title, content);
    return StatusCode(postId.GetStatusCode(), new { title, content });
  }
  
  // -----------------------------------

  // TODO: Crear el apartado para crear un post

  // -----------------------------------

  [HttpDelete("post/delete/{id}")]
  public object DeletePost(string id)
  {
    var post = _post.RemovePost(id);
    return post;
  }
}




