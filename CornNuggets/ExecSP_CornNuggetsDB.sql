exec dbo.spOrders_GetDetails 1002

exec dbo.spCustomer_GetByFullName 'Stacey','Joseph'

exec dbo.spOrders_GetAllByStore 1

exec dbo.spCustomers_DisplayOrdersByID 100000005

exec dbo.spCustomers_AddNew 'New', 'Customer', 'TEXA002'

exec dbo.spOrders_PlaceToStoreForCustomer @productqty = 4