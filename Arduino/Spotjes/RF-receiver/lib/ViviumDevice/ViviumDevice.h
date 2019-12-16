#include "Settings.h"
#include "Device.h"
#include <ESP8266WiFi.h>
#include <ArduinoHttpClient.h>
#include <ArduinoJson.h>

WiFiClient wifi;
HttpClient client = HttpClient(wifi, HOST_NAME);

class ViviumDevice
{
private:
    int lastLoopMs;
    int pingInterval;
    bool started;
    bool finished;
    String name;
    String category;

public:
    ViviumDevice(String name, String category, int pingInterval = 5000, bool started = false, bool finished = false)
    {
        this->name = name;
        this->category = category;
        this->lastLoopMs = millis();
        this->started = started;
        this->finished = finished;
        this->pingInterval = pingInterval;
    }

    void connect()
    {
        Serial.print("Connecting to ");
        Serial.println(WIFI_SSID);

        WiFi.mode(WIFI_STA);
        WiFi.begin(WIFI_SSID, WIFI_PASSWORD);

        while (WiFi.status() != WL_CONNECTED)
        {
            Serial.print(".");
            delay(500);
        }

        Serial.println("");
        Serial.println("WiFxi connected");
        Serial.println("IP address: ");
        Serial.println(WiFi.localIP());
        Serial.println("Macaddress: ");
        Serial.println(WiFi.macAddress());
    }

    void loop()
    {
        if (millis() - lastLoopMs > this->pingInterval)
        {
            Serial.println("Pinging the web server...");
            this->ping();
            this->lastLoopMs = millis();
        }
    }

    void ping()
    {
        String call = "/devices/register";
        Device device = Device(this->name, this->category);

        Serial.println("Calling " + call);
        Serial.println(device.toJson());

        client.post(
            call,
            "application/json",
            device.toJson());

        int statusCode = client.responseStatusCode();
        String response = client.responseBody();

        // The response should be parsed and checked wether the game is stopped or started
        this->started = this->parseResponse(response);;

        Serial.println(statusCode);
        Serial.println(response);
    }

    bool parseResponse(String response)
    {
        const size_t capacity = JSON_OBJECT_SIZE(3) + JSON_OBJECT_SIZE(7) + 160;
        DynamicJsonDocument doc(capacity);

        deserializeJson(doc, response);
        return doc["Started"];
    }

    bool shouldStart()
    {
        return this->started && !this->finished;
    }

    void finish()
    {
        Serial.println("Stopping the game right now");

        String call = "/devices/finish?macAddress=" + WiFi.macAddress();
        Device device = Device(this->name, this->category);

        Serial.println("Calling " + call);

        client.get(call);

        int statusCode = client.responseStatusCode();
        String response = client.responseBody();
        
        Serial.println(statusCode);
        Serial.println(response);
    }
};