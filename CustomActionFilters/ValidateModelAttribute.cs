using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZZwalks.CustomActionFilters
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        //this method will be executed before executing the controller action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid == false)
            {
                //context.Result = new BadRequestResult();
                List<string> errorlist = new List<string>();
                foreach (var value in context.ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorlist.Add(error.ErrorMessage);
                    }
                }
                string errors = string.Join("\n", errorlist);
                context.Result = new BadRequestObjectResult(errors);
            }
        }

        //after controller action is executed then this method will be executed
      /*public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }*/
    }
}
