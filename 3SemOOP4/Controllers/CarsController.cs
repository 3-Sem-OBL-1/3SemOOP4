using _3.Sem_OOP_1;
using _3SemOOP4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3SemOOP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsRepsitory? _carsRepsitory;

        public CarsController(CarsRepsitory? carsRepsitory)
        {
            _carsRepsitory = carsRepsitory;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car>? cars = _carsRepsitory!.GetAll();
            if (cars != null)
            {
                return Ok(cars);
            }
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? car = _carsRepsitory!.GetById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car) 
        {
            try
            {
                Car createdCar = _carsRepsitory!.Add(car);
                return Created($"/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car car) 
        {
            try
            {
                Car? updatedCar = _carsRepsitory!.Update(id, car);
                if (updatedCar != null)
                {
                    return Ok(updatedCar);
                }
                return NotFound();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id) 
        { 
            Car? car = _carsRepsitory!.Delete(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }
    }
}
