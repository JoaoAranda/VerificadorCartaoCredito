using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ValidaCartaoCredito.Business;
using ValidaCartaoCredito.Models;

namespace ValidaCartaoCredito.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index(IndexModel model)
        {
            if (String.IsNullOrEmpty(model.Numero))
                model.Resultado = "Informe o numero do cartão";
            else
                model.Resultado = new Validacao().ValidaGenerico(model.Numero);

            return View(model);
        }

    }
}
