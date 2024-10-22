#include <WiFi.h>
#include <PubSubClient.h>
#define PAYLOAD_MAXSIZE 64

#include <Wire.h>
#include <BH1750.h>
BH1750 lightMeter;

#include "DHT.h"
#define DHTPIN D2
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);



const char* ssid = "pcroom";
const char* password = "12345678";
const char* userId = "mqtt_girl"; //girl로 pub하겠다
const char* userPw = "1234";
const char* clientId = userId;
const char *topic = "SmartFarm/Indoor/SensorValue";
const char* serverIPAddress = "192.168.0.2"; 

WiFiClient wifiClient; 
PubSubClient client(serverIPAddress, 1883, wifiClient);

//아웃풋 핀 설정
const int motorPin = D9;  // DC 모터
const int ledPin = D5;    // LED

void setup() {
  Serial.begin(9600);
  Serial.print("\nConnecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
  Serial.print("."); delay(1000);
  }
  Serial.println("\nWiFi Connected");
  Serial.println("Connecting to broker");
  while ( !client.connect(clientId, userId, userPw) ){ 
  Serial.print("*"); delay(1000);
  }
  Serial.println("Connected to broker\n");

  pinMode(motorPin, OUTPUT);
  pinMode(ledPin, OUTPUT);

   // 모터 및 LED를 처음에  OFF
  digitalWrite(motorPin, LOW);
  digitalWrite(ledPin, LOW);

  dht.begin();
  Wire.begin();
  lightMeter.begin();

}

void loop() {
char payload[PAYLOAD_MAXSIZE];
float h = dht.readHumidity();
float t = dht.readTemperature();
if (isnan(h) || isnan(t) ) {
  Serial.println("Failed to read from DHT sensor!");
  return;
  } 
  //조도값 읽기

  //MQTT로 보내는 JSON 데이터
  float lux = lightMeter.readLightLevel();
  String sPayload = 
    + "{\"Temp\":"
    + String(t, 1)
    + ",\"Humi\":"
    + String(h, 1)
    + ",\"Lux\":"
    + String(lux, 1)
    + " }";
  sPayload.toCharArray(payload, PAYLOAD_MAXSIZE);

  // MQTT에 전송
  client.publish(topic, payload);
  Serial.print(String(topic) + " ");
  Serial.println(payload);
   // DC 모터 제조: 온도가 25°C 이상이면 모터를 켜고
  if (t >= 24.0) {
    digitalWrite(motorPin, HIGH);  // 모터 켜기
    Serial.println("Motor ON");
    delay(200);
  } 
  // 온도가 25°C 미만이면 모터를 끄고
  else {
    digitalWrite(motorPin, LOW);   // 모터 끄기
    Serial.println("Motor OFF");
    delay(200);
  }

  // LED 제조: 조도 값이 150 lux 미만이면 LED를 켜고
  if (lux < 150) {
    digitalWrite(ledPin, HIGH);    // LED 켜기
    Serial.println("LED ON");
    delay(200);
  } 
  // 조도 값이 150 lux 이상이면 LED를 끄고
  else {
    digitalWrite(ledPin, LOW);     // LED 끄기
    Serial.println("LED OFF");
    delay(200);
  }
  delay(500);
}
