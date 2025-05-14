FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar os arquivos de projeto e restaurar dependências
COPY ["FakeStoreProducts.Worker/FakeStoreProducts.Worker.csproj", "FakeStoreProducts.Worker/"]
COPY ["FakeStoreProducts.Domain/FakeStoreProducts.Domain.csproj", "FakeStoreProducts.Domain/"]
COPY ["FakeStoreProducts.Infrastructure/FakeStoreProducts.Infrastructure.csproj", "FakeStoreProducts.Infrastructure/"]
RUN dotnet restore "FakeStoreProducts.Worker/FakeStoreProducts.Worker.csproj"

# Copiar o resto do código e fazer o build
COPY . .
WORKDIR "/src/FakeStoreProducts.Worker"
RUN dotnet build "FakeStoreProducts.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FakeStoreProducts.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeStoreProducts.Worker.dll"]