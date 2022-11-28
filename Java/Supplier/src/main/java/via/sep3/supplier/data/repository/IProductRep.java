package via.sep3.supplier.data.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.sep3.supplier.domain.Product;

import java.util.List;

@Repository
public interface IProductRep extends JpaRepository<Product, Long>
{
    @Query(value = "SELECT * FROM products a WHERE a.product_id = :product_id",nativeQuery = true)
    List<Product> getProductById(Long product_id);


}
