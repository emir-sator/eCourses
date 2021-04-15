
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Model;
using eCourses.WebAPI.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Controllers
{
    public class TransactionController : CRUDController<MTransaction, TransactionSearchRequest, TransactionUpsertRequest, TransactionUpsertRequest>
    {
        public TransactionController(ICRUDService<MTransaction, TransactionSearchRequest, TransactionUpsertRequest, TransactionUpsertRequest> service) : base(service)
    {

    }
}
}
