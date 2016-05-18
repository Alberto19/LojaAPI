using Loja.DAO;
using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            try
            {
                CarrinhoDAO dao = new CarrinhoDAO();
                Carrinho carrinho = dao.Busca(id);
                return  Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch(KeyNotFoundException)
            {

                string mensagem = string.Format("O carrinho {0} não foi encontrado", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
           
        }


        public HttpResponseMessage Post([FromBody] Carrinho carrinho)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new {controller = "carrinho", id = carrinho.Id});
            response.Headers.Location = new Uri(location);

            return response;
        }

    }
}
