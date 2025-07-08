namespace FoodBook.Domain
{
    public class OperationResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public bool IsFailure => !IsSuccess;

        protected OperationResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static OperationResult Success() => new OperationResult(true, string.Empty);
        public static OperationResult Failure(string message) => new OperationResult(false, message);
    }


    public class OperationResult<T> : OperationResult
    {
        public T Value { get; }

        protected OperationResult(T value, bool isSuccess, string message)
            : base(isSuccess, message)
        {
            Value = value;
        }

        public static new OperationResult<T> Success(T value) => new OperationResult<T>(value, true, string.Empty);
        public static new OperationResult<T> Failure(string message) => new OperationResult<T>(default, false, message); 
    }
}