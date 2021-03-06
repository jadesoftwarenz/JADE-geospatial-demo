//*****************************************************************************
//
//      This code was generated by the JADE Exposure Wizard.
//
//      JADE Version    : 20.0.01
//      Generation date : Tuesday, 19 January 2021
//      Generated by    : cnwta3
//      JADE Schema     : JoobSpatialDemoSchema
//      Exposure Name   : SpatialDemoExposure
//
//      NOTE: You should NOT change this file as it may cause incorrect
//            behaviour. Any changes that you do make will be lost if
//            this code is regenerated.
//
//*****************************************************************************

namespace SpatialDemoExposure
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using JadeSoftware.Joob;
	using JadeSoftware.Joob.Client;
	using JadeSoftware.Joob.Metadata;
	using JadeSoftware.Joob.Management;
	using JadeSoftware.Joob.MetaSchema;
	using JadeSoftware.Jade.DotNetInterop;

	[System.Runtime.Serialization.KnownTypeAttribute(typeof(County))]
	[System.Runtime.Serialization.KnownTypeAttribute(typeof(Root))]
	[System.Runtime.Serialization.KnownTypeAttribute(typeof(State))]
	[System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
	[System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(CityMetadata))]
	[JadeSoftware.Joob.Client.JoobClassAttribute("City", "RootSchema.JoobSpatialDemoSchema", ClassNamespace="SpatialDemoExposure")]
	[JadeSoftware.Joob.Metadata.JomlTypeAttribute(JadeSoftware.Joob.Metadata.JomlTypeKind.Class, "City", typeof(ObjectWithSpatialInfo))]
	public partial class City : ObjectWithSpatialInfo
	{
		private static CityMetadata _metaModel;
		partial void _initialize();
		static City()
		{
			_metaModel = MetadataCache<CityMetadata>.GetData(null);
		}
		public City() :
			this(JadeSoftware.Joob.ClassPersistence.Persistent)
		{
		}
		public City(JadeSoftware.Joob.ClassPersistence lifetime) :
			base(lifetime, typeof(City), _metaModel.metaClass)
		{
			this._initialize();
		}
		protected City(JadeSoftware.Joob.ClassPersistence lifetime, System.Type type, JadeSoftware.Joob.ClassMetadata metaClass, params System.Object[] parameters) :
			base(lifetime, type, metaClass, parameters)
		{
			this._initialize();
		}
	
#region Jade Properties

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("id", typeof(Int32), DatabaseTypeName="Integer")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public Int32 Id
		{
			get
			{
				return this.GetPropertyInt32(_metaModel.metaClass, _metaModel.id);
			}
			set
			{
				this.SetPropertyInt32(_metaModel.metaClass, _metaModel.id, value);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("myCounty", typeof(County), DatabaseTypeName="County")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public County MyCounty
		{
			get
			{
				return this.GetPropertyReference<County>(_metaModel.metaClass, _metaModel.myCounty);
			}
			set
			{
				this.SetPropertyReference(_metaModel.metaClass, _metaModel.myCounty, value, false);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("myRoot", typeof(Root), DatabaseTypeName="Root")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public Root MyRoot
		{
			get
			{
				return this.GetPropertyReference<Root>(_metaModel.metaClass, _metaModel.myRoot);
			}
			set
			{
				this.SetPropertyReference(_metaModel.metaClass, _metaModel.myRoot, value, false);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("myState", typeof(State), DatabaseTypeName="State")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public State MyState
		{
			get
			{
				return this.GetPropertyReference<State>(_metaModel.metaClass, _metaModel.myState);
			}
			set
			{
				this.SetPropertyReference(_metaModel.metaClass, _metaModel.myState, value, false);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("name", typeof(String), Length=50, DatabaseTypeName="String")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public String Name
		{
			get
			{
				return this.GetPropertyString(_metaModel.metaClass, _metaModel.name);
			}
			set
			{
				this.SetPropertyString(_metaModel.metaClass, _metaModel.name, value);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("population", typeof(Int32), DatabaseTypeName="Integer")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public Int32 Population
		{
			get
			{
				return this.GetPropertyInt32(_metaModel.metaClass, _metaModel.population);
			}
			set
			{
				this.SetPropertyInt32(_metaModel.metaClass, _metaModel.population, value);
			}
		}
	#endregion
	}

	public partial class CityMetadata : JadeSoftware.Joob.IDomainMetadata
	{

		internal JadeSoftware.Joob.ClassMetadata metaClass;
		internal JadeSoftware.Joob.PropertyMetadata id;
		internal JadeSoftware.Joob.PropertyMetadata myCounty;
		internal JadeSoftware.Joob.PropertyMetadata myRoot;
		internal JadeSoftware.Joob.PropertyMetadata myState;
		internal JadeSoftware.Joob.PropertyMetadata name;
		internal JadeSoftware.Joob.PropertyMetadata population;

		private CityMetadata()
		{
		}
		partial void InitializeDynamicProperties(JadeSoftware.Joob.Client.IJoobConnection connection);

		public CityMetadata(JadeSoftware.Joob.Client.JoobConnection connection)
		{
			metaClass = new JadeSoftware.Joob.ClassMetadata(connection, typeof(City), "City", "RootSchema.JoobSpatialDemoSchema");
			this.InitializeProperties(connection);
			this.InitializeDynamicProperties(connection);
		}

		private void InitializeProperties(JadeSoftware.Joob.Client.IJoobConnection connection)
		{
			id = metaClass.CheckProperty("id", typeof(Int32));
			myCounty = metaClass.CheckProperty("myCounty", typeof(County));
			myRoot = metaClass.CheckProperty("myRoot", typeof(Root));
			myState = metaClass.CheckProperty("myState", typeof(State));
			name = metaClass.CheckProperty("name", typeof(String), 50);
			population = metaClass.CheckProperty("population", typeof(Int32));
		}
	}
}
