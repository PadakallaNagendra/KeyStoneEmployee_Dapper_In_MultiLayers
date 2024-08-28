using KeyStoneEmployeeManageMent_BusinessObject.InterFace;
using KeyStoneEmployeeManageMent_BusinessObject.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyStoneEmployee_Dapper_In_MultiLayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> post([FromBody] CustomerDTO customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _customerService.AddCustomer(customer);
                    return StatusCode(StatusCodes.Status200OK, "Customer Detais Added");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server eroer");

            }
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var htldata = await _customerService.GetAllCustomer();
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, htldata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        //        [Route("GetBookingDetailsById/{id}")]
        [HttpGet]
        [Route("GetCustomerById/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var htldata = await _customerService.GetCustomerById(id);
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "sip position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, htldata);
                }
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> Put([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _customerService.UpdateCustomer(customerDTO);
                return StatusCode(StatusCodes.Status201Created, "Customer Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }


        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var htldata = await _customerService.DeleteCustomer(id);
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "hotelId not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "hotelId is deleted succesfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

    }
}
