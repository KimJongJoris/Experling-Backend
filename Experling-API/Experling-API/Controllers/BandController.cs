using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;

namespace Experling_API.Controllers
{
    public class BandController : ControllerBase
    {
        private readonly IBandRepository bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            this.bandRepository = bandRepository;
        }



    }
}
