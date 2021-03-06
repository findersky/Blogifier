using Blogifier.Core.Providers;
using Blogifier.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogifier.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryProvider _categoryProvider;

		public CategoryController(ICategoryProvider categoryProvider)
		{
			_categoryProvider = categoryProvider;
		}

		[HttpGet("{postId:int}")]
		public async Task<ICollection<Category>> GetPostCategories(int postId)
		{
			return await _categoryProvider.GetPostCategories(postId);
		}

		[Authorize]
		[HttpPost("{postId:int}/{tag}")]
		public async Task<ActionResult<bool>> AddPostCategory(int postId, string tag)
		{
			return await _categoryProvider.AddPostCategory(postId, tag);
		}

        [Authorize]
        [HttpPut("{postId:int}")]
        public async Task<ActionResult<bool>> SavePostCategories(int postId, List<Category> categories)
        {
            return await _categoryProvider.SavePostCategories(postId, categories);
        }

        [Authorize]
		[HttpDelete("{postId:int}/{categoryId:int}")]
		public async Task<ActionResult<bool>> RemoveCategory(int postId, int categoryId)
		{
			return await _categoryProvider.RemoveCategory(postId, categoryId);
		}
	}
}
