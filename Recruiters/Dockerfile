FROM microsoft/aspnetcore:2.0

WORKDIR /app
COPY ./dist /app
EXPOSE 80
ENTRYPOINT ["dotnet", "Recruiters.dll"]