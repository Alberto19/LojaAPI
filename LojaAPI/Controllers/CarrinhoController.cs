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
        public string Get(int id)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho =  dao.Busca(id);

            return carrinho.ToXml();
        }
    }
}
