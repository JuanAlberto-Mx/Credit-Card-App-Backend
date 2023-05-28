using credit_card_app_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace credit_card_app_backend.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        // ReadOnly variable to set the application DB context
        private readonly ApplicationDBContext _context;

        // Dependency injection
        public CreditCardController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<CreditCardController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Get the list of credit cards
                var creditCardList = await _context.dbCreditCards.ToListAsync();

                // Return a status 200 with the credit card list
                return Ok(creditCardList);
            }
            catch (Exception ex)
            {
                // Message of Error 404 in case of something goes wrong
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CreditCardController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                // Finds the credit card in the database
                var creditCard = await _context.dbCreditCards.FindAsync(id);

                // Returns a NotFound message if credit card does not exist
                if(creditCard == null)
                {
                    return NotFound();
                }

				// Returns the status 200 with the credit card information
				return Ok(creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CreditCardController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditCard creditCard)
        {
            try
            {
                // Add the credit card entered from the web page
                _context.Add(creditCard);

                // Save changes made in the database
                await _context.SaveChangesAsync();

                // Returns the status 200
                return Ok(creditCard);
            }
            catch (Exception ex)
            {
				// Message of Error 404 in case of something goes wrong
				return BadRequest(ex.Message);
            }
        }

        // PUT api/<CreditCardController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditCard creditCard)
        {
            try
            {
                // A NotFound messages is returned in case of id specified is different to the target credit card
                if(id != creditCard.id)
                {
                    return NotFound();
                }
                
                // Updates the credit card received from the web page
                _context.Update(creditCard);

                // Save the changes made in the database
                await _context.SaveChangesAsync();

                // Returns a customized status 200 message
                return Ok(new {message = "Credit card updated successfully"});
            }
            catch (Exception ex)
            {
				// Message of Error 404 in case of something goes wrong
				return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CreditCardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Finds the credit card with the id received from the web page
                var creditCard = await _context.dbCreditCards.FindAsync(id);

                // If credit card is different to NULL then exists the record
				if (creditCard != null)
				{
                    // Removes the credit card found
					_context.dbCreditCards.Remove(creditCard);

                    // Saves the changes made in the database
					await _context.SaveChangesAsync();

                    // Returns a customized status 200 message
					return Ok(new { message = "Credit card deleted successfully" });
				}

                return NotFound();
			}
            catch(Exception ex)
            {
				// Message of Error 404 in case of something goes wrong
				return BadRequest();
            }
        }
    }
}
