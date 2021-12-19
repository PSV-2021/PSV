FROM node:14.15 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/ManagerAngularApp /usr/share/nginx/html 

EXPOSE 80