#include <Device.h>
#include <ViviumDevice.h>

#include <NewRemoteTransmitter.h>

NewRemoteTransmitter transmitter(64349184, D2, 260, 3);

void setup() {
}

void loop() {  
  if(){
    
  }
  if(){
    
  }
  transmitter.sendUnit();
  
  delay(1000);
  
  transmitter.sendUnit(false);
}
