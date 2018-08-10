using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application
{
    public abstract class ServiceResult<T>
    {
        public T Result { get; protected set; }
        public bool IsSucceed { get; protected set; }
        public OperationError OperationError { get; protected set; }
    }


    public class ServiceErrorResult<T> : ServiceResult<T>{

        public ServiceErrorResult(OperationError error)
        {
            IsSucceed = false;
            OperationError = error;
        }
        public ServiceErrorResult(ErrorType errorType, string errorMessage, Exception ex)
        {
            IsSucceed = false;
            OperationError = new OperationError(errorType, errorMessage, ex);
        }
    }

    public class ServiceSucceedResult<T> : ServiceResult<T>
    {
        public ServiceSucceedResult(T result)
        {
            IsSucceed = true;
            Result = result;
        }
    }
    public enum OperationStatus {
        Succeed,
        Error
    }

    public enum ErrorType {
        Validation,
        Concurrency,
        Exception
    }

    public class OperationError {
        public OperationError(ErrorType type, string errorMessage, Exception ex)
        {
            ErrorType = type;
            this.errorMessage = errorMessage;
            Exception = ex;
        }
        public OperationError(ErrorType type, string errorMessage)
        {
            ErrorType = type;
            this.errorMessage = errorMessage;
        }
        public ErrorType ErrorType { get; private set; }
        public string errorMessage { get; private set; }
        public Exception Exception { get; private set; }
    }

    public class PagedResult<T> {
        public PagedResult(int totalPages, int totalRows, List<T> result)
        {
            TotalPages = totalPages;
            TotalRows = totalRows;
            Result = result;
        }
        public int TotalPages { get; private set; }
        public int TotalRows { get; private set; }
        public List<T> Result { get; private set; }
    }
}
