﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="db_aa7784_bdemprende")]
	public partial class ConnectionDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void Inserttb_imagen_binario(tb_imagen_binario instance);
    partial void Updatetb_imagen_binario(tb_imagen_binario instance);
    partial void Deletetb_imagen_binario(tb_imagen_binario instance);
    #endregion
		
		public ConnectionDataContext() : 
				base(global::Backend.Properties.Settings.Default.db_aa7784_bdemprendeConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tb_imagen_binario> tb_imagen_binario
		{
			get
			{
				return this.GetTable<tb_imagen_binario>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_ActualizarUsuario")]
		public int sp_ActualizarUsuario([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string apellidos, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(255)")] string direccion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string telefono, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(500)")] string descripcion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, nombre, apellidos, email, direccion, telefono, descripcion);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_CrearUsuario")]
		public int sp_CrearUsuario([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string apellidos, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string password, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(255)")] string direccion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string telefono, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(500)")] string descripcion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nombre, apellidos, email, password, direccion, telefono, descripcion);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_EliminarUsuario")]
		public int sp_EliminarUsuario([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_IngresarCalificacion")]
		public int sp_IngresarCalificacion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="TinyInt")] System.Nullable<byte> calificacion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, calificacion);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_obtener_usuario_por_id")]
		public ISingleResult<sp_obtener_usuario_por_idResult> sp_obtener_usuario_por_id([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<sp_obtener_usuario_por_idResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ELIMINAR_PUBLICACION")]
		public int SP_ELIMINAR_PUBLICACION([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_PUBLICACION", DbType="Int")] System.Nullable<int> iD_PUBLICACION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FILASACTUALIZADAS", DbType="Int")] ref System.Nullable<int> fILASACTUALIZADAS)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_PUBLICACION, iDRETURN, eRRORID, eRRORDESCRIPCION, fILASACTUALIZADAS);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(1)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(2)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(3)));
			fILASACTUALIZADAS = ((System.Nullable<int>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_INGRESAR_PUBLICACION")]
		public int SP_INGRESAR_PUBLICACION([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USUARIO", DbType="BigInt")] System.Nullable<long> iD_USUARIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DESCRIPCION", DbType="VarChar(MAX)")] string dESCRIPCION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PRECIO", DbType="Decimal(18,0)")] System.Nullable<decimal> pRECIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CATEGORIA", DbType="VarChar(MAX)")] string cATEGORIA, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Imagenes", DbType="VarChar(MAX)")] string imagenes, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDRETURN", DbType="Int")] ref System.Nullable<int> iDRETURN, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORID", DbType="Int")] ref System.Nullable<int> eRRORID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ERRORDESCRIPCION", DbType="NVarChar(MAX)")] ref string eRRORDESCRIPCION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USUARIO, dESCRIPCION, pRECIO, cATEGORIA, imagenes, iDRETURN, eRRORID, eRRORDESCRIPCION);
			iDRETURN = ((System.Nullable<int>)(result.GetParameterValue(5)));
			eRRORID = ((System.Nullable<int>)(result.GetParameterValue(6)));
			eRRORDESCRIPCION = ((string)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_validar_inicio_sesion")]
		public ISingleResult<sp_validar_inicio_sesionResult> sp_validar_inicio_sesion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string correo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), correo);
			return ((ISingleResult<sp_validar_inicio_sesionResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_obtener_publicacion_por_id_usuario")]
		public ISingleResult<sp_obtener_publicacion_por_id_usuarioResult> sp_obtener_publicacion_por_id_usuario([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<sp_obtener_publicacion_por_id_usuarioResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_MOSTRAR_PUBLICACIONES_GUARDADAS")]
		public ISingleResult<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult> SP_MOSTRAR_PUBLICACIONES_GUARDADAS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USUARIO", DbType="Int")] System.Nullable<int> iD_USUARIO)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USUARIO);
			return ((ISingleResult<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_GUARDAR_PUBLICACION_DESEO")]
		public ISingleResult<SP_GUARDAR_PUBLICACION_DESEOResult> SP_GUARDAR_PUBLICACION_DESEO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USUARIO", DbType="Int")] System.Nullable<int> iD_USUARIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_PUBLICACION", DbType="Int")] System.Nullable<int> iD_PUBLICACION, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RESULTADO", DbType="Int")] ref System.Nullable<int> rESULTADO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MENSAJE_SALIDA", DbType="NVarChar(300)")] ref string mENSAJE_SALIDA)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USUARIO, iD_PUBLICACION, rESULTADO, mENSAJE_SALIDA);
			rESULTADO = ((System.Nullable<int>)(result.GetParameterValue(2)));
			mENSAJE_SALIDA = ((string)(result.GetParameterValue(3)));
			return ((ISingleResult<SP_GUARDAR_PUBLICACION_DESEOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_ELIMINAR_PUBLICACION_LISTA_DESEO")]
		public int SP_ELIMINAR_PUBLICACION_LISTA_DESEO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_USUARIO", DbType="Int")] System.Nullable<int> iD_USUARIO, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID_PUBLICACION", DbType="Int")] System.Nullable<int> iD_PUBLICACION)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD_USUARIO, iD_PUBLICACION);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_OBTENER_PUBLICACIONES")]
		public ISingleResult<SP_OBTENER_PUBLICACIONESResult> SP_OBTENER_PUBLICACIONES([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Categoria", DbType="VarChar(MAX)")] string categoria, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> usuarioID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoria, usuarioID);
			return ((ISingleResult<SP_OBTENER_PUBLICACIONESResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tb_imagen_binario")]
	public partial class tb_imagen_binario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _tb_imagen_id;
		
		private System.Nullable<long> _tb_publicacion_id;
		
		private System.Data.Linq.Binary _tb_imagen_binario1;
		
		private string _tb_imagen_extension;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontb_imagen_idChanging(int value);
    partial void Ontb_imagen_idChanged();
    partial void Ontb_publicacion_idChanging(System.Nullable<long> value);
    partial void Ontb_publicacion_idChanged();
    partial void Ontb_imagen_binario1Changing(System.Data.Linq.Binary value);
    partial void Ontb_imagen_binario1Changed();
    partial void Ontb_imagen_extensionChanging(string value);
    partial void Ontb_imagen_extensionChanged();
    #endregion
		
		public tb_imagen_binario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_imagen_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int tb_imagen_id
		{
			get
			{
				return this._tb_imagen_id;
			}
			set
			{
				if ((this._tb_imagen_id != value))
				{
					this.Ontb_imagen_idChanging(value);
					this.SendPropertyChanging();
					this._tb_imagen_id = value;
					this.SendPropertyChanged("tb_imagen_id");
					this.Ontb_imagen_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_id", DbType="BigInt")]
		public System.Nullable<long> tb_publicacion_id
		{
			get
			{
				return this._tb_publicacion_id;
			}
			set
			{
				if ((this._tb_publicacion_id != value))
				{
					this.Ontb_publicacion_idChanging(value);
					this.SendPropertyChanging();
					this._tb_publicacion_id = value;
					this.SendPropertyChanged("tb_publicacion_id");
					this.Ontb_publicacion_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="tb_imagen_binario", Storage="_tb_imagen_binario1", DbType="VarBinary(MAX)", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary tb_imagen_binario1
		{
			get
			{
				return this._tb_imagen_binario1;
			}
			set
			{
				if ((this._tb_imagen_binario1 != value))
				{
					this.Ontb_imagen_binario1Changing(value);
					this.SendPropertyChanging();
					this._tb_imagen_binario1 = value;
					this.SendPropertyChanged("tb_imagen_binario1");
					this.Ontb_imagen_binario1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_imagen_extension", DbType="Char(4)")]
		public string tb_imagen_extension
		{
			get
			{
				return this._tb_imagen_extension;
			}
			set
			{
				if ((this._tb_imagen_extension != value))
				{
					this.Ontb_imagen_extensionChanging(value);
					this.SendPropertyChanging();
					this._tb_imagen_extension = value;
					this.SendPropertyChanged("tb_imagen_extension");
					this.Ontb_imagen_extensionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class sp_obtener_usuario_por_idResult
	{
		
		private long _tb_usuario_id;
		
		private string _tb_usuario_nombre;
		
		private string _tb_usuario_apellidos;
		
		private string _tb_usuario_email;
		
		private string _tb_usuario_password;
		
		private string _tb_usuario_direccion;
		
		private string _tb_usuario_telefono;
		
		private System.Nullable<int> _tb_usuario_calificacion;
		
		private string _tb_usuario_descripcion;
		
		private System.Nullable<byte> _tb_usuario_estado;
		
		public sp_obtener_usuario_por_idResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_id", DbType="BigInt NOT NULL")]
		public long tb_usuario_id
		{
			get
			{
				return this._tb_usuario_id;
			}
			set
			{
				if ((this._tb_usuario_id != value))
				{
					this._tb_usuario_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_nombre", DbType="VarChar(255)")]
		public string tb_usuario_nombre
		{
			get
			{
				return this._tb_usuario_nombre;
			}
			set
			{
				if ((this._tb_usuario_nombre != value))
				{
					this._tb_usuario_nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_apellidos", DbType="VarChar(255)")]
		public string tb_usuario_apellidos
		{
			get
			{
				return this._tb_usuario_apellidos;
			}
			set
			{
				if ((this._tb_usuario_apellidos != value))
				{
					this._tb_usuario_apellidos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_email", DbType="VarChar(255)")]
		public string tb_usuario_email
		{
			get
			{
				return this._tb_usuario_email;
			}
			set
			{
				if ((this._tb_usuario_email != value))
				{
					this._tb_usuario_email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_password", DbType="VarChar(255)")]
		public string tb_usuario_password
		{
			get
			{
				return this._tb_usuario_password;
			}
			set
			{
				if ((this._tb_usuario_password != value))
				{
					this._tb_usuario_password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_direccion", DbType="VarChar(255)")]
		public string tb_usuario_direccion
		{
			get
			{
				return this._tb_usuario_direccion;
			}
			set
			{
				if ((this._tb_usuario_direccion != value))
				{
					this._tb_usuario_direccion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_telefono", DbType="VarChar(255)")]
		public string tb_usuario_telefono
		{
			get
			{
				return this._tb_usuario_telefono;
			}
			set
			{
				if ((this._tb_usuario_telefono != value))
				{
					this._tb_usuario_telefono = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_calificacion", DbType="Int")]
		public System.Nullable<int> tb_usuario_calificacion
		{
			get
			{
				return this._tb_usuario_calificacion;
			}
			set
			{
				if ((this._tb_usuario_calificacion != value))
				{
					this._tb_usuario_calificacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_descripcion", DbType="VarChar(255)")]
		public string tb_usuario_descripcion
		{
			get
			{
				return this._tb_usuario_descripcion;
			}
			set
			{
				if ((this._tb_usuario_descripcion != value))
				{
					this._tb_usuario_descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_estado", DbType="TinyInt")]
		public System.Nullable<byte> tb_usuario_estado
		{
			get
			{
				return this._tb_usuario_estado;
			}
			set
			{
				if ((this._tb_usuario_estado != value))
				{
					this._tb_usuario_estado = value;
				}
			}
		}
	}
	
	public partial class sp_validar_inicio_sesionResult
	{
		
		private long _tb_usuario_id;
		
		private string _tb_usuario_nombre;
		
		private string _tb_usuario_apellidos;
		
		private string _tb_usuario_email;
		
		private string _tb_usuario_password;
		
		private string _tb_usuario_direccion;
		
		private string _tb_usuario_telefono;
		
		private System.Nullable<int> _tb_usuario_calificacion;
		
		private string _tb_usuario_descripcion;
		
		private System.Nullable<byte> _tb_usuario_estado;
		
		public sp_validar_inicio_sesionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_id", DbType="BigInt NOT NULL")]
		public long tb_usuario_id
		{
			get
			{
				return this._tb_usuario_id;
			}
			set
			{
				if ((this._tb_usuario_id != value))
				{
					this._tb_usuario_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_nombre", DbType="VarChar(255)")]
		public string tb_usuario_nombre
		{
			get
			{
				return this._tb_usuario_nombre;
			}
			set
			{
				if ((this._tb_usuario_nombre != value))
				{
					this._tb_usuario_nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_apellidos", DbType="VarChar(255)")]
		public string tb_usuario_apellidos
		{
			get
			{
				return this._tb_usuario_apellidos;
			}
			set
			{
				if ((this._tb_usuario_apellidos != value))
				{
					this._tb_usuario_apellidos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_email", DbType="VarChar(255)")]
		public string tb_usuario_email
		{
			get
			{
				return this._tb_usuario_email;
			}
			set
			{
				if ((this._tb_usuario_email != value))
				{
					this._tb_usuario_email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_password", DbType="VarChar(255)")]
		public string tb_usuario_password
		{
			get
			{
				return this._tb_usuario_password;
			}
			set
			{
				if ((this._tb_usuario_password != value))
				{
					this._tb_usuario_password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_direccion", DbType="VarChar(255)")]
		public string tb_usuario_direccion
		{
			get
			{
				return this._tb_usuario_direccion;
			}
			set
			{
				if ((this._tb_usuario_direccion != value))
				{
					this._tb_usuario_direccion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_telefono", DbType="VarChar(255)")]
		public string tb_usuario_telefono
		{
			get
			{
				return this._tb_usuario_telefono;
			}
			set
			{
				if ((this._tb_usuario_telefono != value))
				{
					this._tb_usuario_telefono = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_calificacion", DbType="Int")]
		public System.Nullable<int> tb_usuario_calificacion
		{
			get
			{
				return this._tb_usuario_calificacion;
			}
			set
			{
				if ((this._tb_usuario_calificacion != value))
				{
					this._tb_usuario_calificacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_descripcion", DbType="VarChar(255)")]
		public string tb_usuario_descripcion
		{
			get
			{
				return this._tb_usuario_descripcion;
			}
			set
			{
				if ((this._tb_usuario_descripcion != value))
				{
					this._tb_usuario_descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_estado", DbType="TinyInt")]
		public System.Nullable<byte> tb_usuario_estado
		{
			get
			{
				return this._tb_usuario_estado;
			}
			set
			{
				if ((this._tb_usuario_estado != value))
				{
					this._tb_usuario_estado = value;
				}
			}
		}
	}
	
	public partial class sp_obtener_publicacion_por_id_usuarioResult
	{
		
		private long _publicacion_id;
		
		private System.Nullable<long> _usuario_id;
		
		private System.Nullable<System.DateTime> _publicacion_fecha;
		
		private string _publicacion_descripcion;
		
		private System.Nullable<decimal> _publicacion_precio;
		
		private string _publicacion_categoria;
		
		private System.Nullable<byte> _publicacion_estado;
		
		public sp_obtener_publicacion_por_id_usuarioResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_id", DbType="BigInt NOT NULL")]
		public long publicacion_id
		{
			get
			{
				return this._publicacion_id;
			}
			set
			{
				if ((this._publicacion_id != value))
				{
					this._publicacion_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_usuario_id", DbType="BigInt")]
		public System.Nullable<long> usuario_id
		{
			get
			{
				return this._usuario_id;
			}
			set
			{
				if ((this._usuario_id != value))
				{
					this._usuario_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_fecha", DbType="DateTime")]
		public System.Nullable<System.DateTime> publicacion_fecha
		{
			get
			{
				return this._publicacion_fecha;
			}
			set
			{
				if ((this._publicacion_fecha != value))
				{
					this._publicacion_fecha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_descripcion", DbType="VarChar(255)")]
		public string publicacion_descripcion
		{
			get
			{
				return this._publicacion_descripcion;
			}
			set
			{
				if ((this._publicacion_descripcion != value))
				{
					this._publicacion_descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_precio", DbType="Decimal(8,2)")]
		public System.Nullable<decimal> publicacion_precio
		{
			get
			{
				return this._publicacion_precio;
			}
			set
			{
				if ((this._publicacion_precio != value))
				{
					this._publicacion_precio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_categoria", DbType="VarChar(255)")]
		public string publicacion_categoria
		{
			get
			{
				return this._publicacion_categoria;
			}
			set
			{
				if ((this._publicacion_categoria != value))
				{
					this._publicacion_categoria = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_publicacion_estado", DbType="TinyInt")]
		public System.Nullable<byte> publicacion_estado
		{
			get
			{
				return this._publicacion_estado;
			}
			set
			{
				if ((this._publicacion_estado != value))
				{
					this._publicacion_estado = value;
				}
			}
		}
	}
	
	public partial class SP_MOSTRAR_PUBLICACIONES_GUARDADASResult
	{
		
		private long _tb_lista_deseos_id;
		
		private string _tb_usuario_nombre;
		
		private System.Nullable<long> _tb_usuario_id;
		
		private long _tb_publicacion_id;
		
		private string _tb_publicacion_descripcion;
		
		private System.Nullable<byte> _tb_publicacion_estado;
		
		private System.Nullable<System.DateTime> _tb_publicacion_fecha;
		
		private System.Nullable<decimal> _tb_publicacion_precio;
		
		private System.Nullable<System.DateTime> _tb_lista_deseos_creacion;
		
		private System.Nullable<byte> _tb_lista_deseos_estado;
		
		public SP_MOSTRAR_PUBLICACIONES_GUARDADASResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_lista_deseos_id", DbType="BigInt NOT NULL")]
		public long tb_lista_deseos_id
		{
			get
			{
				return this._tb_lista_deseos_id;
			}
			set
			{
				if ((this._tb_lista_deseos_id != value))
				{
					this._tb_lista_deseos_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_nombre", DbType="VarChar(255)")]
		public string tb_usuario_nombre
		{
			get
			{
				return this._tb_usuario_nombre;
			}
			set
			{
				if ((this._tb_usuario_nombre != value))
				{
					this._tb_usuario_nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_usuario_id", DbType="BigInt")]
		public System.Nullable<long> tb_usuario_id
		{
			get
			{
				return this._tb_usuario_id;
			}
			set
			{
				if ((this._tb_usuario_id != value))
				{
					this._tb_usuario_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_id", DbType="BigInt NOT NULL")]
		public long tb_publicacion_id
		{
			get
			{
				return this._tb_publicacion_id;
			}
			set
			{
				if ((this._tb_publicacion_id != value))
				{
					this._tb_publicacion_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_descripcion", DbType="VarChar(255)")]
		public string tb_publicacion_descripcion
		{
			get
			{
				return this._tb_publicacion_descripcion;
			}
			set
			{
				if ((this._tb_publicacion_descripcion != value))
				{
					this._tb_publicacion_descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_estado", DbType="TinyInt")]
		public System.Nullable<byte> tb_publicacion_estado
		{
			get
			{
				return this._tb_publicacion_estado;
			}
			set
			{
				if ((this._tb_publicacion_estado != value))
				{
					this._tb_publicacion_estado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_fecha", DbType="DateTime")]
		public System.Nullable<System.DateTime> tb_publicacion_fecha
		{
			get
			{
				return this._tb_publicacion_fecha;
			}
			set
			{
				if ((this._tb_publicacion_fecha != value))
				{
					this._tb_publicacion_fecha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_publicacion_precio", DbType="Decimal(8,2)")]
		public System.Nullable<decimal> tb_publicacion_precio
		{
			get
			{
				return this._tb_publicacion_precio;
			}
			set
			{
				if ((this._tb_publicacion_precio != value))
				{
					this._tb_publicacion_precio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_lista_deseos_creacion", DbType="DateTime")]
		public System.Nullable<System.DateTime> tb_lista_deseos_creacion
		{
			get
			{
				return this._tb_lista_deseos_creacion;
			}
			set
			{
				if ((this._tb_lista_deseos_creacion != value))
				{
					this._tb_lista_deseos_creacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tb_lista_deseos_estado", DbType="TinyInt")]
		public System.Nullable<byte> tb_lista_deseos_estado
		{
			get
			{
				return this._tb_lista_deseos_estado;
			}
			set
			{
				if ((this._tb_lista_deseos_estado != value))
				{
					this._tb_lista_deseos_estado = value;
				}
			}
		}
	}
	
	public partial class SP_GUARDAR_PUBLICACION_DESEOResult
	{
		
		private string _MENSAJE;
		
		private System.Nullable<int> _RESULTADO;
		
		public SP_GUARDAR_PUBLICACION_DESEOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MENSAJE", DbType="NVarChar(300)")]
		public string MENSAJE
		{
			get
			{
				return this._MENSAJE;
			}
			set
			{
				if ((this._MENSAJE != value))
				{
					this._MENSAJE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RESULTADO", DbType="Int")]
		public System.Nullable<int> RESULTADO
		{
			get
			{
				return this._RESULTADO;
			}
			set
			{
				if ((this._RESULTADO != value))
				{
					this._RESULTADO = value;
				}
			}
		}
	}
	
	public partial class SP_OBTENER_PUBLICACIONESResult
	{
		
		private long _ID_PUBLICACION;
		
		private System.Nullable<long> _ID_USUARIO;
		
		private System.Nullable<System.DateTime> _FECHA_PUBLICACION;
		
		private string _DESCRIPCION;
		
		private System.Nullable<decimal> _PRECIO;
		
		private string _CATEGORIA;
		
		private System.Nullable<byte> _ESTADO;
		
		private System.Nullable<bool> _IsFavorito;
		
		private string _NOMBRE_USUARIO;
		
		private string _APELLIDOS_USUARIO;
		
		private string _IMAGEN_BINARIO;
		
		public SP_OBTENER_PUBLICACIONESResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_PUBLICACION", DbType="BigInt NOT NULL")]
		public long ID_PUBLICACION
		{
			get
			{
				return this._ID_PUBLICACION;
			}
			set
			{
				if ((this._ID_PUBLICACION != value))
				{
					this._ID_PUBLICACION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_USUARIO", DbType="BigInt")]
		public System.Nullable<long> ID_USUARIO
		{
			get
			{
				return this._ID_USUARIO;
			}
			set
			{
				if ((this._ID_USUARIO != value))
				{
					this._ID_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FECHA_PUBLICACION", DbType="DateTime")]
		public System.Nullable<System.DateTime> FECHA_PUBLICACION
		{
			get
			{
				return this._FECHA_PUBLICACION;
			}
			set
			{
				if ((this._FECHA_PUBLICACION != value))
				{
					this._FECHA_PUBLICACION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPCION", DbType="VarChar(255)")]
		public string DESCRIPCION
		{
			get
			{
				return this._DESCRIPCION;
			}
			set
			{
				if ((this._DESCRIPCION != value))
				{
					this._DESCRIPCION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRECIO", DbType="Decimal(8,2)")]
		public System.Nullable<decimal> PRECIO
		{
			get
			{
				return this._PRECIO;
			}
			set
			{
				if ((this._PRECIO != value))
				{
					this._PRECIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CATEGORIA", DbType="VarChar(255)")]
		public string CATEGORIA
		{
			get
			{
				return this._CATEGORIA;
			}
			set
			{
				if ((this._CATEGORIA != value))
				{
					this._CATEGORIA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ESTADO", DbType="TinyInt")]
		public System.Nullable<byte> ESTADO
		{
			get
			{
				return this._ESTADO;
			}
			set
			{
				if ((this._ESTADO != value))
				{
					this._ESTADO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsFavorito", DbType="Bit")]
		public System.Nullable<bool> IsFavorito
		{
			get
			{
				return this._IsFavorito;
			}
			set
			{
				if ((this._IsFavorito != value))
				{
					this._IsFavorito = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOMBRE_USUARIO", DbType="VarChar(255)")]
		public string NOMBRE_USUARIO
		{
			get
			{
				return this._NOMBRE_USUARIO;
			}
			set
			{
				if ((this._NOMBRE_USUARIO != value))
				{
					this._NOMBRE_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APELLIDOS_USUARIO", DbType="VarChar(255)")]
		public string APELLIDOS_USUARIO
		{
			get
			{
				return this._APELLIDOS_USUARIO;
			}
			set
			{
				if ((this._APELLIDOS_USUARIO != value))
				{
					this._APELLIDOS_USUARIO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IMAGEN_BINARIO", DbType="VarChar(MAX)")]
		public string IMAGEN_BINARIO
		{
			get
			{
				return this._IMAGEN_BINARIO;
			}
			set
			{
				if ((this._IMAGEN_BINARIO != value))
				{
					this._IMAGEN_BINARIO = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
