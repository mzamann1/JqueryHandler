﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JqueryHandler
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NIC Parent")]
	public partial class SampleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertstudent(student instance);
    partial void Updatestudent(student instance);
    partial void Deletestudent(student instance);
    partial void Insertguardian(guardian instance);
    partial void Updateguardian(guardian instance);
    partial void Deleteguardian(guardian instance);
    #endregion
		
		public SampleDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["NIC_ParentConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SampleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<student> students
		{
			get
			{
				return this.GetTable<student>();
			}
		}
		
		public System.Data.Linq.Table<guardian> guardians
		{
			get
			{
				return this.GetTable<guardian>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spAddGuardian")]
		public int spAddGuardian([global::System.Data.Linq.Mapping.ParameterAttribute(Name="F_Name", DbType="VarChar(20)")] string f_Name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="L_Name", DbType="VarChar(20)")] string l_Name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Address", DbType="VarChar(20)")] string address, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> std_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), f_Name, l_Name, address, std_id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spDltStd")]
		public int spDltStd([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetAllCount")]
		public ISingleResult<spGetAllCountResult> spGetAllCount([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> num)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), num);
			num = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((ISingleResult<spGetAllCountResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetGuardianByStdId")]
		public ISingleResult<spGetGuardianByStdIdResult> spGetGuardianByStdId([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<spGetGuardianByStdIdResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetResponseStudent")]
		public ISingleResult<spGetResponseStudentResult> spGetResponseStudent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string fname, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string lname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="class", DbType="Int")] System.Nullable<int> @class)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fname, lname, @class);
			return ((ISingleResult<spGetResponseStudentResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spindexWork")]
		public ISingleResult<student> spindexWork([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pageindex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> incr)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pageindex, incr);
			return ((ISingleResult<student>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.student")]
	public partial class student : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _std_id;
		
		private string _std_Fname;
		
		private string _std_Lname;
		
		private int _std_class;
		
		private EntitySet<guardian> _guardians;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onstd_idChanging(int value);
    partial void Onstd_idChanged();
    partial void Onstd_FnameChanging(string value);
    partial void Onstd_FnameChanged();
    partial void Onstd_LnameChanging(string value);
    partial void Onstd_LnameChanged();
    partial void Onstd_classChanging(int value);
    partial void Onstd_classChanged();
    #endregion
		
		public student()
		{
			this._guardians = new EntitySet<guardian>(new Action<guardian>(this.attach_guardians), new Action<guardian>(this.detach_guardians));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int std_id
		{
			get
			{
				return this._std_id;
			}
			set
			{
				if ((this._std_id != value))
				{
					this.Onstd_idChanging(value);
					this.SendPropertyChanging();
					this._std_id = value;
					this.SendPropertyChanged("std_id");
					this.Onstd_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_Fname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string std_Fname
		{
			get
			{
				return this._std_Fname;
			}
			set
			{
				if ((this._std_Fname != value))
				{
					this.Onstd_FnameChanging(value);
					this.SendPropertyChanging();
					this._std_Fname = value;
					this.SendPropertyChanged("std_Fname");
					this.Onstd_FnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_Lname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string std_Lname
		{
			get
			{
				return this._std_Lname;
			}
			set
			{
				if ((this._std_Lname != value))
				{
					this.Onstd_LnameChanging(value);
					this.SendPropertyChanging();
					this._std_Lname = value;
					this.SendPropertyChanged("std_Lname");
					this.Onstd_LnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_class", DbType="Int NOT NULL")]
		public int std_class
		{
			get
			{
				return this._std_class;
			}
			set
			{
				if ((this._std_class != value))
				{
					this.Onstd_classChanging(value);
					this.SendPropertyChanging();
					this._std_class = value;
					this.SendPropertyChanged("std_class");
					this.Onstd_classChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="student_guardian", Storage="_guardians", ThisKey="std_id", OtherKey="std_id")]
		public EntitySet<guardian> guardians
		{
			get
			{
				return this._guardians;
			}
			set
			{
				this._guardians.Assign(value);
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
		
		private void attach_guardians(guardian entity)
		{
			this.SendPropertyChanging();
			entity.student = this;
		}
		
		private void detach_guardians(guardian entity)
		{
			this.SendPropertyChanging();
			entity.student = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.guardian")]
	public partial class guardian : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _g_Fname;
		
		private string _g_Lname;
		
		private string _g_Address;
		
		private System.Nullable<int> _std_id;
		
		private EntityRef<student> _student;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Ong_FnameChanging(string value);
    partial void Ong_FnameChanged();
    partial void Ong_LnameChanging(string value);
    partial void Ong_LnameChanged();
    partial void Ong_AddressChanging(string value);
    partial void Ong_AddressChanged();
    partial void Onstd_idChanging(System.Nullable<int> value);
    partial void Onstd_idChanged();
    #endregion
		
		public guardian()
		{
			this._student = default(EntityRef<student>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Fname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Fname
		{
			get
			{
				return this._g_Fname;
			}
			set
			{
				if ((this._g_Fname != value))
				{
					this.Ong_FnameChanging(value);
					this.SendPropertyChanging();
					this._g_Fname = value;
					this.SendPropertyChanged("g_Fname");
					this.Ong_FnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Lname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Lname
		{
			get
			{
				return this._g_Lname;
			}
			set
			{
				if ((this._g_Lname != value))
				{
					this.Ong_LnameChanging(value);
					this.SendPropertyChanging();
					this._g_Lname = value;
					this.SendPropertyChanged("g_Lname");
					this.Ong_LnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Address", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Address
		{
			get
			{
				return this._g_Address;
			}
			set
			{
				if ((this._g_Address != value))
				{
					this.Ong_AddressChanging(value);
					this.SendPropertyChanging();
					this._g_Address = value;
					this.SendPropertyChanged("g_Address");
					this.Ong_AddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_id", DbType="Int")]
		public System.Nullable<int> std_id
		{
			get
			{
				return this._std_id;
			}
			set
			{
				if ((this._std_id != value))
				{
					if (this._student.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onstd_idChanging(value);
					this.SendPropertyChanging();
					this._std_id = value;
					this.SendPropertyChanged("std_id");
					this.Onstd_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="student_guardian", Storage="_student", ThisKey="std_id", OtherKey="std_id", IsForeignKey=true)]
		public student student
		{
			get
			{
				return this._student.Entity;
			}
			set
			{
				student previousValue = this._student.Entity;
				if (((previousValue != value) 
							|| (this._student.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._student.Entity = null;
						previousValue.guardians.Remove(this);
					}
					this._student.Entity = value;
					if ((value != null))
					{
						value.guardians.Add(this);
						this._std_id = value.std_id;
					}
					else
					{
						this._std_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("student");
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
	
	public partial class spGetAllCountResult
	{
		
		private System.Nullable<int> _Column1;
		
		public spGetAllCountResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
	
	public partial class spGetGuardianByStdIdResult
	{
		
		private string _g_Fname;
		
		private string _g_Lname;
		
		private string _g_Address;
		
		public spGetGuardianByStdIdResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Fname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Fname
		{
			get
			{
				return this._g_Fname;
			}
			set
			{
				if ((this._g_Fname != value))
				{
					this._g_Fname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Lname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Lname
		{
			get
			{
				return this._g_Lname;
			}
			set
			{
				if ((this._g_Lname != value))
				{
					this._g_Lname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_g_Address", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string g_Address
		{
			get
			{
				return this._g_Address;
			}
			set
			{
				if ((this._g_Address != value))
				{
					this._g_Address = value;
				}
			}
		}
	}
	
	public partial class spGetResponseStudentResult
	{
		
		private int _std_id;
		
		private string _std_Fname;
		
		private string _std_Lname;
		
		private int _std_class;
		
		public spGetResponseStudentResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_id", DbType="Int NOT NULL")]
		public int std_id
		{
			get
			{
				return this._std_id;
			}
			set
			{
				if ((this._std_id != value))
				{
					this._std_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_Fname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string std_Fname
		{
			get
			{
				return this._std_Fname;
			}
			set
			{
				if ((this._std_Fname != value))
				{
					this._std_Fname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_Lname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string std_Lname
		{
			get
			{
				return this._std_Lname;
			}
			set
			{
				if ((this._std_Lname != value))
				{
					this._std_Lname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_std_class", DbType="Int NOT NULL")]
		public int std_class
		{
			get
			{
				return this._std_class;
			}
			set
			{
				if ((this._std_class != value))
				{
					this._std_class = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
