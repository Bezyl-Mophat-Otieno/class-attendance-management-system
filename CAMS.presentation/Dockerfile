FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClassAttendanceManagementSystem-backend/ClassAttendanceManagementSystem-backend.csproj", "ClassAttendanceManagementSystem-backend/"]
RUN dotnet restore "ClassAttendanceManagementSystem-backend/ClassAttendanceManagementSystem-backend.csproj"
COPY . .
WORKDIR "/src/ClassAttendanceManagementSystem-backend"
RUN dotnet build "./ClassAttendanceManagementSystem-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClassAttendanceManagementSystem-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassAttendanceManagementSystem-backend.dll"]
