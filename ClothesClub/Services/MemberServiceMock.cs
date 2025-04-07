using ClothesClub.Interfaces;
using System.Reflection;

namespace ClothesClub.Services
{
    public class MemberServiceMock : IMemberService
    {
        public void CreateMember(MemberInfo member)
        {
            throw new NotImplementedException();
        }

        public List<MemberInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(MemberInfo member)
        {
            throw new NotImplementedException();
        }
    }
}
