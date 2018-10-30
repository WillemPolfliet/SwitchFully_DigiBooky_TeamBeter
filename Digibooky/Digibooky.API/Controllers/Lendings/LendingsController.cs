using Digibooky.API.Controllers.Lendings.Interfaces;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;
using Digibooky.Services.LendingServices;
using Digibooky.Services.LendingServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Digibooky.API.Controllers.Lendings
{
	[Authorize]
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
		[Authorize(Policy = "MustBeLibrarian")]
		[HttpGet]
        public List<LendingDTO> GetAll()
        {
            var allLendings = _lendingService.GetAll();
            var allLendingDTOs = _lendingMapper.LendingListToLendingDTOList(allLendings);

            return allLendingDTOs;
        }

        // POST api/<controller>
		[Authorize(Policy = "MustBeMember")]
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

		[Authorize(Policy = "MustBeMember")]
		[HttpPost]
        [Route("ReturnBook")]
        public ActionResult ReturnBook([FromBody]string lendID)
        {
            try
            {
                _lendingService.ReturnBook(lendID);
                return Ok();
            }
            catch (LentOutException lentoutEx)
            {
                return BadRequest(lentoutEx.Message);
            }
            catch (LendingException lendingEx)
            {
                return BadRequest(lendingEx.Message);

            }

        }
    }
}
