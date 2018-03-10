select Barcode, ProductName, Weight, TotalUnits, UnitPriceToSell, ReorderLevel  from Products

update Products set TotalUnits=TotalUnits-1 where Barcode='4443'