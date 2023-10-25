create database QLKH
on
(
	name = qlkh_data,
	filename = 'E:\HK1_Nam3\PTTK HTTH\SQL\qlkh_data.mdf'
)
log on
(
	name = qlkh_log,
	filename = 'E:\HK1_Nam3\PTTK HTTH\SQL\qlkh_data.ldf'
)
use QLKH
select dtt.TENSP
from DONTHANHTOAN dtt
join KIEMTRA kt on kt.MATT = dtt.MATT
join DONDATHANG ddh on ddh.MA_DATHANG = kt.MA_DATHANG
where dtt.SOLUONG = ddh.SOLUONG