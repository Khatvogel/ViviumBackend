/**
 * Demo for RF remote switch receiver.
 * For details, see NewRemoteReceiver.h!
 *
 * Connect the transmitter to digital pin 11.
 *
 * This sketch demonstrates the use of the NewRemoteTransmitter class.
 *
 * When run, this sketch switches some pre-defined devices on and off in a loop.
 *
 * NOTE: the actual receivers have the address and group numbers in this example
 * are only for demonstration! If you want to duplicate an existing remote, please
 * try the "retransmitter"-example instead.
 * 
 * To use this actual example, you'd need to "learn" the used code in the receivers
 * This sketch is unsuited for that.
 * 
 */

#include <NewRemoteTransmitter.h>

// Create a transmitter on address 123, using digital pin 11 to transmit, 
// with a period duration of 260ms (default), repeating the transmitted
// code 2^3=8 times.
NewRemoteTransmitter transmitter(64349184, D2, 260, 3);

void setup() {
}

void loop() {  
  // Switch all devices in the group off
  transmitter.sendGroup(true);
  transmitter.sendUnit(1, false);

  // Wait 5 seconds
  delay(5000);
 
  // Switch all devices in the group on
  transmitter.sendGroup(false);

  // Wait 5 seconds
  delay(5000);

  transmitter.sendGroup(true);
  delay(5000);
}