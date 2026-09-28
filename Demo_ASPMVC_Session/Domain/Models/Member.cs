namespace Demo_ASPMVC_Session.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? HashPwd { get; set; }
        public string Role { get; set; }

        public Member(string username, string hashPwd, string role)
        {
            this.Id = 0;
            this.Username = username;
            this.HashPwd = hashPwd;
            this.Role = role;
        }

        public Member(int id, string username, string role) 
        {
            this.Id = id;
            this.Username = username;
            this.HashPwd = null;
            this.Role = role;
        }
    }
}
