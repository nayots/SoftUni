namespace WebServer.Http.Response
{
    using Common;
    using Enums;
    using System;

    public class InternalServerErrorResponse : ContentResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex).View())
        {
        }
    }
}