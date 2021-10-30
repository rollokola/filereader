using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileReader.Contract;
using System.IO;

namespace FileReader.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFileController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MyFile> Get()
        {
           var files =  Directory.GetFiles("c:\\temp\\");
           var resultList = new List<MyFile>();
            foreach (var f in files)
            {
                var rng = new MyFile();
                rng.Filename = f;
                rng.FileDate = DateTime.Now.ToString();
            
                resultList.Add(rng);

            }
          
            return resultList;
        }

        [HttpPost]
        public IEnumerable<MyFile> Post()
        {
            var rng = new MyFile();
            rng.Filename = "hej";
            rng.FileDate = "datum";
            var resultList = new List<MyFile>();
            resultList.Add(rng);
            return resultList;
        }
    }
}