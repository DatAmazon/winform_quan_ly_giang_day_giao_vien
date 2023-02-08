﻿
CREATE DATABASE QLLDGV
ON(
		FILENAME='D:\ThucHanh SQL\BTLSQL.mdf',--COPY XONG HET
		SIZE=3MB,
		MAXSIZE= UNLIMITED,
		FILEGROWTH=10%,
		NAME='QLLDGV');
go
USE QLLDGV
go
CREATE TABLE GIANGVIEN
(
	sMagv nvarchar(10) not null,
	sTengv nvarchar(25) not null,
	sGioitinh nvarchar(10),
	dNgaysinh date,
	sDiachi nvarchar(25),
	sSdt nvarchar(10),
	sChucvu nvarchar(20),
	CONSTRAINT pk_GV PRIMARY KEY(sMaGV),
	CONSTRAINT ck_Gioitinh CHECK (sGioitinh = N'Nam' OR sGioitinh = N'Nữ')
);

CREATE TABLE MON
(
	sMamon nvarchar(10) not null,
	sTenmon nvarchar(25) not null,
	iSotin int,
	CONSTRAINT pk_MON PRIMARY KEY(sMamon),
	CONSTRAINT ck_Sotin CHECK(iSotin > = 0)
);
GO
CREATE TABLE LOP
(
	sMalop nvarchar(20) not null,
	iSosv int,
	CONSTRAINT pk_LOP PRIMARY KEY(sMalop),
	CONSTRAINT ck_Sosv check(iSoSv > 0 or iSosv is null)
);

CREATE TABLE PHONG
(
	sMap nvarchar(10) not null,
	sChucnang nvarchar(25),
	CONSTRAINT pk_PHONG PRIMARY KEY (sMap)
);

CREATE TABLE THOIGIAN
(
	dNgayday datetime not null PRIMARY KEY,
	sCaday nvarchar(12),
	sGhichu nvarchar(50)
)

CREATE TABLE LICHDAY
(
	dNgayday datetime not null,
	sMagv nvarchar(10) not null,
	sMamon nvarchar(10) not null,
	sMalop nvarchar(20) not null,
	sMap nvarchar(10) not null,
	sTrangthai nvarchar(10),
	sGhichu nvarchar(50),
	CONSTRAINT pk_LICHDAY PRIMARY KEY(dNgayday, sMagv, sMamon, sMalop, sMap),
	CONSTRAINT ck_Trangthai CHECK (sTrangthai = N'Nghỉ' or sTrangthai = N'Học'),
	CONSTRAINT fk_LICHDAY_THOIGIAN FOREIGN KEY (dNgayday) REFERENCES THOIGIAN(dNgayday),
	CONSTRAINT fk_LICHDAY_GIANGVIEN FOREIGN KEY (sMagv) REFERENCES GIANGVIEN(sMagv),
	CONSTRAINT fk_LICHDAY_MON FOREIGN KEY (sMamon) REFERENCES MON(sMamon),
	CONSTRAINT fk_LICHDAY_LOP FOREIGN KEY (sMalop) REFERENCES LOP(sMalop),
	CONSTRAINT fk_LICHDAY_PHONG FOREIGN KEY (sMap) REFERENCES PHONG(sMap)
);

--Dữ liệu

INSERT INTO GIANGVIEN 
VALUES
	('GV1', N'Nguyễn Thị Tâm'       , N'Nữ' , '1985-8-7', N'Hà Nội'   , '0835271890', N'Giảng Viên'     ),
	('GV2', N'Lê Hữu Dũng'			, N'Nam', '1980-8-16', N'Thái Bình', '0927184638', N'Phó Trưởng Khoa'),
	('GV3', N'Trịnh Thị Xuân'		, N'Nữ' , '1984-2-2', N'Bắc Ninh' , '0926183828', N'Giảng Viên'     ),
	('GV4', N'Nguyễn Thành Huy'		, N'Nam', '1982-9-21', N'Hà Nam'   , '0926381912', N'Giảng Viên'     ),
	('GV5', N'Thái Thanh Tùng'		, N'Nam', '1972-3-21', N'Hà Nội'   , '0292819381', N'Trưởng Khoa'    ),
	('GV6', N'Nguyễn Thị Quỳnh Như'	, N'Nữ',  '1984-9-21', N'Huế'      , '0908081979', N'Giảng Viên'     ),
	('GV7', N'Nguyễn Đức Tuấn'		, N'Nam', '1984-8-25', N'Hà Nội'   , '0902260781', N'Giảng Viên'     ),
	('GV8', N'Nguyễn Thị Thuý Lan'	, N'Nữ',  '1974-9-12', N'Hà Nội'   , '0989080074', N'Giảng Viên'     ),
	('GV9', N'Trần Tiến Dũng'	    , N'Nam', '1980-7-11', N'Hà Nội'   , '0989080074', N'Giảng Viên'     ),
	('GV10', N'Lương Minh Hạnh'		, N'Nữ',  '1980-6-15', N'Hà Nội'   , '0926381000', N'Giảng Viên'     );
	


