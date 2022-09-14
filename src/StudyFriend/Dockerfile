FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/StudyFriend/StudyFriend.csproj", "src/StudyFriend/"]
RUN dotnet restore "src/StudyFriend/StudyFriend.csproj"
COPY . .
WORKDIR "/src/src/StudyFriend"
RUN dotnet build "StudyFriend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyFriend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyFriend.dll"]