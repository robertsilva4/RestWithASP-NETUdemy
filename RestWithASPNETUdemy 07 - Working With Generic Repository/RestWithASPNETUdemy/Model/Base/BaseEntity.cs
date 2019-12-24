using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model.Base
{
    //[DataContract]
    public class BaseEntity
    {
        //contrato entre atributos
        //e a estrutura da tabela
        [Column("id")]
        public long? Id { get; set; }

    }
}
