FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibrarySystemV8.Web.Host/LibrarySystemV8.Web.Host.csproj", "src/LibrarySystemV8.Web.Host/"]
COPY ["src/LibrarySystemV8.Web.Core/LibrarySystemV8.Web.Core.csproj", "src/LibrarySystemV8.Web.Core/"]
COPY ["src/LibrarySystemV8.Application/LibrarySystemV8.Application.csproj", "src/LibrarySystemV8.Application/"]
COPY ["src/LibrarySystemV8.Core/LibrarySystemV8.Core.csproj", "src/LibrarySystemV8.Core/"]
COPY ["src/LibrarySystemV8.EntityFrameworkCore/LibrarySystemV8.EntityFrameworkCore.csproj", "src/LibrarySystemV8.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystemV8.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystemV8.Web.Host", "src/LibrarySystemV8.Web.Host"]
COPY ["src/LibrarySystemV8.Web.Core", "src/LibrarySystemV8.Web.Core"]
COPY ["src/LibrarySystemV8.Application", "src/LibrarySystemV8.Application"]
COPY ["src/LibrarySystemV8.Core", "src/LibrarySystemV8.Core"]
COPY ["src/LibrarySystemV8.EntityFrameworkCore", "src/LibrarySystemV8.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystemV8.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystemV8.Web.Host.dll"]
