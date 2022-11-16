package domain;

public class Product {

    public int id;
    public String name;
    public String description;
    public double price;
    public Category category;

    public Product(int id, String name, String description, double price, Category category){

        this.id=id;
        this.name=name;
        this.description=description;
        this.price=price;
        this.category=category;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setCategory(Category category) {
        this.category = category;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getId() {
        return id;
    }

    public Category getCategory() {
        return category;
    }

    public double getPrice() {
        return price;
    }

    public String getDescription() {
        return description;
    }

    public String getName() {
        return name;
    }


}
