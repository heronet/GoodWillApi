# syntax=docker/dockerfile:1

# Create a stage for building the application.
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
COPY . /source
WORKDIR /source
RUN dotnet publish --use-current-runtime --self-contained false -o /app

################################################################################
# Production Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app .
# Switch to a non-privileged user (defined in the base image) that the app will run under.
USER $APP_UID
ENTRYPOINT ["dotnet", "GoodWillApi.dll"]
