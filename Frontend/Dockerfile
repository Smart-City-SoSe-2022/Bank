FROM node:lts as building-stage

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY ./ .

RUN npm run build

## Create NGINX deployment
FROM nginx:latest

RUN mkdir /app

COPY --from=building-stage /app/build /app

COPY nginx.conf /etc/nginx/nginx.conf

