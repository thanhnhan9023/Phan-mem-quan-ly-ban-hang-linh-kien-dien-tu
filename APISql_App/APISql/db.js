const sql = require('mssql')

//var config = {
//    user: 'sa',
//    password: 'sa123456',
//    server:'localhost',
//    database: 'QuanLyVatLieuXayDung',
    
//    "options": {
        
//        "options.encrypt": false ,
//        "enableArithAbort": true
//    }

//};
var config = {
    user: 'sa',
    password: 'Nhan09575789@',
    server: 'localhost',
    database: 'QuanLyBanhangdientu2'
};

//var config = {
//    "user": 'sa',
//    "password": 'sa123456',
//    "server": 'localhost',
//    "database": 'QuanLyVatLieuXayDung',
//    "dialect": "mssql",
//    "dialectOptions": {
//        "instanceName": "SQLEXPRESS"
//    }
//}

const poolPromise = new sql.ConnectionPool(config)
    .connect()
    .then(pool => {
        console.log('Connected to MSSQL')
        return pool
    })
    .catch(err => console.log('Database Connection Failed! Bad Config: ', err))

module.exports = {
    sql, poolPromise
}