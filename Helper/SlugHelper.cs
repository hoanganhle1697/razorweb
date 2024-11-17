using System.Text.RegularExpressions;
using Entity_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Razor.Helper
{
    public class SlugHelper
    {


        public static string GetSlug<T>(string str, DbSet<T> dbset) where T : class
        {
            string slug = Regex.Replace(str.ToLower().Trim(), @"[^a-z0-9\s-]", "")
                         .Replace(" ", "-")
                         .Replace("--", "-");
            int count = 1;
            string uniqueSlug=slug;

            var listSlug=dbset.Select(s => EF.Property<string>(s,"Slug")).ToList();

            while (listSlug.Contains(uniqueSlug))
            {
                
                uniqueSlug = $"{slug}-{count++}";
            }
            return uniqueSlug;
        }
    }
}
