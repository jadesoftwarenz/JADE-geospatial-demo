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
	[System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(JoobSpatialDemoSchemaMetadata))]
	[JadeSoftware.Joob.Client.JoobClassAttribute("JoobSpatialDemoSchema", "RootSchema.JoobSpatialDemoSchema", ClassNamespace="SpatialDemoExposure")]
	[JadeSoftware.Joob.Metadata.JomlTypeAttribute(JadeSoftware.Joob.Metadata.JomlTypeKind.Class, "JoobSpatialDemoSchema", typeof(JoobObject))]
	public partial class JoobSpatialDemoSchema : JoobObject
	{
		private static JoobSpatialDemoSchemaMetadata _metaModel;
		partial void _initialize();
		static JoobSpatialDemoSchema()
		{
			_metaModel = MetadataCache<JoobSpatialDemoSchemaMetadata>.GetData(null);
		}
		public JoobSpatialDemoSchema() :
			this(JadeSoftware.Joob.ClassPersistence.Transient)
		{
		}
		public JoobSpatialDemoSchema(JadeSoftware.Joob.ClassPersistence lifetime) :
			base(lifetime, typeof(JoobSpatialDemoSchema), _metaModel.metaClass)
		{
			this._initialize();
		}
		protected JoobSpatialDemoSchema(JadeSoftware.Joob.ClassPersistence lifetime, System.Type type, JadeSoftware.Joob.ClassMetadata metaClass, params System.Object[] parameters) :
			base(lifetime, type, metaClass, parameters)
		{
			this._initialize();
		}
	}

	public partial class JoobSpatialDemoSchemaMetadata : JadeSoftware.Joob.IDomainMetadata
	{

		internal JadeSoftware.Joob.ClassMetadata metaClass;

		private JoobSpatialDemoSchemaMetadata()
		{
		}
		partial void InitializeDynamicProperties(JadeSoftware.Joob.Client.IJoobConnection connection);

		public JoobSpatialDemoSchemaMetadata(JadeSoftware.Joob.Client.JoobConnection connection)
		{
			metaClass = new JadeSoftware.Joob.ClassMetadata(connection, typeof(JoobSpatialDemoSchema), "JoobSpatialDemoSchema", "RootSchema.JoobSpatialDemoSchema");
			this.InitializeProperties(connection);
			this.InitializeDynamicProperties(connection);
		}

		private void InitializeProperties(JadeSoftware.Joob.Client.IJoobConnection connection)
		{
		}
	}
}
