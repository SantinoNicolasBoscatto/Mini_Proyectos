namespace CleanArchitecture.API.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string? msg = null)
        {
            StatusCode = statusCode;
            Msg = msg == null? GetDefaultMessageStatusCode(statusCode) : msg;
        }

        public int StatusCode { get; set; }
        public string? Msg { get; set; }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes authorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se produjo errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
