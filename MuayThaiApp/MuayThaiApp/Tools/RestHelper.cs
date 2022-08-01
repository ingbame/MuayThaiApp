using MuayThaiApp.Tools.Enums;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MuayThaiApp.Tools
{
    public class RestHelper
    {

        #region Request params
        public string ApiUrl { get; set; }
        public string ContollerName { get; set; }
        public string MethodName { get; set; }
        public HttpMethodsEnum _HttpMethod { get; set; }
        public object Params { get; set; }
        public string Body { get; set; }
        #endregion
        #region Result params
        public bool Error { get; set; }
        public string Message { get; set; }
        #endregion
        #region Public Methods
        public async Task<T> RestRequest<T>()
        {
            try
            {
                var uri = $"{this.ApiUrl.Trim()}/{this.ContollerName.Trim()}";
                if (!string.IsNullOrEmpty(this.MethodName?.Trim() ?? null))
                {
                    uri += $"/{this.MethodName.Trim()}";
                    if (Params != null)
                        uri += $"?{GetQueryString(Params)}";
                }

                var client = new HttpClient();
                switch (this._HttpMethod)
                {
                    case HttpMethodsEnum.Get:
                        var request = new HttpRequestMessage()
                        {
                            RequestUri = new Uri(uri),
                            Method = HttpMethod.Get
                        };
                        request.Headers.Add("Accept", "aplication/json");
                        if (Body != null)
                        {
                            var jsonBodyGet = JsonConvert.SerializeObject(this.Body);
                            request.Content = new StringContent(jsonBodyGet, Encoding.UTF8, "application/json");
                        }

                        HttpResponseMessage responseGet = client.SendAsync(request).Result;
                        if (responseGet.StatusCode == HttpStatusCode.OK)
                        {
                            string content = await responseGet.Content.ReadAsStringAsync();
                            var resultado = JsonConvert.DeserializeObject<T>(content);
                            return resultado;
                        }
                        else
                        {
                            this.Error = true;
                            this.Message = responseGet.Content.ReadAsStringAsync().Result;
                        }
                        break;
                    case HttpMethodsEnum.Post:
                        var RequestUri = new Uri(uri);
                        var json = JsonConvert.SerializeObject(this.Body);
                        var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                        var responsePost = await client.PostAsync(RequestUri, contentJson);
                        if (responsePost.StatusCode == HttpStatusCode.OK)
                        {
                            string content = await responsePost.Content.ReadAsStringAsync();
                            var resultado = JsonConvert.DeserializeObject<T>(content);
                            return resultado;
                        }
                        else
                        {
                            this.Error = true;
                            this.Message = responsePost.Content.ReadAsStringAsync().Result;

                        }
                        break;
                    case HttpMethodsEnum.Put:
                        break;
                    case HttpMethodsEnum.Delete:
                        break;
                    default:
                        this.Error = true;
                        this.Message = "La petición HTTP no está configurada";
                        break;
                }
                return default(T);
            }
            catch (Exception ex)
            {
                this.Error = true;
                this.Message = ex.Message;
                if (ex.InnerException != null)
                    this.Message += $"\n{ex.InnerException.Message}";
                return default(T);
            }

        }
        #endregion
        #region Private Methods
        private string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
        #endregion
    }
}
