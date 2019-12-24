using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;
        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        //Método de atualizar as pessoas
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
