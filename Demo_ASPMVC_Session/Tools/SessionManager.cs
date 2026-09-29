using Demo_ASPMVC_Session.Domain.Models;

namespace Demo_ASPMVC_Session.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public bool isConnect
        {
            get { return _session.GetInt32(nameof(MemberId)) is not null; }
        }
        public int? MemberId
        {
            get { return _session.GetInt32(nameof(MemberId));  }
        }
        public string? Username
        {
            get { return _session.GetString(nameof(Username)); }
        }

        public void Login(Member member)
        {
            _session.SetInt32(nameof(MemberId), member.Id);
            _session.SetString(nameof(Username), member.Username);
        }
        public void Logout()
        {
            _session.Clear();
        }
    }
}
