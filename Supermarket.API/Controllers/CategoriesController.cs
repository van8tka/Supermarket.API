using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;
using Supermarket.API.Services.Interfaces;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IAsyncEnumerable<CategoryResource> GetAllAsync()
        {
            var categories = _categoryServices.ListAsync();
            var resources = _mapper.Map<IAsyncEnumerable<Category>,IAsyncEnumerable<CategoryResource>>(categories);
            return  resources;
        }
    }
}