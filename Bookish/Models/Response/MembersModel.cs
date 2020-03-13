using System.Collections.Generic;
using System.Linq;
using Bookish.Models.Domain;

namespace Bookish.Models.Response
{
    public class MemberModel
    {
        private readonly Member _member;

        public MemberModel(Member member)
        {
            _member = member;
        }

        public string DisplayName => $"{_member.FirstName} {_member.LastName}";
    }
    
    public class MembersModel
    {
        public IEnumerable<MemberModel> Members { get; }

        public MembersModel(IEnumerable<Member> members)
        {
            Members = members.Select(m => new MemberModel(m));
        }
    }
}