// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/product.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MyProto {
  public static partial class GrpcProduct
  {
    static readonly string __ServiceName = "GrpcProduct";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::MyProto.Empty> __Marshaller_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.Empty.Parser));
    static readonly grpc::Marshaller<global::MyProto.ProductList> __Marshaller_ProductList = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.ProductList.Parser));
    static readonly grpc::Marshaller<global::MyProto.IDRequest> __Marshaller_IDRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.IDRequest.Parser));
    static readonly grpc::Marshaller<global::MyProto.Product> __Marshaller_Product = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.Product.Parser));
    static readonly grpc::Marshaller<global::MyProto.CreateProductRequest> __Marshaller_CreateProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.CreateProductRequest.Parser));
    static readonly grpc::Marshaller<global::MyProto.UpdateProductRequest> __Marshaller_UpdateProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.UpdateProductRequest.Parser));
    static readonly grpc::Marshaller<global::MyProto.CategoryList> __Marshaller_CategoryList = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.CategoryList.Parser));
    static readonly grpc::Marshaller<global::MyProto.SearchRequest> __Marshaller_SearchRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::MyProto.SearchRequest.Parser));

    static readonly grpc::Method<global::MyProto.Empty, global::MyProto.ProductList> __Method_GetAll = new grpc::Method<global::MyProto.Empty, global::MyProto.ProductList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_Empty,
        __Marshaller_ProductList);

    static readonly grpc::Method<global::MyProto.IDRequest, global::MyProto.Product> __Method_GetProductById = new grpc::Method<global::MyProto.IDRequest, global::MyProto.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProductById",
        __Marshaller_IDRequest,
        __Marshaller_Product);

    static readonly grpc::Method<global::MyProto.CreateProductRequest, global::MyProto.Product> __Method_CreateProduct = new grpc::Method<global::MyProto.CreateProductRequest, global::MyProto.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateProduct",
        __Marshaller_CreateProductRequest,
        __Marshaller_Product);

    static readonly grpc::Method<global::MyProto.UpdateProductRequest, global::MyProto.Product> __Method_UpdateProduct = new grpc::Method<global::MyProto.UpdateProductRequest, global::MyProto.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateProduct",
        __Marshaller_UpdateProductRequest,
        __Marshaller_Product);

    static readonly grpc::Method<global::MyProto.IDRequest, global::MyProto.Empty> __Method_DeleteProduct = new grpc::Method<global::MyProto.IDRequest, global::MyProto.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteProduct",
        __Marshaller_IDRequest,
        __Marshaller_Empty);

    static readonly grpc::Method<global::MyProto.Empty, global::MyProto.CategoryList> __Method_GetAllCategory = new grpc::Method<global::MyProto.Empty, global::MyProto.CategoryList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllCategory",
        __Marshaller_Empty,
        __Marshaller_CategoryList);

    static readonly grpc::Method<global::MyProto.SearchRequest, global::MyProto.ProductList> __Method_SearchProduct = new grpc::Method<global::MyProto.SearchRequest, global::MyProto.ProductList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SearchProduct",
        __Marshaller_SearchRequest,
        __Marshaller_ProductList);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MyProto.ProductReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GrpcProduct</summary>
    [grpc::BindServiceMethod(typeof(GrpcProduct), "BindService")]
    public abstract partial class GrpcProductBase
    {
      public virtual global::System.Threading.Tasks.Task<global::MyProto.ProductList> GetAll(global::MyProto.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.Product> GetProductById(global::MyProto.IDRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.Product> CreateProduct(global::MyProto.CreateProductRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.Product> UpdateProduct(global::MyProto.UpdateProductRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.Empty> DeleteProduct(global::MyProto.IDRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.CategoryList> GetAllCategory(global::MyProto.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::MyProto.ProductList> SearchProduct(global::MyProto.SearchRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GrpcProductBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetProductById, serviceImpl.GetProductById)
          .AddMethod(__Method_CreateProduct, serviceImpl.CreateProduct)
          .AddMethod(__Method_UpdateProduct, serviceImpl.UpdateProduct)
          .AddMethod(__Method_DeleteProduct, serviceImpl.DeleteProduct)
          .AddMethod(__Method_GetAllCategory, serviceImpl.GetAllCategory)
          .AddMethod(__Method_SearchProduct, serviceImpl.SearchProduct).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcProductBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.Empty, global::MyProto.ProductList>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetProductById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.IDRequest, global::MyProto.Product>(serviceImpl.GetProductById));
      serviceBinder.AddMethod(__Method_CreateProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.CreateProductRequest, global::MyProto.Product>(serviceImpl.CreateProduct));
      serviceBinder.AddMethod(__Method_UpdateProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.UpdateProductRequest, global::MyProto.Product>(serviceImpl.UpdateProduct));
      serviceBinder.AddMethod(__Method_DeleteProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.IDRequest, global::MyProto.Empty>(serviceImpl.DeleteProduct));
      serviceBinder.AddMethod(__Method_GetAllCategory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.Empty, global::MyProto.CategoryList>(serviceImpl.GetAllCategory));
      serviceBinder.AddMethod(__Method_SearchProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MyProto.SearchRequest, global::MyProto.ProductList>(serviceImpl.SearchProduct));
    }

  }
}
#endregion
