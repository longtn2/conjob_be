namespace ConJob.Domain.Response
{
    public class EServiceResponseTypes
    {
        public enum EResponseType
        {
            Success =200,
            Created = 201,
            NotFound = 404,
            Forbid = 403,
            BadRequest = 400,
            Unauthorized = 401,
            ServerError = 500,
            CannotUpdate,
            CannotCreate
        }
    }
}
