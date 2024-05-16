namespace Domain.Enums
{
    public enum TransactionStatus
    {
        WaitingForConFirm,
        Complete,
        Failed,
    }

    public enum TransactionType
    {
        recharge,
        withdraw
    }
}
