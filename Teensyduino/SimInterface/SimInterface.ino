#include <Queue.h>

Queue sendQueue;
int n;
    
void setup() {
  Serial.begin(9600);
  Serial.println(F("SimInterface Initialized"));
  
  sendQueue.scheduleFunction(sendData, "Send", 500, 1000);
  
  //Setup pins
  for (int i=0; i<7; i++) {
    pinMode(i, OUTPUT);
  }
}

// RawHID packets are always 64 bytes
byte buffer[64];
unsigned int packetCount = 0;

void loop() {
  sendQueue.Run(millis());
  
  n = RawHID.recv(buffer, 1); // 0 timeout = do not wait
  if (n > 0) {
    // the computer sent a message.  Display the bits
    // of the first byte on pin 0 to 7.  Ignore the
    // other 63 bytes!
    Serial.print(F("Received packet, first byte: "));
    Serial.println((int)buffer[0]);
    for (int i=0; i<8; i++) {
      int b = buffer[0] & (1 << i);
      digitalWrite(i, b);
    }
  }
}

int sendData(unsigned long now)
{
    // first 2 bytes are a signature
    buffer[0] = 0xAB;
    buffer[1] = 0xCD;
    // next 24 bytes are analog measurements
    for (int i=0; i<12; i++) {
      int val = analogRead(i);
      buffer[i * 2 + 2] = highByte(val);
      buffer[i * 2 + 3] = lowByte(val);
    }
    // fill the rest with zeros
    for (int i=26; i<62; i++) {
      buffer[i] = 0;
    }
    // and put a count of packets sent at the end
    buffer[62] = highByte(packetCount);
    buffer[63] = lowByte(packetCount);
    // actually send the packet
    n = RawHID.send(buffer, 100);
    if (n > 0) {
      Serial.print(F("Transmit packet "));
      Serial.println(packetCount);
      packetCount = packetCount + 1;
    } else {
      Serial.println(F("Unable to transmit packet"));
    }
}
