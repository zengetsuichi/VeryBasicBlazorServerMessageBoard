using Domain.Domain.Interface;
using Domain.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private IPostHome postHome;

    public PostController(IPostHome postHome)
    {
        this.postHome = postHome;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> GetAll()
    {
        try
        {
            ICollection<Post> posts = await postHome.GetAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ICollection<Post>>> GetbyId([FromRoute] int id)
    {
        try
        {
            ICollection<Post> posts = await postHome.GetAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> AddTodo([FromBody] Post todo)
    {
        try
        {
            Post added = await postHome.AddAsync(todo);
            return Created($"/posts/{added.Id}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}