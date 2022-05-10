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
    [Route("ShoppingCartItem")]
    public class ShoppingCartItemController : ControllerBase {
        
        private IDbEntities _entities;
        
        private IMapper _mapper;
        
        private ILoggerManager _logger;
        
        public ShoppingCartItemController(EntitiesContext context, IMapper mapper, ILoggerManager logger) {
            _entities = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IQueryable<ShoppingCartItemModel> GetAllShoppingCartItems() {

            ICollection<ShoppingCartItemModel> models = _mapper.Map<ICollection<ShoppingCartItemModel>>(_entities.ShoppingCartItems);

            return models.AsQueryable();
        }
        
        [HttpGet("Paged")]
        public IPagedList<ShoppingCartItemModel> GetPagedShoppingCartItems(int pageIndex, int pageSize) {

            ICollection<ShoppingCartItemModel> models = _mapper.Map<ICollection<ShoppingCartItemModel>>(_entities.ShoppingCartItems);

            return models.ToPagedList(pageIndex, pageSize, 0, models.Count);
        }
        
        [HttpGet("{shoppingCartItemID}")]
        public async Task<ActionResult> GetShoppingCartItem_ByShoppingCartItemID(int shoppingCartItemID) {

            ShoppingCartItemModel model;

          var query = await SearchByPk(shoppingCartItemID);
            if (!query.Any()) {
              return NotFound();
            }
            else {
           model = _mapper.Map<ShoppingCartItemModel>(query.SingleOrDefault());
            }

            return Ok(model);
        }
        
        [HttpPost("")]
        public async Task<ActionResult> AddShoppingCartItem([FromBody]ShoppingCartItemModel model) {

            ShoppingCartItem entity = null;

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }


            var search = SearchbyUnique(model.ShoppingCartID, model.Quantity, model.ProductID);
            if (search.Result.Count() > 0) {
              return BadRequest("Duplicate Record;" + string.Format("Record already exists in the system with this(these) value(s):{0}, {1}, {2}", model.ShoppingCartID, model.Quantity, model.ProductID));
            }

           try
           {
                 entity = _mapper.Map<ShoppingCartItem>(model);
                _entities.ShoppingCartItems.Add(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            model.ShoppingCartItemID = entity.ShoppingCartItemID;
            _logger.LogInfo(string.Format("ShoppingCartItem added with values: '{0}'", JsonConvert.SerializeObject(model)));

            return CreatedAtAction("GetShoppingCartItem_ByShoppingCartItemID", new {shoppingCartItemID = entity.ShoppingCartItemID}, model);
        }
        
        [HttpPut("{shoppingCartItemID}")]
        public async Task<ActionResult> UpdateShoppingCartItem(int shoppingCartItemID, [FromBody]ShoppingCartItemModel model) {

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var query = SearchByPk(shoppingCartItemID).Result;
            if (!query.Any()) {
              ModelState.AddModelError("Record Not Found", string.Format("ShoppingCartItem with _shoppingCartItemID = '{0}' doesn't exist.",shoppingCartItemID)); 
              return BadRequest(ModelState);
            }

           try
           {
            ShoppingCartItem entity = query.SingleOrDefault();
             entity = model.ToEntity(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("ShoppingCartItem updated with values: '{0}'", JsonConvert.SerializeObject(model)));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        
        [HttpDelete("{shoppingCartItemID}")]
        public async Task<ActionResult> DeleteShoppingCartItem(int shoppingCartItemID) {

            var query = SearchByPk(shoppingCartItemID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("ShoppingCartItem with _shoppingCartItemID = '{0}' doesn't exist.",shoppingCartItemID));
            }
            var entity = query.SingleOrDefault();

           try
           {
                _entities.ShoppingCartItems.Remove(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("ShoppingCartItem deleted with values: '{0}'", JsonConvert.SerializeObject(new ShoppingCartItemModel(entity))));

            return Ok(new ShoppingCartItemModel(entity));
        }
        
        private async Task<IQueryable<ShoppingCartItem>> SearchByPk(int shoppingCartItemID) {

            var pb = PredicateBuilder.New<ShoppingCartItem>();
            pb = pb.And(p => p.ShoppingCartItemID.Equals(shoppingCartItemID));

            return await Task.FromResult(_entities.ShoppingCartItems.AsExpandable().Where(pb));
        }
        
        private async Task<IQueryable<ShoppingCartItem>> SearchbyUnique(string shoppingCartID, int quantity, int productID) {

            var pb = PredicateBuilder.New<ShoppingCartItem>();
            pb = pb.And(p => p.ShoppingCartID.Equals(shoppingCartID));
            pb = pb.And(p => p.Quantity.Equals(quantity));
            pb = pb.And(p => p.ProductID.Equals(productID));

            return await Task.FromResult(_entities.ShoppingCartItems.AsExpandable().Where(pb));
        }
    }
}
