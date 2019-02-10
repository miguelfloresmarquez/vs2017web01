using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Filters
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        //Método se ejecuta antes de iniciar la acción (Action)
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        //Método que se ejecuta despues de finalizar la acción (Action)
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}