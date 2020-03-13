using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.implementattions
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        private readonly PersonConverter _converter;
        
        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        //Método responsável por gerar uma nova pessoa
        //caso houesse um banco de dados seria necessário persistir nos dados
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }


        //Método responsável por retornar todas as pessoas 
        //porém as pessoas no momento são mockus
        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        //Método responsáve por retornar uma pessoa
        //como não acessamos o banco de dados estamos retornando um mock
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName( firstName, lastName));
        }

        //Método de atualizar as pessoas
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
        //Método responsável por deletar uma pessoa através do ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public bool Exist(long id)
        {
            return _repository.Exist(id);
        }
    }
}
