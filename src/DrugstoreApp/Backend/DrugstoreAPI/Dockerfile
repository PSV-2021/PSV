FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /tmp/app
COPY ./Drugstore/Drugstore.csproj ./Drugstore/
COPY ./DrugstoreAPI/DrugstoreAPI.csproj ./DrugstoreAPI/

RUN dotnet restore ./DrugstoreAPI/
COPY . .
RUN dotnet publish -c Release -o /app ./DrugstoreAPI

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /tmp/app/out .
ENTRYPOINT [ "dotnet","DrugstoreAPI.dll" ]

