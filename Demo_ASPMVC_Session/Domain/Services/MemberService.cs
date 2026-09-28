using Demo_ASPMVC_Session.Domain.Models;
using Isopoh.Cryptography.Argon2;

namespace Demo_ASPMVC_Session.Domain.Services
{
    public class MemberService
    {
        #region Fake Data
        private static List<Member> _members = [
            new Member(1, "della", "admin") { HashPwd = "$argon2id$v=19$m=65536,t=3,p=1$kjbwN1aeg2CcT3uC5Ivpcg$P/gfs61Zs75UDJIV+ltN6/d4d8ObACZjhzr2X1xMlH4"},
            new Member(2, "zaza", "user") { HashPwd = "$argon2id$v=19$m=16,t=2,p=1$WWtxODlUYTY0Z0w5YmxEMg$ydSGNlrDtpCqjUGYDJ6LJA"},
        ];
        private static int _nextProductId = 3;
        #endregion

        #region Methodes
        public void Register(string username, string password, string role = "user")
        {
            int id  = _nextProductId++;
            string hashPwd = Argon2.Hash(password); // Hachage avec Argon2

            Member memberToRegister = new Member(id, username, role) { HashPwd = hashPwd };
            _members.Add(memberToRegister);
        }

        public Member Login(string username, string password)
        {
            Member? member = _members.SingleOrDefault(m => m.Username == username);
            if(member is null)
            {
                throw new Exception("Bad credential !");
            }

            if(!Argon2.Verify(member.HashPwd, password)) // Vérification via Argon2
            {
                throw new Exception("Bad credential !");
            }

            return new Member(member.Id, member.Username, member.Role);
        }
        #endregion
    }
}
