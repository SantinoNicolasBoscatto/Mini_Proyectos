using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Domain;
using NotesApp.PresentationController.Controllers.GenericController;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : GenericControllers
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {}

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await GetAllBase<Category, GetCategoriesQuery>();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> Post([FromForm] CreateCategoryCommand createCategory)
        {
            return await PostBase<CreateCategoryCommand>(createCategory);
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> Update([FromForm] UpdateCategoryCommand updateCategory, int id)
        {
            updateCategory.Id = id;
            return await PutBase<UpdateCategoryCommand>(updateCategory);
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> Delete(int id)
        {
            return await DeleteBase<DeleteCategoryCommand>(new DeleteCategoryCommand { Id = id});
        }
    }
}
