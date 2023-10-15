FROM node:lts-alpine as build-stage
RUN npm install -g http-server
WORKDIR /app
COPY ./package*.json ./
RUN npm install
COPY . .
RUN cat ./.env
RUN npm run build


# production stage
FROM nginx:stable-alpine as production-stage
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]