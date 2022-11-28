package via.sep3.supplier.data.seed;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;
import via.sep3.supplier.data.repository.ICategoryRep;
import via.sep3.supplier.data.repository.IProductRep;
import via.sep3.supplier.domain.Category;
import via.sep3.supplier.domain.Product;

import java.time.LocalDate;
import java.util.ArrayList;

@Component
public class seedDB implements CommandLineRunner {

    ICategoryRep categoryRepository;
    IProductRep productRepository;

    @Autowired
    protected seedDB(ICategoryRep categoryRepository, IProductRep productRepository )
    {
        this.productRepository= productRepository;
        this.categoryRepository = categoryRepository;
    }

    @Override
    public void run(String... args) throws Exception {
        loadProductData();
    }

    private void loadProductData()
    {
        productRepository.deleteAll();
        categoryRepository.deleteAll();

        Category category1 = new Category("jewelry");
        Category category2  = new Category("clothes");
        Category category3 = new Category("house_decor");
        Category category4 = new Category("cosmetics");

        categoryRepository.save(category1);
        categoryRepository.save(category2);
        categoryRepository.save(category3);
        categoryRepository.save(category4);

        Product product1 = new Product(1, "Infinity Ring", "AU0269, 19x8x1.2 mm, 5.6g", 15, category1);
        Product product2 = new Product(2, "Bamboo Fibre Lunchbox - Pink Coral", "Bamboo fibre lunchbox with pink coral design with a food grade silicone seal to keep your food fresh and bamboo lid which can be used as a place to put your sandwiches.", 22, category3);
        Product product3 = new Product(3, "Expressionist Pro Mascara", "Long-wear, defining and lengthening mascara", 20, category4);

        productRepository.save(product1);
        productRepository.save(product2);
        productRepository.save(product3);
    }
}
