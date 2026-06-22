FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
RUN apt-get update && apt-get install -y libgssapi-krb5-2
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "DemoApi.dll"]