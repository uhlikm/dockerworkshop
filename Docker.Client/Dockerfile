FROM nginx:alpine

MAINTAINER Martin Uhlik

COPY nginx.conf /etc/nginx/nginx.conf



WORKDIR /usr/share/nginx/html

COPY dist/docker-test/ .
