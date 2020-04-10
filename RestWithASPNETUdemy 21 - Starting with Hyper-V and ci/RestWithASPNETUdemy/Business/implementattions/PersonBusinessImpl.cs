using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

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
        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            string query = @"select * from Persons p where 1 = 1";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";

            query = query + $"order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"SELECT COUNT(*) FROM persons p WHERE 1 = 1";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" AND p.firstName LIKE '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page + 1,
                List = _converter.ParseList(persons),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
        public bool Exist(long id)
        {
            return _repository.Exist(id);
        }
    }
}
