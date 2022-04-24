FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ./toomanycookbooks.api.sln .
COPY ./toomanycookbooks.api/*.csproj ./toomanycookbooks.api/
COPY ./toomanycookbooks.api.data/*.csproj ./toomanycookbooks.api.data/

RUN dotnet restore

COPY . .
RUN dotnet build --configuration Release -o ./output

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /src/output/ .

CMD ["dotnet", "toomanycookbooks.api.dll"]