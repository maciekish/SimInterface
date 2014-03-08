#include <Queue.h>

Queue sendQueue;
int n;
    
void setup() {
  Serial.begin(9600);
  Serial.println(F("SimInterface Initialized"));
  
  //sendQueue.scheduleFunction(sendData, "Send", 500, 1000);
  
  //Setup pins
  for (int i=0; i<=4; i++) {
    pinMode(i, INPUT);
  }
  pinMode(12, OUTPUT);
  
  attachInterrupt(0, pin0, RISING);
  attachInterrupt(1, pin1, RISING);
  attachInterrupt(2, pin2, RISING);
  attachInterrupt(3, pin3, RISING);
  attachInterrupt(4, pin4, RISING);
}

// RawHID packets are always 64 bytes
byte buffer[64];
byte receiveBuffer[64];
unsigned int packetCount = 0;

void loop() {
  sendQueue.Run(millis());
  
  n = RawHID.recv(receiveBuffer, 1); // 0 timeout = do not wait
  if (n > 0) {
    //String message = String((char *)buffer);
    //Serial.println(message);
    
    byte chars[63];
    memcpy(chars, receiveBuffer, 63);
    
    String command = "";
    for (int i=1; i<63; i++) {
      //Serial.print((char)receiveBuffer[i]);
      String.concat(command);
      //Serial.print(String((char)receiveBuffer[i]));
    }
    Serial.println(command);
        
    // the computer sent a message.  Display the bits
    // of the first byte on pin 0 to 7.  Ignore the
    // other 63 bytes!
    /*Serial.print(F("Received packet, first byte: "));
    Serial.println((int)buffer[0]);
    for (int i=0; i<8; i++) {
      int b = buffer[0] & (1 << i);
      digitalWrite(i, b);
    }*/
  }
}

void pin0() {
  buttonHandler(0);
}

void pin1() {
  buttonHandler(1);
}

void pin2() {
  buttonHandler(2);
}

void pin3() {
  buttonHandler(3);
}

void pin4() {
  buttonHandler(4);
}

boolean bounced() {
  static unsigned long last_interrupt_time = 0;
  unsigned long interrupt_time = millis();
  if (interrupt_time - last_interrupt_time < 150) {
    last_interrupt_time = interrupt_time;
    return true;
  } else {
    last_interrupt_time = interrupt_time;
    return false;
  }
}

void buttonHandler(int button) {
  if (!bounced()) {
    Serial.print("Pressed ");
    Serial.println(button);
    
    String message;
    
    //message = "EFIS;";
    message = "";
    
    switch(button) {
      case 0:
        message = message + "LVL_CHG";
        break;
      case 1:
        message = message + "HDG_DEC";
        break;
      case 2:
        message = message + "HDG_INC";
        break;
      case 3:
        message = message + "ALT_DEC";
        break;
      case 4:
        message = message + "ALT_INC";
        break;
    }
    
    message.getBytes(buffer, 64);
    RawHID.send(buffer, 100);
  }
}

int sendData(unsigned long now)
{
    // first 2 bytes are a signature
    buffer[0] = 0x73;
    buffer[1] = 0x70;
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
