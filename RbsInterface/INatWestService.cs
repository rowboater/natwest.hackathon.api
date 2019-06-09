namespace RbsService
{
    public interface INatWestService
    {
        void EstablishConnection();
        void AuthoriseConsent(string consentId);
        void ListAccounts(string customerId);
        void ListTransactions(string accountId);
    }
}