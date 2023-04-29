using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using DataLayer.Models;

namespace PruebaPT.PaginasPrueba
{
    public partial class Index : System.Web.UI.Page
    {
        DataLayer.Controller.TareaController TareaGestor = new DataLayer.Controller.TareaController();


        private DateTime? fechaAnteriorTerminada;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ObtenerTareas();
            }

        }
        public List<Tareas> ObtenerTareas()
        {
            List<Tareas> ListTareas = TareaGestor.ObtenerTareas();
            dgv_Tareas.DataSource = ListTareas;
            dgv_Tareas.DataBind();
            return ListTareas;
        }

        protected void dgv_Tareas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgv_Tareas.EditIndex = e.NewEditIndex;
            ObtenerTareas();
            GridViewRow editingRow = dgv_Tareas.Rows[e.NewEditIndex];
        }

        protected void dgv_Tareas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgv_Tareas.EditIndex = -1;
            ObtenerTareas();

        }

        protected void dgv_Tareas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Tareas oTarea = new Tareas();
            oTarea.Id_Task = Int32.Parse((dgv_Tareas.Rows[e.RowIndex].FindControl("txtId_TaskEdit") as TextBox).Text.Trim());
            oTarea.Titulo = (dgv_Tareas.Rows[e.RowIndex].FindControl("txtTituloEdit") as TextBox).Text.Trim();
            oTarea.Descripcion = (dgv_Tareas.Rows[e.RowIndex].FindControl("txtDescripcionEdit") as TextBox).Text.Trim();
            oTarea.Estado = (dgv_Tareas.Rows[e.RowIndex].FindControl("cbxEstadoEdit") as CheckBox).Checked;

            DateTime FechaRegistro = DateTime.Parse((dgv_Tareas.Rows[e.RowIndex].FindControl("DateFecha_RegistroEdit") as Calendar).SelectedDate.ToString());
            DateTime FechaTerminada = DateTime.Parse((dgv_Tareas.Rows[e.RowIndex].FindControl("DateFecha_TerminadaEdit") as Calendar).SelectedDate.ToString());

            DateTime fechaAnterior;
            DateTime fechaTerAnterior;
            if (FechaRegistro != DateTime.MinValue)
            {
                oTarea.Fecha_Registro = FechaRegistro;
            }
            else if (DateTime.TryParse(dgv_Tareas.Rows[e.RowIndex].Attributes["data-fecharegistro"], out fechaAnterior))
            {
                oTarea.Fecha_Registro = fechaAnterior;

            if (FechaTerminada != fechaAnteriorTerminada && FechaTerminada != DateTime.MinValue)
            {
                oTarea.Fecha_Terminada = FechaTerminada;
            }
            else if (DateTime.TryParse(dgv_Tareas.Rows[e.RowIndex].Attributes["data-fechaterminada"], out fechaTerAnterior))
            {
                oTarea.Fecha_Terminada = fechaTerAnterior;
            }
            else
            {
                oTarea.Fecha_Terminada = null;
            }
            TareaGestor.ActualizarTarea(oTarea);

            dgv_Tareas.EditIndex = -1;
            DataBind();
            ObtenerTareas();
            string message = "Se actualizó el registro.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        protected void dgv_Tareas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTarea;
            if (int.TryParse(dgv_Tareas.Rows[e.RowIndex].Attributes["data-idTask"], out idTarea))
            {
                TareaGestor.EliminarTarea(idTarea);
                DataBind();
                ObtenerTareas();
            }
        }

        protected void dgv_Tareas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (string.IsNullOrEmpty((dgv_Tareas.FooterRow.FindControl("txtTitulo_footer") as TextBox).Text.Trim()) || string.IsNullOrEmpty((dgv_Tareas.FooterRow.FindControl("txtDescripcion_footer") as TextBox).Text.Trim()))
                {
                    
                    string message = "Los campos de título y descripción no pueden estar vacíos.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    Tareas oTarea = new Tareas();
                    oTarea.Titulo = (dgv_Tareas.FooterRow.FindControl("txtTitulo_footer") as TextBox).Text.Trim();
                    oTarea.Descripcion = (dgv_Tareas.FooterRow.FindControl("txtDescripcion_footer") as TextBox).Text.Trim();
                    DateTime fechainicio = DateTime.Parse((dgv_Tareas.FooterRow.FindControl("DateFecha_Registro_footer") as Calendar).SelectedDate.ToString());
                    DateTime fechaTerminada = DateTime.Parse((dgv_Tareas.FooterRow.FindControl("DateFecha_Terminada_footer") as Calendar).SelectedDate.ToString());
                    if (fechainicio != DateTime.MinValue)
                    {
                        oTarea.Fecha_Registro = fechainicio;
                    }
                    else
                    {
                        oTarea.Fecha_Terminada = DateTime.Now;
                    }
                    if (fechaTerminada != DateTime.MinValue)
                    {
                        oTarea.Fecha_Terminada = fechaTerminada;
                    }
                    else
                    {
                        oTarea.Fecha_Terminada = null;

                    }
                    if (oTarea.Fecha_Terminada < oTarea.Fecha_Registro)
                    {
                        // Mostrar mensaje de error
                        string message = "La fecha de finalización no puede ser menor que la fecha de registro.";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);
                        return;
                    }
                    else
                    {
                        oTarea.Estado = (dgv_Tareas.FooterRow.FindControl("cbxEstado_footer") as CheckBox).Checked;
                        TareaGestor.CrearTarea(oTarea);
                        dgv_Tareas.EditIndex = -1;
                        DataBind();
                        ObtenerTareas();
                    }
                    
                }
            }

        }

        protected void dgv_Tareas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime fechaRegistro = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Registro"));
                DateTime? fechaTerminada = DataBinder.Eval(e.Row.DataItem, "Fecha_Terminada") as DateTime?;
                int idTarea = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Task"));
                e.Row.Attributes["data-idTask"] = idTarea.ToString();
                e.Row.Attributes["data-fecharegistro"] = fechaRegistro.ToString("yyyy-MM-dd");
                if (fechaTerminada.HasValue)
                {
                    e.Row.Attributes["data-fechaterminada"] = fechaTerminada.Value.ToString("yyyy-MM-dd");
                }
                
            }
        }

        protected void btnMostrarPendientes_Click(object sender, EventArgs e)
        {
            List<Tareas> ListTareasPendientes = TareaGestor.ObtenerTareasPendientes(0);
            dgv_Tareas.DataSource = ListTareasPendientes;
            dgv_Tareas.DataBind();
        }

        protected void btnMostrarTareasFinalizadas_Click(object sender, EventArgs e)
        {
            List<Tareas> ListTareasPendientes = TareaGestor.ObtenerTareasTerminadas(1);
            dgv_Tareas.DataSource = ListTareasPendientes;
            dgv_Tareas.DataBind();
        }

        protected void btnMostrarTodasTareas_Click(object sender, EventArgs e)
        {
            ObtenerTareas();
        }

        protected void btnBuscarTarea_Click(object sender, EventArgs e)
        {
            if (!txtBuscar.Text.Trim().Equals(""))
            {
                Busqueda(txtBuscar.Text);

            }
            else if (txtBuscar.Text == "")
            {
                Busqueda();
            }

        }
        public void Busqueda(string busqueda = null)
        {
            
            List<Tareas> lista = (List<Tareas>)TareaGestor.ObtenerTareaEspecifica(busqueda);
            dgv_Tareas.DataSource = lista;
            dgv_Tareas.DataBind();
        }
    }
}