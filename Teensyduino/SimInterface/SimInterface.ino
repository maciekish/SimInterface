#include <Encoder.h>
#include <Queue.h>

#define POS_1 888
#define POS_2 931
#define POS_3 971
int current_pos = 0;

Queue sendQueue;
int n;

Encoder baro(18, 19);
    
void setup() {
  Serial.begin(9600);
  Serial.println(F("SimInterface Initialized"));
  
  //sendQueue.scheduleFunction(sendData, "Send", 500, 1000);
  
  //Setup pins
  for (int i=0; i<=4; i++) {
    pinMode(i, INPUT);
  }
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(15, OUTPUT);
  pinMode(16, OUTPUT);
  pinMode(17, OUTPUT);
    
  attachInterrupt(0, pin0, RISING);
  attachInterrupt(1, pin1, RISING);
  attachInterrupt(2, pin2, RISING);
  attachInterrupt(3, pin3, RISING);
  attachInterrupt(4, pin4, RISING);
  
  pinMode(18, INPUT);
  pinMode(19, INPUT);
  attachInterrupt(20, pin18, RISING);
  attachInterrupt(21, pin19, RISING);
  
  pinMode(20, INPUT);
  pinMode(21, INPUT);
  attachInterrupt(20, pin20, RISING);
  attachInterrupt(21, pin21, RISING);
}

// RawHID packets are always 64 bytes
byte buffer[64];
byte receiveBuffer[64];
unsigned int packetCount = 0;

void loop() {
  delay(50);
  
  //Serial.println(baro.read());
  
  Serial.print(analogRead(18));
  //Serial.print(" ");
  //Serial.println(analogRead(19));
  
  int s1 = analogRead(14);
  if (s1 <= POS_1 + 10 && s1 >= POS_1 - 10)
    if (current_pos != 1) {
      current_pos = 1;
      Serial.println("pos1");
    }
  if (s1 <= POS_2 + 10 && s1 >= POS_2 - 10)
    if (current_pos != 2) {
      current_pos = 2;
      Serial.println("pos2");
    }
  if (s1 <= POS_3 + 10 && s1 >= POS_3 - 10)
    if (current_pos != 3) {
      current_pos = 3;
      Serial.println("pos3");
    }
  
  //Serial.println(analogRead(14));
  
  sendQueue.Run(millis());
  
  n = RawHID.recv(receiveBuffer, 1); // 0 timeout = do not wait
  if (n > 0) {
    //String message = String((char *)buffer);
    //Serial.println(message);
    
    digitalWrite(10, receiveBuffer[1]);
    digitalWrite(11, receiveBuffer[2]);
    digitalWrite(12, receiveBuffer[3]);
    digitalWrite(15, receiveBuffer[4]);
    digitalWrite(16, receiveBuffer[5]);
    digitalWrite(17, receiveBuffer[6]);
        
    /*byte chars[63];
    memcpy(chars, receiveBuffer, 63);
    
    String command = String("");
    for (int i=1; i<63; i++) {
      Serial.print((char)receiveBuffer[i]);
      //command += String((char)receiveBuffer[i]);
      //Serial.print(String((char)receiveBuffer[i]));
    }
    Serial.println(command);*/
        
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


void pin18() {
  Serial.println("Enc 1");
}

void pin19() {
  Serial.println("Enc 2");
}

void pin20() {
  Serial.println("Position 1");
}

void pin21() {
  Serial.println("Position 2");
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
  //if (!bounced()) {
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
  //}
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