INSERT INTO MON 
VALUES

	('SQL'  , N'Hệ quản trị Cơ sở dữ liệu' , 4),
	('CSDL' , N'Cơ sở dữ liệu'             , 4),	
	('MTT'  , N'Mạng truyền thông'         , 3),
	('HDT'  , N'Lập trình hướng đối tượng' , 4),
	('WEB'  , N'Lập trình web cơ bản'      , 4),
	('TA'   , N'Tiếng anh chuyên ngành'	   , 3),
	('MNM'  , N'Mã nguồn mở'              , 3),
	('TT'   , N'Tư tưởng Hồ Chí Minh'	   , 3);
	GO

INSERT INTO LOP(sMalop) 
VALUES
	
	('AAST2TSQL21'),
	('AACT2LTA22'),
	('AAST3DWEB23'),
	('AACT3DMNM24'),
	('AAST4XCSDL24'),
	('AAST5HTT41'),
	('AACT5HMTT41'),
	('AACT6NHDT42'),
	('AACT7TWEB43'),
	('AAST6LTA22'),
	('AAST7LTA22'),
	('AAST6DSQL23');


INSERT INTO PHONG 
VALUES
	
	('P21', N'Lý thuyết'  ),
	('P22', N'Lý thuyết'  ),
	('P23', N'Lý thuyết'  ),
	('P24', N'Lý thuyết'  ),
	('P31', N'Thực hành'  ),
	('P32', N'Thực hành'  ),
	('P33', N'Thực hành'  ),
	('P41', N'Lý thuyết'  ),
	('P42', N'Lý thuyết'  ),
	('P43', N'Lý thuyết'  ),
	('P51', N'Lý thuyết'  ),
	('P52', N'Lý thuyết'  );

INSERT INTO THOIGIAN(dNgayday,sCaday)
VALUES

--tuần 1
	('2021-9-6 06:45:00',N'Sáng'),
	('2021-9-6 12:45:00',N'Chiều'),
	('2021-9-7 06:45:00',N'Sáng'),
	('2021-9-7 12:45:00',N'Chiều'),
	('2021-9-8 06:45:00',N'Sáng'),
	('2021-9-9 06:45:00',N'Sáng'),
	('2021-9-9 12:45:00',N'Chiều'),
	('2021-9-10 12:45:00',N'Chiều'),
	('2021-9-11 12:45:00',N'Chiều'),
	--TA  côc Lan có 3 lịch dạy trên tuần,LHD có lịch dạy 2 môn khác nhau trên tuần 1
	('2021-9-10 06:45:00',N'Sáng'),
	('2021-9-11 06:45:00',N'Sáng'),

--tuần 2
	('2021-9-13 06:45:00',N'Sáng'),
	('2021-9-13 12:45:00',N'Chiều'),
	('2021-9-14 06:45:00',N'Sáng'),
	('2021-9-14 12:45:00',N'Chiều'),
	('2021-9-15 06:45:00',N'Sáng'),
	('2021-9-16 06:45:00',N'Sáng'),
	('2021-9-16 12:45:00',N'Chiều'),
	('2021-9-17 12:45:00',N'Chiều'),
	('2021-9-18 12:45:00',N'Chiều'),
	--TA  côc Lan có 3 lịch dạy trên tuần,LHD có lịch dạy 2 môn khác nhau trên tuần 2
	('2021-9-17 06:45:00',N'Sáng'),
	('2021-9-18 06:45:00',N'Sáng');

	INSERT INTO LICHDAY VALUES
