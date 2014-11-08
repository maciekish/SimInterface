//Put usb_desc.h in arduino\hardware\teensy\cores\teensy3
//#define USB_RAWHID

#define MODE 1
#define RANGE 0
int mode_pos = 0;
int range_pos = 0;

#include <Bounce2.h>

// Settings
#define PANEL  "EFIS.L"

// RawHID packets are always 64 bytes
byte buffer[64];
byte receiveBuffer[64];
unsigned int packetCount = 0;

int ms = 10;
Bounce button1 = Bounce();
Bounce button2 = Bounce();
Bounce button3 = Bounce();
Bounce button4 = Bounce();
Bounce button5 = Bounce();
Bounce button6 = Bounce();
Bounce button7 = Bounce();
Bounce button8 = Bounce();
Bounce button9 = Bounce();
Bounce button10 = Bounce();
Bounce button11 = Bounce();
Bounce button13 = Bounce();
Bounce button16 = Bounce();
Bounce button17 = Bounce();
Bounce button22 = Bounce();
Bounce button23 = Bounce();

void setup() {
  delay(1000);
  
  Serial.begin(9600);
  Serial.println("SimInterface Initialized");
  Serial.print("Panel: ");
  Serial.println(PANEL);
  
  //Setup pins
  for (int i=1; i<=23; i++) {
    pinMode(i, INPUT);
  }
  pinMode(13, OUTPUT);
  
  attachButtons();
  
  //Blink LED to indicate we are alive and kickin'
  digitalWrite(13, HIGH);
  delay(100);
  digitalWrite(13, LOW);
}

void loop() {
  updateButtons();

  checkButtons();
  updatePositions();
  
  processCommands();
}

void processCommands() {
  int n = RawHID.recv(receiveBuffer, 1); //0 = dont wait
  
  if (n > 0) {
    char chars[63];
    memcpy(chars, receiveBuffer, 63);
    
    String command = String(chars);
    Serial.println(command);
    
    //For now always update, later check for correct command.
    updateOnRequest();
  }
}

void updateOnRequest() {
  updateButtons();
  
  Serial.println("Updating");

  if (button1.read() && button2.read()) {
    buttonPressed(-1);
  } else if (button1.read()) {
    buttonPressed(1);
  } else if (button2.read()) {
    buttonPressed(2);
  }
  if (button3.read() && button4.read()) {
    buttonPressed(-3);
  } else if (button3.read()) {
    buttonPressed(3);
  } else if (button4.read()) {
    buttonPressed(4);
  }
}

void buttonPressed(int buttonIndex) {
  String message = PANEL;
  message = message + ":";
  message = message + buttonIndex;
  
  Serial.println(message);
  
  message.getBytes(buffer, 64);
  RawHID.send(buffer, 100);
  memset(buffer,0,sizeof(buffer));
  
  blink();
}

void positionChanged(int switchIndex, int newPosition) {
  String message = PANEL;
  message = message + ":";
  message = message + switchIndex;
  message = message + ":";
  message = message + newPosition;
  
  Serial.println(message);
  
  message.getBytes(buffer, 64);
  RawHID.send(buffer, 100);
  memset(buffer,0,sizeof(buffer));
  
  blink();
}

void blink() {
  digitalWrite(13, HIGH);
  delay(2);
  digitalWrite(13, LOW);
}

void attachButtons() {
  button1.attach(1);
  button1.interval(ms);
  button2.attach(2);
  button2.interval(ms);
  button3.attach(3);
  button3.interval(ms);
  button4.attach(4);
  button4.interval(ms);
  button5.attach(5);
  button5.interval(ms);
  button6.attach(6);
  button6.interval(ms);
  button7.attach(7);
  button7.interval(ms);
  button8.attach(8);
  button8.interval(ms);
  button9.attach(9);
  button9.interval(ms);
  button10.attach(10);
  button10.interval(ms);
  button11.attach(11);
  button11.interval(ms);
  button16.attach(16);
  button16.interval(ms);
  button17.attach(17);
  button17.interval(ms);
  button22.attach(22);
  button22.interval(ms);
  button23.attach(23);
  button23.interval(ms);
}

void updateButtons() {
  button1.update();
  button2.update();
  button3.update();
  button4.update();
  button5.update();
  button6.update();
  button7.update();
  button8.update();
  button9.update();
  button10.update();
  button11.update();
  button16.update();
  button17.update();
  button22.update();
  button23.update();
}

void updatePositions() {
  int mode_val = analogRead(MODE);
  int range_val = analogRead(RANGE);
  
  //Mode
  if (mode_val > 500) { //Check for valid value
    int new_mode_pos = 3;
    if (mode_val > 960 && mode_val < 980) new_mode_pos = 0;
    if (mode_val > 900 && mode_val < 930) new_mode_pos = 1;
    if (mode_val > 870 && mode_val < 890) new_mode_pos = 2;
    
    if (mode_pos != new_mode_pos) {
      mode_pos = new_mode_pos;
      positionChanged(14, mode_pos);
    }
  }
  
  //Range
  if (range_val > 500) { //Check for valid value
    int new_range_pos = 7;
    if (range_val > 960 && range_val <= 980) new_range_pos = 0;
    if (range_val > 900 && range_val <= 960) new_range_pos = 1;
    if (range_val > 870 && range_val <= 900) new_range_pos = 2;
    if (range_val > 840 && range_val <= 870) new_range_pos = 3;
    if (range_val > 820 && range_val <= 840) new_range_pos = 4;
    if (range_val > 790 && range_val <= 820) new_range_pos = 5;
    if (range_val > 760 && range_val <= 790) new_range_pos = 6;
    
    if (range_pos != new_range_pos) {
      range_pos = new_range_pos;
      positionChanged(15, range_pos);
    }
  }
}

void checkButtons() {
  if (button1.rose()) { buttonPressed(1); }
  if (button2.rose()) { buttonPressed(2); }
  if (button3.rose()) { buttonPressed(3); }
  if (button4.rose()) { buttonPressed(4); }
  if (button5.rose()) { buttonPressed(5); }
  if (button6.rose()) { buttonPressed(6); }
  if (button7.rose()) { buttonPressed(7); }
  if (button8.rose()) { buttonPressed(8); }
  if (button9.rose()) { buttonPressed(9); }
  if (button10.rose()) { buttonPressed(10); }
  if (button11.rose()) { buttonPressed(11); }
  if (button16.fell()) { buttonPressed(16); }
  if (button17.rose()) { buttonPressed(17); }
  if (button22.rose()) { buttonPressed(22); }
  if (button23.rose()) { buttonPressed(23); }
  
  if (button1.fell()) { buttonPressed(1 * -1); }
  if (button2.fell()) { buttonPressed(2 * -1); }
  if (button3.fell()) { buttonPressed(3 * -1); }
  if (button4.fell()) { buttonPressed(4 * -1); }
}

