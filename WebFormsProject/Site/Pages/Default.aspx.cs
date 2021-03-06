﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1.Model;
using ClassLibrary1.Persistence;

namespace Site.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuarioLogado = Convert.ToString(Session["NomeUsuarioLogado"]);
                lblUsuarioLogado.Text = usuarioLogado;

                ProjetoDAL pd = new ProjetoDAL();

                if (pd == null)
                {
                    lblMensagem.Text = "Lista Vazia.";
                }
                else
                {
                    gridProjetos.DataSource = pd.ListarProj(Convert.ToInt32(Session["CodigoUsuarioLogado"]));   //Popular a grid
                    gridProjetos.DataBind();                                                                    //Exibe a grid
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}