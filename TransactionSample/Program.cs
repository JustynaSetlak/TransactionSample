using System;
using TransactionSample.Model;
using TransactionSample.Repository;

namespace TransactionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository repository = new PersonRepository(new PeopleContext());
            repository.AddPerson(new Person{FirstName = "Johny", LastName = "Wolf"});
            repository.Update();
        }
    }
}
