using System.Reflection;

namespace ClothesClub.Interfaces
{
    public interface IMemberService
    {
        public List<MemberInfo> GetAll();
        
        public void CreateMember(MemberInfo member);

        public void RemoveMember(MemberInfo member);
    }
}
