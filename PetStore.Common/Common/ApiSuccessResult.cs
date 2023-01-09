using PetStore.Common.Common;

namespace Pet_Store.Common.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T data)
        {
            Success = true;
            Data = data;
        }

        public ApiSuccessResult()
        {
            Success = true;
        }
    }
}