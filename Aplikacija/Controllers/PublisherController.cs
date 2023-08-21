using Aplikacija.Models;
using Aplikacija.Services;
using Aplikacija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Controllers
{
    [Route("api/publisher")]
    public class PublisherController : Controller
    {
        public PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

       [HttpPost("create-publisher")]
       public IActionResult CreatePublisher([FromBody] PublisherVM publisher)
       {
             _publisherService.AddPublisher(publisher);
            return Ok(publisher);
       }
       

        [HttpGet("get-publisher-data/{id}")]
        public IActionResult GetPublisherData(string id)
        {
            try
            {
                var pub = _publisherService.GetPublisherData(id);
                return Ok(pub);
            }
            catch (Exception)
            {

                return BadRequest("Sorry, we coluld not load the publisher...");
            }
          
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            try
            {
                var _result = _publisherService.GetPublishers();
                return Ok(_result);
            }
            catch (Exception)
            {

                return BadRequest("Sorry, we coluld not load the publishers...");
            }
            
        }
    }
}
