using OPC_DA_Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OPC_DA_Proxy.Controllers
{
    public class WorkspaceController : ApiController
    {

        public string[] GetAvailablePictures()
        {
            return PicturesRepository.getBrowsablePictures();
        }

        public string PostFetchScreenForName(GetPictureRequest getPictureRequest)
        {
            return PicturesRepository.getPictureForName(getPictureRequest.name);
        }
    }
}
