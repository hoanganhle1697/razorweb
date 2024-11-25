using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Entity_Razor.Models;
using Entity_Razor.Helper;

namespace Entity_Razor.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly Entity_Razor.Models.MyBlogContext _context;

        public IndexModel(Entity_Razor.Models.MyBlogContext context)
        {
            _context = context;
        }
        

        public const int ITEMS_PER_PAGE = 5;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { set; get; }
        public int countPages { set; get; }



        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync()
        {
            int totalArticle = await _context.articles.CountAsync();
            countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);

            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                currentPage = countPages;

            var list = from item in _context.articles
                       orderby item.Created
                       select item;
            // if(!string.IsNullOrEmpty(searchString)){
            //     Article=await list.Where(x => x.Title.Contains(searchString)).ToListAsync();
            // }
            // else{ Article=await list.ToListAsync();}
            Article = list.Skip((currentPage - 1) *ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToList();
        }
    }
}
