using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    [DeploymentItem("LibraryDBTest.mdf")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void InitializeDataLayerTests(TestContext context)
        {
            string _DBRelativePath = @"LibraryDBTest.mdf";
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public async Task UserTests()
        {
            int userId = 12;

            await _dataRepository.AddUser(userId, "John", "Smith");

            IUser user = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Smith", user.lastName);


        }

        [TestMethod]
        public async Task ProductTests()
        {
            int productId = 12;

            await _dataRepository.AddProduct(12, "Moby Dick", "ABC", 40.0f);

            IProduct product = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.id);
            Assert.AreEqual("Moby Dick", product.productName);
            Assert.AreEqual("ABC", product.productDescription);
            Assert.AreEqual(40.0f, product.price);

            Assert.IsNotNull(await _dataRepository.GetAllProducts());
            Assert.IsTrue(await _dataRepository.GetProductsCount() > 0);

        }

        [TestMethod]
        public async Task StateTests()
        {
            int productId = 3;
            int stateId = 3;

            await _dataRepository.AddProduct(productId, "Moby Dick", "ABC", 40.0f);

            IProduct product = await _dataRepository.GetProduct(productId);

            await _dataRepository.AddState(stateId, productId, true);

            IState state = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.stateId);
            Assert.AreEqual(productId, state.productId);
            Assert.AreEqual(true, state.available);

           
        }

        [TestMethod]
        public async Task EventTests()
        {
            await _dataRepository.AddUser(20, "John", "Smith");
            await _dataRepository.AddProduct(20, "XYZ", "ABC", 3.99f);
            await _dataRepository.AddState(20, 20, true);
            await _dataRepository.AddEvent(20, 20, 20, "PlaceEvent");

            await _dataRepository.DeleteEvent(20);
            await _dataRepository.DeleteUser(20);
            await _dataRepository.DeleteState(20);
            await _dataRepository.DeleteProduct(20);
        }
    }
}