namespace Presentation.ViewModel;

public interface IErrorInformer
{
    void InformError(string message);

    void InformSuccess(string message);

    string GetRecentMessage();
    public void CallMessageBox(string message);
}
