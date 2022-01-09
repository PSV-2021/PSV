FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY ./IntegrationAPI/*.sln /src/IntegrationAPI/
COPY ./IntegrationAPI/*.csproj /src/IntegrationAPI/
COPY ./Integration/*.csproj /src/Integration/
COPY ./IntegrationApiTests/*.csproj /src/IntegrationApiTests/

RUN dotnet restore ./IntegrationAPI

COPY . ./

WORKDIR /src/Integration
RUN dotnet build -c Release -o /app

WORKDIR /src/IntegrationAPI
RUN dotnet build -c Release -o /app

FROM build-env as Publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG SFTP_IP
ENV SFTP_IP=${SFTP_IP}

ARG SFTP_USERNAME
ENV SFTP_USERNAME=${SFTP_USERNAME}

ARG SFTP_PASSWORD=password
ENV SFTP_PASSWORD=${SFTP_PASSWORD}

ARG RABBIT_HOST
ENV RABBIT_HOST=${RABBIT_HOST}

RUN echo ${SFTP_USERNAME}

WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","IntegrationAPI.dll" ]

