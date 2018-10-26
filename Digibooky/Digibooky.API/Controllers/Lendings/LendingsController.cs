﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky.Services.LendingServices;
using Digibooky.API.Controllers.Lendings.Interfaces;
using Digibooky.Services.LendingServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;


namespace Digibooky.API.Controllers.Lendings
{
    [Route("api/[controller]")]
    public class LendingsController : ControllerBase
    {
        private readonly ILendingService _lendingService;
        private readonly ILendingMapper _lendingMapper;

        public LendingsController(ILendingService lendingService, ILendingMapper lendingMapper)
        {
            _lendingService = lendingService;
            _lendingMapper = lendingMapper;
        }



        // GET: api/<controller>
        [HttpGet]
        public List<LendingDTO> Get()
        {
            var allLendings = _lendingService.GetAll();
            var allLendingDTOs = _lendingMapper.LendingListToLendingDTOList(allLendings);

            return allLendingDTOs;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Lend([FromBody]LendingDTOLendingPost lendingDTOLendingPost)
        {
            try
            {
                _lendingService.LendBook(lendingDTOLendingPost.inss, lendingDTOLendingPost.isbn);
                return Ok();
            }
            catch (LendingException lendingException)
            {
                return NotFound(lendingException.Message);
            }
            catch (LentOutException lentOutException)
            {
                return BadRequest(lentOutException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
