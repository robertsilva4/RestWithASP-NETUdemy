using System.Collections.Generic;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        [DataMember(Order = 1, Name = "Código") ]
        public long? Id { get; set; }
        [DataMember(Order = 2, Name = "Nome")]
        public string firstName { get; set; }
        [DataMember(Order = 3, Name = "Sobrenome")]
        public string lastName { get; set; }
        [DataMember(Order = 4, Name = "Endereço")]
        public string Address { get; set; }
        [DataMember(Order = 5, Name = "Genero")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
