exec dbo.spCustomers_AddNew 'Old', 'Yeller', 'TEXA003'

exec dbo.spOrders_GetDetails 1025

exec dbo.spCustomer_GetByFullName 'Stacey','Joseph'

exec dbo.spOrders_GetAllByStore 18

exec dbo.spCustomers_DisplayOrdersByID 100000006

exec dbo.spOrders_PlaceToStoreForCustomer @productqty = 5