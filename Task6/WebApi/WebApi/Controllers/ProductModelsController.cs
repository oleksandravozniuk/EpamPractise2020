using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductModelsController : ApiController
    {
        public IProductService productService;
        private readonly IMapper mapper;

        public ProductModelsController(IProductService serv)
        {
            productService = serv;

            MapperConfiguration configProduct = new MapperConfiguration(con =>
            {
                con.CreateMap<ProductModel, ProductDTO>();
                con.CreateMap<ProductDTO, ProductModel>();
            });
            mapper = configProduct.CreateMapper();


        }

        // GET: api/ProductModels
        public IQueryable<ProductModel> GetProductModels()
        {
            IEnumerable<ProductDTO> productDtos = productService.GetProducts();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductModel>>(productDtos);
            return products.AsQueryable();
        }

        // GET: api/ProductModels/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetProductModel(int id)
        {
            ProductDTO productDto = productService.GetProductById(id);

            if (productDto == null)
            {
                return NotFound();
            }
            var productModel = mapper.Map<ProductDTO, ProductModel>(productDto);
            return Ok(productModel);
        }

        // PUT: api/ProductModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductModel(int id, ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productModel.Id)
            {
                return BadRequest();
            }

            ProductDTO productDTO = mapper.Map<ProductModel, ProductDTO>(productModel);

            productService.UpdateProduct(productDTO);



            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductModels
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult PostProductModel(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductDTO productDTO = mapper.Map<ProductModel, ProductDTO>(productModel);

            productService.CreateProduct(productDTO);


            return CreatedAtRoute("DefaultApi", new { id = productModel.Id }, productModel);
        }

        // DELETE: api/ProductModels/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult DeleteProductModel(int id)
        {

            ProductDTO productDTO = productService.GetProductById(id);

            ProductModel productModel = mapper.Map<ProductDTO, ProductModel>(productDTO);

            productService.DeleteProduct(id);

            return Ok(productModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                productService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductModelExists(int id)
        {
            return productService.GetProducts().Count(e => e.Id == id) > 0;
        }
    }
}