echo simple case
echo curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15T12:00:00\",\"Status\":0}"
curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15T12:00:00\",\"Status\":0}"
sleep 1

echo same amount within 5 sec status should be REJECTED
echo curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15T12:00:25\",\"Status\":0}"
curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15T12:00:25\",\"Status\":0}"
sleep 1

echo different amount within 5 sec status should be NORMAL
echo curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":100,\"Date\":\"2023-09-15T12:00:25\",\"Status\":0}"
curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":100,\"Date\":\"2023-09-15T12:00:25\",\"Status\":0}"
sleep 1

echo invaild Date format no data inserted
echo curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15 12:00:25\",\"Status\":0}"
curl -L "http://localhost:8080/transaction" -H "Content-Type: application/json" -i -d "{\"Id\":0,\"Amount\":20,\"Date\":\"2023-09-15 12:00:25\",\"Status\":0}"
sleep 1

echo Get ALL Transaction
curl -L "http://localhost:8080/transaction"