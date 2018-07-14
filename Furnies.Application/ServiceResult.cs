using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application
{
    public class ServiceResult<T>
    {
        public ServiceResult(OperationStatus status, OperationError error)
        {
            Status = status;
            OperationError = error;
        }
        public ServiceResult(OperationStatus status, T result)
        {
            Status = status;
            Result = result;
        }
        public T Result { get; private set; }
        public OperationStatus Status { get; private set; }
        public OperationError OperationError { get; private set; }
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
        public OperationError(ErrorType type, string friendlyDescription, Exception ex)
        {
            ErrorType = type;
            FriendlyDescription = friendlyDescription;
            Exception = ex;
        }
        public OperationError(ErrorType type, string friendlyDescription)
        {
            ErrorType = type;
            FriendlyDescription = friendlyDescription;
        }
        public ErrorType ErrorType { get; private set; }
        public string FriendlyDescription { get; private set; }
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
