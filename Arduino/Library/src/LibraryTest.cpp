#include <Arduino.h>
#include "Settings.h"
#include "ViviumDevice.h"
#include <ESP8266WiFi.h>
#include <ArduinoHttpClient.h>
#include <ArduinoJson.h>

ViviumDevice device = ViviumDevice("Zeepspel", "Spel");

void setup()
{
  pinMode(D1, INPUT_PULLUP);
  Serial.begin(9600);
  device.connect();
}

int val = HIGH;
bool started = false;
bool finished = false;
void loop()
{
  int newVal = digitalRead(D1); // read input value
  if (newVal == LOW && val == HIGH)
  {
    finished = true;
    Serial.println("i am trying to do something");
  }
  val = newVal;

  device.loop();
  if (device.shouldStart() != started)
  {
    String startOrStop = device.shouldStart() ? "start" : "stop";
    Serial.println("I should " + startOrStop + " now");
    started = device.shouldStart();
  }

  if (finished)
  {
    device.finish();
    finished = false;
  }
}
