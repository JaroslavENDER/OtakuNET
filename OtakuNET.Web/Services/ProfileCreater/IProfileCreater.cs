using OtakuNET.Domain.Entities;

namespace OtakuNET.Web.Services.ProfileCreater
{
    public interface IProfileCreater
    {
        Profile Create(string id, string login);
    }
}
