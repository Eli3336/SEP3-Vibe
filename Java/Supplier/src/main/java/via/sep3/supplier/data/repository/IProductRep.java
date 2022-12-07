package via.sep3.supplier.data.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import via.sep3.supplier.domain.Product;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface IProductRep extends JpaRepository<Product, Long>
{
    @Query(value = "SELECT * FROM products  WHERE id = :product_id",nativeQuery = true)
    List<Product> getProductById(Long product_id);


    @Transactional
    @Modifying
    @Query(value = "UPDATE products  SET product_name= :product_name ," +
            " product_description= :product_description, price= :price " +
            "WHERE  id = :product_id",nativeQuery = true)
    void editProductById(Long product_id, String product_name, String product_description, double price);



}
