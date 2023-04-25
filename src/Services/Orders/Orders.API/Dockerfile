#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Orders/Orders.API/Orders.API.csproj", "src/Services/Orders/Orders.API/"]
COPY ["src/Core/ECommerceLP.Api/ECommerceLP.Api.csproj", "src/Core/ECommerceLP.Api/"]
COPY ["src/Core/ECommerceLP.Common/ECommerceLP.Common.csproj", "src/Core/ECommerceLP.Common/"]
COPY ["src/Core/ECommerceLP.Application/ECommerceLP.Application.csproj", "src/Core/ECommerceLP.Application/"]
COPY ["src/Services/Identity/Identity.Domain/Identity.Domain.csproj", "src/Services/Identity/Identity.Domain/"]
COPY ["src/Core/ECommerceLP.Domain/ECommerceLP.Domain.csproj", "src/Core/ECommerceLP.Domain/"]
COPY ["src/Infrastructure/ECommerceLP.Infrastructure/ECommerceLP.Infrastructure.csproj", "src/Infrastructure/ECommerceLP.Infrastructure/"]
COPY ["src/Services/Products/Products.Infrastructure/Products.Infrastructure.csproj", "src/Services/Products/Products.Infrastructure/"]
COPY ["src/Services/Products/Products.Domain/Products.Domain.csproj", "src/Services/Products/Products.Domain/"]
COPY ["src/Services/Orders/Orders.Application/Orders.Application.csproj", "src/Services/Orders/Orders.Application/"]
COPY ["src/Services/Orders/Orders.Common/Orders.Common.csproj", "src/Services/Orders/Orders.Common/"]
COPY ["src/Services/Orders/Orders.Domain/Orders.Domain/Orders.Domain.csproj", "src/Services/Orders/Orders.Domain/Orders.Domain/"]
COPY ["src/Services/Orders/Orders.Persistence/Orders.Persistence.csproj", "src/Services/Orders/Orders.Persistence/"]
RUN dotnet restore "src/Services/Orders/Orders.API/Orders.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Orders/Orders.API"
RUN dotnet build "Orders.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.API.dll"]