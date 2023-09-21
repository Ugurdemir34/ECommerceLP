#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "src/Services/Baskets/Baskets.API/Baskets.API.csproj" 
WORKDIR "/src/."
COPY . . 
RUN dotnet build "src/Services/Baskets/Baskets.API/Baskets.API.csproj" -c Release -o /app/build

FROM build as publish

RUN dotnet publish "src/Services/Baskets/Baskets.API/Baskets.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENV ASPNETCORE_URLS http://*.PORT_NUMBER
ENTRYPOINT ["dotnet", "Baskets.API.dll"]