--tuần 1
	('2021-9-6 06:45:00', 'GV1', 'SQL' , 'AAST2TSQL21', 'P21', N'Học', ''),
	('2021-9-6 12:45:00', 'GV2', 'WEB', 'AAST3DWEB23', 'P23', N'Học' , ''),
	('2021-9-7 06:45:00', 'GV3', 'CSDL' , 'AAST4XCSDL24', 'P24', N'Học' , ''),
	('2021-9-7 12:45:00', 'GV4', 'MTT' , 'AACT5HMTT41', 'P41', N'Học' , ''),
	('2021-9-8 06:45:00', 'GV6', 'HDT' , 'AACT6NHDT42', 'P42', N'Học' , ''),
	('2021-9-9 06:45:00', 'GV7', 'WEB' , 'AACT7TWEB43', 'P43', N'Học' , ''),
	('2021-9-9 12:45:00', 'GV8', 'TA' , 'AACT2LTA22', 'P22', N'Học' , ''),
	('2021-9-10 12:45:00', 'GV9', 'MNM' , 'AACT3DMNM24', 'P24', N'Học' , ''),
	('2021-9-11 12:45:00', 'GV10', 'TT' , 'AAST5HTT41', 'P41', N'Nghỉ' , ''),

	--TA  côc Lan có 3 lịch dạy trên tuần,LHD có lịch dạy 2 môn khác nhau trên tuần 1
	('2021-9-10 06:45:00', 'GV8', 'TA' , 'AAST6LTA22', 'P22', N'Học' , ''),
	('2021-9-11 06:45:00', 'GV8', 'TA' , 'AAST6LTA22', 'P22', N'Học' , ''),
	('2021-9-10 06:45:00', 'GV2', 'SQL', 'AAST6DSQL23', 'P23', N'Học' , ''),

--tuần 2
	('2021-9-13 06:45:00', 'GV1', 'SQL' , 'AAST2TSQL21', 'P21', N'Học', N'Tuần 2'),
	('2021-9-13 12:45:00', 'GV2', 'WEB', 'AAST3DWEB23', 'P23', N'Học' ,  N'Tuần 2'),
	('2021-9-14 06:45:00', 'GV3', 'CSDL' , 'AAST4XCSDL24', 'P24', N'Học' ,  N'Tuần 2'),
	('2021-9-14 12:45:00', 'GV4', 'MTT' , 'AACT5HMTT41', 'P41', N'Học' ,  N'Tuần 2'),
	('2021-9-15 06:45:00', 'GV6', 'HDT' , 'AACT6NHDT42', 'P42', N'Học' ,  N'Tuần 2'),
	('2021-9-16 06:45:00', 'GV7', 'WEB' , 'AACT7TWEB43', 'P43', N'Học' ,  N'Tuần 2'),
	('2021-9-16 12:45:00', 'GV8', 'TA' , 'AACT2LTA22', 'P22', N'Học' ,  N'Tuần 2'),
	('2021-9-17 12:45:00', 'GV9', 'MNM' , 'AACT3DMNM24', 'P24', N'Học' ,  N'Tuần 2'),
	('2021-9-18 12:45:00', 'GV10', 'TT' , 'AAST5HTT41', 'P41', N'Nghỉ' ,  N'Tuần 2'),

	--TA  côc Lan có 3 lịch dạy trên tuần,LHD có lịch dạy 2 môn khác nhau trên tuần 
	('2021-9-17 06:45:00', 'GV8', 'TA' , 'AAST6LTA22', 'P22', N'Học' ,  N'Tuần 2'),
	('2021-9-18 06:45:00', 'GV8', 'TA' , 'AAST6LTA22', 'P22', N'Học' ,  N'Tuần 2'),
	('2021-9-17 06:45:00', 'GV2', 'SQL', 'AAST6DSQL23', 'P23', N'Học' ,  N'Tuần 2');
	select * from LICHDAY
--đếm số lg giảng viên theo chức vụ
create proc demGVByChucVu
as
SELECT sChucvu, COUNT(sMagv) AS SOLUONG FROM GIANGVIEN
--where sChucvu= N'Phó trưởng khoa'
GROUP BY sChucvu 

create proc ThemGV
@MAGV NVARCHAR(30),
@TenGV NVARCHAR(30),
@GT NVARCHAR(30),
@NS Date,
@DC NVARCHAR(30),
@SDT NVARCHAR(30),
@ChucVu NVARCHAR(30)
AS
	insert into GIANGVIEN(sMagv, sTengv, sGioitinh, dNgaysinh, sDiachi, sSdt,sChucvu)
	                  values(@MAGV, @TenGV, @GT, @NS, @DC, @SDT, @ChucVu)

create proc deleteGV
@MAGV NVARCHAR(10)
AS
	  Delete from GIANGVIEN where sMagv = @MAGV

create proc timGVByChucVu
@Chucvu nvarchar(20)
as
	select * from GIANGVIEN where sChucvu = @Chucvu

