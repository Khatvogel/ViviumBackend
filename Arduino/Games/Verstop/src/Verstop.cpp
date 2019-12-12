#include <Arduino.h>
#include "Settings.h"
#include "ViviumDevice.h"
#include <ESP8266WiFi.h>
#include <ArduinoHttpClient.h>
#include <ArduinoJson.h>

/**
 * Check distance using HC-SR04
 * @author Giel Jurriens
 * @since 2019
 */

// defines pins numbers
const int trigPin = D1;
const int echoPin = D2;
// defines variables
long duration;
int distance;

ViviumDevice device = ViviumDevice("Verstop", "Spel");

void setup()
{
  pinMode(BUILTIN_LED, OUTPUT);
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT);  // Sets the echoPin as an Input
  Serial.begin(9600);
  device.connect();
}


int val = 15;
bool started = false;
bool finished = false;



void loop()
{
  // Clears the trigPin
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);
  // Calculating the distance
  distance = duration * 0.034 / 2;
  // Prints the distance on the Serial Monitor
  // Serial.print("Distance: ");
  // Serial.println(distance);
  if ((distance == 0 || distance > val) && started){
    finished = true;
    started = false;
    device.finish();
  }


  device.loop();
  if (device.shouldStart() != started)
  {
    String startOrStop = device.shouldStart() ? "start" : "stop";
    Serial.println("I should " + startOrStop + " now");

    started = device.shouldStart();
    digitalWrite(LED_BUILTIN, started ? LOW : HIGH);
  }
}
