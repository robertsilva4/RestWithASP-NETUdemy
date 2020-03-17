using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    public class UserVO
    {
        [DataMember(Order = 1, Name = "Login")]
        public string Login { get; set; }

        [DataMember(Order = 2, Name = "Senha")]
        public string AccessKey { get; set; }
    }
}
