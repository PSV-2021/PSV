using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Integration.Model;
using Integration.Repository.Interfaces;
using Npgsql;

namespace Integration.Repository.Sql
{
    class DrugstoreFeedbackSqlRepository : IDrugstoreFeedbackRepository
    {

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("...");
        }
        public bool Delete(string id)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                if (con.State == ConnectionState.Open)
                {

                    return true;
                }
            }

            return false;
        }

        public List<DrugstoreFeedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public DrugstoreFeedback GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(DrugstoreFeedback newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(DrugstoreFeedback editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
