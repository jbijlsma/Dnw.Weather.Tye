# Build image
FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy as build
WORKDIR /source

# Restore nuget dependencies
COPY ./*.csproj .
RUN dotnet restore -r linux-musl-arm64

# Copy other files
COPY . .
RUN dotnet publish -c release -o /app --self-contained false --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy
WORKDIR /app
COPY --from=build /app .

# Configure kestrel
ENV ASPNETCORE_URLS=http://+:5050
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT [ "./Dnw.Weather.Tye.Frontend" ]