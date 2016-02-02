using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using SubtitleAPI.Models;

namespace SubtitleProject.Controllers
{
    [EnableCors(origins: "http://localhost:54436", headers: "*", methods: "*")]
    public class SubtitleManageController : ApiController
    {

        private static List<string> _subtitleFile;

        public SubtitleManageController()
        {
            ReadSubtitleFile();
        }

        [HttpGet]
        public IEnumerable<string> GetAllData()
        {
            if (_subtitleFile != null)
            {
                return _subtitleFile;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/getbycount")]
        //[EnableCors("http://localhost:54436", "Accept, Origin, Content-Type", "GET")]
        public SubtitleDataModel GetByCount(int start = 0 , int end = 15 )
        {
            List<string> subData = new List<string>();
            for (int i = start; i <= end; i++)
            {
                subData.Add(_subtitleFile[i]);
            }
            SubtitleDataModel data = new SubtitleDataModel();
            data.SubDataList = subData;
            data.Start = start;
            data.End = end;
            return data;
        }


        [HttpPost]
        [Route("api/postchanges")]
        public string PostChanges([FromBody]string subs)
        {
            return subs;
        }

        [HttpPost]
        public TestDataModel Post([FromBody]TestDataModel subs)
        {
            string serverPath = HttpContext.Current.Server.MapPath("~/NewSubFile/text.txt");

            try {

                using (StreamWriter sw = File.AppendText(serverPath))
                {
                    for (int i = 0; i < subs.SubDataList.Count; i++)
                    {
                        sw.WriteLine(subs.SubDataList[i].Data);
                    }
                }
            }
            catch (Exception ex)
            {

            }


            return subs;
        }



        private void ReadSubtitleFile()
        {
            string serverPath = HttpContext.Current.Server.MapPath("~/SubtitleFiles/Transporter.srt");
            try {
                var template =  File.ReadAllLines(serverPath);
                if(template != null)
                {
                    _subtitleFile = new List<string>();
                    _subtitleFile.AddRange(template);
                }
            }
            catch (System.Exception e)
            {

            }
            
        }
    }
}
