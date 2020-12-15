using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using PortalApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //TODO: Create a method that knows hot to call the getallusers() function

        //TODO: create a getallhouseholds method

        public List<Household> GetAllHouseholds(IConfiguration configuration)
        {
            //1 need an open connection string
            var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();
            //2 need an empty list of households
            var allHouseholds = new List<Household>();
            //tell npgsql what function to call
            using (var cmd = new NpgsqlCommand("getallhouseholds", connString))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //4 here is where it is called and the data is stored into an NpgsqlDatareader
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                        allHouseholds.AddRange((List<Household>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Household>)));
                    }
                }
                connString.Close();
            }
            return allHouseholds;
        }
    }
}
