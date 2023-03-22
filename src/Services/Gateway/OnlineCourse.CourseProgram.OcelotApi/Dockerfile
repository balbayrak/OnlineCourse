#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Gateway/OnlineCourse.CourseProgram.OcelotApi/OnlineCourse.CourseProgram.OcelotApi.csproj", "src/Services/Gateway/OnlineCourse.CourseProgram.OcelotApi/"]
RUN dotnet restore "src/Services/Gateway/OnlineCourse.CourseProgram.OcelotApi/OnlineCourse.CourseProgram.OcelotApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Gateway/OnlineCourse.CourseProgram.OcelotApi"
RUN dotnet build "OnlineCourse.CourseProgram.OcelotApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineCourse.CourseProgram.OcelotApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineCourse.CourseProgram.OcelotApi.dll"]