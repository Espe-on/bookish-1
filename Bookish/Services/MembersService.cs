using System.Collections.Generic;
using Bookish.Models.Domain;
using Bookish.Models.Request;
using Dapper;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace Bookish.Services
{
    public interface IMembersService
    {
        IEnumerable<Member> GetAllMembers();
        void InsertUser(CreateMemberModel memberModel);
    }
    
    public class MembersService : IMembersService
    {
        private const string DbConnectionString = "Server=localhost;Database=bookish;Uid=root;Pwd=secret";

        public IEnumerable<Member> GetAllMembers()
        {
            var connection = new MySqlConnection(DbConnectionString);
            return connection.Query<Member>("SELECT * FROM member");
        }

        public void InsertUser(CreateMemberModel memberModel)
        {
            var connection = new MySqlConnection(DbConnectionString);
            connection.Execute(
                "INSERT INTO member (first_name, last_name) VALUES (@FirstName, @LastName)",
                new {FirstName = memberModel.FirstName, LastName = memberModel.LastName}
            );
        }
    }
}