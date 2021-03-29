FROM node:12.5.0 AS build
WORKDIR /usr/src/app
# install gettext for envsubst
RUN apt-get update
RUN apt-get install -y gettext-base

RUN npm install -g yarn
RUN npm install -g @angular/cli@11.2.5

COPY . .

RUN npm install

# SET ENVIRONMENT VARIABLES
ENV LotteryDemoApiUrl=http://localhost:5001/

ENTRYPOINT npm run start