var API_KEY = "1234";

var express = require('express')

var router = express.Router();

const { sql, poolPromise } = require('../db')


router.get('/', function (req, res){
    res.end("Run ALL");
});

//router.get('/test', async (req, res, next) => {
//    console.log(req.query);
//    if (req.query.key != API_KEY) {
//        res.send(JSON.stringify({ success: false, message: "Wrong API_KEY" }));
//    }
//    else {
//      //  var fbid = req.query.fbid;
//       // if (fbid != null) {
//            try {
//                const pool = await poolPromise
//                const queryResult = await pool.request().query('SELECT UserPhone,Name,Address FROM [User]')
//                  //  .query('SELECT UserPhone,Name,Address FROM [User] where fbid=@fbid')
//                if (queryResult.recordset.length > 0) {
//                    res.send(JSON.stringify({ success: true, result: queryResult.recordset }));
//                }
//                else
//                    res.send(JSON.stringify({ success: false, message: "Empty" }))


//            }
//            catch (err) {
//                res.status(500);
//                res.send(JSON.stringify({ sucess: false, message: err.message }));
//            }
//        }

//   // }
//}
//);

//router.get('/banner', async (req, res) => {
//    try {

//        const pool = await poolPromise
//        const result = await pool.request()
//            // .input('input_parameter', sql.Int, req.query.input_parameter)
//            .query('select * from banner')

//        res.json(result.recordset)
//    } catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }
//});

//router.get('/loaisp', async (req, res) => {
//    try {
        
//        const pool = await poolPromise
//        const result = await pool.request()
//            // .input('input_parameter', sql.Int, req.query.input_parameter)
//            .query('select * from loaisanpham')

//        res.json(result.recordset)
//    } catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }
//});



//router.get('/sanphamALL', async (req, res) => {
//    try {

//        const pool = await poolPromise
//        const result = await pool.request()
//            // .input('input_parameter', sql.Int, req.query.input_parameter)
//            .query('select * from SanPham ')

//        res.json(result.recordset)
//    } catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }
//});


//router.get('/sanphamMoinhat', async (req, res) => {
//    try {

//        const pool = await poolPromise
//        const result = await pool.request()
//            // .input('input_parameter', sql.Int, req.query.input_parameter)
//            .query('select * from SanPham ')

//        res.json(result.recordset)
//    } catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }
//});







//router.get('/sanphamTheoID', async (req, res) => // lay ra san pham theo loai hang 
//{


//    try {
//        const pool = await poolPromise
//        const result = await pool.request().input('IDsanpham', sql.NVarChar, req.query.IDsanpham)
//            .query('select * from SanPham where ID_SP=@IDsanpham')


//        res.json(result.recordset)
//    }
//    catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }

//}
//);


//router.get('/sanphamTheoLoaisp', async (req, res) => // lay ra san pham theo loai hang 
//{


//    try {
//        const pool = await poolPromise
//        const result = await pool.request().input('IDsanpham', sql.Int, req.query.IDsanpham)
//            .query('select * from SanPham where ID=@IDsanpham')


//        res.json(result.recordset)
//    }
//    catch (err) {
//        res.status(500)
//        res.send(err.message)
//    }

