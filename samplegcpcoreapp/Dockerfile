FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /samplegcpcoreapp

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /samplegcpcoreapp
COPY --from=build-env /samplegcpcoreapp/out .
ENTRYPOINT ["dotnet", "samplegcpcoreapp.dll"]