FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Finance.API/Finance.API.csproj", "Finance.API/"]
COPY ["Finacne.Application/Finance.Application.csproj", "Finacne.Application/"]
COPY ["Finance.Domain/Finance.Domain.csproj", "Finance.Domain/"]
COPY ["Finance.Persistence/Finance.Persistence.csproj", "Finance.Persistence/"]
RUN dotnet restore "Finance.API/Finance.API.csproj"
COPY . .
WORKDIR "/src/Finance.API"
RUN dotnet build "Finance.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finance.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finance.API.dll"]