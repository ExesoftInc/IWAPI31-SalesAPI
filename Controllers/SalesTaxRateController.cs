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
    [Route("SalesTaxRate")]
    public class SalesTaxRateController : ControllerBase {
        
        private IDbEntities _entities;
        
        private IMapper _mapper;
        
        private ILoggerManager _logger;
        
        public SalesTaxRateController(EntitiesContext context, IMapper mapper, ILoggerManager logger) {
            _entities = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IQueryable<SalesTaxRateModel> GetAllSalesTaxRates() {

            ICollection<SalesTaxRateModel> models = _mapper.Map<ICollection<SalesTaxRateModel>>(_entities.SalesTaxRates);

            return models.AsQueryable();
        }
        
        [HttpGet("Paged")]
        public IPagedList<SalesTaxRateModel> GetPagedSalesTaxRates(int pageIndex, int pageSize) {

            ICollection<SalesTaxRateModel> models = _mapper.Map<ICollection<SalesTaxRateModel>>(_entities.SalesTaxRates);

            return models.ToPagedList(pageIndex, pageSize, 0, models.Count);
        }
        
        [HttpGet("{salesTaxRateID}")]
        public async Task<ActionResult> GetSalesTaxRate_BySalesTaxRateID(int salesTaxRateID) {

            SalesTaxRateModel model;

          var query = await SearchByPk(salesTaxRateID);
            if (!query.Any()) {
              return NotFound();
            }
            else {
           model = _mapper.Map<SalesTaxRateModel>(query.SingleOrDefault());
            }

            return Ok(model);
        }
        
        [HttpPost("")]
        public async Task<ActionResult> AddSalesTaxRate([FromBody]SalesTaxRateModel model) {

            SalesTaxRate entity = null;

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }


            var search = SearchbyUnique(model.StateProvinceID, model.TaxType, model.TaxRate, model.Name);
            if (search.Result.Count() > 0) {
              return BadRequest("Duplicate Record;" + string.Format("Record already exists in the system with this(these) value(s):{0}, {1}, {2}, {3}", model.StateProvinceID, model.TaxType, model.TaxRate, model.Name));
            }

           try
           {
                 entity = _mapper.Map<SalesTaxRate>(model);
                _entities.SalesTaxRates.Add(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            model.SalesTaxRateID = entity.SalesTaxRateID;
            _logger.LogInfo(string.Format("SalesTaxRate added with values: '{0}'", JsonConvert.SerializeObject(model)));

            return CreatedAtAction("GetSalesTaxRate_BySalesTaxRateID", new {salesTaxRateID = entity.SalesTaxRateID}, model);
        }
        
        [HttpPut("{salesTaxRateID}")]
        public async Task<ActionResult> UpdateSalesTaxRate(int salesTaxRateID, [FromBody]SalesTaxRateModel model) {

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var query = SearchByPk(salesTaxRateID).Result;
            if (!query.Any()) {
              ModelState.AddModelError("Record Not Found", string.Format("SalesTaxRate with _salesTaxRateID = '{0}' doesn't exist.",salesTaxRateID)); 
              return BadRequest(ModelState);
            }

           try
           {
            SalesTaxRate entity = query.SingleOrDefault();
             entity = model.ToEntity(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("SalesTaxRate updated with values: '{0}'", JsonConvert.SerializeObject(model)));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        
        [HttpDelete("{salesTaxRateID}")]
        public async Task<ActionResult> DeleteSalesTaxRate(int salesTaxRateID) {

            var query = SearchByPk(salesTaxRateID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("SalesTaxRate with _salesTaxRateID = '{0}' doesn't exist.",salesTaxRateID));
            }
            var entity = query.SingleOrDefault();

           try
           {
                _entities.SalesTaxRates.Remove(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("SalesTaxRate deleted with values: '{0}'", JsonConvert.SerializeObject(new SalesTaxRateModel(entity))));

            return Ok(new SalesTaxRateModel(entity));
        }
        
        private async Task<IQueryable<SalesTaxRate>> SearchByPk(int salesTaxRateID) {

            var pb = PredicateBuilder.New<SalesTaxRate>();
            pb = pb.And(p => p.SalesTaxRateID.Equals(salesTaxRateID));

            return await Task.FromResult(_entities.SalesTaxRates.AsExpandable().Where(pb));
        }
        
        private async Task<IQueryable<SalesTaxRate>> SearchbyUnique(int stateProvinceID, byte taxType, decimal taxRate, string name) {

            var pb = PredicateBuilder.New<SalesTaxRate>();
            pb = pb.And(p => p.StateProvinceID.Equals(stateProvinceID));
            pb = pb.And(p => p.TaxType.Equals(taxType));
            pb = pb.And(p => p.TaxRate.Equals(taxRate));
            pb = pb.And(p => p.Name.Equals(name));

            return await Task.FromResult(_entities.SalesTaxRates.AsExpandable().Where(pb));
        }
    }
}

