#include <LiquidCrystal.h>
#include <DHT.h>

// ==========================================
// 1. KHAI BÁO CHÂN CẮM (CONSTANTS)
// ==========================================
#define DHTPIN 2          
#define DHTTYPE DHT11     
const int SOIL_PIN = A0;  
const int LDR_PIN = A1;   

const int PUMP_PIN = 3;   
const int FAN_PIN = 4;    
const int LIGHT_PIN = 5;  

LiquidCrystal lcd(12, 11, 10, 9, 8, 7);
DHT dht(DHTPIN, DHTTYPE);

// Các biến lưu thông số cảm biến
float tempAir = 0;
float humAir = 0;
int soilMoisture = 0;
int lightLevel = 0;

// Các biến phục vụ chế độ Tự động & Ngưỡng cấu hình
bool isAutoMode = true;
int tempThreshold = 31;
int soilThreshold = 30;
int lightThreshold = 40;

void setup() {
  Serial.begin(9600);
  
  lcd.begin(20, 4);
  lcd.setCursor(0, 0);
  lcd.print("Smart Agri System");
  lcd.setCursor(0, 1);
  lcd.print("Ready for Command");
  delay(1500);
  lcd.clear();

  dht.begin();

  pinMode(PUMP_PIN, OUTPUT);
  pinMode(FAN_PIN, OUTPUT);
  pinMode(LIGHT_PIN, OUTPUT);

  // Khởi động mặc định tắt hết thiết bị
  digitalWrite(PUMP_PIN, LOW);
  digitalWrite(FAN_PIN, LOW);
  digitalWrite(LIGHT_PIN, LOW);
}

void loop() {
  readSensors();
  
  // Thực hiện điều khiển tự động nếu đang ở chế độ Tự động
  if (isAutoMode) {
    runAutoControl();
  }
  
  updateLCD();
  sendDataToPC();         // Liên tục gửi thông tin lên PC
  receiveCommandFromPC(); // Kiểm tra lệnh điều khiển từ Winform
  
  delay(1000); // Đọc và đồng bộ dữ liệu mỗi giây
}

void readSensors() {
  humAir = dht.readHumidity();
  tempAir = dht.readTemperature();
  soilMoisture = map(analogRead(SOIL_PIN), 0, 1023, 0, 100);
  lightLevel = map(analogRead(LDR_PIN), 0, 1023, 0, 100);
}

void runAutoControl() {
  // 1. Tự động điều khiển máy bơm theo độ ẩm đất
  if (soilMoisture < soilThreshold) {
    digitalWrite(PUMP_PIN, HIGH);
  } else if (soilMoisture >= (soilThreshold + 5)) { // Thêm khoảng trễ 5% tránh bật tắt liên tục
    digitalWrite(PUMP_PIN, LOW);
  }

  // 2. Tự động điều khiển quạt theo nhiệt độ không khí
  if (tempAir > tempThreshold) {
    digitalWrite(FAN_PIN, HIGH);
  } else if (tempAir <= (tempThreshold - 1)) { // Khoảng trễ 1 độ C
    digitalWrite(FAN_PIN, LOW);
  }

  // 3. Tự động điều khiển đèn theo cường độ ánh sáng
  if (lightLevel < lightThreshold) {
    digitalWrite(LIGHT_PIN, HIGH);
  } else if (lightLevel >= (lightThreshold + 5)) { // Khoảng trễ 5%
    digitalWrite(LIGHT_PIN, LOW);
  }
}

void updateLCD() {
  lcd.setCursor(0, 0);
  lcd.print("T:"); lcd.print(tempAir, 1); lcd.print("C  ");
  lcd.print("Mode:"); lcd.print(isAutoMode ? "AUTO  " : "MANUAL");
  
  lcd.setCursor(0, 1);
  lcd.print("H_Air:"); lcd.print(humAir, 1); lcd.print("%  ");
  
  lcd.setCursor(0, 2);
  lcd.print("H_Soil:"); lcd.print(soilMoisture); lcd.print("% (S:"); lcd.print(soilThreshold); lcd.print("%) ");
  
  lcd.setCursor(0, 3);
  lcd.print("L_Lvl:"); lcd.print(lightLevel); lcd.print("% (S:"); lcd.print(lightThreshold); lcd.print("%) ");
}

void sendDataToPC() {
  // Gói tin định dạng mới gửi lên Winform: 11 trường thông tin
  // *tempAir|humAir|soilMoisture|lightLevel|pumpState|fanState|lightState|isAutoMode|tempThreshold|soilThreshold|lightThreshold#
  Serial.print("*");
  Serial.print(tempAir, 1); Serial.print("|");
  Serial.print(humAir, 1); Serial.print("|");
  Serial.print(soilMoisture); Serial.print("|");
  Serial.print(lightLevel); Serial.print("|");
  Serial.print(digitalRead(PUMP_PIN)); Serial.print("|");
  Serial.print(digitalRead(FAN_PIN)); Serial.print("|");
  Serial.print(digitalRead(LIGHT_PIN)); Serial.print("|");
  Serial.print(isAutoMode ? 1 : 0); Serial.print("|");
  Serial.print(tempThreshold); Serial.print("|");
  Serial.print(soilThreshold); Serial.print("|");
  Serial.print(lightThreshold);
  Serial.println("#"); 
}

// =========================
// HÀM NHẬN LỆNH ĐIỀU KHIỂN 
// =========================
void receiveCommandFromPC() {
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n'); 
    command.trim();

    // Chuyển đổi chế độ hoạt động
    if (command == "MODE_AUTO") {
      isAutoMode = true;
    }
    else if (command == "MODE_MANUAL") {
      isAutoMode = false;
    }
    
    // Nhận cài đặt ngưỡng tự động
    else if (command.startsWith("SET_TEMP:")) {
      tempThreshold = command.substring(9).toInt();
    }
    else if (command.startsWith("SET_SOIL:")) {
      soilThreshold = command.substring(9).toInt();
    }
    else if (command.startsWith("SET_LIGHT:")) {
      lightThreshold = command.substring(10).toInt();
    }

    // Điều khiển thiết bị thủ công (Chỉ có tác dụng khi ở chế độ Thủ công)
    else if (!isAutoMode) {
      if (command == "PUMP_ON")   digitalWrite(PUMP_PIN, HIGH);
      if (command == "PUMP_OFF")  digitalWrite(PUMP_PIN, LOW);
      if (command == "FAN_ON")    digitalWrite(FAN_PIN, HIGH);
      if (command == "FAN_OFF")   digitalWrite(FAN_PIN, LOW);
      if (command == "LIGHT_ON")  digitalWrite(LIGHT_PIN, HIGH);
      if (command == "LIGHT_OFF") digitalWrite(LIGHT_PIN, LOW);
    }
  }
}