using core;
using System.Reflection;


namespace ClothesClub.Interfaces
{
    public interface IMemberService
    {
        public List<MemberItem> GetAll();

        public void CreateMember(MemberItem member);

        public void RemoveMember(MemberItem member);
    }
}
