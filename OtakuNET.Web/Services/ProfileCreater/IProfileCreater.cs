using OtakuNET.Domain.Entities;

namespace OtakuNET.Web.Services.ProfileCreater
{
    public interface IProfileCreater
    {
        Profile Create(string applicationUserId, string login);
    }
}
