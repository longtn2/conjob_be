namespace ConJob.Domain.Response
{
    public class EServiceResponseTypes
    {
        public enum EResponseType
        {
            Success,
            NotFound,
            CannotCreate,
            CannotUpdate,
            CannotDelete,
            Forbid,
            BadRequest,
            Unauthorized
        }
    }
}
