using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TransactionSample.Model;

namespace TransactionSample.Repository
{
    public class PersonRepository
    {
        private readonly PeopleContext _context;

        public PersonRepository(PeopleContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlCommand(
                        "INSERT INTO People VALUES(@firstName, @lastName)",
                        new SqlParameter("firstName", person.FirstName),
                        new SqlParameter("lastName", person.LastName));

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var update = _context.Database.ExecuteSqlCommand(
                        @"UPDATE People SET LastName = 'Novak'" +
                        " WHERE FirstName LIKE 'Johny'"
                    );

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}