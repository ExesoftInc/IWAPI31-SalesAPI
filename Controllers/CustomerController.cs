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
    [Route("Customer")]
    public class CustomerController : ControllerBase {
        
        private IDbEntities _entities;
        
        private IMapper _mapper;
        
        private ILoggerManager _logger;
        
        public CustomerController(EntitiesContext context, IMapper mapper, ILoggerManager logger) {
            _entities = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IQueryable<CustomerModel> GetAllCustomers() {

            ICollection<CustomerModel> models = _mapper.Map<ICollection<CustomerModel>>(_entities.Customers);

            return models.AsQueryable();
        }
        
        [HttpGet("Paged")]
        public IPagedList<CustomerModel> GetPagedCustomers(int pageIndex, int pageSize) {

            ICollection<CustomerModel> models = _mapper.Map<ICollection<CustomerModel>>(_entities.Customers);

            return models.ToPagedList(pageIndex, pageSize, 0, models.Count);
        }
        
        [HttpGet("{customerID}")]
        public async Task<ActionResult> GetCustomer_ByCustomerID(int customerID) {

            CustomerModel model;

          var query = await SearchByPk(customerID);
            if (!query.Any()) {
              return NotFound();
            }
            else {
           model = _mapper.Map<CustomerModel>(query.SingleOrDefault());
            }

            return Ok(model);
        }
        
        [HttpGet("GetCustomer_ByStoreID/{storeID}")]
        public IQueryable<CustomerModel> GetCustomer_ByStoreID(int storeID) {

            ICollection<CustomerModel> models = _mapper.Map<ICollection<CustomerModel>>(_entities.Customers.Where(x => x.StoreID == storeID));

            return models.AsQueryable();
        }
        
        [HttpGet("GetCustomer_ByTerritoryID/{territoryID}")]
        public IQueryable<CustomerModel> GetCustomer_ByTerritoryID(int territoryID) {

            ICollection<CustomerModel> models = _mapper.Map<ICollection<CustomerModel>>(_entities.Customers.Where(x => x.TerritoryID == territoryID));

            return models.AsQueryable();
        }
        
        [HttpPost("")]
        public async Task<ActionResult> AddCustomer([FromBody]CustomerModel model) {

            Customer entity = null;

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            if (model.StoreID != null) {
                var matchStoreID = _entities.Stores.Where(x => x.BusinessEntityID.Equals(model.StoreID));
                if (!matchStoreID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("StoreID = '{0}' doesn't exist in the system.", model.StoreID));
                }
            }

            if (model.TerritoryID != null) {
                var matchTerritoryID = _entities.SalesTerritories.Where(x => x.TerritoryID.Equals(model.TerritoryID));
                if (!matchTerritoryID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("TerritoryID = '{0}' doesn't exist in the system.", model.TerritoryID));
                }
            }


            var search = SearchbyUnique(model.PersonID, model.StoreID, model.TerritoryID);
            if (search.Result.Count() > 0) {
              return BadRequest("Duplicate Record;" + string.Format("Record already exists in the system with this(these) value(s):{0}, {1}, {2}", model.PersonID, model.StoreID, model.TerritoryID));
            }

           try
           {
                 entity = _mapper.Map<Customer>(model);
                _entities.Customers.Add(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            model.CustomerID = entity.CustomerID;
            _logger.LogInfo(string.Format("Customer added with values: '{0}'", JsonConvert.SerializeObject(model)));

            return CreatedAtAction("GetCustomer_ByCustomerID", new {customerID = entity.CustomerID}, model);
        }
        
        [HttpPut("{customerID}")]
        public async Task<ActionResult> UpdateCustomer(int customerID, [FromBody]CustomerModel model) {

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var query = SearchByPk(customerID).Result;
            if (!query.Any()) {
              ModelState.AddModelError("Record Not Found", string.Format("Customer with _customerID = '{0}' doesn't exist.",customerID)); 
              return BadRequest(ModelState);
            }

            var matchStoreID = _entities.Stores.Where(x => x.BusinessEntityID.Equals(model.StoreID));
            if (!matchStoreID.Any()) {
              ModelState.AddModelError("Foreign Key Violation", string.Format("Customer with StoreID = '{0}' doesn't exist.", model.StoreID)); 
              return BadRequest(ModelState);
            }


            var matchTerritoryID = _entities.SalesTerritories.Where(x => x.TerritoryID.Equals(model.TerritoryID));
            if (!matchTerritoryID.Any()) {
              ModelState.AddModelError("Foreign Key Violation", string.Format("Customer with TerritoryID = '{0}' doesn't exist.", model.TerritoryID)); 
              return BadRequest(ModelState);
            }


           try
           {
            Customer entity = query.SingleOrDefault();
             entity = model.ToEntity(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("Customer updated with values: '{0}'", JsonConvert.SerializeObject(model)));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        
        [HttpDelete("{customerID}")]
        public async Task<ActionResult> DeleteCustomer(int customerID) {

            var query = SearchByPk(customerID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("Customer with _customerID = '{0}' doesn't exist.",customerID));
            }
            var entity = query.SingleOrDefault();

           try
           {
                _entities.Customers.Remove(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("Customer deleted with values: '{0}'", JsonConvert.SerializeObject(new CustomerModel(entity))));

            return Ok(new CustomerModel(entity));
        }
        
        private async Task<IQueryable<Customer>> SearchByPk(int customerID) {

            var pb = PredicateBuilder.New<Customer>();
            pb = pb.And(p => p.CustomerID.Equals(customerID));

            return await Task.FromResult(_entities.Customers.AsExpandable().Where(pb));
        }
        
        private async Task<IQueryable<Customer>> SearchbyUnique(System.Int32? personID, System.Int32? storeID, System.Int32? territoryID) {

            var pb = PredicateBuilder.New<Customer>();
            if (personID.HasValue) {
                pb = pb.And(p => ((System.Int32)p.PersonID).Equals(personID.Value));
            }
            else {
                pb = pb.And(p => p.PersonID == null);
            }
            if (storeID.HasValue) {
                pb = pb.And(p => ((System.Int32)p.StoreID).Equals(storeID.Value));
            }
            else {
                pb = pb.And(p => p.StoreID == null);
            }
            if (territoryID.HasValue) {
                pb = pb.And(p => ((System.Int32)p.TerritoryID).Equals(territoryID.Value));
            }
            else {
                pb = pb.And(p => p.TerritoryID == null);
            }

            return await Task.FromResult(_entities.Customers.AsExpandable().Where(pb));
        }
    }
}
