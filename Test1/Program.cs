// See https://aka.ms/new-console-template for more information
using ECommerce.Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var category = Category.Create("Music");
Console.WriteLine(category.Value.CategoryName);

/*var context = new Infrastructure.ECommerceContext();

var categoryRepo = new Infrastructure.Repositories.CategoryRepository(context);

var result = await categoryRepo.AddAsync(category.Value);
Console.WriteLine(result.Value.CategoryName);*/