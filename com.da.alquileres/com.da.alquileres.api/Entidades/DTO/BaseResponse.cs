namespace com.da.alquileres.api.DTO
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }
    }

    public class BaseResponseGeneric<T> : BaseResponse
    {
        public T? Data { get; set; }
    }

    public class BaseCollectionResponse<T> : BaseResponseGeneric<T>
    {
        public int TotalPages { get; set; }
    }

}
