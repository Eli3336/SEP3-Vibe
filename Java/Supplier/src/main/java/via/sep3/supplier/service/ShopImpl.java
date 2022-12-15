package via.sep3.supplier.service;


import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.supplier.data.repository.ICategoryRep;
import via.sep3.supplier.data.repository.IProductRep;
import via.sep3.supplier.domain.Product;
import via.sep3.supplier.logic.ProductsLogic;
import via.sep3.supplier.protobuf.ProductGrpc;
import via.sep3.supplier.protobuf.ProductResponse;
import via.sep3.supplier.protobuf.ShopGrpcGrpc;


@GRpcService
public class ShopImpl extends ShopGrpcGrpc.ShopGrpcImplBase
{
    private ProductsLogic logic;
   @Autowired
    public ShopImpl(ProductsLogic logic)
    {
        this.logic = logic;
    }
    @Override
    public void editProduct(ProductGrpc request, StreamObserver<ProductResponse> responseObserver)
    {
        logic.toEditProduct(request.getId(),request.getName(),request.getDescription(),request.getPrice());
        Product product=logic.getProduct(request.getId()).get(0);
        if(!(product.name.equals(request.getName()) || product.description.equals(request.getDescription())
                || product.price== request.getPrice()))
        {
            ProductResponse response = ProductResponse.newBuilder().setConfirmed("Product not edited").build();
            responseObserver.onNext(response);
            responseObserver.onCompleted();
        }
        else
        {
            ProductResponse response = ProductResponse.newBuilder().setConfirmed("Confirmed").build();
            responseObserver.onNext(response);
            responseObserver.onCompleted();
        }
    }
    @Override
    public void orderProduct(ProductGrpc request, StreamObserver<ProductResponse> responseObserver)
    {
        if(!logic.existsProductById(request.getId()))
        {
            ProductResponse response = ProductResponse.newBuilder().setConfirmed("Product not found").build();
            responseObserver.onNext(response);
            responseObserver.onCompleted();
        }
        else
        {
            ProductResponse response = ProductResponse.newBuilder().setConfirmed("Confirmed").build();
            responseObserver.onNext(response);
            responseObserver.onCompleted();
        }
    }
}
