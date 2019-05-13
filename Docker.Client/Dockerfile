# https://www.codementor.io/yomateo/angular-docker-dockerize-your-app-in-5-minutes-video-included-oohw2mzuj

# FROM node:alpine AS builder
# FROM node:latest AS builder
FROM node:alpine AS builder

WORKDIR /app

COPY . .

RUN npm install
RUN node_modules\.bin\ng build --prod


# build runtime image
FROM nginx:alpine

COPY nginx.conf /etc/nginx/nginx.conf

WORKDIR /usr/share/nginx/html

COPY --from=builder /app/dist/docker-test/* .
