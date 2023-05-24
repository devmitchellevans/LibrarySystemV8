FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/LibrarySystemV8.Web.Mvc/LibrarySystemV8.Web.Mvc.csproj", "src/LibrarySystemV8.Web.Mvc/"]
COPY ["src/LibrarySystemV8.Web.Core/LibrarySystemV8.Web.Core.csproj", "src/LibrarySystemV8.Web.Core/"]
COPY ["src/LibrarySystemV8.Application/LibrarySystemV8.Application.csproj", "src/LibrarySystemV8.Application/"]
COPY ["src/LibrarySystemV8.Core/LibrarySystemV8.Core.csproj", "src/LibrarySystemV8.Core/"]
COPY ["src/LibrarySystemV8.EntityFrameworkCore/LibrarySystemV8.EntityFrameworkCore.csproj", "src/LibrarySystemV8.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystemV8.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystemV8.Web.Mvc", "src/LibrarySystemV8.Web.Mvc"]
COPY ["src/LibrarySystemV8.Web.Core", "src/LibrarySystemV8.Web.Core"]
COPY ["src/LibrarySystemV8.Application", "src/LibrarySystemV8.Application"]
COPY ["src/LibrarySystemV8.Core", "src/LibrarySystemV8.Core"]
COPY ["src/LibrarySystemV8.EntityFrameworkCore", "src/LibrarySystemV8.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystemV8.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystemV8.Web.Mvc.dll"]
