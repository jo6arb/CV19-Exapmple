namespace CV19.Services.Interfaces
{
    public interface IUserDialogService
    {
        bool Edit(object item);

        void ShowInfo(string Information, string Caption);

        void ShowWarning(string Message, string Caption);
        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);


    }
}