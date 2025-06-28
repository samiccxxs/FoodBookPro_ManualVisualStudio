
public class ServiceResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } 

    private ServiceResult(bool isSuccess, T data, string message, List<string> errors = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
        Errors = errors;
    }

    public static ServiceResult<T> Success(T data, string message = "Operation successful")
    {
        return new ServiceResult<T>(true, data, message);
    }

    public static ServiceResult<T> Failure(string message, List<string> errors = null, T data = default(T))
    {
        return new ServiceResult<T>(false, data, message, errors);
    }
}

public class ServiceResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

    private ServiceResult(bool isSuccess, string message, List<string> errors = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Errors = errors;
    }

    public static ServiceResult Success(string message = "Operation successful")
    {
        return new ServiceResult(true, message);
    }

    public static ServiceResult Failure(string message, List<string> errors = null)
    {
        return new ServiceResult(false, message, errors);
    }
}