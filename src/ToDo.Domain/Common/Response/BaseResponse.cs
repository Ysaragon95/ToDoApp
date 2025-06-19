namespace ToDo.Domain.Common.Response
{
    /// <summary>
    /// Representa una respuesta estándar para operaciones de la aplicación.
    /// Incluye datos opcionales, código de estado, mensaje y una bandera de éxito.
    /// </summary>
    /// <typeparam name="T">Tipo de dato retornado en la propiedad <see cref="Data"/>.</typeparam>
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success => StatusCode is >= 200 and < 300;

        public BaseResponse() { }

        public BaseResponse(T data, int statusCode = 200, string message = "")
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }

        public static BaseResponse<T> Ok(T data, string message = "") =>
            new(data, 200, message);

        public static BaseResponse<T> Created(T data, string message = "") =>
            new(data, 201, message);

        public static BaseResponse<T> BadRequest(string message) =>
            new(default!, 400, message);

        public static BaseResponse<T> NotFound(string message) =>
            new(default!, 404, message);

        public static BaseResponse<T> Error(string message, int statusCode = 500) =>
            new(default!, statusCode, message);
    }
}
