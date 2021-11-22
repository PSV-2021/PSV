FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY DrugstoreAPI.sln ./
COPY Drugstore/*.csproj ./Drugstore/
COPY DrugstoreAPI/*.csproj ./DrugstoreAPI/
COPY DrugstoreApiTests/DrugstoreApiTests.csproj ./DrugstoreApiTests/
RUN dotnet restore

COPY . ./

WORKDIR /src/Drugstore
RUN dotnet build -c Release -o /app

WORKDIR /src/DrugstoreAPI
RUN dotnet build -c Release -o /app

FROM build-env as Publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","DrugstoreAPI.dll" ]

