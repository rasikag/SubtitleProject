using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;

namespace SubtitleProject.Controllers
{
    public class SubtitleManageController : ApiController
    {

        private List<string> _subtitleFiel = null;

        [HttpGet]
        public IEnumerable<string> GetAllData()
        {
            if (_subtitleFiel != null)
            {
                return _subtitleFiel;
            }
            else
            {
                return ReadSubtitleFile();
            }
        }

        private List<string> ReadSubtitleFile()
        {
            string serverPath = HttpContext.Current.Server.MapPath("~/SubtitleFiles/Transporter.srt");
            try {
                var template =  File.ReadAllLines(serverPath);
                if(template != null)
                {
                    _subtitleFiel = new List<string>();
                    _subtitleFiel.AddRange(template);
                }
            }
            catch (System.Exception e)
            {

            }
            return _subtitleFiel;
        }

        


    }
}
