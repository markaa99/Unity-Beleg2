/*
 * Typical pin layout used:
 * -----------------------------------------------------------------------------------------
 *             MFRC522      Arduino       Arduino   Arduino    Arduino          Arduino
 *             Reader/PCD   Uno/101       Mega      Nano v3    Leonardo/Micro   Pro Micro
 * Signal      Pin          Pin           Pin       Pin        Pin              Pin
 * -----------------------------------------------------------------------------------------
 * RST/Reset   RST          9             5         D9         RESET/ICSP-5     RST
 * SPI SS      SDA(SS)      10            53        D10        10               10
 * SPI MOSI    MOSI         11 / ICSP-4   51        D11        ICSP-4           16
 * SPI MISO    MISO         12 / ICSP-1   50        D12        ICSP-1           14
 * SPI SCK     SCK          13 / ICSP-3   52        D13        ICSP-3           15
 */

#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN 9  // SPI Reset Pin
#define SS_PIN 10  // SPI Slave Select Pin

MFRC522 mfrc522(SS_PIN, RST_PIN);  // Instanz des MFRC522 erzeugen

byte blue_uid[] = { 0xD3, 0xA2, 0x23, 0x14 };
byte red_uid[] = { 0x33, 0xBB, 0xF9, 0x2E };

int blue_led = 5;  // Pin der blauen LED
int red_led = 3;   // Pin der roten LED

int blue_check = false;
int red_check = false;


void setup() {
  // Diese Funktion wird einmalig beim Start ausgeführt
  Serial.begin(9600);  // Serielle Kommunikation mit dem PC initialisieren
  SPI.begin();         // Initialisiere SPI Kommunikation
  mfrc522.PCD_Init();  // Initialisiere MFRC522 Lesemodul
  pinMode(blue_led, OUTPUT);
  pinMode(red_led, OUTPUT);
  
}

void loop() {
  // Diese Funktion wird in Endlosschleife ausgeführt

  // Nur wenn eine Karte gefunden wird und gelesen werden konnte, wird der Inhalt von IF ausgeführt
  // PICC = proximity integrated circuit card = kontaktlose Chipkarte
  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    //Serial.print("Gelesene UID:");
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      // Abstand zwischen HEX-Zahlen und führende Null bei Byte < 16
      //Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
      //Serial.print(mfrc522.uid.uidByte[i], HEX);
    }
    //Serial.println();

    // UID Vergleichen mit blue_uid
    blue_check = true;
    for (int j = 0; j < 4; j++) {
      if (mfrc522.uid.uidByte[j] != blue_uid[j]) {
        blue_check = false;
      }
    }

    // UID Vergleichen mit red_uid
    red_check = true;
    for (int j = 0; j < 4; j++) {
      if (mfrc522.uid.uidByte[j] != red_uid[j]) {
        red_check = false;
      }
    }

    if (blue_check) {
      digitalWrite(blue_led, HIGH);
      Serial.println("blue");
    }

    if (red_check) {
      digitalWrite(red_led, HIGH);
      Serial.println("red");
    }

    // Versetzt die gelesene Karte in einen Ruhemodus, um nach anderen Karten suchen zu können.
    mfrc522.PICC_HaltA();
    delay(1000);
    digitalWrite(blue_led, LOW);
    digitalWrite(red_led, LOW);
  }
}