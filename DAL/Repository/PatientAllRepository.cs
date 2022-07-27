using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;

namespace DAL.Repository
{
    public class PatientAllRepository
    {
        public PatientAllRepository(Connection connection)
        {
            this.connection = connection;
        }

        public Connection connection { get; set; }

        public IEnumerable<PatientAllEntity> GetAll()
        {
            Command cmd = new Command("Select * from AllPatient");
            return connection.ExecuteReader(cmd, MapToRecordEntity);
        }

        public bool Remove(int patientId)
        {
            Command cmd = new Command($"Delete from AllPatient where Id = @id ");
            cmd.AddParameter("id", patientId);
            return connection.ExecuteNonQuery(cmd) == 1;
        }

        public int Add(PatientAllEntity entity)
        {
            Command cmd = new Command("Insert into AllPatient(Id,LastName,FirstName,Problem,Date_Entry,Level,Statut) output inserted.Id " +
                $" values (@id,@lastName , @firstName,@problem,GETDATE(),@level,@statut) ;");
            
            cmd.AddParameter("id", entity.id);
            cmd.AddParameter("lastName", entity.lastName);
            cmd.AddParameter("firstName", entity.firstName);
            cmd.AddParameter("problem", entity.problem);
            cmd.AddParameter("level", entity.level);
            cmd.AddParameter("statut", entity.statut);


            return (int)connection.ExecuteScalar(cmd);


        }



        public bool Update(int id, PatientAllEntity entity)
        {
            Command cmd = new Command($"Update PatientAll SET Lastname =@lastname, Firstname=@firstname" +
                ",Problem=@problem, Level=@level, Statut = @statut where Id=@id");
            cmd.AddParameter("id", entity.id);
            cmd.AddParameter("lastname", entity.lastName);
            cmd.AddParameter("firstname", entity.firstName);
            cmd.AddParameter("problem", entity.problem);
            cmd.AddParameter("level", entity.level);
            //cmd.AddParameter("date_entry", entity.date_entry);
            cmd.AddParameter("statut", entity.statut);

            return connection.ExecuteNonQuery(cmd) == 1;



        }
        public PatientAllEntity MapToRecordEntity(IDataRecord record)
        {
            return new PatientAllEntity()
            {
                id = (int)record["Id"],
                lastName = (string)record["LastName"],
                firstName = (string)record["FirstName"],
                problem = (string)record["Problem"],
                date_entry = (DateTime)record["Date_Entry"],
                level = (int)record["Level"],
                statut = (string)record["Statut"]
            };
        }
    }
}

