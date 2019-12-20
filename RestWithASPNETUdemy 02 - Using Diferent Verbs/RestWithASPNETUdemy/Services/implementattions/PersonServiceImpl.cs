using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNETUdemy.Services.implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        //contador responsável por gerar um fake ID
        private volatile int count;

        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public Person Create(Person person)
        {
            return person;
        }

        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            //codigo de deleção
        }

        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                firstName = "Robert",
                lastName = "Silva",
                Address = "Sao Paulo - SP - Brasil",
                Gender = "Male"
            };
        }

        //Método de atualizar as pessoas
        public Person Update(Person person)
        {
            return person;
        }

        //metodo responsável por gerar mocks de pessoas (fake)
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                firstName = "Person Name" + i,
                lastName = "Person LastName" + i,
                Address = "Some address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
