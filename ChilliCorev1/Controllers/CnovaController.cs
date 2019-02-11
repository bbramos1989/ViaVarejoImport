using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ChilliCorev1.Models;

namespace ChilliCorev1.Controllers
{
    [Route("/import")]
    public class CnovaController : Controller
    {
        DirectoryInfo save = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Downloads");
        DirectoryInfo categoriesdirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Downloads\\Categorias");
        DirectoryInfo avaliabledirectory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Downloads\\Avaliable");
        string caminho = Directory.GetCurrentDirectory() + "\\Downloads\\";
       

        public string avaliablePersist(Produtos produto)
        {
            try
            {
                var context = new marketplaceextraprdContext();
                context.Produtos.Update(produto);
                context.SaveChanges();
                return "salvo";

            }
            catch (Exception e)
            {

            }

            return "";

        }
        

        [HttpGet]
        [Route("saveavaliable")]
        public string UpdateAvaliable()
        {
            //string url = "http://b2b.extra.com.br/Arquivos/CatalogoB2B/Disponibilidade?idParceiro=73";

            //using (var webClient = new WebClient())
            //{
            //    webClient.DownloadFile(address: url, fileName: "avaliable.zip");

            //}

            ZipFile.ExtractToDirectory("avaliable.zip", caminho.ToString() + "Avaliable");

            XmlDocument xmlDoc = new XmlDocument();
            foreach (FileInfo file in avaliabledirectory.GetFiles())
            {

                xmlDoc.Load(file.FullName);

                XmlNodeList node = xmlDoc.SelectNodes("//Produtos/Produto");
                marketplaceextraprdContext context = new marketplaceextraprdContext();

                foreach (XmlNode row in node)
                {
                    var result = context.Produtos.SingleOrDefault(b => b.CodigoProduto == row.Attributes["codigo"].Value);
                    if (result != null)
                    {
                        result.Habilitado = row.Attributes["disponibilidade"].Value == "1" ? true : false ;
                        this.avaliablePersist(result);
                    }

                }

            }
            return "Salvo com sucesso";
        }
    }
}
