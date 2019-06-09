using RbsInterface.AccessModels;

namespace RbsService.Data
{
    public interface IConsentRepository
    {
        Root Get(string document);
    }
}