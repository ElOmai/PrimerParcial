using BLL;
using Entidades;
using PrimerParcial.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.Registros
{
    public partial class rEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!Page.IsPostBack)
                {
                    int id = Utils.ToInt(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        FechaTextBox.Text = DateTime.Now.ToString("dd-mm-yyyy");
                        RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                        var registro = repositorio.Buscar(id);
                        ViewState["Evaluacion"] = new Evaluacion();
                        BindGrid();

                        if (registro == null)
                        {
                            Utils.ShowToastr(this.Page, "Registro no existe", "Error", "error");
                        }
                        else
                        {
                            LlenaCampos(registro);
                           
                        }
                    }
                }
            }
        }

        protected void BindGrid()
        {
            if (ViewState["Evaluacion"] != null)
            {
                DetalleGridView.DataSource = ((Evaluacion)ViewState["Evaluacion"]).Detalle;
                DetalleGridView.DataBind();
            }
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Evaluacion Evaluacion = new Evaluacion();

            Evaluacion = (Evaluacion)ViewState["Evaluacion"];

            ViewState["Detalle"] = Evaluacion.Detalle;

            int Fila = e.RowIndex;

            Evaluacion.Detalle.RemoveAt(Fila);

            this.BindGrid();

           TotalTextBox.Text = string.Empty;
        }

        protected void Limpiar()
        {
            IDTextBox.Text = "0";
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;
            LogradoTextBox.Text = string.Empty;
            
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected Evaluacion LlenaClase(Evaluacion Evaluacion)
        {
            Evaluacion.EvaluacionID = Utils.ToInt(IDTextBox.Text);
            Evaluacion.Estudiante = EstudianteTextBox.Text;
            Evaluacion.Categoria = CategoriaTextBox.Text;
            Evaluacion.Valor = Utils.ToDecimal(ValorTextBox.Text);
            Evaluacion.Logrado = Utils.ToDecimal(LogradoTextBox.Text);
            Evaluacion.Fecha = DateTime.Now;
            return Evaluacion;
        }

        private void LlenaCampos(Evaluacion Evaluacion)
        {
            IDTextBox.Text = Convert.ToString(Evaluacion.EvaluacionID);
            EstudianteTextBox.Text = Evaluacion.Estudiante;
            CategoriaTextBox.Text = Evaluacion.Categoria;
            ValorTextBox.Text = Convert.ToString(Evaluacion.Valor);
            LogradoTextBox.Text = Convert.ToString(Evaluacion.Logrado); 

        }


        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
            Evaluacion Evaluacion = repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (Evaluacion != null);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluacion> Repositorio = new RepositorioBase<Evaluacion>();
            Evaluacion Evaluacion = new Evaluacion();
            bool paso = false;

            Evaluacion = LlenaClase(Evaluacion);

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Evaluacion);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(Evaluacion);
                Limpiar();
            }

            if (paso)
            {
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                return;
            }
            else

                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }



        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
            var Evaluacion = repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (Evaluacion != null)
            {
                Limpiar();
                LlenaCampos(Evaluacion);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this.Page, "El Evaluacion que intenta buscar no existe", "Error", "error");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utils.ToInt(IDTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(IDTextBox.Text);
                RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                if (repositorio.Eliminar(id))
                {

                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utils.ShowToastr(this.Page, "No se pudo eliminar, Evaluacion no existe", "error", "error");
            }
        }

    }
}
