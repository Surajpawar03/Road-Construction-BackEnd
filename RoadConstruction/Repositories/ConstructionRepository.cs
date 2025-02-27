using Dapper;
using Microsoft.Data.SqlClient;
using RoadConstruction.Models;
using System.Data;
using System.Text.Json;

namespace RoadConstruction.Repositories
{
    public class ConstructionRepository
    {
        private readonly string _connectionString;

        public ConstructionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //public async Task<int> InsertConstructionProjectAsync(ConstructionRequest project)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@SamplingTime", project.SamplingTime);
        //        parameters.Add("@Properties", JsonSerializer.Serialize(project.Properties));

        //        return await connection.ExecuteScalarAsync<int>("InsertConstructionProject", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}


        //public async Task<ConstructionResponse> GetConstructionDataAsync(int projectId)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();
        //        using (var multi = await connection.QueryMultipleAsync("GetConstructionProject", new { ProjectId = projectId }, commandType: CommandType.StoredProcedure))
        //        {
        //            var project = await multi.ReadFirstOrDefaultAsync<ConstructionResponse>();
        //            if (project != null)
        //            {
        //                project.Properties = (await multi.ReadAsync<Property>()).AsList();
        //            }
        //            return project;
        //        }
        //    }
        //}

        public async Task<string> UpdateConstructionProjectAsync(ConstructionRequest project)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@ProjectId", project.Id);
                parameters.Add("@SamplingTime", project.SamplingTime);
                parameters.Add("@Properties", JsonSerializer.Serialize(project.Properties));

                return await connection.ExecuteScalarAsync<string>("UpdateConstructionProject", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<ConstructionRequest>> GetAllConstructionDataAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var multi = await connection.QueryMultipleAsync("GetAllConstructionProjects", commandType: CommandType.StoredProcedure))
                {
                    var projects = (await multi.ReadAsync<ConstructionRequest>()).ToList();
                    var properties = (await multi.ReadAsync<dynamic>()).ToList();

                    foreach (var project in projects)
                    {
                        project.Properties = properties
                            .Where(p => p.ProjectId == project.Id)
                            .Select(p => new Property
                            {
                                Label = p.Label,
                                Value = p.Value
                            }).ToList();
                    }

                    return projects;
                }
            }
        }
    }
}
