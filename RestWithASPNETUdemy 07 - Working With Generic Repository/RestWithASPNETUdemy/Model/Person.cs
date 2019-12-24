using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Model
{
    public class Person : BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

    }
}
