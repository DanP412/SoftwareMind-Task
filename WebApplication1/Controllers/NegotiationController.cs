﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegotiationApp.Entities.DTOs.Negotiation;
using NegotiationApp.Entities.Negotiations;
using NegotiationApp.Services.NegotiationService;
using NegotiationApp.Services.ProductService;
using NegotiationApp.Services.Validation.NegotiationValidationService;

namespace NegotiationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegotiationController : ControllerBase
    {
        private readonly ILogger<NegotiationController> _logger;
        private readonly INegotiationService _negotiationService;
        private readonly INegotiationValidationService _negotiationValidationService;
        private readonly IProductService _productService;

        public NegotiationController(
            ILogger<NegotiationController> logger,
            INegotiationService negotiationService,
            INegotiationValidationService negotiationValidationService,
            IProductService productService
            )
        {
            _negotiationValidationService = negotiationValidationService;
            _negotiationService = negotiationService;
            _productService = productService;
            _logger = logger;
        }

      
        [HttpGet(Name = "GetAllNegotiations")]
        public async Task<ActionResult<IEnumerable<NegotiationResponseDto>>> GetAll()
        {
            var negotiations = await _negotiationService.GetAllNegotiationsAsync();

            if (negotiations != null)
            {
                return Ok(negotiations);
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetNegotiationById")]
        public async Task<ActionResult<NegotiationResponseDto>> Get(int id)
        {
            var negotiation = await _negotiationService.GetNegotiationByIdAsync(id);

            if (negotiation != null)
            {
                return Ok(negotiation);
            }

            return NotFound();
        }

        [HttpPost(Name = "AddNegotiation")]
        public async Task<ActionResult<Negotiation>> Post([FromBody] NegotiationCreateDto negotiationToCreate)
        {
            string errorMessage = _negotiationValidationService.ValidateNegotiation(negotiationToCreate);
            bool NegotiationAlreadyExist = await _negotiationValidationService.
                CheckIfNegotiationAlreadyExist(negotiationToCreate.ProductId, negotiationToCreate.CustomerId);

            var product = await _productService.GetProductByIdAsync(negotiationToCreate.ProductId);
            bool priceIsNotValid = _negotiationValidationService.ProposedPriceIsValid(negotiationToCreate, product.Price);

            if (errorMessage != string.Empty)
            {
                return BadRequest(errorMessage);

            }
            else if (priceIsNotValid)
            {
                return Ok("Your ngeotiation has been rejected");
            }

            var createdNegotiation = await _negotiationService.AddNegotiationAsync(negotiationToCreate);

            return CreatedAtAction(nameof(Get), new { id = createdNegotiation.Id }, createdNegotiation);
        }

        [HttpPut("{id}", Name = "UpdateNegotiation")]
        public async Task<ActionResult> Update(int id, [FromBody] NegotiationUpdateDto negotiationToUpdate)
        {
            var currentNegotiation = await _negotiationService.GetNegotiationByIdAsync(id);
            var product = await _productService.GetProductByIdAsync(currentNegotiation.ProductId);
            var attempts = currentNegotiation.Attempts.Count;

            string errorMessage = _negotiationValidationService.ValidateNegotiation(new NegotiationCreateDto
            {
                ProposedPrice = negotiationToUpdate.ProposedPrice
            });
            bool priceIsNotValid = !_negotiationValidationService.ProposedPriceIsValid(
            new NegotiationCreateDto
            {
                ProposedPrice = negotiationToUpdate.ProposedPrice,
            }
            , product.Price);


            if (errorMessage != string.Empty)
            {
                return BadRequest(errorMessage);

            }
            else if (attempts >= 3)
            {
                return BadRequest("You have used the maximum number of negotiation attempts");
            }
            else if (priceIsNotValid)
            {
                return Ok("Your ngeotiation has been rejected");
            }

            var updatedNegotiation = await _negotiationService.UpdateNegotiationAsync(id, negotiationToUpdate);

            return Ok(updatedNegotiation);
        }
     
        [HttpPut("{id}/status", Name = "UpdateNegotiationStatus")]
        public async Task<ActionResult> Update(int id, [FromBody] NegotiationStatusUpdateDto negotiationStatusToUpdate)
        {
            var updatedNegotiation = await _negotiationService.UpdateNegotiationStatusAsync(id, negotiationStatusToUpdate);

            if (updatedNegotiation != null)
            {
                return Ok(updatedNegotiation);
            }

            return NotFound();
        }

        [HttpDelete("{id}", Name = "DeleteNegotiation")]
        public async Task<IActionResult> Delete(int id)
        {
            bool successfullyDeleted = await _negotiationService.DeleteNegotiationAsync(id);

            if (successfullyDeleted)
            {
                return Ok();
            }

            else return NotFound();
        }
    }
}
