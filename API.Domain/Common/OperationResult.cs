namespace API.Domain.Common;

public class OperationResult<T>
{
    public bool Success { get; private set; } = true;
    public List<string> ErrorsList { get; } = [];
    
    public T Data { get; set; }

    public void AddError(string error)
    {
        ErrorsList.Add(error);
        Success = false;
    }
}