create proc CapNhatGV
@MAGV NVARCHAR(10),
@TenGV NVARCHAR(25),
@GT NVARCHAR(10),
@NS Date,
@DC NVARCHAR(25),
@SDT NVARCHAR(10),
@ChucVu NVARCHAR(20)
AS
	update GIANGVIEN set sTengv = @TenGV, sGioitinh=@GT, dNgaysinh= @NS, sDiachi = @DC, sSdt= @SDT, sChucvu = @ChucVu
	where sMagv = @MAGV


alter table Lichday
add STT INT IDENTITY(1,1) 
go
create proc deleteLD
@STT int
as 
	delete from LICHDAY where iSTT = 7
select * from LICHDAY

go
create proc updateLD
@ngayday datetime,
@magv NVARCHAR(10),
@mamon NVARCHAR(10),
@malop NVARCHAR(20),
@map NVARCHAR(10),
@trangthai NVARCHAR(10),
@ghichu NVARCHAR(50),
@STT int
as
	update LICHDAY 
	set dNgayday = @ngayday, sMagv = @magv,sMamon = @mamon,sMalop= @malop,sMap = @map,sTrangthai= @trangthai,sGhichu = @ghichu
	where iSTT = @STT
go
create proc timLDByTrangThai
@Trangthai nvarchar(10)
as
	select * from LICHDAY where sTrangthai = @Trangthai

go
create proc updateTG
@Ngayday datetime,
@Caday nvarchar(12),
@Ghichu nvarchar(50)
as	
	update THOIGIAN set sCaday = @Caday, sGhichu = @Ghichu where dNgayday = @Ngayday

create proc deleteTG
@Ngayday datetime
as
	delete THOIGIAN where dNgayday= @Ngayday
Delete THOIGIAN where dNgayday = 'dtpNgayDay.Value'

select * from LICHDAY

create proc timAllByCaDay
@Caday nvarchar(12)
as
	select * from THOIGIAN where sCaday = @Caday
	
create proc TimMonByTinChi
@Tinchi int
as
	select *from mon where iSotin = @Tinchi
exec TimMonByTinChi 3 	   
create proc XoaMon
@Mamon NVARCHAR(10),
@tenmon NVARCHAR(25),
@sotin int
as
	delete from MON where sMamon = @Mamon

