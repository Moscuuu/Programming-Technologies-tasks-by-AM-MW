using Presentation.Model.API;
using Presentation.ViewModel;
using PresentationTests.FakeItems;

namespace PresentationTests;

internal class RandomGenerator : IGenerator
{
    private readonly IErrorInformer _informer = new TextErrorInformer();

    public void GenerateUserModels(IUserMasterViewModel viewModel)
    {
        IUserModelOperation operation = new FakeUserCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Users.Add(IUserDetailViewModel.CreateViewModel(i, RandomString(10), RandomString(10), operation, _informer));
        }
    }

    public void GenerateProductModels(IProductMasterViewModel viewModel)
    {
        IProductModelOperation operation = new FakeProductCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Products.Add(IProductDetailViewModel.CreateViewModel(i, RandomString(10), RandomString(10), RandomNumber<float>(4), operation, _informer));
        }
    }

    public void GenerateStateModels(IStateMasterViewModel viewModel)
    {
        IStateModelOperation operation = new FakeStateCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.States.Add(IStateDetailViewModel.CreateViewModel(i, i, RandomBool(), operation, _informer));
        }
    }

    public void GenerateEventModels(IEventMasterViewModel viewModel)
    {
        IEventModelOperation operation = new FakeEventCRUD();

        for (int i = 1; i <= 10; i++)
        {
            viewModel.Events.Add(IEventDetailViewModel.CreateViewModel(i, i, i, "PlacedEvent", operation, _informer));
        }
    }

    private string RandomString(int length)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var randomText = new char[length];

        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            randomText[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomText);
    }

    private string RandomStringWithNumber(int length)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var randomText = new char[length];

        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            randomText[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomText);
    }

    private T RandomNumber<T>(int length) where T : struct, IComparable
    {
        if (length <= 0)
            throw new ArgumentException("Number of digits must be positive.");

        Random random = new Random();

        T maxNumber = (T)Convert.ChangeType(Math.Pow(10, length), typeof(T));

        T randomNumber = (T)Convert.ChangeType(
            random.Next(
                Convert.ToInt32(Math.Pow(10, length - 1)),
                Convert.ToInt32(maxNumber)
            ), typeof(T)
        );

        return randomNumber;
    }

    private bool RandomBool()
    {
        Random random = new Random();

        if (random.Next(0, 2) == 0)
        {
            return false;
        }

        return true;
    }

}
