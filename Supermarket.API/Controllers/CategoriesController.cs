using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Services.Interfaces;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
        }

        [HttpGet]
        public IAsyncEnumerable<Category> GetAllAsync()
        {
            var categories = _categoryServices.ListAsync();
            return categories;
        }
    }
}