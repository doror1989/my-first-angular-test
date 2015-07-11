﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;
using IntelAgentWebApi.common;
using IntelAgentWebApi.DAL;
using IntelAgentWebApi.Models;
using Microsoft.AspNet.Identity;

namespace IntelAgentWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [Authorize]
    public class StocksManagerController : ApiController
    {
        private readonly StocksHandler _stocksMatchManager = StocksHandler.GetInstance();

        // GET: api/StocksManager/5
        public List<stocks_action> Get()
        {


            return _stocksMatchManager.GetStocksByUser(User.Identity.GetUserId());

        }

        // POST: api/StocksManager
        public void Post([FromBody]stocks_action value)
        {
         
            value.user_id = User.Identity.GetUserId();
            value.date_time = DateTime.Now;
            value.id = Guid.NewGuid().ToString();
            _stocksMatchManager.Insert2Db(value);
        }

        public void Put([FromBody]stocks_action value)
        {
            try
            {
                 _stocksMatchManager.UpdateDb(value);
            }
            catch (Exception ex)
            {
                
                throw new HttpException(400, string.Format("update stock in db faild error:{0}",ex.Message));
            }
        }

        public void Delete([FromBody]string id)
        {
            try
            {
                _stocksMatchManager.DeleteFromDb(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(400, ex.Message);
            }
        }
     
    }
}
