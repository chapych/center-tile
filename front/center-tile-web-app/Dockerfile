FROM node:latest AS compile-image
WORKDIR /app
COPY /front/center-tile-web-app/package.json /front/center-tile-web-app/package-lock.json ./
RUN npm install
COPY /front/center-tile-web-app .
RUN npm run build

FROM nginx
COPY --from=compile-image app/dist/center-tile-web-app/browser /usr/share/nginx/html
COPY --from=compile-image app/nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 4200
