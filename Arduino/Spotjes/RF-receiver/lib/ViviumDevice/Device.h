#include <ESP8266WiFi.h>

class Device
{
public:
    String macAddress;
    String name;
    String category;

    Device(String name, String category)
    {
        this->macAddress = WiFi.macAddress();
        this->name = name;
        this->category = category;
    }

    String toJson()
    {
        return "{\"category\": \"" + this->category + "\",\"macAddress\": \"" + this->macAddress + "\",\"name\": \"" + this->name + "\"}";
    }
};