namespace ShopApplication.Logic;

public class PurchaseLogic
{
    private readonly IPurchaseDao purchaseDao;

    public PurchaseLogic(IPurchaseDao purchaseDao)
    {
        this.purchaseDao = purchaseDao;
    }
}