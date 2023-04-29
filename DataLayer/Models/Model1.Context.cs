﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PTecnicaPayTechEntities : DbContext
    {
        public PTecnicaPayTechEntities()
            : base("name=PTecnicaPayTechEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tareas> Tareas { get; set; }
    
        public virtual int SP_ActualizarEstado(Nullable<int> id_Task, Nullable<bool> estado)
        {
            var id_TaskParameter = id_Task.HasValue ?
                new ObjectParameter("Id_Task", id_Task) :
                new ObjectParameter("Id_Task", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ActualizarEstado", id_TaskParameter, estadoParameter);
        }
    
        public virtual int SP_CrearTarea(string titulo, string descripcion, Nullable<System.DateTime> fecha_Registro, Nullable<System.DateTime> fecha_Terminada, Nullable<bool> estado)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fecha_RegistroParameter = fecha_Registro.HasValue ?
                new ObjectParameter("Fecha_Registro", fecha_Registro) :
                new ObjectParameter("Fecha_Registro", typeof(System.DateTime));
    
            var fecha_TerminadaParameter = fecha_Terminada.HasValue ?
                new ObjectParameter("Fecha_Terminada", fecha_Terminada) :
                new ObjectParameter("Fecha_Terminada", typeof(System.DateTime));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CrearTarea", tituloParameter, descripcionParameter, fecha_RegistroParameter, fecha_TerminadaParameter, estadoParameter);
        }
    
        public virtual int SP_EliminarTarea(Nullable<int> id_Task)
        {
            var id_TaskParameter = id_Task.HasValue ?
                new ObjectParameter("Id_Task", id_Task) :
                new ObjectParameter("Id_Task", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EliminarTarea", id_TaskParameter);
        }
    
        public virtual ObjectResult<SP_ExtraerTareaEspecifica_Result> SP_ExtraerTareaEspecifica(Nullable<int> id_Task)
        {
            var id_TaskParameter = id_Task.HasValue ?
                new ObjectParameter("Id_Task", id_Task) :
                new ObjectParameter("Id_Task", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ExtraerTareaEspecifica_Result>("SP_ExtraerTareaEspecifica", id_TaskParameter);
        }
    
        public virtual ObjectResult<SP_ExtraerTareasPendientes_Result> SP_ExtraerTareasPendientes(Nullable<bool> estado)
        {
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ExtraerTareasPendientes_Result>("SP_ExtraerTareasPendientes", estadoParameter);
        }
    
        public virtual ObjectResult<SP_ExtraerTareasTerminadas_Result> SP_ExtraerTareasTerminadas(Nullable<bool> estado)
        {
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ExtraerTareasTerminadas_Result>("SP_ExtraerTareasTerminadas", estadoParameter);
        }
    
        public virtual ObjectResult<SP_ExtraerTodasTareas_Result> SP_ExtraerTodasTareas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ExtraerTodasTareas_Result>("SP_ExtraerTodasTareas");
        }
    
        public virtual int SP_ModificarTarea(Nullable<int> id_Task, string titulo, string descripcion, Nullable<System.DateTime> fecha_Registro, Nullable<System.DateTime> fecha_Terminada, Nullable<bool> estado)
        {
            var id_TaskParameter = id_Task.HasValue ?
                new ObjectParameter("Id_Task", id_Task) :
                new ObjectParameter("Id_Task", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var fecha_RegistroParameter = fecha_Registro.HasValue ?
                new ObjectParameter("Fecha_Registro", fecha_Registro) :
                new ObjectParameter("Fecha_Registro", typeof(System.DateTime));
    
            var fecha_TerminadaParameter = fecha_Terminada.HasValue ?
                new ObjectParameter("Fecha_Terminada", fecha_Terminada) :
                new ObjectParameter("Fecha_Terminada", typeof(System.DateTime));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ModificarTarea", id_TaskParameter, tituloParameter, descripcionParameter, fecha_RegistroParameter, fecha_TerminadaParameter, estadoParameter);
        }
    }
}