//}
//);
//----------------------------------------------------------------------
router.get('/loaiHang', async (req, res) => { // loai hang 
    try {

        const pool = await poolPromise
        const result = await pool.request()
            // .input('input_parameter', sql.Int, req.query.input_parameter)
            .query('select * from LoaiHang')

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});

router.get('/Banner', async (req, res) => { // banner
    try {

        const pool = await poolPromise
        const result = await pool.request()
            // .input('input_parameter', sql.Int, req.query.input_parameter)
            .query('select * from Banner')

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});

router.get('/sanphamTheoID', async (req, res) => // lay ra san pham theo idhh
{


    try {
        const pool = await poolPromise
        const result = await pool.request().input('IdHH', sql.NVarChar, req.query.IdHH)
            .query('select * from HangHoa where MaHH=@IdHH')


        res.json(result.recordset)
    }
    catch (err) {
        res.status(500)
        res.send(err.message)
    }

}
);


router.get('/sanphamTheoLoaisp', async (req, res) => // lay ra san pham theo loai hang 
{


    try {
        const pool = await poolPromise
        const result = await pool.request().input('IDLoaiHang', sql.NVarChar, req.query.IDLoaiHang)
            .query('select * from HangHoa where MaLoai=@IDLoaiHang')


        res.json(result.recordset)
    }
    catch (err) {
        res.status(500)
        res.send(err.message)
    }

});

router.get('/getMakhtheouser', async (req, res) => // lay ra san pham theo loai hang 
{

    
    try {
        const pool = await poolPromise
        const result = await pool.request().input('userkhachhang', sql.NVarChar, req.query.userkhachhang)
            .query('select MaKH from UserKhachHang where UserName=@userkhachhang')


        res.json(result.recordset)
    }
    catch (err) {
        res.status(500)
        res.send(err.message)
    }

});


router.get('/getMadhtheomakh', async (req, res) => // lay ra san pham theo loai hang 
{


    try {
        const pool = await poolPromise
        const result = await pool.request().input('makh', sql.VarChar, req.query.makh)
            .query('select max(MaDH) as"MaDH" from  DonHang where MaKH=@makh')


        res.json(result.recordset)
    }
    catch (err) {
        res.status(500)
        res.send(err.message)
    }

});

router.get('/getALLdonhang', async (req, res) => { // banner
    try {

        const pool = await poolPromise
        const result = await pool.request()
            // .input('input_parameter', sql.Int, req.query.input_parameter)
            .query('select * from DonHang')

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


    router.get('/sanphammoinhat', async (req, res) => // lay ra san pham theo loai hang 
    {


        try {
            const pool = await poolPromise
           const result = await pool.request()//.input('IDLoaiHang', sql.NVarChar, req.query.IDLoaiHang)
                .query('select  top 10 *from HangHoa ORDER BY MAHH DESC')


            res.json(result.recordset)
        }
        catch (err) {
            res.status(500)
            res.send(err.message)
        }

    }

);



router.get('/sanphamALL', async (req, res) => {
    try {

        const pool = await poolPromise
        const result = await pool.request()
            // .input('input_parameter', sql.Int, req.query.input_parameter)
            .query('select * from HangHoa')

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


router.get('/getchitietdonhangtheouser', async (req, res) => {
    try {

    


        const pool = await poolPromise
        const result = await pool.request().input('username', sql.VarChar, req.query.username)
            .query("select Chitietdondathang.MaDH,Chitietdondathang.MAHH,Giaban,Soluong,Thanhtien,Duongdan from Chitietdondathang,HangHoa,DonHang,UserKhachHang where HangHoa.MaHH=Chitietdondathang.MAHH and  DonHang.MaDH=Chitietdondathang.MaDH and UserKhachHang.MaKH=DonHang.MaKH  and UserKhachHang.UserName=@username and Tinhtrang='false'")

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});

router.get('/getdonhangxacnhan', async (req, res) => {
    try {




        const pool = await poolPromise
        const result = await pool.request().input('username', sql.VarChar, req.query.username)
            .query("select TenHH,Giaban,Soluong,Thanhtien,Duongdan from Chitietdondathang,HangHoa,DonHang,UserKhachHang where HangHoa.MaHH=Chitietdondathang.MAHH and  DonHang.MaDH=Chitietdondathang.MaDH and UserKhachHang.MaKH=DonHang.MaKH  and UserKhachHang.UserName=@username and Tinhtrang='true'")

        res.json(result.recordset)
    } catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


router.post('/themuser', async (req, res) => {
    try {


        const pool = await poolPromise
        var username = req.body.username;
        var password = req.body.password;
        var MaKH = req.body.MaKH;
        
        const result = await pool.request()
            .input('username', sql.VarChar, username)
            .input('password', sql.NVarChar, password)
            .input('Makh', sql.VarChar, MaKH) 
            .query('insert into UserKhachHang (UserName,Password,MaKH) values (@username,@password,@Makh)')
            // .input('input_parameter' , sql.Int, req.query.input_parameter)

        res.send(JSON.stringify({ succes: true, message: "ok" }));           
    }
    

    catch (err) {
        res.status(500)
        res.send(err.message)
    }
});

router.post('/themthongtinkhachhang', async (req, res) => {
    try {


        const pool = await poolPromise
        var makh = req.body.makh;
        var tenkh = req.body.tenkh;
        var ngaysinh = req.body.ngaysinh;
        var diachi = req.body.diachi;
        var sdt = req.body.sdt;
       // var email = req.body.email;
        var gioitinh = req.body.gioitinh;
        var maloaikh = req.body.maloaikh;

        const result = await pool.request()
            .input('makh', sql.VarChar, makh)
            .input('tenkh', sql.NVarChar, tenkh)
            .input('ngaysinh', sql.Date, ngaysinh)
            .input('diachi', sql.VarChar, diachi)
            .input('sdt', sql.NVarChar, sdt)
           // .input('email', sql.VarChar, email)
            .input('gioitinh', sql.NVarChar, gioitinh)
            .input('maloaikh', sql.VarChar, maloaikh)
            .query('insert into KhachHang(MaKH,TenKH,Ngaysinh,DiaChi,SDT,GioiTinh,Maloaikh) values (@makh,@tenkh,@ngaysinh,@diachi,@sdt,@gioitinh,@maloaikh)')
        // .input('input_parameter' , sql.Int, req.query.input_parameter)

        res.send(JSON.stringify({ succes: true, message: "ok" }));
    }


    catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


router.post('/updatethongtinkhachhang', async (req, res) => {
    try {


        const pool = await poolPromise
        var makh = req.body.makh;
        var tenkh = req.body.tenkh;
        var ngaysinh = req.body.ngaysinh;
        var diachi = req.body.diachi;
        var sdt = req.body.sdt;
        // var email = req.body.email;
        var gioitinh = req.body.gioitinh;
        var maloaikh = req.body.maloaikh;

        const result = await pool.request()
            .input('makh', sql.VarChar, makh)
            .input('tenkh', sql.NVarChar, tenkh)
            .input('ngaysinh', sql.Date, ngaysinh)
            .input('diachi', sql.VarChar, diachi)
            .input('sdt', sql.NVarChar, sdt)
            // .input('email', sql.VarChar, email)
            .input('gioitinh', sql.NVarChar, gioitinh)
            .input('maloaikh', sql.VarChar, maloaikh)
            .query('update KhachHang set TenKH=@tenkh,Ngaysinh=@ngaysinh,DiaChi=@diachi,GioiTinh=@gioitinh,SDT=@sdt,Maloaikh=@maloaikh where MaKH=@makh')
        // .input('input_parameter' , sql.Int, req.query.input_parameter)

        res.send(JSON.stringify({ succes: true, message: "ok" }));
    }


    catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


router.post('/them1donhang', async (req, res) => {
    try {


        const pool = await poolPromise
        var madh = req.body.madh;
        var makh = req.body.makh;
        var ngaydathang = req.body.ngaydathang;
        var tongtien = req.body.tongtien;
        var ngaythanhtoan = req.body.ngaythanhtoan;
        var Tinhtrang = req.body.Tinhtrang;
      
      
        const result = await pool.request()
            .input('madh', sql.VarChar, madh)
            .input('makh', sql.VarChar, makh)
            .input('ngaydathang', sql.Date, ngaydathang)
            .input('tongtien', sql.BigInt, tongtien)
            .input('ngaythanhtoan', sql.Date, ngaythanhtoan)
            .input('Tinhtrang', sql.NVarChar, Tinhtrang)
            .query('insert into DonHang(MaDH,MaKH,Ngaydathang,Tongtien,Ngaythanhtoan,Tinhtrang) values(@madh,@makh,@ngaydathang,@tongtien,@ngaythanhtoan,@Tinhtrang)')
        // .input('input_parameter' , sql.Int, req.query.input_parameter)

        res.send(JSON.stringify({ succes: true, message: "ok" }));
    }


    catch (err) {
        res.status(500)
        res.send(err.message)
    }
});


router.post('/them1chietdonhang', async (req, res) => {
    try {


        const pool = await poolPromise
        var madh = req.body.madh;
        var mahh = req.body.mahh;
        var soluong = req.body.soluong;
        var giaban = req.body.giaban;
        var thanhtien = req.body.thanhtien;
       


        const result = await pool.request()
            .input('madh', sql.VarChar, madh)
            .input('mahh', sql.VarChar, mahh)
            .input('soluong', sql.Int, soluong)
            .input('giaban', sql.Float, giaban)
            .input('thanhtien', sql.BigInt, thanhtien)
            .query('insert into Chitietdondathang(MaDH,MaHH,SoLuong,Giaban,Thanhtien) values(@madh,@mahh,@soluong,@giaban,@thanhtien)')
       

        res.send(JSON.stringify({ succes: true, message: "ok" }));
    }


    catch (err) {
        res.status(500)
        res.send(err.message)
    }
})


router.post('/xoa1chitietdonhang', async (req, res) => {
    try {


        const pool = await poolPromise
        var madh = req.body.madh;
        var mahh = req.body.mahh;
        var soluong = req.body.soluong;
        var giaban = req.body.giaban;
        var thanhtien = req.body.thanhtien;



        const result = await pool.request()
            .input('madh', sql.VarChar, madh)
            .input('mahh', sql.VarChar, mahh)
            .query('delete from Chitietdondathang where MAHH=@mahh and MaDH=@madh')


        res.send(JSON.stringify({ succes: true, message: "ok" }));
    }


    catch (err) {
        res.status(500)
        res.send(err.message)
    }
})

module.exports = router;
