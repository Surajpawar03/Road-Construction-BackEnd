using System.Data;
using Dapper;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RoadConstruction.Models;
using RoadConstruction.Repositories;

namespace RoadConstruction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        private readonly ConstructionRepository _repository;

        public ConstructionController(ConstructionRepository repository)
        {
            _repository = repository;
        }

        //[HttpPost("insert")]
        //public async Task<IActionResult> InsertConstructionProject([FromBody] ConstructionRequest project)
        //{
        //    if (project == null)
        //        return BadRequest("Invalid input data");

        //    int insertedId = await _repository.InsertConstructionProjectAsync(project);

        //    return Ok(new { Message = "Data inserted successfully", ProjectId = insertedId });
        //}

        //[HttpGet("get-construction-data/{id}")]
        //public async Task<IActionResult> GetConstructionData(int id)
        //{
        //    var result = await _repository.GetConstructionDataAsync(id);
        //    if (result == null)
        //        return NotFound(new { Message = "Project not found" });

        //    return Ok(result);
        //}
            
        [HttpPut("update")]
        public async Task<IActionResult> UpdateConstructionProject([FromBody] ConstructionRequest project)
        {
            if (project == null || project.Id <= 0)
                return BadRequest("Invalid input data");

            var message = await _repository.UpdateConstructionProjectAsync(project);

            return Ok(new { Message = message });
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllConstructionData()
        {
            var result = await _repository.GetAllConstructionDataAsync();
            if (result == null || result.Count == 0)
                return NotFound(new { Message = "No projects found" });

            return Ok(result);
        }
    }
}
