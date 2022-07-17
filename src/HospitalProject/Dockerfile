FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
ENV REFRESHED_AT 03-10-2022 18:55
COPY . ./

WORKDIR /HospitalAPI/HospitalAPI

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","HospitalAPI.dll" ]


