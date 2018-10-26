using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky.Services.LendingServices;
using Digibooky.API.Controllers.Lendings.Interfaces;
using Digibooky.Services.LendingServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Digibooky.Domain.Lendings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void Post([FromBody]LendingDTOLendingPost lendingDTOLendingPost)
        {
            _lendingService.LendBook(lendingDTOLendingPost.inss, lendingDTOLendingPost.isbn);
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
