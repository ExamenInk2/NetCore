FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV CUSTOMER_NAME="netcoregalaxy"
ENV BaseDatos="server=ppanana.mysql.database.azure.com;Port=3306;Uid=administrador@ppanana;Pwd=P@ssw0rd;persistsecurityinfo=True;Database=examen;SslMode=Preferred;"


EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/wsServices.dll"]