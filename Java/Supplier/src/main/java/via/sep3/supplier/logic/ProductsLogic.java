package via.sep3.supplier.logic;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import via.sep3.supplier.data.repository.ICategoryRep;
import via.sep3.supplier.data.repository.IProductRep;

@Service
public class ProductsLogic {
    private ICategoryRep categoryRep;
    private IProductRep productRep;

    @Autowired
    public ProductsLogic(IProductRep productRep, ICategoryRep categoryRep)
    {
        this.categoryRep = categoryRep;
        this.productRep = productRep;
    }

    public boolean existsProductById(long id)
    {
        return productRep.existsById(id);
    }

}
