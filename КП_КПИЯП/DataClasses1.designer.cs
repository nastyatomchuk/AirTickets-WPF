﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace КП_КПИЯП
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TravelAgency")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertCity(City instance);
    partial void UpdateCity(City instance);
    partial void DeleteCity(City instance);
    partial void InsertHotel(Hotel instance);
    partial void UpdateHotel(Hotel instance);
    partial void DeleteHotel(Hotel instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertTour(Tour instance);
    partial void UpdateTour(Tour instance);
    partial void DeleteTour(Tour instance);
    partial void InsertVoucher(Voucher instance);
    partial void UpdateVoucher(Voucher instance);
    partial void DeleteVoucher(Voucher instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::КП_КПИЯП.Properties.Settings.Default.TravelAgencyConnectionString1, mappingSource)
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
		
		public System.Data.Linq.Table<City> City
		{
			get
			{
				return this.GetTable<City>();
			}
		}
		
		public System.Data.Linq.Table<Hotel> Hotel
		{
			get
			{
				return this.GetTable<Hotel>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Tour> Tour
		{
			get
			{
				return this.GetTable<Tour>();
			}
		}
		
		public System.Data.Linq.Table<Voucher> Voucher
		{
			get
			{
				return this.GetTable<Voucher>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.City")]
	public partial class City : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_city;
		
		private string _city_name;
		
		private EntitySet<Hotel> _Hotel;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_cityChanging(int value);
    partial void Onid_cityChanged();
    partial void Oncity_nameChanging(string value);
    partial void Oncity_nameChanged();
    #endregion
		
		public City()
		{
			this._Hotel = new EntitySet<Hotel>(new Action<Hotel>(this.attach_Hotel), new Action<Hotel>(this.detach_Hotel));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_city", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_city
		{
			get
			{
				return this._id_city;
			}
			set
			{
				if ((this._id_city != value))
				{
					this.Onid_cityChanging(value);
					this.SendPropertyChanging();
					this._id_city = value;
					this.SendPropertyChanged("id_city");
					this.Onid_cityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city_name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string city_name
		{
			get
			{
				return this._city_name;
			}
			set
			{
				if ((this._city_name != value))
				{
					this.Oncity_nameChanging(value);
					this.SendPropertyChanging();
					this._city_name = value;
					this.SendPropertyChanged("city_name");
					this.Oncity_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="City_Hotel", Storage="_Hotel", ThisKey="id_city", OtherKey="id_city")]
		public EntitySet<Hotel> Hotel
		{
			get
			{
				return this._Hotel;
			}
			set
			{
				this._Hotel.Assign(value);
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
		
		private void attach_Hotel(Hotel entity)
		{
			this.SendPropertyChanging();
			entity.City = this;
		}
		
		private void detach_Hotel(Hotel entity)
		{
			this.SendPropertyChanging();
			entity.City = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Hotel")]
	public partial class Hotel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_hotel;
		
		private int _id_city;
		
		private string _hotel_name;
		
		private int _class;
		
		private double _pay_on_day;
		
		private string _desctiption;
		
		private System.Data.Linq.Binary _image;
		
		private EntitySet<Tour> _Tour;
		
		private EntityRef<City> _City;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_hotelChanging(int value);
    partial void Onid_hotelChanged();
    partial void Onid_cityChanging(int value);
    partial void Onid_cityChanged();
    partial void Onhotel_nameChanging(string value);
    partial void Onhotel_nameChanged();
    partial void OnclassChanging(int value);
    partial void OnclassChanged();
    partial void Onpay_on_dayChanging(double value);
    partial void Onpay_on_dayChanged();
    partial void OndesctiptionChanging(string value);
    partial void OndesctiptionChanged();
    partial void OnimageChanging(System.Data.Linq.Binary value);
    partial void OnimageChanged();
    #endregion
		
		public Hotel()
		{
			this._Tour = new EntitySet<Tour>(new Action<Tour>(this.attach_Tour), new Action<Tour>(this.detach_Tour));
			this._City = default(EntityRef<City>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_hotel", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_hotel
		{
			get
			{
				return this._id_hotel;
			}
			set
			{
				if ((this._id_hotel != value))
				{
					this.Onid_hotelChanging(value);
					this.SendPropertyChanging();
					this._id_hotel = value;
					this.SendPropertyChanged("id_hotel");
					this.Onid_hotelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_city", DbType="Int NOT NULL")]
		public int id_city
		{
			get
			{
				return this._id_city;
			}
			set
			{
				if ((this._id_city != value))
				{
					if (this._City.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_cityChanging(value);
					this.SendPropertyChanging();
					this._id_city = value;
					this.SendPropertyChanged("id_city");
					this.Onid_cityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hotel_name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string hotel_name
		{
			get
			{
				return this._hotel_name;
			}
			set
			{
				if ((this._hotel_name != value))
				{
					this.Onhotel_nameChanging(value);
					this.SendPropertyChanging();
					this._hotel_name = value;
					this.SendPropertyChanged("hotel_name");
					this.Onhotel_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="class", Storage="_class", DbType="Int NOT NULL")]
		public int @class
		{
			get
			{
				return this._class;
			}
			set
			{
				if ((this._class != value))
				{
					this.OnclassChanging(value);
					this.SendPropertyChanging();
					this._class = value;
					this.SendPropertyChanged("@class");
					this.OnclassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pay_on_day", DbType="Float NOT NULL")]
		public double pay_on_day
		{
			get
			{
				return this._pay_on_day;
			}
			set
			{
				if ((this._pay_on_day != value))
				{
					this.Onpay_on_dayChanging(value);
					this.SendPropertyChanging();
					this._pay_on_day = value;
					this.SendPropertyChanged("pay_on_day");
					this.Onpay_on_dayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desctiption", DbType="NVarChar(MAX)")]
		public string desctiption
		{
			get
			{
				return this._desctiption;
			}
			set
			{
				if ((this._desctiption != value))
				{
					this.OndesctiptionChanging(value);
					this.SendPropertyChanging();
					this._desctiption = value;
					this.SendPropertyChanged("desctiption");
					this.OndesctiptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Hotel_Tour", Storage="_Tour", ThisKey="id_hotel", OtherKey="id_hotel")]
		public EntitySet<Tour> Tour
		{
			get
			{
				return this._Tour;
			}
			set
			{
				this._Tour.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="City_Hotel", Storage="_City", ThisKey="id_city", OtherKey="id_city", IsForeignKey=true)]
		public City City
		{
			get
			{
				return this._City.Entity;
			}
			set
			{
				City previousValue = this._City.Entity;
				if (((previousValue != value) 
							|| (this._City.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._City.Entity = null;
						previousValue.Hotel.Remove(this);
					}
					this._City.Entity = value;
					if ((value != null))
					{
						value.Hotel.Add(this);
						this._id_city = value.id_city;
					}
					else
					{
						this._id_city = default(int);
					}
					this.SendPropertyChanged("City");
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
		
		private void attach_Tour(Tour entity)
		{
			this.SendPropertyChanging();
			entity.Hotel = this;
		}
		
		private void detach_Tour(Tour entity)
		{
			this.SendPropertyChanging();
			entity.Hotel = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_user;
		
		private string _fname;
		
		private string _login;
		
		private string _password;
		
		private System.Nullable<System.DateTime> _birthday;
		
		private string _passport;
		
		private EntitySet<Voucher> _Voucher;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_userChanging(int value);
    partial void Onid_userChanged();
    partial void OnfnameChanging(string value);
    partial void OnfnameChanged();
    partial void OnloginChanging(string value);
    partial void OnloginChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnbirthdayChanging(System.Nullable<System.DateTime> value);
    partial void OnbirthdayChanged();
    partial void OnpassportChanging(string value);
    partial void OnpassportChanged();
    #endregion
		
		public User()
		{
			this._Voucher = new EntitySet<Voucher>(new Action<Voucher>(this.attach_Voucher), new Action<Voucher>(this.detach_Voucher));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_user", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_user
		{
			get
			{
				return this._id_user;
			}
			set
			{
				if ((this._id_user != value))
				{
					this.Onid_userChanging(value);
					this.SendPropertyChanging();
					this._id_user = value;
					this.SendPropertyChanged("id_user");
					this.Onid_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fname", DbType="NVarChar(MAX)")]
		public string fname
		{
			get
			{
				return this._fname;
			}
			set
			{
				if ((this._fname != value))
				{
					this.OnfnameChanging(value);
					this.SendPropertyChanging();
					this._fname = value;
					this.SendPropertyChanged("fname");
					this.OnfnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this.OnloginChanging(value);
					this.SendPropertyChanging();
					this._login = value;
					this.SendPropertyChanged("login");
					this.OnloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_birthday", DbType="Date")]
		public System.Nullable<System.DateTime> birthday
		{
			get
			{
				return this._birthday;
			}
			set
			{
				if ((this._birthday != value))
				{
					this.OnbirthdayChanging(value);
					this.SendPropertyChanging();
					this._birthday = value;
					this.SendPropertyChanged("birthday");
					this.OnbirthdayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_passport", DbType="NChar(9)")]
		public string passport
		{
			get
			{
				return this._passport;
			}
			set
			{
				if ((this._passport != value))
				{
					this.OnpassportChanging(value);
					this.SendPropertyChanging();
					this._passport = value;
					this.SendPropertyChanged("passport");
					this.OnpassportChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Voucher", Storage="_Voucher", ThisKey="id_user", OtherKey="id_tourist")]
		public EntitySet<Voucher> Voucher
		{
			get
			{
				return this._Voucher;
			}
			set
			{
				this._Voucher.Assign(value);
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
		
		private void attach_Voucher(Voucher entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Voucher(Voucher entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tour")]
	public partial class Tour : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_tour;
		
		private int _id_hotel;
		
		private System.DateTime _departure;
		
		private EntitySet<Voucher> _Voucher;
		
		private EntityRef<Hotel> _Hotel;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_tourChanging(int value);
    partial void Onid_tourChanged();
    partial void Onid_hotelChanging(int value);
    partial void Onid_hotelChanged();
    partial void OndepartureChanging(System.DateTime value);
    partial void OndepartureChanged();
    #endregion
		
		public Tour()
		{
			this._Voucher = new EntitySet<Voucher>(new Action<Voucher>(this.attach_Voucher), new Action<Voucher>(this.detach_Voucher));
			this._Hotel = default(EntityRef<Hotel>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_tour", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_tour
		{
			get
			{
				return this._id_tour;
			}
			set
			{
				if ((this._id_tour != value))
				{
					this.Onid_tourChanging(value);
					this.SendPropertyChanging();
					this._id_tour = value;
					this.SendPropertyChanged("id_tour");
					this.Onid_tourChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_hotel", DbType="Int NOT NULL")]
		public int id_hotel
		{
			get
			{
				return this._id_hotel;
			}
			set
			{
				if ((this._id_hotel != value))
				{
					if (this._Hotel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_hotelChanging(value);
					this.SendPropertyChanging();
					this._id_hotel = value;
					this.SendPropertyChanged("id_hotel");
					this.Onid_hotelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_departure", DbType="Date NOT NULL")]
		public System.DateTime departure
		{
			get
			{
				return this._departure;
			}
			set
			{
				if ((this._departure != value))
				{
					this.OndepartureChanging(value);
					this.SendPropertyChanging();
					this._departure = value;
					this.SendPropertyChanged("departure");
					this.OndepartureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tour_Voucher", Storage="_Voucher", ThisKey="id_tour", OtherKey="id_tour")]
		public EntitySet<Voucher> Voucher
		{
			get
			{
				return this._Voucher;
			}
			set
			{
				this._Voucher.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Hotel_Tour", Storage="_Hotel", ThisKey="id_hotel", OtherKey="id_hotel", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Hotel Hotel
		{
			get
			{
				return this._Hotel.Entity;
			}
			set
			{
				Hotel previousValue = this._Hotel.Entity;
				if (((previousValue != value) 
							|| (this._Hotel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Hotel.Entity = null;
						previousValue.Tour.Remove(this);
					}
					this._Hotel.Entity = value;
					if ((value != null))
					{
						value.Tour.Add(this);
						this._id_hotel = value.id_hotel;
					}
					else
					{
						this._id_hotel = default(int);
					}
					this.SendPropertyChanged("Hotel");
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
		
		private void attach_Voucher(Voucher entity)
		{
			this.SendPropertyChanging();
			entity.Tour = this;
		}
		
		private void detach_Voucher(Voucher entity)
		{
			this.SendPropertyChanging();
			entity.Tour = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Voucher")]
	public partial class Voucher : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_voucher;
		
		private int _id_tour;
		
		private int _id_tourist;
		
		private decimal _cost;
		
		private System.Nullable<int> _kol_chelovek;
		
		private System.Nullable<int> _days;
		
		private string _status;
		
		private EntityRef<Tour> _Tour;
		
		private EntityRef<User> _User;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_voucherChanging(int value);
    partial void Onid_voucherChanged();
    partial void Onid_tourChanging(int value);
    partial void Onid_tourChanged();
    partial void Onid_touristChanging(int value);
    partial void Onid_touristChanged();
    partial void OncostChanging(decimal value);
    partial void OncostChanged();
    partial void Onkol_chelovekChanging(System.Nullable<int> value);
    partial void Onkol_chelovekChanged();
    partial void OndaysChanging(System.Nullable<int> value);
    partial void OndaysChanged();
    partial void OnstatusChanging(string value);
    partial void OnstatusChanged();
    #endregion
		
		public Voucher()
		{
			this._Tour = default(EntityRef<Tour>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_voucher", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_voucher
		{
			get
			{
				return this._id_voucher;
			}
			set
			{
				if ((this._id_voucher != value))
				{
					this.Onid_voucherChanging(value);
					this.SendPropertyChanging();
					this._id_voucher = value;
					this.SendPropertyChanged("id_voucher");
					this.Onid_voucherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_tour", DbType="Int NOT NULL")]
		public int id_tour
		{
			get
			{
				return this._id_tour;
			}
			set
			{
				if ((this._id_tour != value))
				{
					if (this._Tour.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_tourChanging(value);
					this.SendPropertyChanging();
					this._id_tour = value;
					this.SendPropertyChanged("id_tour");
					this.Onid_tourChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_tourist", DbType="Int NOT NULL")]
		public int id_tourist
		{
			get
			{
				return this._id_tourist;
			}
			set
			{
				if ((this._id_tourist != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_touristChanging(value);
					this.SendPropertyChanging();
					this._id_tourist = value;
					this.SendPropertyChanged("id_tourist");
					this.Onid_touristChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cost", DbType="Money NOT NULL")]
		public decimal cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				if ((this._cost != value))
				{
					this.OncostChanging(value);
					this.SendPropertyChanging();
					this._cost = value;
					this.SendPropertyChanged("cost");
					this.OncostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kol_chelovek", DbType="Int")]
		public System.Nullable<int> kol_chelovek
		{
			get
			{
				return this._kol_chelovek;
			}
			set
			{
				if ((this._kol_chelovek != value))
				{
					this.Onkol_chelovekChanging(value);
					this.SendPropertyChanging();
					this._kol_chelovek = value;
					this.SendPropertyChanged("kol_chelovek");
					this.Onkol_chelovekChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_days", DbType="Int")]
		public System.Nullable<int> days
		{
			get
			{
				return this._days;
			}
			set
			{
				if ((this._days != value))
				{
					this.OndaysChanging(value);
					this.SendPropertyChanging();
					this._days = value;
					this.SendPropertyChanged("days");
					this.OndaysChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="NChar(10)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tour_Voucher", Storage="_Tour", ThisKey="id_tour", OtherKey="id_tour", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Tour Tour
		{
			get
			{
				return this._Tour.Entity;
			}
			set
			{
				Tour previousValue = this._Tour.Entity;
				if (((previousValue != value) 
							|| (this._Tour.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tour.Entity = null;
						previousValue.Voucher.Remove(this);
					}
					this._Tour.Entity = value;
					if ((value != null))
					{
						value.Voucher.Add(this);
						this._id_tour = value.id_tour;
					}
					else
					{
						this._id_tour = default(int);
					}
					this.SendPropertyChanged("Tour");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Voucher", Storage="_User", ThisKey="id_tourist", OtherKey="id_user", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Voucher.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Voucher.Add(this);
						this._id_tourist = value.id_user;
					}
					else
					{
						this._id_tourist = default(int);
					}
					this.SendPropertyChanged("User");
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
}
#pragma warning restore 1591