insert into Mon(sMamon, sTenmon, iSotin) values(

insert into LICHDAY(dNgayday,sMagv,sMamon,sMalop,sMap,sTrangthai,sGhichu) values ('','','','','',N'',N'')
 --('2022-3-3 06:45:00','GV1','HSK','AALTHSKT2','P24',N'Học',N'th ng')
 --('2022-3-30 06:45:00','GV7','HSK','AAST7LTA22','P24',N'Học',N'th ng')
create proc insLichDay
@ngayday datetime,
@magv NVARCHAR(10),
@mamon NVARCHAR(10),
@malop NVARCHAR(20),
@map NVARCHAR(10),
@trangthai NVARCHAR(10),
@ghichu NVARCHAR(50)
as
	insert into LICHDAY	
	values (@ngayday,@magv,@mamon,@malop,@map,@trangthai,@ghichu)

exec insLichDay '2022-3-3 06:45:00','GV1','HSK','AALTHSKT2','P24',N'Học',N'th ng'


--Thêm môn theo text
insert into MON values('thu ng', 'thu ng', 3);
--Thêm môn theo proc
CREATE PROC THEMMON
@MAMON NVARCHAR(30),
@TENMON NVARCHAR(30),
@SOTIN INT
AS
	IF EXISTS(SELECT sMamon FROM MON WHERE @MAMON=sMamon)
	BEGIN
		PRINT N'ĐÃ XẢY RA LỖI VUI LÒNG KIỂM TRA'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO MON(sMamon,sTenmon,iSotin) VALUES (@MAMON,@Tenmon,@SOTIN)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC THEMMON 'haha1','haha','5'	
go
--lấy môn theo số tín-proc- DataTable
Create proc getMaMonBySoTin
@soTin int 
as
	select * from Mon 
	where iSotin = @soTin
exec getMaMonBySoTin 3
go
--xóa ngayday theo ghichu
create proc deleteNgayDayByGhiChu
@ghichu nvarchar(30)
as 
	delete from THOIGIAN
	where sGhichu = @ghichu
--thêm thoigian theo proc
alter PROC insertTimebyProc
@ngayday datetime,
@caday NVARCHAR(30),
@ghichu NVARCHAR(30)
AS
	IF EXISTS(SELECT dNgayday FROM THOIGIAN WHERE @ngayday=dNgayday)
	BEGIN
		PRINT N'duplicate key, please enter again'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO THOIGIAN(dNgayday,sCaday,sGhichu) VALUES (@ngayday,@caday,@ghichu)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC insertTimebyProc '2022-02-02 12:45:00','thu ng','thu ng'

alter proc countGV
@DiaCHi NVARCHAR(30)
AS
BEGIN
	SELECT sDiachi, COUNT(smagv) as count FROM  GIANGVIEN 
	WHERE sDiachi =  @DiaCHi
	group by sDiachi
END
exec countGV N'Hà Nội'

CREATE PROC searchLichdayBySubject
@MAMON NVARCHAR(30)
AS
BEGIN
	SELECT * FROM  LICHDAY 
	WHERE sMamon =  @MAMON
END
EXEC searchLichdayBySubject 'MNM'




SELECT distinct *  FROM LICHDAY LD, GIANGVIEN GV,MON M,LOP L,PHONG P,THOIGIAN TG
WHERE LD.sMamon=M.sMamon
AND LD.sMalop=L.sMalop
AND LD.sMagv=GV.sMagv
AND LD.sMap=P.sMap
AND LD.dNgayday=TG.dNgayday
GO
select * from THOIGIAN
WHERE dNgayday>='2021-09-06 06:45:00.000' AND dNgayday<='2021-09-6 12:45:00.000'


--4. Trigger không cho phép sửa mãMôn
GO
alter TRIGGER NonupdateMaMon
ON MOn
FOR Update
As
Begin
	If update(smamon)
		Begin
			RAISERROR('Không thể thay đổi mã môn',16,10)
			RollBack transaction 
		end
End
select * from PHONG


delete from phong where sMap ='P678'
update PHONG set sMap = 'p99999' where sChucnang = 'THINGHIEM'

--4. Trigger không cho phép sửa MaP
GO
alter TRIGGER UpdateMaP
ON PHONG
FOR Update
As
Begin
	If update(sMap)
		Begin
			--Print N'Không thể thay đổi sMAP'
			RAISERROR('Không thể thay đổi sMAP',16,10)
			RollBack transaction 
		end
End


	DECLARE @gt NVARCHAR(5)
	SELECT @gt = sGIOITINH from INSERTED
	IF ( @gt NOT IN ('Nam', N'Nữ') )
	BEGIN
	RAISERROR('Không thể thay đổi sMAP',16,10)
	ROLLBACK TRAN
	END



--TRUY VẤN:
--LD-MON: LICHDAY LD INNER JOIN MON M ON LD.sMamon=M.sMamon
--LD-LOP: LICHDAY LD INNER JOIN LOP L ON LD.sMalop=L.sMalop
--LD-GV: LICHDAY LD INNER JOIN GIANGVIEN GV ON LD.sMagv=GV.sMagv
--LD-PHONG: LICHDAY LD INNER JOIN PHONG P ON LD.sMap=P.sMap
--LD-TG: LICHDAY LD INNER JOIN THOIGIAN TG ON LD.dNgayday=TG.dNgayday
select * from LICHDAY
where sDiachi = N'Hà Nội'
go
create procedure getSL
as
select sDiachi,Count(sMagv) as soluong from GIANGVIEN 
group by sDiachi
--where sDiachi = N'Hà Nội'
update GIANGVIEN 
set sTengv = 'sda',
	sGioitinh = N'nữ',
	dNgaysinh = '2000-2-5',
	sDiachi = 'hn',
	sSdt = '939383388',
	sChucvu = 'gv'
	where sMagv = 'gv11'


insert into GIANGVIEN values('thu11', 'thu','nam','2000-3-2','thu','0876675656','thu')
go


delete from GiangVien where sMagv = 'thu11';
--**insert
CREATE PROC THEMMON
@MAMON NVARCHAR(30),
@TENMON NVARCHAR(30),
@SOTIN INT
AS
	IF EXISTS(SELECT sMamon FROM MON WHERE @MAMON=sMamon)
	BEGIN
		PRINT N'ĐÃ XẢY RA LỖI VUI LÒNG KIỂM TRA'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO MON(sMamon,sTenmon,iSotin) VALUES (@MAMON,@Tenmon,@SOTIN)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC THEMMON 'haha1','haha','5'


--**Update
CREATE PROC updatemon
@MAMON NVARCHAR(30),
@TENMON NVARCHAR(30),
@SOTIN INT
AS
BEGIN
UPDATE MON 
	SET sTenmon= @Tenmon, iSotin = @SOTIN 
	WHERE sMamon =  @MAMON
END



--**delete
alter PROC deletes
@MAMON NVARCHAR(30)
AS
BEGIN
	DELETE FROM  MON 
	WHERE sMamon =  @MAMON
END

--search
CREATE PROC search
@MAMON NVARCHAR(30)
AS
BEGIN
	SELECT * FROM  MON 
	WHERE sMamon =  @MAMON
END
EXEC search 'MNM'
GO

ALTER PROC sortBYObjectName

AS
BEGIN
	 SELECT * FROM mon
	 ORDER BY sTenmon ASC
END
GO
DROP TRIGGER THEMLICH
DROP PROC THEMLICH
---------------------------------------------------------------------------- lichday----------------------------------------------------------------------------------------
--**insert lichday
ALTER PROC Themlichday
@NGAYDAY DATETIME,
@MAGV NVARCHAR(30),
@MAMON NVARCHAR(30),
@MALOP NVARCHAR(30),
@MAP NVARCHAR(30),
@TRANGTHAI NVARCHAR(30),
@GHICHU NVARCHAR(30)
AS
	BEGIN		
		INSERT INTO LICHDAY(dNgayday,sMagv,sMamon, sMalop, sMap, sTrangthai, sGhichu) VALUES (@NGAYDAY,@MAGV,@MAMON, @MALOP,@MAP,@TRANGTHAI,@GHICHU)
	END
EXEC Themlichday '2021-9-8 06:45:00', 'GV8', 'SQL' , 'AAST5HTT41', 'P33', N'Nghỉ' , 'HAHAAHA'


--**Update lichday by magv
CREATE PROC updatelichday
@NGAYDAY DATETIME,
@MAGV NVARCHAR(30),
@MAMON NVARCHAR(30),
@MALOP NVARCHAR(30),
@MAP NVARCHAR(30),
@TRANGTHAI NVARCHAR(30),
@GHICHU NVARCHAR(30)
AS
BEGIN
	UPDATE LICHDAY 
	SET dngayday= @NGAYDAY, sMagv = @MAGV,sMamon = @MAMON, sMalop = @MALOP, sMap = @MAP, sTrangthai =@TRANGTHAI, sGhichu = @GHICHU
	WHERE sMagv = @MAGV
END

--**delete lichday by ngayday
create PROC deletelichday
@NGAYDAY datetime
AS
BEGIN
	DELETE FROM  LICHDAY 
	WHERE dNgayday =  @NGAYDAY
END
exec deletelichday '2021-09-20 06:45:00.000'

--search  lichday by mon
CREATE PROC searchLichdayBySubject
@MAMON NVARCHAR(30)
AS
BEGIN
	SELECT * FROM  LICHDAY 
	WHERE sMamon =  @MAMON
END
EXEC searchLichdayBySubject 'MNM'
GO
--sort ngayday in lichday by decrease
ALTER PROC sortBYObjectName
AS
BEGIN
	 SELECT * FROM LICHDAY
	 ORDER BY dNgayday DESC
END
GO

select * from GIANGVIEN
where sTengv like '%X%'



SELECT distinct *  FROM LICHDAY LD, GIANGVIEN GV,MON M,LOP L,PHONG P,THOIGIAN TG
WHERE LD.sMamon=M.sMamon
AND LD.sMalop=L.sMalop
AND LD.sMagv=GV.sMagv
AND LD.sMap=P.sMap
AND LD.dNgayday=TG.dNgayday
GO
--I. VIEW
--1. Lấy Thông Tin Giảng Viên Có Giới Tính Nữ 
CREATE VIEW GT
AS 
	SELECT *FROM GIANGVIEN
	WHERE sGioitinh=N'Nữ'
GO
SELECT * FROM GT 
--2. Lấy Tên Sinh Viên Dạy Tiếng Anh Chuyên Ngành Và Địa Chỉ Tại Hà Nội
CREATE VIEW QUE_MON
AS
	SELECT DISTINCT sTengv FROM GIANGVIEN GV  
INNER JOIN LICHDAY LD ON GV.sMaGV=LD.sMagv
	INNER JOIN MON M ON LD.sMamON=M.sMamON
	WHERE sDiachi=N'Hà Nội' 
and sTenmON=N'tiếng anh chuyên ngành'

GO
--3. Lấy Thông Tin Sinh Viên Sinh Năm 1980
CREATE VIEW NS_1980
AS
	SELECT * FROM GIANGVIEN
	WHERE YEAR(dNgaysinh)=1980 
GO
--4. 	Lấy Thông Tin Giảng Viên Có Độ Tuổi Lớn Hơn 40
CREATE VIEW TUOI40
AS
	SELECT sTengv,dNgaysinh, sChucvu
	FROM GIANGVIEN
	WHERE YEAR(GETDATE()) - YEAR( dNgaysinh) > 40

GO
--PROC
--1.Thủ tục đếm  gv nam và gv nữ VÀ TỔNG CẢ 2
CREATE  PROC spDemNhanvien
@Nam INT OUTPUT,
@Nu INT OUTPUT
AS
	SET @Nam=0
	SET @Nu=0
	SELECT @Nam=COUNT(*)	FROM  GIANGVIEN
	WHERE sGioitinh='Nam';
	SELECT @Nu=COUNT(*)	FROM  GIANGVIEN
	WHERE sGioitinh=N'Nữ';
	RETURN @NAM+@NU --Tổng số nhân viên
DECLARE @H INT, @M INT, @T INT  
EXEC @T= spDemNhanvien 
@NAM=@H OUTPUT, 
@NU=@M OUTPUT
SELECT @H AS [Nam], @M AS [Nữ], @T AS [Tổng]
GO

--1. way 1(A FEW RIGHT )
CREATE PROC TUOICAONHAT
@TCAONHAT INT OUTPUT,
@TENGV NVARCHAR(20) OUTPUT
AS
	SELECT ALL @TENGV=STENGV,@TCAONHAT=YEAR(GETDATE())-YEAR(dNgaysinh)  FROM GIANGVIEN
	WHERE YEAR(GETDATE())-YEAR(dNgaysinh)>=ALL(SELECT YEAR(GETDATE())-YEAR(dNgaysinh) FROM GIANGVIEN)

DECLARE @TC INT,@TGV NVARCHAR(20) 
EXEC TUOICAONHAT 
@TCAONHAT=@TC OUTPUT,@TENGV=@TGV OUTPUT
SELECT @TGV AS TEN,@TC AS TUOICAONHAT
GO

--way 2(right but not paragmeter output)
CREATE PROC ABC
AS
	SELECT ALL STENGV,YEAR(GETDATE())-YEAR(dNgaysinh) tuoicao1  FROM GIANGVIEN
	WHERE YEAR(GETDATE())-YEAR(dNgaysinh)>=ALL(SELECT YEAR(GETDATE())-YEAR(dNgaysinh) FROM GIANGVIEN)
	--@maxtuoi = max(year(getdate())-year(DNgaySinh)) --slide
GO
--way 3(no right a lot)
CREATE VIEW VI_TUOICAONHAT
AS
	SELECT STENGV TENGV,YEAR(GETDATE())-YEAR(dNgaysinh) TUOI  FROM GIANGVIEN 
GO
CREATE PROC PROTUOICao1
@TENGV NVARCHAR(30) OUTPUT,
@TUOI INT OUTPUT
AS 
	SELECT ALL  @TENGV=TENGV,@TUOI=TUOI  FROM VI_TUOICAONHAT
	WHERE TUOI>=ALL (SELECT TUOI FROM VI_TUOICAONHAT)
DECLARE @PROTENGV NVARCHAR(30), @TC1  INT
EXEC PROTUOICao1 @TENGV=@PROTENGV OUTPUT,@TUOI=@TC1 OUTPUT
SELECT @PROTENGV AS TENGV, @TC1 AS TUOICAO1
GO

--3: Thêm môn nếu có môn đó rồi thì báo lỗi
CREATE PROC THEMMON
@MAMON NVARCHAR(30),
@TENMON NVARCHAR(30),
@SOTIN INT
AS
	IF EXISTS(SELECT sMamon FROM MON WHERE @MAMON=sMamon)
	BEGIN
		PRINT N'ĐÃ XẢY RA LỖI VUI LÒNG KIỂM TRA'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO MON(sMamon,sTenmon,iSotin) VALUES (@MAMON,@Tenmon,@SOTIN)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC THEMMON 'C','@Tenmon','5'

GO
--4: Thêm phòng nếu có phòng đó thì báo lỗi
CREATE PROC THEMPHONG
@MAP NVARCHAR(30),
@CHUCNANG NVARCHAR(30)
AS
	IF EXISTS(SELECT sMap FROM PHONG WHERE @MAP=sMap)
	BEGIN
		PRINT N'ĐÃ XẢY RA LỖI VUI LÒNG KIỂM TRA'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO PHONG(sMap,sChucnang) VALUES (@MAP,@CHUCNANG)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC THEMPHONG 'IQEM','THU NGHIEM'
GO
--5: thêm 1 gv vào lichday nếu không có gv đó thì báo lỗi
CREATE PROC THEMGVVAOLD
@NGAYDAY DATETIME,
@MAGV NVARCHAR(30),
@MAMON NVARCHAR(30),
@MALOP NVARCHAR(30),
@MAP NVARCHAR(30),
@TRANGTHAI NVARCHAR(30),
@GHICHU NVARCHAR(30)
AS
	IF NOT EXISTS(SELECT sMagv FROM GIANGVIEN WHERE @MAGV=sMagv)
	BEGIN
		PRINT N'ĐÃ XẢY RA LỖI VUI LÒNG KIỂM TRA'
		RETURN 
	END
	ELSE
	BEGIN		
		INSERT INTO LICHDAY VALUES (@NGAYDAY,@MAGV,@MAMON,@MALOP,@MAP,@TRANGTHAI,@GHICHU)
		PRINT N'NHẬP THÀNH CÔNG'
	END
EXEC THEMGVVAOLD '2021-9-13 06:45:00', 'GV4', 'SQL', 'AAST6DSQL23', 'P23', N'Học' ,  N'THUNGHIEM'

DROP PROC LICHDAYNGAY16_9

--TRIGGER

--1. GIỚI TÍNH GIẢNG VIÊN CHỈ ĐƯỢC LÀ NAM HOẶC NỮ
CREATE TRIGGER GV_GT
ON GIANGVIEN
AFTER INSERT
As
BEGIN
	DECLARE @gt NVARCHAR(5)
	SELECT @gt = sGIOITINH from INSERTED
	IF ( @gt NOT IN ('Nam', N'Nữ') )
	BEGIN
	RAISERROR('Ban nhap sai Gioi tinh',16,10)
	ROLLBACK TRAN
	END
END
GO
INSERT INTO GIANGVIEN VALUES('ASDD', 'ÁDAS', 'DASDAS','2010-4-6','WER','DSFSDF','FSDF')
GO


-- 2. Trigger kiểm tra một LOP có tồn tại hay không trước khi thêm cho một LICHDAY()
CREATE TRIGGER TKTRLOP
ON LICHDAY
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @MALOP NVARCHAR(20)
	SELECT SMALOP=@MALOP FROM INSERTED
	IF (@MALOP NOT IN( SELECT sMALOP FROM LOP WHERE @MALOP=SMALOP))
	BEGIN
		Raiserror('LOP K TON TAI VUI LONG NHAP LAI, VUI LONG NHAP LAI', 16,10)
		ROLLBACK TRAN
	END
END

 DROP TRIGGER TKTRLOP
 GO
 --3. Trigger Xóa một LOP thì xóa các LICHDAY tương ứng
CREATE TRIGGER XoaLOP
ON LOP
AFTER Delete
AS
BEGIN
	DECLARE @MaLOP nvarchar(9)
	SELECT @MaLOP = SMALOP FROM DELETED
	IF EXISTS( SELECT * FROM LICHDAY WHERE @MaLOP = SMALOP)
	BEGIN
		DELETE FROM LICHDAY
		WHERE  @MaLOP = SMALOP
	END
END
--4. Trigger không cho phép sửa MaP
GO
CREATE TRIGGER UpdateMaP
ON PHONG
FOR Update
As
Begin
	If update(sMap)
		Begin
			Print N'Không thể thay đổi sMAP'
			RollBack transaction 
		end
End
GO
--5. Cập nhật mã LOP thì LICHDAY cập nhật theo
CREATE TRIGGER UpdateLOP
ON LOP
FOR UPDATE
AS
BEGIN
	IF UPDATE( smalop )
		BEGIN
			DECLARE @MaLopCu nvarchar(9), @MaLopMoi nvarchar(9)
			SELECT @MaLopCu = sMalop FROM DELETED
			SELECT @MaLopMoi = sMalop FROM INSERTED
	If (EXISTS (select sMalop from LICHDAY Where sMalop=@MaLopCu) )
	      BEGIN
			UPDATE LICHDAY SET sMalop = @MaLopMoi
			WHERE sMalop = @MaLopCu
		  END
		END
END
GO
--6. Chỉ có 1 mã lớp duy nhất trong mỗi lịch dạy
CREATE TRIGGER MALOPDUYNHAT
ON LICHDAY
INSTEAD OF INSERT
AS
BEGIN

	DECLARE @MALOP NVARCHAR(20)
	SELECT @MALOP=sMalop FROM INSERTED
	IF EXISTS(SELECT sMalop FROM LICHDAY WHERE sMalop=@MALOP)
		BEGIN
			RAISERROR(N'Mã lớp đã tồn tại',16,10)
			ROLLBACK TRAN
		END
END
GO