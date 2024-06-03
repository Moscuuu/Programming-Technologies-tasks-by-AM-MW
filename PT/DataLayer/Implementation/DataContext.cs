using DataLayer.API;
using DataLayer.Instrumentation;

namespace DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        public DataContext(string? connectionString = null)
        {
            this.ConnectionString = connectionString;
        }

        private readonly string ConnectionString;



        public async Task AddUser(IUser user)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User entity = new Instrumentation.User()
                {
                    Id = user.id,
                    FirstName = user.firstName,
                    LastName = user.lastName,
                };

                context.Users.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IUser?> GetUserAsyncQuerySyntax(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User? user = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.User> query =
                        from u in context.Users
                        where u.Id == id
                        select u;

                    return query.FirstOrDefault();
                });

                return user is not null ? new User(user.Id, user.FirstName, user.LastName) : null;
            }
        }

        public async Task<IUser?> GetUserAsyncMethodSyntax(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User? user = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.User> query = context.Users.Where(u => u.Id == id);

                    return query.FirstOrDefault();
                });

                return user is not null ? new User(user.Id, user.FirstName, user.LastName) : null;
            }
        }

        public async Task UpdateUser(IUser user)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User toUpdate = (from u in context.Users where u.Id == user.id select u).FirstOrDefault()!;

                toUpdate.Id = user.id;
                toUpdate.FirstName = user.firstName;
                toUpdate.LastName = user.lastName;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteUser(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User toDelete = (from u in context.Users where u.Id == id select u).FirstOrDefault()!;

                context.Users.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IUser>> GetAllUsers()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IUser> usersQuery = from u in context.Users
                                               select
                                                   new User(u.Id, u.FirstName, u.LastName) as IUser;

                return await Task.Run(() => usersQuery.ToDictionary(k => k.id));
            }
        }

        public async Task<int> GetUsersCount()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Users.Count());
            }
        }




        public async Task AddProduct(IProduct product)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product entity = new Instrumentation.Product()
                {
                    Id = product.id,
                    ProductName = product.productName,
                    ProductDescription = product.productDescription,
                    Price = product.price,
                };

                context.Products.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IProduct?> GetProduct(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product? product = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Product> query =
                        from p in context.Products
                        where p.Id == id
                        select p;

                    return query.FirstOrDefault();
                });

                return product is not null ? new Product(product.Id, product.ProductName, product.ProductDescription, (float)product.Price) : null;
            }
        }

        public async Task UpdateProduct(IProduct product)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product toUpdate = (from p in context.Products where p.Id == product.id select p).FirstOrDefault()!;

                toUpdate.ProductName = product.productName;
                toUpdate.ProductDescription = product.productDescription;
                toUpdate.Price = product.price;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product toDelete = (from p in context.Products where p.Id == id select p).FirstOrDefault()!;

                context.Products.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IProduct>> GetAllProducts()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IProduct> productQuery = from p in context.Products
                                                    select
                                                        new Product(p.Id, p.ProductName, p.ProductDescription, (float)p.Price) as IProduct;

                return await Task.Run(() => productQuery.ToDictionary(k => k.id));
            }
        }

        public async Task<int> GetProductsCount()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Products.Count());
            }
        }




        public async Task AddState(IState state)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State entity = new Instrumentation.State()
                {
                    StateId = state.stateId,
                    ProductId = state.productId,
                    Availavle = state.available,
                };

                context.States.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IState?> GetState(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State? state = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.State> query =
                        from s in context.States
                        where s.StateId == id
                        select s;

                    return query.FirstOrDefault();
                });

                return state is not null ? new State(state.StateId, state.ProductId, state.Availavle) : null;
            }
        }

        public async Task UpdateState(IState state)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State toUpdate = (from s in context.States where s.StateId == state.stateId select s).FirstOrDefault()!;

                toUpdate.ProductId = state.productId;
                toUpdate.Availavle = state.available;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteState(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State toDelete = (from s in context.States where s.StateId == id select s).FirstOrDefault()!;

                context.States.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IState>> GetAllStates()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IState> stateQuery = from s in context.States
                                                select
                                                    new State(s.StateId, s.ProductId, s.Availavle) as IState;

                return await Task.Run(() => stateQuery.ToDictionary(k => k.stateId));
            }
        }

        public async Task<int> GetStatesCount()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.States.Count());
            }
        }




        public async Task AddEvent(IEvent e)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event entity = new Instrumentation.Event()
                {
                    Id = e.eventId,
                    StateId = e.stateId,
                    UserId = e.userId,
                    EventDate = e.eventDate,
                    Type = e.type

                };

                context.Events.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IEvent?> GetEvent(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event? even = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Event> query =
                        from e in context.Events
                        where e.Id == id
                        select e;

                    return query.FirstOrDefault();
                });

                return even is not null ? new Event(even.Id, even.StateId, even.UserId, even.Type) : null;
            }

        }

        public async Task UpdateEvent(IEvent even)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event toUpdate = (from e in context.Events where e.Id == even.eventId select e).FirstOrDefault()!;

                toUpdate.StateId = even.stateId;
                toUpdate.UserId = even.userId;
                toUpdate.Id = even.eventId;
                toUpdate.Type = even.type;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteEvent(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event toDelete = (from e in context.Events where e.Id == id select e).FirstOrDefault()!;

                context.Events.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IEvent>> GetAllEvents()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IEvent> eventQuery = from e in context.Events
                                                select
                                                    new Event(e.Id, e.StateId, e.UserId, e.Type) as IEvent;

                return await Task.Run(() => eventQuery.ToDictionary(k => k.eventId));
            }
        }

        public async Task<int> GetEventsCount()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Events.Count());
            }
        }




        public async Task<bool> CheckIfUserExists(int id)
        {
            return (await this.GetUserAsyncQuerySyntax(id)) != null;
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return (await this.GetProduct(id)) != null;
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return (await this.GetState(id)) != null;
        }

        public async Task<bool> CheckIfEventExists(int id)
        {
            return (await this.GetEvent(id)) != null;
        }

    }
}
