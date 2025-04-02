using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("find-cart/{id}")]
        [ProducesResponseType(typeof(CartVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartVO>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);

            if (cart == null) return NotFound();

            return Ok(cart);
        } 
        
        [HttpPost("add-cart")]
        [ProducesResponseType(typeof(CartVO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartVO>> AddCart(CartVO cartVO)
        {
            var cart = await _repository.SaveOrUpdateCart(cartVO);

            if (cart == null) return BadRequest();

            return CreatedAtAction(nameof(FindById), new { id = cart.CartHeader.UserId }, cart);
        }

        [HttpPut("update-cart")]
        [ProducesResponseType(typeof(CartVO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO cartVO)
        {
            var cart = await _repository.SaveOrUpdateCart(cartVO);

            if (cart == null) return BadRequest();

            return Ok(cart);
        }
        
        [HttpDelete("remove-cart/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();

            return NoContent();
        }
    }
}
