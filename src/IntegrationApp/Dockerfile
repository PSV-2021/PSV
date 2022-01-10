FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /src
COPY ./IntegrationAPI/*.sln /src/IntegrationAPI/
COPY ./IntegrationAPI/*.csproj /src/IntegrationAPI/
COPY ./Integration/*.csproj /src/Integration/
COPY ./IntegrationApiTests/*.csproj /src/IntegrationApiTests/
COPY ./IntegrationSeleniumTests/*.csproj /src/IntegrationSeleniumTests/
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

ARG HOSPITAL_DOMAIN
ENV HOSPITAL_DOMAIN=${HOSPITAL_DOMAIN}
ARG HOSPITAL_PORT
ENV HOSPITAL_PORT=${HOSPITAL_PORT}

ARG DRUGSTORE_GRPC_DOMAIN
ENV DRUGSTORE_GRPC_DOMAIN=${DRUGSTORE_GRPC_DOMAIN}
ARG DRUGSTORE_GRPC_PORT
ENV DRUGSTORE_GRPC_PORT=${DRUGSTORE_GRPC_PORT}

ARG HOSPITAL_GRPC_DOMAIN
ENV HOSPITAL_GRPC_DOMAIN=${HOSPITAL_GRPC_DOMAIN}
ARG HOSPITAL_GRPC_PORT
ENV HOSPITAL_GRPC_PORT=${HOSPITAL_GRPC_PORT}

RUN echo ${SFTP_USERNAME}

WORKDIR /app
EXPOSE 80
COPY --from=build-env /app .
ENTRYPOINT [ "dotnet","IntegrationAPI.dll" ]

