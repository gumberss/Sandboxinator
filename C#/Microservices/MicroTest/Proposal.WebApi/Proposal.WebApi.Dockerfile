#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Proposal.WebApi/Attendance.Proposals.WebApi.csproj", "Attendance.Proposals.WebApi/"]
RUN dotnet restore "Attendance.Proposals.WebApi/Attendance.Proposals.WebApi.csproj"
COPY . .
WORKDIR "/src/Proposal.WebApi"
RUN dotnet build "Attendance.Proposals.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Attendance.Proposals.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attendance.Proposals.WebApi.dll"]