// Template: Base Controller (ApiControllerBase.t4) version 3.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ChinookAspNet5Sample.ChinookV1.Models;

// Do not modify this file. This code was generated by RAML Web Api 2 Scaffolder

namespace ChinookAspNet5Sample.ChinookV1
{
    [Route("invoices")]
    public partial class InvoicesController : Controller
    {


        		/// <returns>IList&lt;Invoice&gt;</returns>
        [HttpGet]
        [Route("")]
        public virtual IActionResult GetBase()
        {
            // Do not modify this code
            return  ((IInvoicesController)this).Get();
        }

        		/// <param name="content"></param>
        [HttpPost]
        [Route("")]
        public virtual IActionResult PostBase([FromBody] Models.Invoice content)
        {
            // Do not modify this code
            return  ((IInvoicesController)this).Post(content);
        }

        		/// <param name="id"></param>
		/// <returns>Invoice</returns>
        [HttpGet]
        [Route("{id}")]
        public virtual IActionResult GetByIdBase(string id)
        {
            // Do not modify this code
            return  ((IInvoicesController)this).GetById(id);
        }

        		/// <param name="content"></param>
		/// <param name="id"></param>
        [HttpPut]
        [Route("{id}")]
        public virtual IActionResult PutBase([FromBody] Models.Invoice content,string id)
        {
            // Do not modify this code
            return  ((IInvoicesController)this).Put(content,id);
        }

        		/// <param name="id"></param>
        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult DeleteBase(string id)
        {
            // Do not modify this code
            return  ((IInvoicesController)this).Delete(id);
        }
    }
}
