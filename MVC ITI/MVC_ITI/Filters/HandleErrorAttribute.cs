using Microsoft.AspNetCore.Mvc;


namespace MVC_ITI.Filters
{
    public class HandleErrorAttribute : Attribute , IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();   
            viewResult.ViewName = "Error";
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some Exception throw";
            context.Result = viewResult;
        }
    }
}
