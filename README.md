# gRPCServer
Тестовый проект для пробы grpc 
Из protofile генерируется клиентская и серверная части
Надо отредактировать файл проекта и добавить
<ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" /> или Server 
