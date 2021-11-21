FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
COPY *.sln .
COPY ArchiSolveApi/*.csproj ./ArchiSolveApi/
COPY Common/*.csproj ./Common/
COPY Data/*.csproj ./Data/
COPY Entities/*.csproj ./Entities/
COPY Services/*.csproj ./Services/ 
COPY WebFrameWork/*.csproj ./WebFrameWork/ 
#
RUN dotnet restore 
#
COPY ArchiSolveApi/. ./ArchiSolveApi/
COPY Common/. ./Common/
COPY Data/. ./Data/
COPY Entities/. ./Entities/
COPY Services/. ./Services/
COPY WebFrameWork/. ./WebFrameWork/
#
WORKDIR /app/ArchiSolveApi
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
#
COPY --from=build /app/ArchiSolveApi/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ArchiSolveApi.dll