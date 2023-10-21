create database QLKH
on
(
	name = qlkh_data,
	filename = 'E:\HK1_Nam3\PTTK HTTH\BaoCao_PTTK_HTTT\SQL\qlkh_data.mdf'
)
log on
(
	name = qlkh_log,
	filename = 'E:\HK1_Nam3\PTTK HTTH\BaoCao_PTTK_HTTT\SQL\qlkh_data.ldf'
)

select s. as tensp
from SHELF s
join PUT p on p.SHELF_ID = s.SHELF_ID
join PRODUCT pd on pd.PRODUCT_ID = p.PRODUCT_ID