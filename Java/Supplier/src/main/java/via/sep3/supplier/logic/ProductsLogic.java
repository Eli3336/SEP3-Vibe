package via.sep3.supplier.logic;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import via.sep3.supplier.data.repository.ICategoryRep;
import via.sep3.supplier.data.repository.IProductRep;
import via.sep3.supplier.domain.Product;

import java.util.List;

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

    public void toEditProduct(long id, String name, String description, double price)
    {
        productRep.editProductById(id,name,description,price);

    }

    public List<Product> getProduct(long id)
    {
        return productRep.getProductById(id);
    }


}
