/**
 * Checks if distilled water contains salt, by using a moisture sensor.
 * @author Giel Jurriens
 * @since 2019
 */
#include <ESP8266WiFi.h>
#include <Arduino.h>
#include <ArduinoJson.h>
#include <HttpClient.h>
#include <ESP8266HTTPClient.h>
#include <Config.h>

static bool isStarted = false;
static int minimumValue = 500;
int status = WL_IDLE_STATUS; 

void setup() {
    Serial.begin(115200);
    
    while ( status != WL_CONNECTED) {
      Serial.print("Attempting to connect to WEP network, SSID: ");
      Serial.println(CONFIG_SSID);
      status = WiFi.begin(CONFIG_SSID, CONFIG_PASSWORD);
  
      // wait 10 seconds for connection:
      delay(10000);
    }
}

void sendJson() {
    
}

void saltCheck(){
    // Read A0 for a voltage
    int sensorValue = analogRead(A0);
    Serial.println(sensorValue);
    
    if(sensorValue > minimumValue){
        isStarted = false;
        sendJson();
      }
}

void loop() {
  if(isStarted){
    saltCheck();
  }    
}




