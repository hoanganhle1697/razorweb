using Bogus;
using Entity_Razor.Models;
using Microsoft.EntityFrameworkCore;

public static class SeedData{
    public static void Seed(this ModelBuilder builder,int num){
        builder.Entity<Article>().HasData("", "");

        var faker= new Faker<Article>()
                                        //  .RuleFor(a=>a.Id,f=>f.IndexFaker+1)
                                         .RuleFor(a=>a.Title,f=>f.Lorem.Sentence(6))
                                         .RuleFor(a=>a.Created,f=>f.Date.Past(1))
                                         .RuleFor(a=>a.Content,f=>f.Lorem.Paragraph());
                                         
        

    }
}