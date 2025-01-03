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

namespace Proiect_ABD
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TabaraDeVara")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertActivitate(Activitate instance);
    partial void UpdateActivitate(Activitate instance);
    partial void DeleteActivitate(Activitate instance);
    partial void InsertCopil(Copil instance);
    partial void UpdateCopil(Copil instance);
    partial void DeleteCopil(Copil instance);
    partial void InsertCopilActivitate(CopilActivitate instance);
    partial void UpdateCopilActivitate(CopilActivitate instance);
    partial void DeleteCopilActivitate(CopilActivitate instance);
    partial void InsertCopilParinte(CopilParinte instance);
    partial void UpdateCopilParinte(CopilParinte instance);
    partial void DeleteCopilParinte(CopilParinte instance);
    partial void InsertEducator(Educator instance);
    partial void UpdateEducator(Educator instance);
    partial void DeleteEducator(Educator instance);
    partial void InsertParinte(Parinte instance);
    partial void UpdateParinte(Parinte instance);
    partial void DeleteParinte(Parinte instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::Proiect_ABD.Properties.Settings.Default.TabaraDeVaraConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Activitate> Activitates
		{
			get
			{
				return this.GetTable<Activitate>();
			}
		}
		
		public System.Data.Linq.Table<Copil> Copils
		{
			get
			{
				return this.GetTable<Copil>();
			}
		}
		
		public System.Data.Linq.Table<CopilActivitate> CopilActivitates
		{
			get
			{
				return this.GetTable<CopilActivitate>();
			}
		}
		
		public System.Data.Linq.Table<CopilParinte> CopilParintes
		{
			get
			{
				return this.GetTable<CopilParinte>();
			}
		}
		
		public System.Data.Linq.Table<Educator> Educators
		{
			get
			{
				return this.GetTable<Educator>();
			}
		}
		
		public System.Data.Linq.Table<Parinte> Parintes
		{
			get
			{
				return this.GetTable<Parinte>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Activitate")]
	public partial class Activitate : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActivitateID;
		
		private string _Nume;
		
		private string _Descriere;
		
		private System.DateTime _Data;
		
		private System.TimeSpan _Ora;
		
		private int _Durata;
		
		private int _EducatorID;
		
		private EntitySet<CopilActivitate> _CopilActivitates;
		
		private EntityRef<Educator> _Educator;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivitateIDChanging(int value);
    partial void OnActivitateIDChanged();
    partial void OnNumeChanging(string value);
    partial void OnNumeChanged();
    partial void OnDescriereChanging(string value);
    partial void OnDescriereChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    partial void OnOraChanging(System.TimeSpan value);
    partial void OnOraChanged();
    partial void OnDurataChanging(int value);
    partial void OnDurataChanged();
    partial void OnEducatorIDChanging(int value);
    partial void OnEducatorIDChanged();
    #endregion
		
		public Activitate()
		{
			this._CopilActivitates = new EntitySet<CopilActivitate>(new Action<CopilActivitate>(this.attach_CopilActivitates), new Action<CopilActivitate>(this.detach_CopilActivitates));
			this._Educator = default(EntityRef<Educator>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivitateID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ActivitateID
		{
			get
			{
				return this._ActivitateID;
			}
			set
			{
				if ((this._ActivitateID != value))
				{
					this.OnActivitateIDChanging(value);
					this.SendPropertyChanging();
					this._ActivitateID = value;
					this.SendPropertyChanged("ActivitateID");
					this.OnActivitateIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nume", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descriere", DbType="NVarChar(255)")]
		public string Descriere
		{
			get
			{
				return this._Descriere;
			}
			set
			{
				if ((this._Descriere != value))
				{
					this.OnDescriereChanging(value);
					this.SendPropertyChanging();
					this._Descriere = value;
					this.SendPropertyChanged("Descriere");
					this.OnDescriereChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="Date NOT NULL")]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ora", DbType="Time NOT NULL")]
		public System.TimeSpan Ora
		{
			get
			{
				return this._Ora;
			}
			set
			{
				if ((this._Ora != value))
				{
					this.OnOraChanging(value);
					this.SendPropertyChanging();
					this._Ora = value;
					this.SendPropertyChanged("Ora");
					this.OnOraChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Durata", DbType="Int NOT NULL")]
		public int Durata
		{
			get
			{
				return this._Durata;
			}
			set
			{
				if ((this._Durata != value))
				{
					this.OnDurataChanging(value);
					this.SendPropertyChanging();
					this._Durata = value;
					this.SendPropertyChanged("Durata");
					this.OnDurataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EducatorID", DbType="Int NOT NULL")]
		public int EducatorID
		{
			get
			{
				return this._EducatorID;
			}
			set
			{
				if ((this._EducatorID != value))
				{
					if (this._Educator.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEducatorIDChanging(value);
					this.SendPropertyChanging();
					this._EducatorID = value;
					this.SendPropertyChanged("EducatorID");
					this.OnEducatorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Activitate_CopilActivitate", Storage="_CopilActivitates", ThisKey="ActivitateID", OtherKey="ActivitateID")]
		public EntitySet<CopilActivitate> CopilActivitates
		{
			get
			{
				return this._CopilActivitates;
			}
			set
			{
				this._CopilActivitates.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Educator_Activitate", Storage="_Educator", ThisKey="EducatorID", OtherKey="EducatorID", IsForeignKey=true)]
		public Educator Educator
		{
			get
			{
				return this._Educator.Entity;
			}
			set
			{
				Educator previousValue = this._Educator.Entity;
				if (((previousValue != value) 
							|| (this._Educator.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Educator.Entity = null;
						previousValue.Activitates.Remove(this);
					}
					this._Educator.Entity = value;
					if ((value != null))
					{
						value.Activitates.Add(this);
						this._EducatorID = value.EducatorID;
					}
					else
					{
						this._EducatorID = default(int);
					}
					this.SendPropertyChanged("Educator");
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
		
		private void attach_CopilActivitates(CopilActivitate entity)
		{
			this.SendPropertyChanging();
			entity.Activitate = this;
		}
		
		private void detach_CopilActivitates(CopilActivitate entity)
		{
			this.SendPropertyChanging();
			entity.Activitate = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Copil")]
	public partial class Copil : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CopilID;
		
		private string _Nume;
		
		private string _Prenume;
		
		private int _Varsta;
		
		private string _Parola;
		
		private int _EducatorID;
		
		private EntitySet<CopilActivitate> _CopilActivitates;
		
		private EntitySet<CopilParinte> _CopilParintes;
		
		private EntityRef<Educator> _Educator;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCopilIDChanging(int value);
    partial void OnCopilIDChanged();
    partial void OnNumeChanging(string value);
    partial void OnNumeChanged();
    partial void OnPrenumeChanging(string value);
    partial void OnPrenumeChanged();
    partial void OnVarstaChanging(int value);
    partial void OnVarstaChanged();
    partial void OnParolaChanging(string value);
    partial void OnParolaChanged();
    partial void OnEducatorIDChanging(int value);
    partial void OnEducatorIDChanged();
    #endregion
		
		public Copil()
		{
			this._CopilActivitates = new EntitySet<CopilActivitate>(new Action<CopilActivitate>(this.attach_CopilActivitates), new Action<CopilActivitate>(this.detach_CopilActivitates));
			this._CopilParintes = new EntitySet<CopilParinte>(new Action<CopilParinte>(this.attach_CopilParintes), new Action<CopilParinte>(this.detach_CopilParintes));
			this._Educator = default(EntityRef<Educator>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CopilID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CopilID
		{
			get
			{
				return this._CopilID;
			}
			set
			{
				if ((this._CopilID != value))
				{
					this.OnCopilIDChanging(value);
					this.SendPropertyChanging();
					this._CopilID = value;
					this.SendPropertyChanged("CopilID");
					this.OnCopilIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Varsta", DbType="Int NOT NULL")]
		public int Varsta
		{
			get
			{
				return this._Varsta;
			}
			set
			{
				if ((this._Varsta != value))
				{
					this.OnVarstaChanging(value);
					this.SendPropertyChanging();
					this._Varsta = value;
					this.SendPropertyChanged("Varsta");
					this.OnVarstaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parola", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Parola
		{
			get
			{
				return this._Parola;
			}
			set
			{
				if ((this._Parola != value))
				{
					this.OnParolaChanging(value);
					this.SendPropertyChanging();
					this._Parola = value;
					this.SendPropertyChanged("Parola");
					this.OnParolaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EducatorID", DbType="Int NOT NULL")]
		public int EducatorID
		{
			get
			{
				return this._EducatorID;
			}
			set
			{
				if ((this._EducatorID != value))
				{
					if (this._Educator.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEducatorIDChanging(value);
					this.SendPropertyChanging();
					this._EducatorID = value;
					this.SendPropertyChanged("EducatorID");
					this.OnEducatorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Copil_CopilActivitate", Storage="_CopilActivitates", ThisKey="CopilID", OtherKey="CopilID")]
		public EntitySet<CopilActivitate> CopilActivitates
		{
			get
			{
				return this._CopilActivitates;
			}
			set
			{
				this._CopilActivitates.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Copil_CopilParinte", Storage="_CopilParintes", ThisKey="CopilID", OtherKey="CopilID")]
		public EntitySet<CopilParinte> CopilParintes
		{
			get
			{
				return this._CopilParintes;
			}
			set
			{
				this._CopilParintes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Educator_Copil", Storage="_Educator", ThisKey="EducatorID", OtherKey="EducatorID", IsForeignKey=true)]
		public Educator Educator
		{
			get
			{
				return this._Educator.Entity;
			}
			set
			{
				Educator previousValue = this._Educator.Entity;
				if (((previousValue != value) 
							|| (this._Educator.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Educator.Entity = null;
						previousValue.Copils.Remove(this);
					}
					this._Educator.Entity = value;
					if ((value != null))
					{
						value.Copils.Add(this);
						this._EducatorID = value.EducatorID;
					}
					else
					{
						this._EducatorID = default(int);
					}
					this.SendPropertyChanged("Educator");
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
		
		private void attach_CopilActivitates(CopilActivitate entity)
		{
			this.SendPropertyChanging();
			entity.Copil = this;
		}
		
		private void detach_CopilActivitates(CopilActivitate entity)
		{
			this.SendPropertyChanging();
			entity.Copil = null;
		}
		
		private void attach_CopilParintes(CopilParinte entity)
		{
			this.SendPropertyChanging();
			entity.Copil = this;
		}
		
		private void detach_CopilParintes(CopilParinte entity)
		{
			this.SendPropertyChanging();
			entity.Copil = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CopilActivitate")]
	public partial class CopilActivitate : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CopilID;
		
		private int _ActivitateID;
		
		private bool _Prezenta;
		
		private string _Observatii;
		
		private EntityRef<Activitate> _Activitate;
		
		private EntityRef<Copil> _Copil;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCopilIDChanging(int value);
    partial void OnCopilIDChanged();
    partial void OnActivitateIDChanging(int value);
    partial void OnActivitateIDChanged();
    partial void OnPrezentaChanging(bool value);
    partial void OnPrezentaChanged();
    partial void OnObservatiiChanging(string value);
    partial void OnObservatiiChanged();
    #endregion
		
		public CopilActivitate()
		{
			this._Activitate = default(EntityRef<Activitate>);
			this._Copil = default(EntityRef<Copil>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CopilID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CopilID
		{
			get
			{
				return this._CopilID;
			}
			set
			{
				if ((this._CopilID != value))
				{
					if (this._Copil.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCopilIDChanging(value);
					this.SendPropertyChanging();
					this._CopilID = value;
					this.SendPropertyChanged("CopilID");
					this.OnCopilIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivitateID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ActivitateID
		{
			get
			{
				return this._ActivitateID;
			}
			set
			{
				if ((this._ActivitateID != value))
				{
					if (this._Activitate.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivitateIDChanging(value);
					this.SendPropertyChanging();
					this._ActivitateID = value;
					this.SendPropertyChanged("ActivitateID");
					this.OnActivitateIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prezenta", DbType="Bit NOT NULL")]
		public bool Prezenta
		{
			get
			{
				return this._Prezenta;
			}
			set
			{
				if ((this._Prezenta != value))
				{
					this.OnPrezentaChanging(value);
					this.SendPropertyChanging();
					this._Prezenta = value;
					this.SendPropertyChanged("Prezenta");
					this.OnPrezentaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Observatii", DbType="VarChar(255)")]
		public string Observatii
		{
			get
			{
				return this._Observatii;
			}
			set
			{
				if ((this._Observatii != value))
				{
					this.OnObservatiiChanging(value);
					this.SendPropertyChanging();
					this._Observatii = value;
					this.SendPropertyChanged("Observatii");
					this.OnObservatiiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Activitate_CopilActivitate", Storage="_Activitate", ThisKey="ActivitateID", OtherKey="ActivitateID", IsForeignKey=true)]
		public Activitate Activitate
		{
			get
			{
				return this._Activitate.Entity;
			}
			set
			{
				Activitate previousValue = this._Activitate.Entity;
				if (((previousValue != value) 
							|| (this._Activitate.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Activitate.Entity = null;
						previousValue.CopilActivitates.Remove(this);
					}
					this._Activitate.Entity = value;
					if ((value != null))
					{
						value.CopilActivitates.Add(this);
						this._ActivitateID = value.ActivitateID;
					}
					else
					{
						this._ActivitateID = default(int);
					}
					this.SendPropertyChanged("Activitate");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Copil_CopilActivitate", Storage="_Copil", ThisKey="CopilID", OtherKey="CopilID", IsForeignKey=true)]
		public Copil Copil
		{
			get
			{
				return this._Copil.Entity;
			}
			set
			{
				Copil previousValue = this._Copil.Entity;
				if (((previousValue != value) 
							|| (this._Copil.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Copil.Entity = null;
						previousValue.CopilActivitates.Remove(this);
					}
					this._Copil.Entity = value;
					if ((value != null))
					{
						value.CopilActivitates.Add(this);
						this._CopilID = value.CopilID;
					}
					else
					{
						this._CopilID = default(int);
					}
					this.SendPropertyChanged("Copil");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CopilParinte")]
	public partial class CopilParinte : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CopilID;
		
		private int _ParinteID;
		
		private EntityRef<Copil> _Copil;
		
		private EntityRef<Parinte> _Parinte;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCopilIDChanging(int value);
    partial void OnCopilIDChanged();
    partial void OnParinteIDChanging(int value);
    partial void OnParinteIDChanged();
    #endregion
		
		public CopilParinte()
		{
			this._Copil = default(EntityRef<Copil>);
			this._Parinte = default(EntityRef<Parinte>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CopilID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CopilID
		{
			get
			{
				return this._CopilID;
			}
			set
			{
				if ((this._CopilID != value))
				{
					if (this._Copil.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCopilIDChanging(value);
					this.SendPropertyChanging();
					this._CopilID = value;
					this.SendPropertyChanged("CopilID");
					this.OnCopilIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParinteID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ParinteID
		{
			get
			{
				return this._ParinteID;
			}
			set
			{
				if ((this._ParinteID != value))
				{
					if (this._Parinte.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParinteIDChanging(value);
					this.SendPropertyChanging();
					this._ParinteID = value;
					this.SendPropertyChanged("ParinteID");
					this.OnParinteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Copil_CopilParinte", Storage="_Copil", ThisKey="CopilID", OtherKey="CopilID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Copil Copil
		{
			get
			{
				return this._Copil.Entity;
			}
			set
			{
				Copil previousValue = this._Copil.Entity;
				if (((previousValue != value) 
							|| (this._Copil.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Copil.Entity = null;
						previousValue.CopilParintes.Remove(this);
					}
					this._Copil.Entity = value;
					if ((value != null))
					{
						value.CopilParintes.Add(this);
						this._CopilID = value.CopilID;
					}
					else
					{
						this._CopilID = default(int);
					}
					this.SendPropertyChanged("Copil");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Parinte_CopilParinte", Storage="_Parinte", ThisKey="ParinteID", OtherKey="ParinteID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Parinte Parinte
		{
			get
			{
				return this._Parinte.Entity;
			}
			set
			{
				Parinte previousValue = this._Parinte.Entity;
				if (((previousValue != value) 
							|| (this._Parinte.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Parinte.Entity = null;
						previousValue.CopilParintes.Remove(this);
					}
					this._Parinte.Entity = value;
					if ((value != null))
					{
						value.CopilParintes.Add(this);
						this._ParinteID = value.ParinteID;
					}
					else
					{
						this._ParinteID = default(int);
					}
					this.SendPropertyChanged("Parinte");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Educator")]
	public partial class Educator : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EducatorID;
		
		private string _Nume;
		
		private string _Prenume;
		
		private string _Parola;
		
		private string _NumarTel;
		
		private string _Email;
		
		private EntitySet<Activitate> _Activitates;
		
		private EntitySet<Copil> _Copils;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEducatorIDChanging(int value);
    partial void OnEducatorIDChanged();
    partial void OnNumeChanging(string value);
    partial void OnNumeChanged();
    partial void OnPrenumeChanging(string value);
    partial void OnPrenumeChanged();
    partial void OnParolaChanging(string value);
    partial void OnParolaChanged();
    partial void OnNumarTelChanging(string value);
    partial void OnNumarTelChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Educator()
		{
			this._Activitates = new EntitySet<Activitate>(new Action<Activitate>(this.attach_Activitates), new Action<Activitate>(this.detach_Activitates));
			this._Copils = new EntitySet<Copil>(new Action<Copil>(this.attach_Copils), new Action<Copil>(this.detach_Copils));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EducatorID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EducatorID
		{
			get
			{
				return this._EducatorID;
			}
			set
			{
				if ((this._EducatorID != value))
				{
					this.OnEducatorIDChanging(value);
					this.SendPropertyChanging();
					this._EducatorID = value;
					this.SendPropertyChanged("EducatorID");
					this.OnEducatorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parola", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Parola
		{
			get
			{
				return this._Parola;
			}
			set
			{
				if ((this._Parola != value))
				{
					this.OnParolaChanging(value);
					this.SendPropertyChanging();
					this._Parola = value;
					this.SendPropertyChanged("Parola");
					this.OnParolaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumarTel", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string NumarTel
		{
			get
			{
				return this._NumarTel;
			}
			set
			{
				if ((this._NumarTel != value))
				{
					this.OnNumarTelChanging(value);
					this.SendPropertyChanging();
					this._NumarTel = value;
					this.SendPropertyChanged("NumarTel");
					this.OnNumarTelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Educator_Activitate", Storage="_Activitates", ThisKey="EducatorID", OtherKey="EducatorID")]
		public EntitySet<Activitate> Activitates
		{
			get
			{
				return this._Activitates;
			}
			set
			{
				this._Activitates.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Educator_Copil", Storage="_Copils", ThisKey="EducatorID", OtherKey="EducatorID")]
		public EntitySet<Copil> Copils
		{
			get
			{
				return this._Copils;
			}
			set
			{
				this._Copils.Assign(value);
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
		
		private void attach_Activitates(Activitate entity)
		{
			this.SendPropertyChanging();
			entity.Educator = this;
		}
		
		private void detach_Activitates(Activitate entity)
		{
			this.SendPropertyChanging();
			entity.Educator = null;
		}
		
		private void attach_Copils(Copil entity)
		{
			this.SendPropertyChanging();
			entity.Educator = this;
		}
		
		private void detach_Copils(Copil entity)
		{
			this.SendPropertyChanging();
			entity.Educator = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Parinte")]
	public partial class Parinte : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ParinteID;
		
		private string _Nume;
		
		private string _Prenume;
		
		private string _Parola;
		
		private string _NumarTel;
		
		private string _Email;
		
		private EntitySet<CopilParinte> _CopilParintes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnParinteIDChanging(int value);
    partial void OnParinteIDChanged();
    partial void OnNumeChanging(string value);
    partial void OnNumeChanged();
    partial void OnPrenumeChanging(string value);
    partial void OnPrenumeChanged();
    partial void OnParolaChanging(string value);
    partial void OnParolaChanged();
    partial void OnNumarTelChanging(string value);
    partial void OnNumarTelChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Parinte()
		{
			this._CopilParintes = new EntitySet<CopilParinte>(new Action<CopilParinte>(this.attach_CopilParintes), new Action<CopilParinte>(this.detach_CopilParintes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParinteID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ParinteID
		{
			get
			{
				return this._ParinteID;
			}
			set
			{
				if ((this._ParinteID != value))
				{
					this.OnParinteIDChanging(value);
					this.SendPropertyChanging();
					this._ParinteID = value;
					this.SendPropertyChanged("ParinteID");
					this.OnParinteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenume", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parola", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Parola
		{
			get
			{
				return this._Parola;
			}
			set
			{
				if ((this._Parola != value))
				{
					this.OnParolaChanging(value);
					this.SendPropertyChanging();
					this._Parola = value;
					this.SendPropertyChanged("Parola");
					this.OnParolaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumarTel", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string NumarTel
		{
			get
			{
				return this._NumarTel;
			}
			set
			{
				if ((this._NumarTel != value))
				{
					this.OnNumarTelChanging(value);
					this.SendPropertyChanging();
					this._NumarTel = value;
					this.SendPropertyChanged("NumarTel");
					this.OnNumarTelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Parinte_CopilParinte", Storage="_CopilParintes", ThisKey="ParinteID", OtherKey="ParinteID")]
		public EntitySet<CopilParinte> CopilParintes
		{
			get
			{
				return this._CopilParintes;
			}
			set
			{
				this._CopilParintes.Assign(value);
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
		
		private void attach_CopilParintes(CopilParinte entity)
		{
			this.SendPropertyChanging();
			entity.Parinte = this;
		}
		
		private void detach_CopilParintes(CopilParinte entity)
		{
			this.SendPropertyChanging();
			entity.Parinte = null;
		}
	}
}
#pragma warning restore 1591
