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

	[System.Runtime.Serialization.KnownTypeAttribute(typeof(CityByGeomRTree))]
	[System.Runtime.Serialization.KnownTypeAttribute(typeof(CityByNameDict))]
	[System.Runtime.Serialization.KnownTypeAttribute(typeof(Root))]
	[System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
	[System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(StateMetadata))]
	[JadeSoftware.Joob.Client.JoobClassAttribute("State", "RootSchema.JoobSpatialDemoSchema", ClassNamespace="SpatialDemoExposure")]
	[JadeSoftware.Joob.Metadata.JomlTypeAttribute(JadeSoftware.Joob.Metadata.JomlTypeKind.Class, "State", typeof(ObjectWithSpatialInfo))]
	public partial class State : ObjectWithSpatialInfo
	{
		private static StateMetadata _metaModel;
		partial void _initialize();
		static State()
		{
			_metaModel = MetadataCache<StateMetadata>.GetData(null);
		}
		public State() :
			this(JadeSoftware.Joob.ClassPersistence.Persistent)
		{
		}
		public State(JadeSoftware.Joob.ClassPersistence lifetime) :
			base(lifetime, typeof(State), _metaModel.metaClass)
		{
			this._initialize();
		}
		protected State(JadeSoftware.Joob.ClassPersistence lifetime, System.Type type, JadeSoftware.Joob.ClassMetadata metaClass, params System.Object[] parameters) :
			base(lifetime, type, metaClass, parameters)
		{
			this._initialize();
		}
	
#region Jade Properties

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("abbr", typeof(String), Length=2, DatabaseTypeName="String")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public String Abbr
		{
			get
			{
				return this.GetPropertyString(_metaModel.metaClass, _metaModel.abbr);
			}
			set
			{
				this.SetPropertyString(_metaModel.metaClass, _metaModel.abbr, value);
			}
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("allCitiesByGeom", typeof(CityByGeomRTree), DatabaseTypeName="CityByGeomRTree")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public CityByGeomRTree AllCitiesByGeom
		{
			get
			{
				return this.GetPropertyReference<CityByGeomRTree>(_metaModel.metaClass, _metaModel.allCitiesByGeom);
			}
			private set { }
		}

		[JadeSoftware.Joob.Client.JoobPropertyAttribute("allCitiesByName", typeof(CityByNameDict), DatabaseTypeName="CityByNameDict")]
		[System.Runtime.Serialization.DataMemberAttribute()]
		public CityByNameDict AllCitiesByName
		{
			get
			{
				return this.GetPropertyReference<CityByNameDict>(_metaModel.metaClass, _metaModel.allCitiesByName);
			}
			private set { }
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
	#endregion
	}

	public partial class StateMetadata : JadeSoftware.Joob.IDomainMetadata
	{

		internal JadeSoftware.Joob.ClassMetadata metaClass;
		internal JadeSoftware.Joob.PropertyMetadata abbr;
		internal JadeSoftware.Joob.PropertyMetadata allCitiesByGeom;
		internal JadeSoftware.Joob.PropertyMetadata allCitiesByName;
		internal JadeSoftware.Joob.PropertyMetadata myRoot;
		internal JadeSoftware.Joob.PropertyMetadata name;

		private StateMetadata()
		{
		}
		partial void InitializeDynamicProperties(JadeSoftware.Joob.Client.IJoobConnection connection);

		public StateMetadata(JadeSoftware.Joob.Client.JoobConnection connection)
		{
			metaClass = new JadeSoftware.Joob.ClassMetadata(connection, typeof(State), "State", "RootSchema.JoobSpatialDemoSchema");
			this.InitializeProperties(connection);
			this.InitializeDynamicProperties(connection);
		}

		private void InitializeProperties(JadeSoftware.Joob.Client.IJoobConnection connection)
		{
			abbr = metaClass.CheckProperty("abbr", typeof(String), 2);
			allCitiesByGeom = metaClass.CheckProperty("allCitiesByGeom", typeof(CityByGeomRTree));
			allCitiesByName = metaClass.CheckProperty("allCitiesByName", typeof(CityByNameDict));
			myRoot = metaClass.CheckProperty("myRoot", typeof(Root));
			name = metaClass.CheckProperty("name", typeof(String), 50);
		}
	}
}
