#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Order.Application/Order.Application.csproj", "Order.Application/"]
RUN dotnet restore "Order.Application/Order.Application.csproj"
COPY . .
WORKDIR "/src/Order.Application"
RUN dotnet build "Order.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Application.dll"]