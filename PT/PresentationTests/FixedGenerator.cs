using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;

namespace PresentationTests;

internal class FixedGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    public void GenerateUserModels(IUserMasterViewModel viewModel)
    {
        IUserModelOperation operation = new FakeUserCRUD();

        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(1, "John", "Doe", operation, _informer));
        viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(2, "Jane", "Doe", operation, _informer));
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductModelOperation operation = new FakeProductCRUD();

        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(1, "Moby Dick", "XZY", 30.5f, operation, _informer));
        viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(2, "Pan Tadeusz", "Super Ksiazka", 40.5f, operation, _informer));

    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateModelOperation operation = new FakeStateCRUD();

        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(1, 1, true, operation, _informer));
        viewModel.States.Add(IStateDetailViewModel.CreateViewModel(2, 2, false, operation, _informer));
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {

        IEventModelOperation operation = new FakeEventCRUD();
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(1, 1, 1, "PlacedEvent", operation, _informer));
        viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(2, 2, 2, "PayedEvent", operation, _informer));


    }
}