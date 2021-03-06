#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL_AdreseDB_Practica.Adrese
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AdreseDB")]
	public partial class AdreseDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAdreseTable(AdreseTable instance);
    partial void UpdateAdreseTable(AdreseTable instance);
    partial void DeleteAdreseTable(AdreseTable instance);
    partial void InsertPersoaneTable(PersoaneTable instance);
    partial void UpdatePersoaneTable(PersoaneTable instance);
    partial void DeletePersoaneTable(PersoaneTable instance);
    #endregion
		
		public AdreseDBDataContext() : 
				base(global::SQL_AdreseDB_Practica.Properties.Settings.Default.AdreseDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AdreseDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdreseDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdreseDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdreseDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<AdreseTable> AdreseTables
		{
			get
			{
				return this.GetTable<AdreseTable>();
			}
		}
		
		public System.Data.Linq.Table<PersoaneTable> PersoaneTables
		{
			get
			{
				return this.GetTable<PersoaneTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AdreseTable")]
	public partial class AdreseTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAdresa;
		
		private string _Municipiu;
		
		private string _Judet;
		
		private string _Oras;
		
		private string _Comuna;
		
		private string _Sat;
		
		private string _Strada;
		
		private string _Numar;
		
		private string _Bloc;
		
		private string _Scara;
		
		private int _IdPersoana;
		
		private EntityRef<PersoaneTable> _PersoaneTable;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAdresaChanging(int value);
    partial void OnIdAdresaChanged();
    partial void OnMunicipiuChanging(string value);
    partial void OnMunicipiuChanged();
    partial void OnJudetChanging(string value);
    partial void OnJudetChanged();
    partial void OnOrasChanging(string value);
    partial void OnOrasChanged();
    partial void OnComunaChanging(string value);
    partial void OnComunaChanged();
    partial void OnSatChanging(string value);
    partial void OnSatChanged();
    partial void OnStradaChanging(string value);
    partial void OnStradaChanged();
    partial void OnNumarChanging(string value);
    partial void OnNumarChanged();
    partial void OnBlocChanging(string value);
    partial void OnBlocChanged();
    partial void OnScaraChanging(string value);
    partial void OnScaraChanged();
    partial void OnIdPersoanaChanging(int value);
    partial void OnIdPersoanaChanged();
    #endregion
		
		public AdreseTable()
		{
			this._PersoaneTable = default(EntityRef<PersoaneTable>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAdresa", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdAdresa
		{
			get
			{
				return this._IdAdresa;
			}
			set
			{
				if ((this._IdAdresa != value))
				{
					this.OnIdAdresaChanging(value);
					this.SendPropertyChanging();
					this._IdAdresa = value;
					this.SendPropertyChanged("IdAdresa");
					this.OnIdAdresaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Municipiu", DbType="VarChar(50)")]
		public string Municipiu
		{
			get
			{
				return this._Municipiu;
			}
			set
			{
				if ((this._Municipiu != value))
				{
					this.OnMunicipiuChanging(value);
					this.SendPropertyChanging();
					this._Municipiu = value;
					this.SendPropertyChanged("Municipiu");
					this.OnMunicipiuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Judet", DbType="VarChar(50)")]
		public string Judet
		{
			get
			{
				return this._Judet;
			}
			set
			{
				if ((this._Judet != value))
				{
					this.OnJudetChanging(value);
					this.SendPropertyChanging();
					this._Judet = value;
					this.SendPropertyChanged("Judet");
					this.OnJudetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Oras", DbType="VarChar(50)")]
		public string Oras
		{
			get
			{
				return this._Oras;
			}
			set
			{
				if ((this._Oras != value))
				{
					this.OnOrasChanging(value);
					this.SendPropertyChanging();
					this._Oras = value;
					this.SendPropertyChanged("Oras");
					this.OnOrasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comuna", DbType="VarChar(50)")]
		public string Comuna
		{
			get
			{
				return this._Comuna;
			}
			set
			{
				if ((this._Comuna != value))
				{
					this.OnComunaChanging(value);
					this.SendPropertyChanging();
					this._Comuna = value;
					this.SendPropertyChanged("Comuna");
					this.OnComunaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sat", DbType="VarChar(50)")]
		public string Sat
		{
			get
			{
				return this._Sat;
			}
			set
			{
				if ((this._Sat != value))
				{
					this.OnSatChanging(value);
					this.SendPropertyChanging();
					this._Sat = value;
					this.SendPropertyChanged("Sat");
					this.OnSatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Strada", DbType="VarChar(50)")]
		public string Strada
		{
			get
			{
				return this._Strada;
			}
			set
			{
				if ((this._Strada != value))
				{
					this.OnStradaChanging(value);
					this.SendPropertyChanging();
					this._Strada = value;
					this.SendPropertyChanged("Strada");
					this.OnStradaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Numar", DbType="VarChar(10)")]
		public string Numar
		{
			get
			{
				return this._Numar;
			}
			set
			{
				if ((this._Numar != value))
				{
					this.OnNumarChanging(value);
					this.SendPropertyChanging();
					this._Numar = value;
					this.SendPropertyChanged("Numar");
					this.OnNumarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bloc", DbType="VarChar(10)")]
		public string Bloc
		{
			get
			{
				return this._Bloc;
			}
			set
			{
				if ((this._Bloc != value))
				{
					this.OnBlocChanging(value);
					this.SendPropertyChanging();
					this._Bloc = value;
					this.SendPropertyChanged("Bloc");
					this.OnBlocChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Scara", DbType="VarChar(10)")]
		public string Scara
		{
			get
			{
				return this._Scara;
			}
			set
			{
				if ((this._Scara != value))
				{
					this.OnScaraChanging(value);
					this.SendPropertyChanging();
					this._Scara = value;
					this.SendPropertyChanged("Scara");
					this.OnScaraChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPersoana", DbType="Int NOT NULL")]
		public int IdPersoana
		{
			get
			{
				return this._IdPersoana;
			}
			set
			{
				if ((this._IdPersoana != value))
				{
					if (this._PersoaneTable.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdPersoanaChanging(value);
					this.SendPropertyChanging();
					this._IdPersoana = value;
					this.SendPropertyChanged("IdPersoana");
					this.OnIdPersoanaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PersoaneTable_AdreseTable", Storage="_PersoaneTable", ThisKey="IdPersoana", OtherKey="IdPersoana", IsForeignKey=true)]
		public PersoaneTable PersoaneTable
		{
			get
			{
				return this._PersoaneTable.Entity;
			}
			set
			{
				PersoaneTable previousValue = this._PersoaneTable.Entity;
				if (((previousValue != value) 
							|| (this._PersoaneTable.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PersoaneTable.Entity = null;
						previousValue.AdreseTables.Remove(this);
					}
					this._PersoaneTable.Entity = value;
					if ((value != null))
					{
						value.AdreseTables.Add(this);
						this._IdPersoana = value.IdPersoana;
					}
					else
					{
						this._IdPersoana = default(int);
					}
					this.SendPropertyChanged("PersoaneTable");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PersoaneTable")]
	public partial class PersoaneTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdPersoana;
		
		private string _Nume;
		
		private string _Prenume;
		
		private string _Sex;
		
		private System.Nullable<System.DateTime> _DataNasteri;
		
		private string _CNP;
		
		private EntitySet<AdreseTable> _AdreseTables;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdPersoanaChanging(int value);
    partial void OnIdPersoanaChanged();
    partial void OnNumeChanging(string value);
    partial void OnNumeChanged();
    partial void OnPrenumeChanging(string value);
    partial void OnPrenumeChanged();
    partial void OnSexChanging(string value);
    partial void OnSexChanged();
    partial void OnDataNasteriChanging(System.Nullable<System.DateTime> value);
    partial void OnDataNasteriChanged();
    partial void OnCNPChanging(string value);
    partial void OnCNPChanged();
    #endregion
		
		public PersoaneTable()
		{
			this._AdreseTables = new EntitySet<AdreseTable>(new Action<AdreseTable>(this.attach_AdreseTables), new Action<AdreseTable>(this.detach_AdreseTables));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPersoana", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdPersoana
		{
			get
			{
				return this._IdPersoana;
			}
			set
			{
				if ((this._IdPersoana != value))
				{
					this.OnIdPersoanaChanging(value);
					this.SendPropertyChanging();
					this._IdPersoana = value;
					this.SendPropertyChanged("IdPersoana");
					this.OnIdPersoanaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nume", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nume
		{
			get
			{
				return this._Nume;
			}
			set
			{
				if ((this._Nume != value))
				{
					this.OnNumeChanging(value);
					this.SendPropertyChanging();
					this._Nume = value;
					this.SendPropertyChanged("Nume");
					this.OnNumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenume", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Prenume
		{
			get
			{
				return this._Prenume;
			}
			set
			{
				if ((this._Prenume != value))
				{
					this.OnPrenumeChanging(value);
					this.SendPropertyChanging();
					this._Prenume = value;
					this.SendPropertyChanged("Prenume");
					this.OnPrenumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="VarChar(10)")]
		public string Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataNasteri", DbType="Date")]
		public System.Nullable<System.DateTime> DataNasteri
		{
			get
			{
				return this._DataNasteri;
			}
			set
			{
				if ((this._DataNasteri != value))
				{
					this.OnDataNasteriChanging(value);
					this.SendPropertyChanging();
					this._DataNasteri = value;
					this.SendPropertyChanged("DataNasteri");
					this.OnDataNasteriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CNP", DbType="VarChar(13)")]
		public string CNP
		{
			get
			{
				return this._CNP;
			}
			set
			{
				if ((this._CNP != value))
				{
					this.OnCNPChanging(value);
					this.SendPropertyChanging();
					this._CNP = value;
					this.SendPropertyChanged("CNP");
					this.OnCNPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PersoaneTable_AdreseTable", Storage="_AdreseTables", ThisKey="IdPersoana", OtherKey="IdPersoana")]
		public EntitySet<AdreseTable> AdreseTables
		{
			get
			{
				return this._AdreseTables;
			}
			set
			{
				this._AdreseTables.Assign(value);
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
		
		private void attach_AdreseTables(AdreseTable entity)
		{
			this.SendPropertyChanging();
			entity.PersoaneTable = this;
		}
		
		private void detach_AdreseTables(AdreseTable entity)
		{
			this.SendPropertyChanging();
			entity.PersoaneTable = null;
		}
	}
}
#pragma warning restore 1591
