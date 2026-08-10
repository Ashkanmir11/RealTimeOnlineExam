using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineExam.Ui.Components
{
    public class BaseComponent : ComponentBase
    {
        protected List<string> Errors { get; set; } = new();
        public void SetErrors(List<string> errors)
        {
            Errors.Clear();
            if (errors != null)
            {
                Errors.AddRange(errors);
            }
            StateHasChanged();
        }
        public void SetErrors(string error)
        {
            Errors.Clear();
            if (error != null)
            {
                Errors.Add(error);
            }
            StateHasChanged();
        }
    }
}
