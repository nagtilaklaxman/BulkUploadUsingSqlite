using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Models;
using Core.Entities;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        protected new IActionResult Ok(object result = null)
        {
            return new EnvelopeResult(Envelope.Ok(result), HttpStatusCode.OK);
        }

        protected IActionResult NotFound(BulkError error, string invalidField = null)
        {
            return new EnvelopeResult(Envelope.Error(error, invalidField), HttpStatusCode.NotFound);
        }

        protected IActionResult Error(BulkError error, string invalidField = null)
        {
            return new EnvelopeResult(Envelope.Error(error, invalidField), HttpStatusCode.BadRequest);
        }

        protected IActionResult FromResult<T>(Result<T, BulkError> result)
        {
            if (result.IsSuccess)
                return Ok();

            return Error(result.Error);
        }
    }
    public sealed class EnvelopeResult : IActionResult
    {
        private readonly Envelope _envelope;
        private readonly int _statusCode;

        public EnvelopeResult(Envelope envelope, HttpStatusCode statusCode)
        {
            _statusCode = (int)statusCode;
            _envelope = envelope;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_envelope)
            {
                StatusCode = _statusCode
            };

            return objectResult.ExecuteResultAsync(context);
        }
    }
}

