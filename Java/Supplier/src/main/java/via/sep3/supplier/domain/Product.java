package via.sep3.supplier.domain;

import lombok.*;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;

@Entity
@Getter
@Setter
@ToString
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Table(name = "products")
public class Product {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public long id;

    @NotBlank(message = "Product name cannot be null")
    @Column(name = "product_name")
    public String name;

    @NotBlank(message = "Product description cannot be null")
    @Column(name = "product_description")
    public String description;

    @NotNull
    @Column(name = "price", nullable = false)
    public double price;

    @ManyToOne(fetch = FetchType.EAGER)
    @ToString.Exclude
    @JoinColumn(name = "category_name", nullable = false)
    public Category category;

}
