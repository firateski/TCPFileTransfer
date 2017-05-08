using File_Transfer.Extensions;

namespace File_Transfer.Controller
{
    interface IMainViewController
    {
        void SetController(MainViewController controller);

        string GetInputValueOnForm(MainFormInputs input);
    }
}
