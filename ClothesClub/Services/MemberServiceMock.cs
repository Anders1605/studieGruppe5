using ClothesClub.Interfaces;
using System.Reflection;
using core;

namespace ClothesClub.Services
{
    public class MemberServiceMock : IMemberService
    {
        public List<MemberItem> Members = new();
       
        public void CreateMember(MemberItem member)
        {
            int max = 0;
            if (Members.Count > 0)
                max = Members.Select(b => b.Memberid).Max();
            member.Memberid = max + 1;
            Members.Add(member);
        }


        public List<MemberItem> GetAll()
        {
            return Members.ToList();
        }

        public void RemoveMember(MemberItem membertoremove)
        {
            Members.Remove(membertoremove);
        }
    }
}
