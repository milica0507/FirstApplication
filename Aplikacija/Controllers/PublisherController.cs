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
    public class PublisherController : Controller
    {
        public PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

       [HttpPost]
       [Route("CreatePublisher")]
       public IActionResult CreatePublisher([FromBody] PublisherVM publisher)
       {
             _publisherService.AddPublisher(publisher);
            return Ok(publisher);
       }
       

        [HttpGet]
        [Route("GetPublisherData/{id}")]
        public IActionResult GetPublisherData(string id)
        {
           var pub= _publisherService.GetPublisherData(id);
            return Ok(pub);
        }

        [HttpGet]
        [Route("GetAllPublishers")]
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
