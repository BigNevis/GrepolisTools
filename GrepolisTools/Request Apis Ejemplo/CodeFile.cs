

////Crear Usuarios
//curl--location 'https://localhost:7028/api/User' \
//--header 'Content-Type: application/json' \
//--data-raw '{
//    "Username": "testuser2212111",
//    "Name": "Test User",
//    "Password": "password",
//    "Email": "2212112t1estuser@example.com",
//    "RoleId": 1,
//    "AllianceId": 1,
//    "StateId": 8
//}
//'

//// Login
//curl--location 'https://localhost:7028/api/User/login' \
//--header 'Content-Type: application/json' \
//--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3R1c2VyMjIxMjEiLCJuYmYiOjE2ODk3ODM4MDIsImV4cCI6MTY5MDM4ODYwMiwiaWF0IjoxNjg5NzgzODAyfQ.4sqg_sgMEFC_clyTZQtWa7UgpR3WZa1wugrcXCz-ARI' \
//--data '{
//    "Username": "testuser221211",
//    "Password": "password"
//}'