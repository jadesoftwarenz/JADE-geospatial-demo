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

	[System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
	[System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(PersonMetadata))]
	[JadeSoftware.Joob.Client.JoobClassAttribute("Person", "RootSchema.JoobSpatialDemoSchema", ClassNamespace="SpatialDemoExposure")]
	[JadeSoftware.Joob.Metadata.JomlTypeAttribute(JadeSoftware.Joob.Metadata.JomlTypeKind.Class, "Person", typeof(ObjectWithSpatialInfo))]
	public partial class Person : ObjectWithSpatialInfo
	{
		private static PersonMetadata _metaModel;
		partial void _initialize();
		static Person()
		{
			_metaModel = MetadataCache<PersonMetadata>.GetData(null);
		}
		public Person() :
			this(JadeSoftware.Joob.ClassPersistence.Persistent)
		{
		}
		public Person(JadeSoftware.Joob.ClassPersistence lifetime) :
			base(lifetime, typeof(Person), _metaModel.metaClass)
		{
			this._initialize();
		}
		protected Person(JadeSoftware.Joob.ClassPersistence lifetime, System.Type type, JadeSoftware.Joob.ClassMetadata metaClass, params System.Object[] parameters) :
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
	#endregion
	}

	public partial class PersonMetadata : JadeSoftware.Joob.IDomainMetadata
	{

		internal JadeSoftware.Joob.ClassMetadata metaClass;
		internal JadeSoftware.Joob.PropertyMetadata id;

		private PersonMetadata()
		{
		}
		partial void InitializeDynamicProperties(JadeSoftware.Joob.Client.IJoobConnection connection);

		public PersonMetadata(JadeSoftware.Joob.Client.JoobConnection connection)
		{
			metaClass = new JadeSoftware.Joob.ClassMetadata(connection, typeof(Person), "Person", "RootSchema.JoobSpatialDemoSchema");
			this.InitializeProperties(connection);
			this.InitializeDynamicProperties(connection);
		}

		private void InitializeProperties(JadeSoftware.Joob.Client.IJoobConnection connection)
		{
			id = metaClass.CheckProperty("id", typeof(Int32));
		}
	}
}
