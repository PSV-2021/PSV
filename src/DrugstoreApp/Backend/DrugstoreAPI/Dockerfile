FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
ENV REFRESHED_AT 03-10-2022 17:04
COPY . ./
RUN dotnet restore

WORKDIR /DrugstoreAPI
RUN dotnet build -c Release -o /app

FROM build-env as Publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","DrugstoreAPI.dll" ]

