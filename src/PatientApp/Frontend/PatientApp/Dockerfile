FROM node:16.13 as node
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . . 
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/PatientApp /usr/share/nginx/html 
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80