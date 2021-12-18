using Microsoft.EntityFrameworkCore;


namespace OnlineBookstore.Entities
{
    public class OnlineBookstoreDBInitializer
    {
        private readonly OnlineBookstoreDbContext _dbContext;

        public OnlineBookstoreDBInitializer(OnlineBookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
                if (!_dbContext.Roles.Any())
                {
                    _dbContext.Roles.AddRange(GetRoles());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Warehouses.Any())
                {
                    _dbContext.Warehouses.AddRange(GetWarehouses());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.OrderStatuses.Any())
                {
                    _dbContext.OrderStatuses.AddRange(GetOrderStatuses());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Books.Any())
                {
                    _dbContext.Books.AddRange(GetBooks());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    _dbContext.Categories.AddRange(GetCategories());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.BookCategories.Any())
                {
                    _dbContext.BookCategories.AddRange(GetBookCategories());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Authors.Any())
                {
                    _dbContext.Authors.AddRange(GetAuthors());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.AuthorBooks.Any())
                {
                    _dbContext.AuthorBooks.AddRange(GetAuthorBooks());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Customers.Any())
                {
                    _dbContext.Customers.AddRange(GetCustomers());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Publishers.Any())
                {
                    _dbContext.Publishers.AddRange(GetPublishers());
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.ShoppingBaskets.Any())
                {
                    _dbContext.ShoppingBaskets.AddRange(GetShoppingBaskets());
                    _dbContext.SaveChanges();
                }
                //if (!_dbContext.InstanceBooks.Any())
                //{
                //    _dbContext.InstanceBooks.AddRange(GetInstanceBooks());
                //    _dbContext.SaveChanges();
                //}
                //if (!_dbContext.Orders.Any())
                //{
                //    _dbContext.Orders.AddRange(GetOrders());
                //    _dbContext.SaveChanges();
                //}

            }
        }
        private ICollection<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name ="Admin"
                },
                new Role()
                {
                    Name="Customer"
                }

            };
            return roles;
        }
        private ICollection<Warehouse> GetWarehouses()
        {
            var warehosues = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Name="MagazynA",
                    Address=new Address()
                    {
                        City="Rzeszów",
                        Street="Konopnickiej",
                        AddressLine="12 A",
                        PostalCode="34-309"
                    }
                },
                new Warehouse()
                {
                    Name="MagazynB",
                    Address=new Address()
                    {
                        City="Kraków",
                        Street="Warszwska",
                        AddressLine="42 C",
                        PostalCode="04-218"
                    }
                },
                  new Warehouse()
                {
                    Name="MagazynC",
                    Address=new Address()
                    {
                        City="Gdańsk",
                        Street="Portowa",
                        AddressLine="142 V",
                        PostalCode="80-007"
                    }
                },

            };
            return warehosues;
        }

        private ICollection<OrderStatus> GetOrderStatuses()
        {
            var statuses = new List<OrderStatus>()
            {
                new OrderStatus()
                {
                    NameStatus="Oczekuje na potwierdzenie"
                },
                 new OrderStatus()
                {
                    NameStatus="W realizacji"
                },
                 new OrderStatus()
                 {
                     NameStatus="W drodze"
                 },
                 new OrderStatus()
                 {
                     NameStatus="Zrealizowane"
                 }

            };
            return statuses;
        }

        private ICollection<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Pan Tadeusz",
                    Language = "pl"
                },
                   new Book()
                {
                    Title = "Batman",
                    Language = "pl"
                },
                      new Book()
                {
                    Title = "SpiderMan",
                    Language = "en"
                },
                new Book()
                {
                    Title = "Star Wars",
                    Language = "de"
                },
                new Book()
                {
                    Title = "Star Trek",
                    Language = "pl"
                }
            };
            return books;
        }
        private ICollection<Category> GetCategories()
        {
            return new List<Category>(){
                new Category()
                {
                    Name="Fantasytka"
                },
                 new Category()
                {
                    Name="Przygodowe"
                },
                  new Category()
                {
                    Name="Komedia"
                },
                   new Category()
                {
                    Name="Kryminał"
                },
                    new Category()
                {
                    Name="Horror"
                },
                     new Category()
                {
                    Name="Dramat"
                },
            };
        }

        private ICollection<BookCategory> GetBookCategories()
        {
            return new List<BookCategory>()
            {
                new BookCategory(){BookId=1,CategoryId=2},
                new BookCategory(){BookId=1,CategoryId=3},
                new BookCategory(){BookId=2,CategoryId=6},
                new BookCategory(){BookId=3,CategoryId=4},
                new BookCategory(){BookId=3,CategoryId=2},
                new BookCategory(){BookId=3,CategoryId=1},
                new BookCategory(){BookId=4,CategoryId=3},
                new BookCategory(){BookId=4,CategoryId=4},
                new BookCategory(){BookId=5,CategoryId=6},
                new BookCategory(){BookId=5,CategoryId=2},
                new BookCategory(){BookId=5,CategoryId=1},
                new BookCategory(){BookId=5,CategoryId=3}            
            };
           
        }       

        private ICollection<Author> GetAuthors()
        {
            return new List<Author>()
            {
                new Author()
                {
                    FirstName="Jan",
                    LastName="Anonim"
                },
                 new Author()
                {
                    FirstName="Piotr",
                    LastName="Skrol"
                },
                  new Author()
                {
                    FirstName="Kordian",
                    LastName="Placek"
                },
                   new Author()
                {
                    FirstName="Krystyna",
                    LastName="Tran"
                },
                    new Author()
                {
                    FirstName="Dominik",
                    LastName="Dron"
                },
                     new Author()
                {
                    FirstName="Krzysztof",
                    LastName="Trol"
                },

            };
        }

        private ICollection<AuthorBook> GetAuthorBooks()
        {
            return new List<AuthorBook>()
            {
                new AuthorBook(){AuthorID=4,BookId=1},
                new AuthorBook(){AuthorID=3,BookId=1},
                new AuthorBook(){AuthorID=6,BookId=1},
                new AuthorBook(){AuthorID=3,BookId=2},
                new AuthorBook(){AuthorID=5,BookId=2},
                new AuthorBook(){AuthorID=4,BookId=3},
                new AuthorBook(){AuthorID=2,BookId=3},
                new AuthorBook(){AuthorID=6,BookId=4},
                new AuthorBook(){AuthorID=1,BookId=4},
                new AuthorBook(){AuthorID=1,BookId=5},
                new AuthorBook(){AuthorID=3,BookId=5},
                new AuthorBook(){AuthorID=4,BookId=5}            
            };
        }

        private ICollection<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                    {
                        FisrtName="Jan",
                        LastName="Kowalski",
                        Email="jan@example.com",
                        Nationality="Polska",
                        Phone="555333777",
                        DateOfBirth=DateTime.Now.AddYears(-Random.Shared.Next(20,50)).AddDays(Random.Shared.Next(10,340)),
                        RoleId=2,
                        PasswordHash="1234",
                        Address=new Address()
                        {
                            City="Rzeszów",
                            Street="L.Siemańskiego",
                            AddressLine="1/21",
                            PostalCode="34-309"
                        }
                    },
                  new Customer()
                    {
                        FisrtName="Adrian",
                        LastName="Twardowski",
                        Email="adi@example.com",
                        Nationality="Polska",
                        Phone="555333722",
                        DateOfBirth=DateTime.Now.AddYears(-Random.Shared.Next(20,50)).AddDays(Random.Shared.Next(10,340)),
                        RoleId=2,
                        PasswordHash="1234",
                        Address=new Address()
                        {
                            City="Rzeszów",
                            Street="Konponickiej",
                            AddressLine="40A",
                            PostalCode="34-309"
                        }
                    },
                    new Customer()
                    {
                        FisrtName="Aldona",
                        LastName="Wiert",
                        Email="aldona@example.com",
                        Nationality="Polska",
                        Phone="552613777",
                        DateOfBirth=DateTime.Now.AddYears(-Random.Shared.Next(20,50)).AddDays(Random.Shared.Next(10,340)),
                        RoleId=2,
                        PasswordHash="1234",
                        Address=new Address()
                        {
                            City="Rzeszów",
                            Street="Korczaka",
                            AddressLine="52C",
                            PostalCode="34-309"
                        }
                    },
            };
        }

        private ICollection<Publisher> GetPublishers()
        {
            return new List<Publisher>()
            {
                new Publisher()
                {
                    Name="AgentReklama",
                    Email="agent@reklama",
                    Phone="222333111",
                    Url=""
                },
                 new Publisher()
                {
                    Name="NowoczesnyDesign",
                    Email="design@reklama",
                    Phone="2223345211",
                    Url=""
                },
                  new Publisher()
                {
                    Name="TorandoSpace",
                    Email="tspace@reklama",
                    Phone="222366111",
                    Url=""
                },
            };
        }

        private ICollection<ShoppingBasket> GetShoppingBaskets()
        {
            return new List<ShoppingBasket>()
            {
                new ShoppingBasket(){},
                new ShoppingBasket(){},
                new ShoppingBasket(){},
                new ShoppingBasket(){},
                new ShoppingBasket(){},
                new ShoppingBasket(){},
                new ShoppingBasket(){}                
            };
        }

        private ICollection<InstanceBook> GetInstanceBooks()
        {
            return new List<InstanceBook>()
            {
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=1,
                    WarehouseId=1,
                    PublisherId=1
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=1,
                    WarehouseId=1,
                    PublisherId=2
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=1,
                    WarehouseId=2,
                    PublisherId=1
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=2,
                    WarehouseId=3,
                    PublisherId=3
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=2,
                    WarehouseId=3,
                    PublisherId=1
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=2,
                    WarehouseId=3,
                    PublisherId=2
                },
                new InstanceBook()
                {
                    ISBN=new Guid().ToString(),
                    ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(400,4000)),
                    Price=(decimal)Random.Shared.NextDouble()*10,
                    CoverUrl="",
                    BookId=4,
                    WarehouseId=1,
                    PublisherId=1
                }
            };
        }

        //private ICollection<Order> GetOrders()
        //{
        //    return new List<Order>()
        //    {
        //        new Order()
        //        {
        //            Id = 1,
        //            DateOrder=DateTime.Now.AddDays(-Random.Shared.Next(5,20)),
        //            DateFinish=null,
        //            OrderStatusId=1,
        //            Customer=new Customer()
        //            {
        //                FisrtName="Jan",
        //                LastName="Kowalski",
        //                Email="jan@example.com",
        //                Nationality="Polska",
        //                Phone="555333777",
        //                DateOfBirth=DateTime.Now.AddYears(-Random.Shared.Next(20,50)).AddDays(Random.Shared.Next(10,340)),
        //                RoleId=2,
        //                PasswordHash="1234",
        //                Address=new Address()
        //                {
        //                    City="Rzeszów",
        //                    Street="L.Siemańskiego",
        //                    AddressLine="1/21",
        //                    PostalCode="34-309"
        //                }
        //            },
        //            ShoppingBasket=new ShoppingBasket()
        //            {
        //                InstanceBooks=new List<InstanceBook>()
        //                {
        //                   new InstanceBook()
        //                   {
        //                       ISBN=new Guid().ToString(),
        //                       ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(10,4000)),
        //                       Price=(decimal)Random.Shared.NextDouble()*10,
        //                       CoverUrl="",
        //                       BookId=1,
        //                       WarehouseId=1,
        //                       Publisher=new Publisher()
        //                       {
        //                           Name="AgentReklama",
        //                           Email="agent@example.com",
        //                           Phone="555222111",
        //                           Url=""
        //                       }
        //                   }
        //                }
        //            }
                    

        //        },
        //         new Order()
        //        {
        //            Id = 1,
        //            DateOrder=DateTime.Now.AddDays(-Random.Shared.Next(5,20)),
        //            DateFinish=null,
        //            OrderStatusId=1,
        //            Customer=new Customer()
        //            {
        //                FisrtName="Adrian",
        //                LastName="Dratkowski",
        //                Email="adi@example.com",
        //                Nationality="Polska",
        //                Phone="555333778",
        //                DateOfBirth=DateTime.Now.AddYears(-Random.Shared.Next(20,50)).AddDays(Random.Shared.Next(10,340)),
        //                RoleId=2,
        //                PasswordHash="1234",
        //                Address=new Address()
        //                {
        //                    City="Rzeszów",
        //                    Street="L.Siemańskiego",
        //                    AddressLine="1/21",
        //                    PostalCode="34-309"
        //                }
        //            },
        //            ShoppingBasket=new ShoppingBasket()
        //            {
        //                InstanceBooks=new List<InstanceBook>()
        //                {
        //                   new InstanceBook()
        //                   {
        //                       ISBN=new Guid().ToString(),
        //                       ReleaseDate=DateTime.Now.AddDays(-Random.Shared.Next(10,4000)),
        //                       Price=(decimal)Random.Shared.NextDouble()*10,
        //                       CoverUrl="",
        //                       BookId=1,
        //                       WarehouseId=1,
        //                       Publisher=new Publisher()
        //                       {
        //                           Name="AgentTran",
        //                           Email="agentT@example.com",
        //                           Phone="555225111",
        //                           Url=""
        //                       }
        //                   }
        //                }
        //            }


        //        }
        //    };
        //}

    }
}
