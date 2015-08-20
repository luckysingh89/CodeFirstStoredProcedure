using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.EntityClient;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleCodeFirst.DB
{
    public class SampleContext : DbContext
    {
        public SampleContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<PeopleEntity> PeopleEntity { get; set; }


    }

    public class HelperMethods
    {
        public List<PeopleEntity> GetPeopleEntity(string matchCase)
        {
            using (var db = new SampleContext())
            {
                // If using Code First we need to make sure the model is built before we open the connection 
                // This isn't required for models created with the EF Designer 
                db.Database.Initialize(force: false);

                // Create a SQL command to execute the sproc 
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "[dbo].[Sp_GetPeople]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.Value = matchCase;
                param.ParameterName = "MatchCase";
                cmd.Parameters.Add(param);

                try
                {
                    db.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    // Read Blogs from the first result set 
                    var entity = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<PeopleEntity>(reader).ToList();

                    return entity;
                }

                catch (Exception ex)
                {

                }
                finally
                {
                    db.Database.Connection.Close();
                }
            }
            return null;
        }
    }

    [Table("tbl_People")]
    public class PeopleEntity
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(2000)]
        public string Name { get; set; }
    }
}
