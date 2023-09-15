namespace Siscon_API_Backend.ViewModels
{
    public class ReturnViewModel<T>
    {
        public ReturnViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ReturnViewModel(T data)
        {
            Data = data;
        }

        public ReturnViewModel(List<string> errors)
        {
            Errors = errors;
        }

        public ReturnViewModel(string error)
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
