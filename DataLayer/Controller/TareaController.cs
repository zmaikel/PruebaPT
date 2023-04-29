using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Controller
{
    public class TareaController
    {
        public List<Tareas> ObtenerTareas()
        {
            using (var context = new Models.PTecnicaPayTechEntities())
            {
                List<Tareas> tareas = context.Database.SqlQuery<Tareas>("EXEC SP_ExtraerTodasTareas").ToList();
                return tareas;
            }

        }
        public List<Tareas> ObtenerTareasPendientes(int oEstado)
        {
            using (var context = new Models.PTecnicaPayTechEntities())
            {
                var tareas = context.Database.SqlQuery<Tareas>("EXEC SP_ExtraerTareasPendientes " + oEstado).ToList();
                return tareas;
            }
        }
        public List<Tareas> ObtenerTareasTerminadas(int oEstado)
        {
            using (var context = new Models.PTecnicaPayTechEntities())
            {
                var tareas = context.Database.SqlQuery<Tareas>("EXEC SP_ExtraerTareasTerminadas " + oEstado).ToList();
                return tareas;
            }
        }
        public Tareas CrearTarea(Tareas oTarea)
        {
            Tareas inTarea = oTarea; //inTarea = InsertTarea
            using (var context = new PTecnicaPayTechEntities())
            {
                string sqlQuery = "EXEC SP_CrearTarea @Titulo, @Descripcion, @Fecha_Registro, @Fecha_Terminada, @Estado";

                SqlParameter tituloParam = new SqlParameter("@Titulo", inTarea.Titulo);
                SqlParameter descripcionParam = new SqlParameter("@Descripcion", inTarea.Descripcion);

                SqlParameter estadoParam = new SqlParameter("@Estado", inTarea.Estado);

                SqlParameter fechaTerminadaParam = null;
                SqlParameter fechaRegistroParam = null;

                if (oTarea.Fecha_Terminada.HasValue)
                {
                    fechaTerminadaParam = new SqlParameter("@Fecha_Terminada", inTarea.Fecha_Terminada.Value);
                }
                else
                {
                    fechaTerminadaParam = new SqlParameter("@Fecha_Terminada", DBNull.Value);
                }
                if (oTarea.Fecha_Registro.Date != DateTime.MinValue)
                {
                    fechaRegistroParam = new SqlParameter("@Fecha_Registro", inTarea.Fecha_Registro);
                }
                else
                {
                    fechaRegistroParam = new SqlParameter("@Fecha_Registro", DateTime.Now);
                }
                context.Database.ExecuteSqlCommand(sqlQuery, tituloParam, descripcionParam, fechaRegistroParam, fechaTerminadaParam, estadoParam);
                context.SaveChanges();
                return inTarea;
            }
        }
        public int EliminarTarea(int idTarea)
        {
            using (var context = new PTecnicaPayTechEntities())
            {
                string sqlQuery = "EXEC SP_EliminarTarea @Id_Task";
                SqlParameter idparam = new SqlParameter("@Id_Task", idTarea);
                context.Database.ExecuteSqlCommand(sqlQuery, idparam);
                context.SaveChanges();
            }
            return 1;
        }
        public Tareas ActualizarTarea(Tareas oTarea)
        {
            using (var context = new PTecnicaPayTechEntities())
            {
                string sqlQuery = "EXEC SP_ModificarTarea @Id_Task, @Titulo, @Descripcion, @Fecha_Registro, @Fecha_Terminada, @Estado";

                SqlParameter idParam = new SqlParameter("@Id_Task", oTarea.Id_Task);
                SqlParameter tituloParam = new SqlParameter("@Titulo", oTarea.Titulo);
                SqlParameter descripcionParam = new SqlParameter("@Descripcion", oTarea.Descripcion);
                SqlParameter fechaRegistroParam = new SqlParameter("@Fecha_Registro", oTarea.Fecha_Registro);
                SqlParameter estadoParam = new SqlParameter("@Estado", oTarea.Estado);
                SqlParameter fechaTerminadaParam = null;
                if (oTarea.Fecha_Terminada.HasValue)
                {
                    fechaTerminadaParam = new SqlParameter("@Fecha_Terminada", oTarea.Fecha_Terminada.Value);
                }
                else
                {
                    fechaTerminadaParam = new SqlParameter("@Fecha_Terminada", DBNull.Value);
                }
                context.Database.ExecuteSqlCommand(sqlQuery, idParam, tituloParam, descripcionParam, fechaRegistroParam, fechaTerminadaParam, estadoParam);
                context.SaveChanges();
                return oTarea;
            }

        }
        //Este m[etodo no se utiliza debido a que con la opci[on de actualizar se puede cambiar el estado
        //de las tareas
        public int ActualizarEstado(int oEstado)
        {
            using (var context = new Models.PTecnicaPayTechEntities())
            {
                context.Database.ExecuteSqlCommand("EXEC SP_ActualizarEstado", oEstado);
                context.SaveChanges();
                return oEstado;
            }
        }
        public IEnumerable<Tareas> ObtenerTareaEspecifica(string Titulo)
        {
            List<Tareas> ListAux;
            using (var context = new Models.PTecnicaPayTechEntities())
            {
                IQueryable<Tareas> ListaTarea = from m in context.Tareas
                                                select m;
                if (Titulo != null && !Titulo.Equals(""))
                {
                    string sqlQuery = "EXEC SP_ExtraerTareaEspecifica @Titulo";
                    SqlParameter Tituloparam = new SqlParameter("@Titulo", Titulo);
                    ListAux = context.Database.SqlQuery<Tareas>(sqlQuery, Tituloparam).ToList();
                }
                else
                {
                    ListAux = ListaTarea.ToList();
                }

                return ListAux;
            }
        }
    }
}
