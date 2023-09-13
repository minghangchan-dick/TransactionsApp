#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TransactionsApp/TransactionsApp.csproj", "TransactionsApp/"]
RUN dotnet restore "TransactionsApp/TransactionsApp.csproj"
COPY . .
WORKDIR "/src/TransactionsApp"
RUN dotnet build "TransactionsApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionsApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet tool install --global dotnet-ef
RUN dotnet ef migrations add init --context TransactionContext
RUN dotnet ef database update --context TransactionContext
ENTRYPOINT ["dotnet", "TransactionsApp.dll"]