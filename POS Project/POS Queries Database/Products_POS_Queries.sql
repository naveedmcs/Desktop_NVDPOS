-- Fetching data From Three Tables
select *
       from Products as p

       LEFT JOIN Categories as c
       ON c.CategoryID = p.CategoryID_FK
       LEFT Join Suppliers as s
       ON s.SupplierID = p.SupplierID_FK

