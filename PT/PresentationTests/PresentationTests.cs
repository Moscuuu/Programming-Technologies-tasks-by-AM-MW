using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;

namespace PresentationTests;

[TestClass]
public class PresentationTests
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    [TestMethod]
    public void UserMasterViewModelTests()
    {
        IUserModelOperation operation = new  FakeUserCRUD();

        IUserMasterViewModel viewModel = IUserMasterViewModel.CreateViewModel(operation, _informer);
        viewModel.FirstName = "John";
        viewModel.LastName = "Doe";

        Assert.IsNotNull(viewModel.CreateUser);
        Assert.IsNotNull(viewModel.RemoveUser);

        Assert.IsTrue(viewModel.CreateUser.CanExecute(null));

        Assert.IsTrue(viewModel.RemoveUser.CanExecute(null));
    }

    [TestMethod]
    public void UserDetailViewModelTests()
    {
        IUserModelOperation operation = new FakeUserCRUD();

        IUserDetailViewModel detail = IUserDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual("John", detail.FirstName);
        Assert.AreEqual("Doe", detail.LastName);

        Assert.IsTrue(detail.UpdateUser.CanExecute(null));
    }

    [TestMethod]
    public void ProductMasterViewModelTests()
    {

        IProductModelOperation operation = new FakeProductCRUD();

        IProductMasterViewModel master = IProductMasterViewModel.CreateViewModel(operation, _informer);

        master.Name = "Pan Tadeusz";
        master.Description = "Super ksiazka";
        master.Price = 3.5f;

        Assert.IsNotNull(master.CreateProduct);
        Assert.IsNotNull(master.RemoveProduct);

        Assert.IsTrue(master.CreateProduct.CanExecute(null));

        master.Price = -1;

        Assert.IsFalse(master.CreateProduct.CanExecute(null));

        Assert.IsTrue(master.RemoveProduct.CanExecute(null));
    }

    [TestMethod]
    public void ProductDetailViewModelTests()
    {

        IProductModelOperation operation = new FakeProductCRUD();

        IProductDetailViewModel detail = IProductDetailViewModel.CreateViewModel(1, "Pan Tadeusz", "Super ksiazka", 3.5f,
            operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual("Pan Tadeusz", detail.ProductName);
        Assert.AreEqual("Super ksiazka", detail.Description);
        Assert.AreEqual(3.5f, detail.Price);

        Assert.IsTrue(detail.UpdateProduct.CanExecute(null));
    }

    [TestMethod]
    public void StateMasterViewModelTests()
    {

        IStateModelOperation operation = new FakeStateCRUD();

        IStateMasterViewModel master = IStateMasterViewModel.CreateViewModel(operation, _informer);

        master.Id = 1;
        master.ProductId = 1;
        master.Available = true;

        Assert.IsNotNull(master.CreateState);
        Assert.IsNotNull(master.RemoveState);

        Assert.IsTrue(master.CreateState.CanExecute(null));

    }

    [TestMethod]
    public void StateDetailViewModelTests()
    {
        IStateModelOperation operation = new FakeStateCRUD();

        IStateDetailViewModel detail = IStateDetailViewModel.CreateViewModel(1, 1, true, operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual(1, detail.ProductId);
        Assert.IsTrue(detail.Available);

        Assert.IsTrue(detail.UpdateState.CanExecute(null));
    }

    [TestMethod]
    public void EventMasterViewModelTests()
    {
        IEventModelOperation operation = new FakeEventCRUD();

        IEventMasterViewModel master = IEventMasterViewModel.CreateViewModel(operation, _informer);

        master.StateId = 1;
        master.UserId = 1;
    }

    [TestMethod]
    public void EventDetailViewModelTests()
    {

        IEventModelOperation operation = new FakeEventCRUD();

        IEventDetailViewModel detail = IEventDetailViewModel.CreateViewModel(1, 1, 1, "PlacedEvent", operation, _informer);

        Assert.AreEqual(1, detail.Id);
        Assert.AreEqual(1, detail.StateId);
        Assert.AreEqual(1, detail.UserId);
        Assert.AreEqual("PlacedEvent", detail.Type);

        Assert.IsTrue(detail.UpdateEvent.CanExecute(null));
    }

    [TestMethod]
    public void DataFixedGenerationMethodTests()
    {
        IGenerator fixedGenerator = new FixedGenerator();

        IUserModelOperation userOperation = new FakeUserCRUD();
        IUserMasterViewModel userViewModel = IUserMasterViewModel.CreateViewModel(userOperation, _informer);

        IProductModelOperation productOperation = new FakeProductCRUD();
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);


        IStateModelOperation stateOperation = new FakeStateCRUD();
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);
        ;
        IEventModelOperation eventOperation = new FakeEventCRUD();
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        fixedGenerator.GenerateUserModels(userViewModel);
        fixedGenerator.GenerateProductModels(productViewModel);
        fixedGenerator.GenerateStateModels(stateViewModel);
        fixedGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(2, userViewModel.Users.Count);
        Assert.AreEqual(2, productViewModel.Products.Count);
        Assert.AreEqual(2, stateViewModel.States.Count);
        Assert.AreEqual(2, eventViewModel.Events.Count);
    }

    [TestMethod]
    public void DataRandomGenerationMethodTests()
    {
        IGenerator randomGenerator = new RandomGenerator();

        IUserModelOperation userOperation = new FakeUserCRUD();
        IUserMasterViewModel userViewModel = IUserMasterViewModel.CreateViewModel(userOperation, _informer);

        IProductModelOperation productOperation = new FakeProductCRUD();
        IProductMasterViewModel productViewModel = IProductMasterViewModel.CreateViewModel(productOperation, _informer);


        IStateModelOperation stateOperation = new FakeStateCRUD();
        IStateMasterViewModel stateViewModel = IStateMasterViewModel.CreateViewModel(stateOperation, _informer);

        IEventModelOperation eventOperation = new FakeEventCRUD();
        IEventMasterViewModel eventViewModel = IEventMasterViewModel.CreateViewModel(eventOperation, _informer);

        randomGenerator.GenerateUserModels(userViewModel);
        randomGenerator.GenerateProductModels(productViewModel);
        randomGenerator.GenerateStateModels(stateViewModel);
        randomGenerator.GenerateEventModels(eventViewModel);

        Assert.AreEqual(10, userViewModel.Users.Count);
        Assert.AreEqual(10, productViewModel.Products.Count);
        Assert.AreEqual(10, stateViewModel.States.Count);
        Assert.AreEqual(10, eventViewModel.Events.Count);
    }


}