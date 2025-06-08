#Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

#Copia o .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

#Copia o restante do código e publica
COPY ./ ./
RUN dotnet publish -c Release -o out

#Etapa final: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

#Copia os arquivos publicados
COPY --from=build /app/out .

#Garante que a aplicação escute na porta 80
ENV ASPNETCORE_HTTP_PORTS=80

#Cria um usuário não-root por segurança
RUN addgroup --system appgroup && adduser --system --ingroup appgroup appuser
RUN chown -R appuser:appgroup /app

USER appuser

#Expõe a porta 80 no container
EXPOSE 80

#Executa a aplicação
ENTRYPOINT ["dotnet", "lugiaweather-api.dll"]