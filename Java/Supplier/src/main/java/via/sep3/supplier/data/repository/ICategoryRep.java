package via.sep3.supplier.data.repository;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.sep3.supplier.domain.Category;

@Repository
public interface ICategoryRep extends JpaRepository<Category, Long> {

}
