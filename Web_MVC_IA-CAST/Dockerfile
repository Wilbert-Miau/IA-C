#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web_MVC_IA-CAST/Web_MVC_IA-CAST.csproj", "Web_MVC_IA-CAST/"]
RUN dotnet restore "Web_MVC_IA-CAST/Web_MVC_IA-CAST.csproj"
COPY . .
WORKDIR "/src/Web_MVC_IA-CAST"
RUN dotnet build "Web_MVC_IA-CAST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web_MVC_IA-CAST.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_MVC_IA-CAST.dll"]