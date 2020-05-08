#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Proposal.WebApi/Attendance.Proposal.WebApi.csproj", "Attendance.Proposal.WebApi/"]
RUN dotnet restore "Attendance.Proposal.WebApi/Attendance.Proposal.WebApi.csproj"
COPY . .
WORKDIR "/src/Proposal.WebApi"
RUN dotnet build "Attendance.Proposal.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Attendance.Proposal.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attendance.Proposal.WebApi.dll"]