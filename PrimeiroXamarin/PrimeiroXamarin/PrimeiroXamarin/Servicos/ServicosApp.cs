using Flurl.Http;
using Flurl.Http.Configuration;
using PrimeiroXamarin.Entidades;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Shapes;

namespace PrimeiroXamarin.Servicos
{

    public class ServicosApp : IServicos
    {


        public ServicosApp(IPageDialogService pageDialogService)
        {
           
             FlurlHttp.Configure(settings => {
                settings.HttpClientFactory = new MyCustomHttpClientFactory();

            });
        }

        public List<Aluno> ObterTodosAlunos()
        {

            string uri = "https://100.100.100.181:5001/api/alunos";
            List<Aluno> resposta = null ;
            try
            {
                //IDictionary<string, object> queryParams = new Dictionary<string, object>();
                //queryParams.Add("id", 2);

                resposta = uri 
                    .WithTimeout(1)                    
                    .GetJsonAsync<List<Aluno>>().Result;

                //.SetQueryParams(queryParams)

                // List<Aluno> response = JsonConvert.DeserializeObject<ListarCompetenciaResult>(resposta);

                return resposta;
            }
            catch (FlurlHttpException flurlE)
            {
                String msg = flurlE.Message;
            }
            catch(Exception e)
            {
                String msg = e.Message;
            }
           
            return resposta;
           
        }



        public bool ExcluirAluno(Aluno aluno)
        {

            string uri = "https://100.100.100.181:5001/api/alunos";
            HttpResponseMessage resposta = null;
            try
            {
                uri += "/" + aluno.IdAluno;

                resposta = uri
                    .WithTimeout(1)                    
                    .DeleteAsync().Result;
                
                if (resposta.IsSuccessStatusCode)
                    return true;
                
            }
            catch (FlurlHttpException flurlE)
            {
                String msg = flurlE.Message;
            }
            catch (Exception e)
            {
                String msg = e.Message;
            }

            
            return false;
        }
    }






    public class MyCustomHttpClientFactory : DefaultHttpClientFactory
    {


        public override HttpMessageHandler CreateMessageHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            /*handler.ServerCertificateCustomValidationCallback += (HttpRequestMessage sender, X509Certificate2 certificadoServidor, X509Chain cadeia, SslPolicyErrors sslerror) =>
            {
                if (certificadoServidor == null)
                    return false;

                //codigo abaixo para fazer a pinagem com a chave publica do servidor
                return certificadoServidor.GetPublicKeyString().ToUpper().Equals(AppSettings.ObtemChavePublicaBackEnd().ToUpper());
            };*/
            return handler;
        }



    }
}
