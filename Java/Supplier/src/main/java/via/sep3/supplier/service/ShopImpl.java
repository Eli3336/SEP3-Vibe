package via.sep3.supplier.service;


import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sdj3.supplier.protobuf.ProductGrpc;
import via.sdj3.supplier.protobuf.ProductResponse;
import via.sdj3.supplier.protobuf.ShopGrpcGrpc;
import via.sep3.supplier.data.repository.ICategoryRep;
import via.sep3.supplier.data.repository.IProductRep;
import via.sep3.supplier.logic.ProductsLogic;


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
