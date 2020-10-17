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
    public class ProductsController:Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet(Name="GetAllProducts")]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ProductResource> Get(int id)
        {
            var product = await _productService.GetAsync(id);
            var resource = _mapper.Map<Product, ProductResource>(product);
            return resource;
        }

    }
}