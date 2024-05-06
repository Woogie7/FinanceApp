FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .  # Копируем все файлы проекта
RUN dotnet restore  # Восстанавливаем зависимости
RUN dotnet publish -c Release -o out  # Сборка проекта

# Используем Nginx для развертывания статических файлов
FROM nginx:latest
COPY --from=build /app/out /usr/share/nginx/html  # Копируем собранные файлы
