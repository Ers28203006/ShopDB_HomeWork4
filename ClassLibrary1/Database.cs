using System;
using System.Data;

namespace ShopDB.DataAccess
{
    public class Database
    {
        public static void InstanceDB()
        {
            DataSet ShopDB = new DataSet("ShopDB");
            DataTable Orders = new DataTable("Orders");
            DataTable Customers = new DataTable("Customers");
            DataTable Employees = new DataTable("Employees");
            DataTable OrderDetails = new DataTable("OrderDetails");
            DataTable Products = new DataTable("Products");

            InitOrder(ref Orders);
            InitCustomers(ref Customers);
            InitEmployees(ref Employees);
            InitOrderDetails(ref OrderDetails);
            InitProducts(ref Products);

            ForeignKeyConstraint FK_Order_OrderDetails = new ForeignKeyConstraint(OrderDetails.Columns["id"], Orders.Columns["orderDetailsId"]);
            ForeignKeyConstraint FK_OrderDetails_Product = new ForeignKeyConstraint(Products.Columns["id"], OrderDetails.Columns["productId"]);
            ForeignKeyConstraint FK_OrderDetails_Customers = new ForeignKeyConstraint(Customers.Columns["id"], OrderDetails.Columns["customersId"]);
            ForeignKeyConstraint FK_OrderDetails_Employees = new ForeignKeyConstraint(Employees.Columns["id"], OrderDetails.Columns["employeesId"]);

            ShopDB.Tables.AddRange
            (
                new DataTable[]
                {
                    Orders, Customers, Employees, OrderDetails, Products
                }
            );
        }
        #region Инициализация таблиц  
        public static void InitOrder(ref DataTable orders)
        {
            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "идентификатор";
            id.AllowDBNull = false;
            id.Unique = true;
            id.ReadOnly = true;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            DataColumn orderDetailsId = new DataColumn("orderDetailsId", typeof(int))
            {
                Caption = "Id деталей товара",
                AllowDBNull = false,
            };

            orders.Columns.AddRange
            (
                new DataColumn[]
                {
                    id, orderDetailsId
                }
            );

            orders.PrimaryKey = new DataColumn[] { orders.Columns[0] };
        }

        public static void InitCustomers(ref DataTable customers)
        {
            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "идентификатор";
            id.AllowDBNull = false;
            id.Unique = true;
            id.ReadOnly = true;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            DataColumn name = new DataColumn("name", typeof(string));
            name.Caption = "Имя";
            name.AllowDBNull = false;
            name.MaxLength = 20;

            DataColumn surname = new DataColumn("surname", typeof(string));
            surname.Caption = "Фамилия";
            surname.AllowDBNull = false;
            surname.MaxLength = 20;

            customers.Columns.AddRange
            (
                new DataColumn[]
                {
                    id, name, surname
                }
            );
            customers.PrimaryKey = new DataColumn[] { customers.Columns[0] };

        }

        public static void InitEmployees(ref DataTable employees)
        {
            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "идентификатор";
            id.AllowDBNull = false;
            id.Unique = true;
            id.ReadOnly = true;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            DataColumn name = new DataColumn("name", typeof(string));
            name.Caption = "Имя";
            name.AllowDBNull = false;
            name.MaxLength = 20;

            DataColumn surname = new DataColumn("surname", typeof(string));
            surname.Caption = "Фамилия";
            surname.AllowDBNull = false;
            surname.MaxLength = 20;

            employees.Columns.AddRange
            (
                new DataColumn[]
                {
                    id, name, surname
                }
            );

            employees.PrimaryKey = new DataColumn[] { employees.Columns[0] };

        }

        public static void InitOrderDetails(ref DataTable orderDetails)
        {
            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "идентификатор";
            id.AllowDBNull = false;
            id.Unique = true;
            id.ReadOnly = true;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            DataColumn price = new DataColumn("price", typeof(double))
            {
                Caption = "Цена за единицу",
                AllowDBNull = false
            };

            DataColumn orderDate = new DataColumn("orderDate", typeof(DateTime))
            {
                Caption = "Дата заказа",
                AllowDBNull=false
            };

            DataColumn productId = new DataColumn("productId", typeof(int))
            {
                Caption="Id товара",
                AllowDBNull=false,
            };

            DataColumn customersId = new DataColumn("customersId", typeof(int))
            {
                Caption = "Id клиентa",
                AllowDBNull = false,
            };

            DataColumn employeesId = new DataColumn("employeesId", typeof(int))
            {
                Caption = "Id работника",
                AllowDBNull = false,
            };

            orderDetails.Columns.AddRange
           (
               new DataColumn[]
               {
                    id, price, orderDate,productId, customersId, employeesId
               }
           );
            orderDetails.PrimaryKey = new DataColumn[] { orderDetails.Columns[0] };
        }
        public static void InitProducts(ref DataTable products)
        {
            DataColumn id = new DataColumn("id", typeof(int));
            id.Caption = "идентификатор";
            id.AllowDBNull = false;
            id.Unique = true;
            id.ReadOnly = true;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            DataColumn productName = new DataColumn("productName", typeof(string));
            productName.Caption = "Наименование продукта";
            productName.AllowDBNull = false;
            productName.MaxLength = 30;

            products.Columns.AddRange
            (
                new DataColumn[]
                {
                    id, productName
                }
            );
            products.PrimaryKey = new DataColumn[] { products.Columns[0] };
        }
        #endregion
    }
}
