// ----------------------------------------------------------------------------------
// <copyright company="Exesoft Inc.">
//	This code was generated by Instant Web API code automation software (https://www.InstantWebAPI.com)
//	Copyright Exesoft Inc. © 2019.  All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------------

using AutoMapper;
using InstantHelper;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesAPI.Entities;
using SalesAPI.Models;
using SalesAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace SalesAPI.Controllers {
    
    
    // Uncomment the following line to use an API Key; change the value of the key in appSetting (X-API-Key)
    // [ApiKey()]
    [Route("SpecialOfferProduct")]
    public class SpecialOfferProductController : ControllerBase {
        
        private IDbEntities _entities;
        
        private IMapper _mapper;
        
        private ILoggerManager _logger;
        
        public SpecialOfferProductController(EntitiesContext context, IMapper mapper, ILoggerManager logger) {
            _entities = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IQueryable<SpecialOfferProductModel> GetAllSpecialOfferProducts() {

            ICollection<SpecialOfferProductModel> models = _mapper.Map<ICollection<SpecialOfferProductModel>>(_entities.SpecialOfferProducts);

            return models.AsQueryable();
        }
        
        [HttpGet("Paged")]
        public IPagedList<SpecialOfferProductModel> GetPagedSpecialOfferProducts(int pageIndex, int pageSize) {

            ICollection<SpecialOfferProductModel> models = _mapper.Map<ICollection<SpecialOfferProductModel>>(_entities.SpecialOfferProducts);

            return models.ToPagedList(pageIndex, pageSize, 0, models.Count);
        }
        
        [HttpGet("{specialOfferID}/{productID}")]
        public async Task<ActionResult> GetSpecialOfferProduct_BySpecialOfferIDProductID(int specialOfferID, int productID) {

            SpecialOfferProductModel model;

          var query = await SearchByPk(specialOfferID, productID);
            if (!query.Any()) {
              return NotFound();
            }
            else {
           model = _mapper.Map<SpecialOfferProductModel>(query.SingleOrDefault());
            }

            return Ok(model);
        }
        
        [HttpGet("GetSpecialOfferProduct_BySpecialOfferID/{specialOfferID}")]
        public IQueryable<SpecialOfferProductModel> GetSpecialOfferProduct_BySpecialOfferID(int specialOfferID) {

            ICollection<SpecialOfferProductModel> models = _mapper.Map<ICollection<SpecialOfferProductModel>>(_entities.SpecialOfferProducts.Where(x => x.SpecialOfferID == specialOfferID));

            return models.AsQueryable();
        }
        
        [HttpPost("")]
        public async Task<ActionResult> AddSpecialOfferProduct([FromBody]SpecialOfferProductModel model) {

            SpecialOfferProduct entity = null;

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var matchSpecialOfferID = _entities.SpecialOffers.Where(x => x.SpecialOfferID.Equals(model.SpecialOfferID));
            if (!matchSpecialOfferID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("SpecialOfferID = '{0}' doesn't exist in the system.", model.SpecialOfferID));
            }


            var search = SearchbyUnique(model.SpecialOfferID, model.ProductID);
            if (search.Result.Count() > 0) {
              return BadRequest("Duplicate Record;" + string.Format("Record already exists in the system with this(these) value(s):{0}, {1}", model.SpecialOfferID, model.ProductID));
            }

           try
           {
                 entity = _mapper.Map<SpecialOfferProduct>(model);
                _entities.SpecialOfferProducts.Add(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            _logger.LogInfo(string.Format("SpecialOfferProduct added with values: '{0}'", JsonConvert.SerializeObject(model)));

            return CreatedAtAction("GetSpecialOfferProduct_BySpecialOfferIDProductID", new {specialOfferID = entity.SpecialOfferID, productID = entity.ProductID}, model);
        }
        
        [HttpPut("")]
        public async Task<ActionResult> UpdateSpecialOfferProduct([FromBody]SpecialOfferProductModel model) {

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var query = SearchByPk(model.SpecialOfferID, model.ProductID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("SpecialOfferProduct with _specialOfferID, _productID = '{0}', '{1}' doesn't exist.",model.SpecialOfferID, model.ProductID));
            }
            var matchSpecialOfferID = _entities.SpecialOffers.Where(x => x.SpecialOfferID.Equals(model.SpecialOfferID));
            if (!matchSpecialOfferID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("SpecialOfferID = '{0}' doesn't exist in the system.", model.SpecialOfferID));
            }


           try
           {
            SpecialOfferProduct entity = query.SingleOrDefault();
             entity = model.ToEntity(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("SpecialOfferProduct updated with values: '{0}'", JsonConvert.SerializeObject(model)));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        
        [HttpDelete("{specialOfferID}/{productID}")]
        public async Task<ActionResult> DeleteSpecialOfferProduct(int specialOfferID, int productID) {

            var query = SearchByPk(specialOfferID, productID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("SpecialOfferProduct with _specialOfferID, _productID = '{0}', '{1}' doesn't exist.",specialOfferID, productID));
            }
            var entity = query.SingleOrDefault();

           try
           {
                _entities.SpecialOfferProducts.Remove(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("SpecialOfferProduct deleted with values: '{0}'", JsonConvert.SerializeObject(new SpecialOfferProductModel(entity))));

            return Ok(new SpecialOfferProductModel(entity));
        }
        
        private async Task<IQueryable<SpecialOfferProduct>> SearchByPk(int specialOfferID, int productID) {

            var pb = PredicateBuilder.New<SpecialOfferProduct>();
            pb = pb.And(p => p.SpecialOfferID.Equals(specialOfferID));
            pb = pb.And(p => p.ProductID.Equals(productID));

            return await Task.FromResult(_entities.SpecialOfferProducts.AsExpandable().Where(pb));
        }
        
        private async Task<IQueryable<SpecialOfferProduct>> SearchbyUnique(int specialOfferID, int productID) {

            var pb = PredicateBuilder.New<SpecialOfferProduct>();
            pb = pb.And(p => p.SpecialOfferID.Equals(specialOfferID));
            pb = pb.And(p => p.ProductID.Equals(productID));

            return await Task.FromResult(_entities.SpecialOfferProducts.AsExpandable().Where(pb));
        }
    }
}
