namespace Richargh.BillionDollar.Classic.Common
{
    public enum Status
    {
        /// <summary>
        /// Standard response for successful requests. 
        /// </summary>
        Ok = 200,

        /// <summary>
        /// The request has been fulfilled, resulting in the creation of a new resource.
        /// </summary>
        Created = 201,

        /// <summary>
        /// The request has been accepted for processing, but the processing has not been completed. 
        /// </summary>
        Accepted = 202,

        /// <summary>
        /// The server successfully processed the request, and is not returning any content.
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// The server cannot or will not process the request due to an apparent client error.
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Authentication is required and has failed or has not yet been provided.
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// The requested resource could not be found but may be available in the future. 
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates.
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.
        /// </summary>
        InternalError = 500,
    }
}