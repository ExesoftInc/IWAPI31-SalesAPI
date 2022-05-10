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
    [Route("PersonCreditCard")]
    public class PersonCreditCardController : ControllerBase {
        
        private IDbEntities _entities;
        
        private IMapper _mapper;
        
        private ILoggerManager _logger;
        
        public PersonCreditCardController(EntitiesContext context, IMapper mapper, ILoggerManager logger) {
            _entities = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IQueryable<PersonCreditCardModel> GetAllPersonCreditCards() {

            ICollection<PersonCreditCardModel> models = _mapper.Map<ICollection<PersonCreditCardModel>>(_entities.PersonCreditCards);

            return models.AsQueryable();
        }
        
        [HttpGet("Paged")]
        public IPagedList<PersonCreditCardModel> GetPagedPersonCreditCards(int pageIndex, int pageSize) {

            ICollection<PersonCreditCardModel> models = _mapper.Map<ICollection<PersonCreditCardModel>>(_entities.PersonCreditCards);

            return models.ToPagedList(pageIndex, pageSize, 0, models.Count);
        }
        
        [HttpGet("{businessEntityID}/{creditCardID}")]
        public async Task<ActionResult> GetPersonCreditCard_ByBusinessEntityIDCreditCardID(int businessEntityID, int creditCardID) {

            PersonCreditCardModel model;

          var query = await SearchByPk(businessEntityID, creditCardID);
            if (!query.Any()) {
              return NotFound();
            }
            else {
           model = _mapper.Map<PersonCreditCardModel>(query.SingleOrDefault());
            }

            return Ok(model);
        }
        
        [HttpGet("GetPersonCreditCard_ByCreditCardID/{creditCardID}")]
        public IQueryable<PersonCreditCardModel> GetPersonCreditCard_ByCreditCardID(int creditCardID) {

            ICollection<PersonCreditCardModel> models = _mapper.Map<ICollection<PersonCreditCardModel>>(_entities.PersonCreditCards.Where(x => x.CreditCardID == creditCardID));

            return models.AsQueryable();
        }
        
        [HttpPost("")]
        public async Task<ActionResult> AddPersonCreditCard([FromBody]PersonCreditCardModel model) {

            PersonCreditCard entity = null;

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var matchCreditCardID = _entities.CreditCards.Where(x => x.CreditCardID.Equals(model.CreditCardID));
            if (!matchCreditCardID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("CreditCardID = '{0}' doesn't exist in the system.", model.CreditCardID));
            }


            var search = SearchbyUnique(model.BusinessEntityID, model.CreditCardID);
            if (search.Result.Count() > 0) {
              return BadRequest("Duplicate Record;" + string.Format("Record already exists in the system with this(these) value(s):{0}, {1}", model.BusinessEntityID, model.CreditCardID));
            }

           try
           {
                 entity = _mapper.Map<PersonCreditCard>(model);
                _entities.PersonCreditCards.Add(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            _logger.LogInfo(string.Format("PersonCreditCard added with values: '{0}'", JsonConvert.SerializeObject(model)));

            return CreatedAtAction("GetPersonCreditCard_ByBusinessEntityIDCreditCardID", new {businessEntityID = entity.BusinessEntityID, creditCardID = entity.CreditCardID}, model);
        }
        
        [HttpPut("")]
        public async Task<ActionResult> UpdatePersonCreditCard([FromBody]PersonCreditCardModel model) {

            if (!ModelState.IsValid) {
              return BadRequest(ModelState);
            }

            var query = SearchByPk(model.BusinessEntityID, model.CreditCardID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("PersonCreditCard with _businessEntityID, _creditCardID = '{0}', '{1}' doesn't exist.",model.BusinessEntityID, model.CreditCardID));
            }
            var matchCreditCardID = _entities.CreditCards.Where(x => x.CreditCardID.Equals(model.CreditCardID));
            if (!matchCreditCardID.Any()) {
              return BadRequest("Foreign Key Violation;" + string.Format("CreditCardID = '{0}' doesn't exist in the system.", model.CreditCardID));
            }


           try
           {
            PersonCreditCard entity = query.SingleOrDefault();
             entity = model.ToEntity(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("PersonCreditCard updated with values: '{0}'", JsonConvert.SerializeObject(model)));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
        
        [HttpDelete("{businessEntityID}/{creditCardID}")]
        public async Task<ActionResult> DeletePersonCreditCard(int businessEntityID, int creditCardID) {

            var query = SearchByPk(businessEntityID, creditCardID).Result;
            if (!query.Any()) {
              return BadRequest("Record Not Found;" + string.Format("PersonCreditCard with _businessEntityID, _creditCardID = '{0}', '{1}' doesn't exist.",businessEntityID, creditCardID));
            }
            var entity = query.SingleOrDefault();

           try
           {
                _entities.PersonCreditCards.Remove(entity);
               await _entities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            _logger.LogInfo(string.Format("PersonCreditCard deleted with values: '{0}'", JsonConvert.SerializeObject(new PersonCreditCardModel(entity))));

            return Ok(new PersonCreditCardModel(entity));
        }
        
        private async Task<IQueryable<PersonCreditCard>> SearchByPk(int businessEntityID, int creditCardID) {

            var pb = PredicateBuilder.New<PersonCreditCard>();
            pb = pb.And(p => p.BusinessEntityID.Equals(businessEntityID));
            pb = pb.And(p => p.CreditCardID.Equals(creditCardID));

            return await Task.FromResult(_entities.PersonCreditCards.AsExpandable().Where(pb));
        }
        
        private async Task<IQueryable<PersonCreditCard>> SearchbyUnique(int businessEntityID, int creditCardID) {

            var pb = PredicateBuilder.New<PersonCreditCard>();
            pb = pb.And(p => p.BusinessEntityID.Equals(businessEntityID));
            pb = pb.And(p => p.CreditCardID.Equals(creditCardID));

            return await Task.FromResult(_entities.PersonCreditCards.AsExpandable().Where(pb));
        }
    }
}

