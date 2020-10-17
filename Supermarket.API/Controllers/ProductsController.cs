using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IMapper mapper, IProductService productService, IMemoryCache memoryCache)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _memoryCache = memoryCache;
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
            var cacheKey = "product_id_"+id;
            if(!_memoryCache.TryGetValue(cacheKey, out ProductResource resource))
            {
                var product = await _productService.GetAsync(id);
                resource = _mapper.Map<Product, ProductResource>(product);
                var cachExpirationOpt = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(3),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                };
                _memoryCache.Set(cacheKey, resource, cachExpirationOpt);
            }
          
            return resource;
        }

    }
}