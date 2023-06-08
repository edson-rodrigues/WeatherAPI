using Integracao.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Integracao.Interfaces
{
    public interface IOpenGeoHttp
    {
        [Get("/geo/1.0/direct")]
        Task<IApiResponse<List<GeoResponse>>> GetCoordenates([Query]string q, string appid);
    }
}
