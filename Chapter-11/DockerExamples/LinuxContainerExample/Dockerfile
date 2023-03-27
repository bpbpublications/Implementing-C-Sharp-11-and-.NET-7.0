FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LinuxContainerExample/LinuxContainerExample.csproj", "LinuxContainerExample/"]
RUN dotnet restore "LinuxContainerExample/LinuxContainerExample.csproj"
COPY . .
WORKDIR "/src/LinuxContainerExample"
RUN dotnet build "LinuxContainerExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxContainerExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxContainerExample.dll"]