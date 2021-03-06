# Simple IoT Weather Station

Simple IoT weather station built with Arduino Uno and ASP.NET Core and React, [demonstrated here](https://youtube.com/watch?v=0aYAbL72kJo).

# Technical details

## Hardware

-   [Arduino Uno WiFi Rev.2](https://arduino.cc)
-   Light Sensor (LM393)
-   LCD Display (HD44780)
-   Raindrop Sensor (MH-RD)
-   Temperature/Humidity Sensor (RHT03/DHT22)
-   UV Sensor (SENS-43UV)

## Software

### Backend

-   [ASP.NET Core](https://asp.net)
-   [SQLite](https://www.sqlite.org/)

### Frontend

-   [React.js](https://reactjs.org)
-   [Chart.js](https://chartjs.org)
-   [Bootstrap.css](https://getbootstrap.com/)

## How it works

Every five minutes, the Arduino Uno reads the sensor values and POSTs them using the powerful [ArduinoJson](https://arduinojson.org/) library to my ASP.NET Core WebAPI/SQLite DB (this endpoint is protected with an API key to prevent unauthorized access). The sensor readings are then presented in a React.js/Chart.js/Bootstrap.css frontend.

## Lessons learned

Building a weather station has made me realize two things: first of all, that it is hard to measure temperature, which requires shade, and UV, which requires sun, from the same location. Secondly, the rain sensor is a bit "dumb" in the sense that it will report that it is raining for as long as it remains wet. This means that it will accurately report when it rains, but inaccurately report when it has stopped raining (it takes some time for the sensor to dry).

### HTTPS requests timing out

Connecting to the WiFi was never a problem, instead, the challenge was getting the data from the Arduino to the API. For some reason, some of the HTTP requests timed out. I tried several different HTTP libraries and WebSockets, to no avail. Finally, I managed to pinpoint the error to the Arduino WiFiSSLClient, i.e HTTPS request on port 443. "Regular" HTTP requests on port 80 never timed out. Therefore, I made an exception in the HTTPS enforcement in my ASP.NET application for Arduino User-Agents (it first checks the API key).

## Install

Project currently requires a Secrets.json in root directory with an "ApiKey" key to run (to validate POST requests).
