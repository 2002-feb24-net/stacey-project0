exec dbo.spOrders_GetDetails 1002

exec dbo.spCustomer_GetByFullName 'Stacey','Joseph'

exec dbo.spOrders_GetAllByStore 1

exec dbo.spCustomers_DisplayOrdersByID

exec dbo.spCustomers_AddNew

exec dbo.spOrders_PlaceToStoreForCustomer @productqty = 4