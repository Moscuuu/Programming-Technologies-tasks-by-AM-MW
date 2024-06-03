using Service.API;
using ServiceTest.FakeItems;

namespace ServiceTest
{
    [TestClass]
    public class ServiceTests
    {

        [TestMethod]
        public async Task UserServiceTests()
        {
            IUserCRUD userCrud = new FakeUserCRUD();
            //int id, string firstName, string lastName
            await userCrud.AddUser(1, "John", "Doe");
            //int id
            IUserDTO user = await userCrud.GetUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);

            Assert.IsNotNull(await userCrud.GetAllUsers());
            Assert.IsTrue(await userCrud.GetUsersCount() > 0);

            await userCrud.UpdateUser(1, "Johnny", "Doer");

            IUserDTO updatedUser = await userCrud.GetUser(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.Id);
            Assert.AreEqual("Johnny", updatedUser.FirstName);
            Assert.AreEqual("Doer", updatedUser.LastName);

            await userCrud.DeleteUser(1);
        }

        [TestMethod]
        public async Task ProductServiceTests()
        {
            IProductCRUD productCrud = new FakeProductCRUD();
            await productCrud.AddProduct(1, "Moby Dick", "XZY", 3.5f);

            IProductDTO product = await productCrud.GetProduct(1);

            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Moby Dick", product.Author);
            Assert.AreEqual("XZY", product.ProductDescription);
            Assert.AreEqual(3.5, product.Price);

            Assert.IsNotNull(await productCrud.GetAllProducts());
            Assert.IsTrue(await productCrud.GetProductsCount() > 0);

            await productCrud.UpdateProduct(1, "Moby Dick", "XZYe", 4);

            IProductDTO updatedProduct = await productCrud.GetProduct(1);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(1, updatedProduct.Id);
            Assert.AreEqual("Moby Dick", updatedProduct.Author);
            Assert.AreEqual("XZYe", updatedProduct.ProductDescription);
            Assert.AreEqual(4, updatedProduct.Price);

            await productCrud.DeleteProduct(1);
        }

        [TestMethod]
        public async Task StateServiceTests()
        {
            IProductCRUD productCrud = new FakeProductCRUD();
            await productCrud.AddProduct(1, "Moby Dick", "XZY", 3.5f);

            IProductDTO product = await productCrud.GetProduct(1);

            IStateCRUD stateCrud = new FakeStateCRUD();
            //int id, int productId
            await stateCrud.AddState(1, product.Id, true);

            IStateDTO state = await stateCrud.GetState(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual(1, state.ProductId);
            Assert.AreEqual(true, state.Available);

            await stateCrud.UpdateState(1, product.Id, false);

            IStateDTO updatedState = await stateCrud.GetState(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.StateId);
            Assert.AreEqual(1, updatedState.ProductId);
            Assert.AreEqual(false, updatedState.Available);

            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
        }

        [TestMethod]
        public async Task PlaceEventServiceTests()
        {
            IProductCRUD productCrud = new FakeProductCRUD();
            //int id, string productName, string productDescription, float price
            await productCrud.AddProduct(1, "Moby Dick", "XZY", 3.5f);

            IProductDTO product = await productCrud.GetProduct(1);

            IStateCRUD stateCrud = new FakeStateCRUD();
            //int id, int productId
            await stateCrud.AddState(1, product.Id, true);

            IStateDTO state = await stateCrud.GetState(1);

            IUserCRUD userCrud = new FakeUserCRUD();

            //int id, string firstName, string lastName
            await userCrud.AddUser(1, "John", "Doe");

            IUserDTO user = await userCrud.GetUser(1);

            IEventCRUD eventCrud = new FakeEventCRUD();
            await eventCrud.AddEvent(1, state.StateId, user.Id, "PlacedEvent");

            user = await userCrud.GetUser(1);
            state = await stateCrud.GetState(1);

            Assert.AreEqual(true, state.Available);

            await eventCrud.DeleteEvent(1);
            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
            await userCrud.DeleteUser(1);
        }

        [TestMethod]
        public async Task PayedEventServiceTests()
        {
            IProductCRUD productCrud = new FakeProductCRUD();

            await productCrud.AddProduct(1, "Moby Dick", "XZY", 2);

            IProductDTO product = await productCrud.GetProduct(1);

            IStateCRUD stateCrud = new FakeStateCRUD();

            await stateCrud.AddState(1, product.Id, true);

            IStateDTO state = await stateCrud.GetState(1);

            IUserCRUD userCrud = new FakeUserCRUD();

            await userCrud.AddUser(1, "John", "Doe");

            IUserDTO user = await userCrud.GetUser(1);

            IEventCRUD eventCrud = new FakeEventCRUD();

            await eventCrud.AddEvent(1, state.StateId, user.Id, "PlacedEvent");

            await eventCrud.AddEvent(2, state.StateId, user.Id, "PayedEvent");

            user = await userCrud.GetUser(1);
            state = await stateCrud.GetState(1);

            Assert.AreEqual(true, state.Available);

            await eventCrud.DeleteEvent(2);
            await eventCrud.DeleteEvent(1);
            await stateCrud.DeleteState(1);
            await productCrud.DeleteProduct(1);
            await userCrud.DeleteUser(1);
        }
    }
}