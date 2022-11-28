package via.sdj3.supplier.protobuf;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.39.0)",
    comments = "Source: contract.proto")
public final class ShopGrpcGrpc {

  private ShopGrpcGrpc() {}

  public static final String SERVICE_NAME = "ShopGrpc";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.sdj3.supplier.protobuf.ProductGrpc,
      via.sdj3.supplier.protobuf.ProductResponse> getOrderProductMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "OrderProduct",
      requestType = via.sdj3.supplier.protobuf.ProductGrpc.class,
      responseType = via.sdj3.supplier.protobuf.ProductResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sdj3.supplier.protobuf.ProductGrpc,
      via.sdj3.supplier.protobuf.ProductResponse> getOrderProductMethod() {
    io.grpc.MethodDescriptor<via.sdj3.supplier.protobuf.ProductGrpc, via.sdj3.supplier.protobuf.ProductResponse> getOrderProductMethod;
    if ((getOrderProductMethod = ShopGrpcGrpc.getOrderProductMethod) == null) {
      synchronized (ShopGrpcGrpc.class) {
        if ((getOrderProductMethod = ShopGrpcGrpc.getOrderProductMethod) == null) {
          ShopGrpcGrpc.getOrderProductMethod = getOrderProductMethod =
              io.grpc.MethodDescriptor.<via.sdj3.supplier.protobuf.ProductGrpc, via.sdj3.supplier.protobuf.ProductResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "OrderProduct"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sdj3.supplier.protobuf.ProductGrpc.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sdj3.supplier.protobuf.ProductResponse.getDefaultInstance()))
              .setSchemaDescriptor(new ShopGrpcMethodDescriptorSupplier("OrderProduct"))
              .build();
        }
      }
    }
    return getOrderProductMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static ShopGrpcStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ShopGrpcStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ShopGrpcStub>() {
        @java.lang.Override
        public ShopGrpcStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ShopGrpcStub(channel, callOptions);
        }
      };
    return ShopGrpcStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static ShopGrpcBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ShopGrpcBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ShopGrpcBlockingStub>() {
        @java.lang.Override
        public ShopGrpcBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ShopGrpcBlockingStub(channel, callOptions);
        }
      };
    return ShopGrpcBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static ShopGrpcFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ShopGrpcFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ShopGrpcFutureStub>() {
        @java.lang.Override
        public ShopGrpcFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ShopGrpcFutureStub(channel, callOptions);
        }
      };
    return ShopGrpcFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class ShopGrpcImplBase implements io.grpc.BindableService {

    /**
     * <pre>
     *rpc EditProduct(ProductGrpc) returns (ProductResponse);
     * </pre>
     */
    public void orderProduct(via.sdj3.supplier.protobuf.ProductGrpc request,
        io.grpc.stub.StreamObserver<via.sdj3.supplier.protobuf.ProductResponse> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getOrderProductMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getOrderProductMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                via.sdj3.supplier.protobuf.ProductGrpc,
                via.sdj3.supplier.protobuf.ProductResponse>(
                  this, METHODID_ORDER_PRODUCT)))
          .build();
    }
  }

  /**
   */
  public static final class ShopGrpcStub extends io.grpc.stub.AbstractAsyncStub<ShopGrpcStub> {
    private ShopGrpcStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ShopGrpcStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ShopGrpcStub(channel, callOptions);
    }

    /**
     * <pre>
     *rpc EditProduct(ProductGrpc) returns (ProductResponse);
     * </pre>
     */
    public void orderProduct(via.sdj3.supplier.protobuf.ProductGrpc request,
        io.grpc.stub.StreamObserver<via.sdj3.supplier.protobuf.ProductResponse> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getOrderProductMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class ShopGrpcBlockingStub extends io.grpc.stub.AbstractBlockingStub<ShopGrpcBlockingStub> {
    private ShopGrpcBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ShopGrpcBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ShopGrpcBlockingStub(channel, callOptions);
    }

    /**
     * <pre>
     *rpc EditProduct(ProductGrpc) returns (ProductResponse);
     * </pre>
     */
    public via.sdj3.supplier.protobuf.ProductResponse orderProduct(via.sdj3.supplier.protobuf.ProductGrpc request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getOrderProductMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class ShopGrpcFutureStub extends io.grpc.stub.AbstractFutureStub<ShopGrpcFutureStub> {
    private ShopGrpcFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ShopGrpcFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ShopGrpcFutureStub(channel, callOptions);
    }

    /**
     * <pre>
     *rpc EditProduct(ProductGrpc) returns (ProductResponse);
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sdj3.supplier.protobuf.ProductResponse> orderProduct(
        via.sdj3.supplier.protobuf.ProductGrpc request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getOrderProductMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_ORDER_PRODUCT = 0;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final ShopGrpcImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(ShopGrpcImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_ORDER_PRODUCT:
          serviceImpl.orderProduct((via.sdj3.supplier.protobuf.ProductGrpc) request,
              (io.grpc.stub.StreamObserver<via.sdj3.supplier.protobuf.ProductResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class ShopGrpcBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    ShopGrpcBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.sdj3.supplier.protobuf.Contract.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("ShopGrpc");
    }
  }

  private static final class ShopGrpcFileDescriptorSupplier
      extends ShopGrpcBaseDescriptorSupplier {
    ShopGrpcFileDescriptorSupplier() {}
  }

  private static final class ShopGrpcMethodDescriptorSupplier
      extends ShopGrpcBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    ShopGrpcMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (ShopGrpcGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new ShopGrpcFileDescriptorSupplier())
              .addMethod(getOrderProductMethod())
              .build();
        }
      }
    }
    return result;
  }
}
