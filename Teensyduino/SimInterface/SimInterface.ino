#include <Encoder.h>
#include <Queue.h>

#define POS_1 888
#define POS_2 931
#define POS_3 971
int current_pos = 0;

// Pins
#define VOR1   1
#define ADF1   2
#define VOR2   3
#define ADF2   4
#define WXR    5
#define STA    6
#define WPT    7
#define ARPT   8
#define DATA   9
#define POS    10
#define TERR   11
#define LED    13
#define RANGE  14
#define MODE   15
#define BAROSTD 16
#define MINSRST 17
#define BAROB  18
#define BAROA  19
#define MINSB  20
#define MINSA  21
#define MTRS   22
#define FPV    23

Queue sendQueue;
int n;

Encoder baro(18, 19);
    
void setup() {
  Serial.begin(9600);
  Serial.println(F("SimInterface Initialized"));
  
  //Setup pins
  for (int i=0; i<=23; i++) {
    pinMode(i, INPUT);
  }
  pinMode(LED, OUTPUT);
  
  //Attach interrupts
  attachInterrupt(0, pin0, RISING);
  attachInterrupt(1, pin1, RISING);
  attachInterrupt(2, pin2, RISING);
  attachInterrupt(3, pin3, RISING);
  attachInterrupt(4, pin4, RISING);
  attachInterrupt(5, pin5, RISING);
  attachInterrupt(6, pin6, RISING);
  attachInterrupt(7, pin7, RISING);
  attachInterrupt(8, pin8, RISING);
  attachInterrupt(9, pin9, RISING);
  attachInterrupt(10, pin10, RISING);
  attachInterrupt(11, pin11, RISING);
  attachInterrupt(12, pin12, RISING);
  attachInterrupt(13, pin13, RISING);
  attachInterrupt(14, pin14, RISING);
  attachInterrupt(15, pin15, RISING);
  attachInterrupt(16, pin16, RISING);
  attachInterrupt(17, pin17, RISING);
  attachInterrupt(18, pin18, RISING);
  attachInterrupt(19, pin19, RISING);
  attachInterrupt(20, pin20, RISING);
  attachInterrupt(21, pin21, RISING);
  attachInterrupt(22, pin22, RISING);
  attachInterrupt(23, pin23, RISING);
  
  //Special extra interrupts for disabling VOR1, ADF1, VOR2, ADF2
  attachInterrupt(0, pin0off, RISING);
  attachInterrupt(1, pin1off, RISING);
  attachInterrupt(2, pin2off, RISING);
  attachInterrupt(3, pin3off, RISING);
  
  //Blink LED to indicate we are alive
  digitalWrite(LED, HIGH);
  delay(100);
  digitalWrite(LED, LOW);
}

// RawHID packets are always 64 bytes
byte buffer[64];
byte receiveBuffer[64];
unsigned int packetCount = 0;

void loop() {
  delay(50);
  
  sendQueue.Run(millis());
  
  /*n = RawHID.recv(receiveBuffer, 1); // 0 timeout = do not wait
  if (n > 0) {
    //String message = String((char *)buffer);
    //Serial.println(message);
    
    digitalWrite(10, receiveBuffer[1]);
    digitalWrite(11, receiveBuffer[2]);
    digitalWrite(12, receiveBuffer[3]);
    digitalWrite(15, receiveBuffer[4]);
    digitalWrite(16, receiveBuffer[5]);
    digitalWrite(17, receiveBuffer[6]);
    
        
    byte chars[63];
    memcpy(chars, receiveBuffer, 63);
    
    String command = String("");
    for (int i=1; i<63; i++) {
      Serial.print((char)receiveBuffer[i]);
      //command += String((char)receiveBuffer[i]);
      //Serial.print(String((char)receiveBuffer[i]));
    }
    Serial.println(command);
        
    // the computer sent a message.  Display the bits
    // of the first byte on pin 0 to 7.  Ignore the
    // other 63 bytes!
    Serial.print(F("Received packet, first byte: "));
    Serial.println((int)buffer[0]);
    for (int i=0; i<8; i++) {
      int b = buffer[0] & (1 << i);
      digitalWrite(i, b);
    }
  }*/
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

void pin5() {
  buttonHandler(5);
}

void pin6() {
  buttonHandler(6);
}

void pin7() {
  buttonHandler(7);
}

void pin8() {
  buttonHandler(8);
}

void pin9() {
  buttonHandler(9);
}

void pin10() {
  buttonHandler(10);
}

void pin11() {
  buttonHandler(11);
}

void pin12() {
  buttonHandler(12);
}

void pin13() {
  buttonHandler(13);
}

void pin14() {
  buttonHandler(14);
}

void pin15() {
  buttonHandler(15);
}

void pin16() {
  buttonHandler(16);
}

void pin17() {
  buttonHandler(17);
}

void pin18() {
  buttonHandler(18);
}

void pin19() {
  buttonHandler(19);
}

void pin20() {
  buttonHandler(20);
}

void pin21() {
  buttonHandler(21);
}

void pin22() {
  buttonHandler(22);
}

void pin23() {
  buttonHandler(23);
}

void pin0off() {
  buttonHandler(0 + 128);
}

void pin1off() {
  buttonHandler(1 + 128);
}

void pin2off() {
  buttonHandler(2 + 128);
}

void pin3off() {
  buttonHandler(3 + 128);
}

boolean bounced() {
  static unsigned long last_interrupt_time = 0;
  unsigned long interrupt_time = millis();
  if (interrupt_time - last_interrupt_time < 250) {
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
    
    String message = "EFIS.L:"; //Left EFIS
    
    switch(button) {
      //VOR & ADF
      case VOR1:
        message = message + "VOR1";
        break;
      case VOR1 + 128:
        message = message + "VOR1.ADF1.OFF";
        break;
      case ADF1:
        message = message + "ADF1";
        break;
      case ADF1 + 128:
        message = message + "VOR1.ADF1.OFF";
        break;
      case VOR2:
        message = message + "VOR2";
        break;
      case VOR2 + 128:
        message = message + "VOR2.ADF1.OFF";
        break;
      case ADF2:
        message = message + "ADF2";
        break;
      case ADF2 + 128:
        message = message + "VOR2.ADF1.OFF";
        break;
      //Buttons
      case WXR:
        message = message + "WXR";
        break;
      case STA:
        message = message + "STA";
        break;
      case WPT:
        message = message + "WPT";
        break;
      case ARPT:
        message = message + "ARPT";
        break;
      case DATA:
        message = message + "DATA";
        break;
      case POS:
        message = message + "POS";
        break;
      case TERR:
        message = message + "TERR";
        break;
      case BAROSTD:
        message = message + "BAROSTD";
        break;
      case MINSRST:
        message = message + "MINSRST";
        break;
      case MTRS:
        message = message + "MTRS";
        break;
      case FPV:
        message = message + "FPV";
        break;
    }
    
    message.getBytes(buffer, 64);
    RawHID.send(buffer, 100);
    
    //Blink LED
    digitalWrite(LED, HIGH);
    delay(2);
    digitalWrite(LED, LOW);
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
