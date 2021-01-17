jadeVersionNumber "18.0.01";
schemaDefinition
JoobSpatialDemoSchema subschemaOf RootSchema completeDefinition, patchVersioningEnabled = false;
		setModifiedTimeStamp "cnwpjr2" "9.9.00" 2011:05:06:10:41:23.853;
importedPackageDefinitions
constantDefinitions
localeDefinitions
	5129 "English (New Zealand)" schemaDefaultLocale;
		setModifiedTimeStamp "<unknown>" "" 2011:05:06:10:41:18;
libraryDefinitions
typeHeaders
	JoobSpatialDemoSchema subclassOf RootSchemaApp transient, sharedTransientAllowed, transientAllowed, subclassSharedTransientAllowed, subclassTransientAllowed, number = 7052;
	GJoobSpatialDemoSchema subclassOf RootSchemaGlobal transient, sharedTransientAllowed, transientAllowed, subclassSharedTransientAllowed, subclassTransientAllowed, number = 7053;
	ObjectWithSpatialInfo subclassOf Object abstract, highestOrdinal = 1, number = 7038;
	City subclassOf ObjectWithSpatialInfo highestOrdinal = 6, number = 7041;
	County subclassOf ObjectWithSpatialInfo highestSubId = 2, highestOrdinal = 4, number = 7040;
	Person subclassOf ObjectWithSpatialInfo highestOrdinal = 1, number = 7042;
	State subclassOf ObjectWithSpatialInfo highestSubId = 2, highestOrdinal = 5, number = 7039;
	Root subclassOf Object highestSubId = 8, highestOrdinal = 8, number = 7037;
	SpatialLayer subclassOf Object highestSubId = 1, highestOrdinal = 2, number = 7050;
	CityByNameDict subclassOf MemberKeyDictionary duplicatesAllowed, number = 7048;
	CountyByNameDict subclassOf MemberKeyDictionary duplicatesAllowed, number = 7046;
	SpatialLayerByNameDict subclassOf MemberKeyDictionary number = 7051;
	StateByAbbrDict subclassOf MemberKeyDictionary number = 7044;
	GeometriesRTree subclassOf JadeExternalKeyRTree loadFactor = 66, number = 7054;
	CityByGeomRTree subclassOf JadeMemberKeyRTree number = 7047;
	CountyByGeomRTree subclassOf JadeMemberKeyRTree number = 7045;
	PersonByGeomRTree subclassOf JadeMemberKeyRTree number = 7049;
	StateByGeomRTree subclassOf JadeMemberKeyRTree number = 7043;
 
interfaceDefs
membershipDefinitions
	CityByNameDict of City ;
	CountyByNameDict of County ;
	SpatialLayerByNameDict of SpatialLayer ;
	StateByAbbrDict of State ;
	GeometriesRTree of Person ;
	CityByGeomRTree of City ;
	CountyByGeomRTree of County ;
	PersonByGeomRTree of Person ;
	StateByGeomRTree of State ;
 
typeDefinitions
	Object completeDefinition
	(
	)
	Application completeDefinition
	(
	)
	RootSchemaApp completeDefinition
	(
	)
	JoobSpatialDemoSchema completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "9.9.00" 2011:05:06:10:41:23.849;
	)
	Global completeDefinition
	(
	)
	RootSchemaGlobal completeDefinition
	(
	)
	GJoobSpatialDemoSchema completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "9.9.00" 2011:05:06:10:41:23.853;
	)
	JadeScript completeDefinition
	(
 
	jadeMethodDefinitions
		deleteAllData() number = 1001;
		setModifiedTimeStamp "cnwpjr1" "9.9.00" 2011:05:20:11:44:42.381;
	)
	ObjectWithSpatialInfo completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		geom:                          JadeGeometry  number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	City completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	attributeDefinitions
		id:                            Integer number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		name:                          String[51] number = 2, ordinal = 2;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		population:                    Integer number = 3, ordinal = 3;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		myCounty:                      County   explicitEmbeddedInverse, number = 6, ordinal = 6;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		myRoot:                        Root   explicitEmbeddedInverse, number = 4, ordinal = 4;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		myState:                       State   explicitEmbeddedInverse, number = 5, ordinal = 5;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	County completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	attributeDefinitions
		name:                          String[51] number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		allCitiesByGeom:               CityByGeomRTree   explicitInverse, subId = 2, number = 4, ordinal = 4;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allCitiesByName:               CityByNameDict   explicitInverse, subId = 1, number = 3, ordinal = 3;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		myRoot:                        Root   explicitEmbeddedInverse, number = 2, ordinal = 2;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	Person completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	attributeDefinitions
		id:                            Integer number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	State completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	attributeDefinitions
		abbr:                          String[3] number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		name:                          String[51] number = 2, ordinal = 2;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		allCitiesByGeom:               CityByGeomRTree   explicitInverse, subId = 2, number = 5, ordinal = 5;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allCitiesByName:               CityByNameDict   explicitInverse, subId = 1, number = 4, ordinal = 4;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		myRoot:                        Root   explicitEmbeddedInverse, number = 3, ordinal = 3;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	Root completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		allCitiesByGeom:               CityByGeomRTree   explicitInverse, subId = 5, number = 5, ordinal = 5;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allCountiesByGeom:             CountyByGeomRTree   explicitInverse, subId = 4, number = 4, ordinal = 4;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allCountiesByName:             CountyByNameDict   explicitInverse, subId = 3, number = 3, ordinal = 3;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allPeopleByGeom:               PersonByGeomRTree  implicitMemberInverse, subId = 6, number = 6, ordinal = 6;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allStatesByAbbr:               StateByAbbrDict   explicitInverse, subId = 1, number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		allStatesByGeom:               StateByGeomRTree   explicitInverse, subId = 2, number = 2, ordinal = 2;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
		externalRTree:                 GeometriesRTree  implicitMemberInverse, subId = 8, number = 8, ordinal = 8;
		setModifiedTimeStamp "cnwpjr2" "9.9.00" 2011:05:06:16:11:52.401;
		otherSpatialLayers:            SpatialLayerByNameDict  implicitMemberInverse, subId = 7, number = 7, ordinal = 7;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	SpatialLayer completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	attributeDefinitions
		name:                          String[51] number = 1, ordinal = 1;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	referenceDefinitions
		geometries:                    JadeSpatialRTree  implicitMemberInverse, subId = 1, number = 2, ordinal = 2;
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	Collection completeDefinition
	(
	)
	Btree completeDefinition
	(
	)
	Dictionary completeDefinition
	(
	)
	MemberKeyDictionary completeDefinition
	(
	)
	CityByNameDict completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	CountyByNameDict completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	SpatialLayerByNameDict completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	StateByAbbrDict completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	JadeRTree completeDefinition
	(
		setModifiedTimeStamp "cnwnhs1" "9.9.00" 2011:04:29:09:47:58.906;
	)
	JadeExternalKeyRTree completeDefinition
	(
		setModifiedTimeStamp "cnwnhs1" "9.9.00" 2011:04:26:17:16:07.435;
	)
	GeometriesRTree completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "9.9.00" 2011:05:06:16:08:55.970;
	)
	JadeMemberKeyRTree completeDefinition
	(
		setModifiedTimeStamp "cnwnhs1" "9.9.00" 2011:04:26:17:16:17.859;
	)
	CityByGeomRTree completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	CountyByGeomRTree completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	PersonByGeomRTree completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
	StateByGeomRTree completeDefinition
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	)
 
memberKeyDefinitions
	CityByNameDict completeDefinition
	(
		name;
	)
	CountyByNameDict completeDefinition
	(
		name;
	)
	SpatialLayerByNameDict completeDefinition
	(
		name;
	)
	StateByAbbrDict completeDefinition
	(
		abbr;
	)
	CityByGeomRTree completeDefinition
	(
		geom;
	)
	CountyByGeomRTree completeDefinition
	(
		geom;
	)
	PersonByGeomRTree completeDefinition
	(
		geom;
	)
	StateByGeomRTree completeDefinition
	(
		geom;
	)
 
inverseDefinitions
	allCitiesByName of County automatic parentOf myCounty of City manual;
	allCitiesByGeom of County automatic parentOf myCounty of City manual;
	allCitiesByGeom of Root automatic parentOf myRoot of City manual;
	allCitiesByName of State automatic parentOf myState of City manual;
	allCitiesByGeom of State automatic parentOf myState of City manual;
	allCountiesByName of Root automatic parentOf myRoot of County manual;
	allCountiesByGeom of Root automatic parentOf myRoot of County manual;
	allStatesByAbbr of Root automatic parentOf myRoot of State manual;
	allStatesByGeom of Root automatic parentOf myRoot of State manual;
databaseDefinitions
JoobSpatialDemoSchemaDb
	(
		setModifiedTimeStamp "cnwpjr2" "6.3.00" 2011:05:06:10:41:18;
	databaseFileDefinitions
		"JoobSpatialDemo" number=165;
		setModifiedTimeStamp "<unknown>" "" 2011:05:06:10:41:18;
	defaultFileDefinition "JoobSpatialDemo";
	classMapDefinitions
		JoobSpatialDemoSchema in "_usergui";
		GJoobSpatialDemoSchema in "JoobSpatialDemo";
		GeometriesRTree in "JoobSpatialDemo";
	)
schemaViewDefinitions
_exposedListDefinitions
SpatialDemoExposure version=0, priorVersion=0, registryId="_CSharp_Exposure"
		setModifiedTimeStamp "<unknown>" "" 2011:05:06:10:46:34;
(
	City javaName="City", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		id javaName="Id", javaType="Int32";
		myCounty javaName="MyCounty", javaType="County";
		myRoot javaName="MyRoot", javaType="Root";
		myState javaName="MyState", javaType="State";
		name javaName="Name", javaType="String";
		population javaName="Population", javaType="Int32";
		)
	)
	CityByGeomRTree autoAdded, javaName="CityByGeomRTree", defaultStyle=0
	(
	)
	CityByNameDict autoAdded, javaName="CityByNameDict", defaultStyle=0
	(
	)
	County javaName="County", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		allCitiesByGeom javaName="AllCitiesByGeom", javaType="CityByGeomRTree";
		allCitiesByName javaName="AllCitiesByName", javaType="CityByNameDict";
		myRoot javaName="MyRoot", javaType="Root";
		name javaName="Name", javaType="String";
		)
	)
	CountyByGeomRTree autoAdded, javaName="CountyByGeomRTree", defaultStyle=0
	(
	)
	CountyByNameDict autoAdded, javaName="CountyByNameDict", defaultStyle=0
	(
	)
	GeometriesRTree autoAdded, javaName="GeometriesRTree", defaultStyle=0
	(
	)
	JadeGeometry javaName="JadeGeometry", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		srid javaName="Srid", javaType="Int32";
		)
	)
	JoobSpatialDemoSchema javaName="JoobSpatialDemoSchema", defaultStyle=0
	(
	)
	ObjectWithSpatialInfo javaName="ObjectWithSpatialInfo", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		geom javaName="Geom", javaType="JadeGeometry";
		)
	)
	Person javaName="Person", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		id javaName="Id", javaType="Int32";
		)
	)
	PersonByGeomRTree autoAdded, javaName="PersonByGeomRTree", defaultStyle=0
	(
	)
	Root javaName="Root", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		allCitiesByGeom javaName="AllCitiesByGeom", javaType="CityByGeomRTree";
		allCountiesByGeom javaName="AllCountiesByGeom", javaType="CountyByGeomRTree";
		allCountiesByName javaName="AllCountiesByName", javaType="CountyByNameDict";
		allPeopleByGeom javaName="AllPeopleByGeom", javaType="PersonByGeomRTree";
		allStatesByAbbr javaName="AllStatesByAbbr", javaType="StateByAbbrDict";
		allStatesByGeom javaName="AllStatesByGeom", javaType="StateByGeomRTree";
		externalRTree javaName="ExternalRTree", javaType="GeometriesRTree";
		otherSpatialLayers javaName="OtherSpatialLayers", javaType="SpatialLayerByNameDict";
		)
	)
	SpatialLayer javaName="SpatialLayer", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		geometries javaName="Geometries", javaType="JadeSpatialRTree";
		name javaName="Name", javaType="String";
		)
	)
	SpatialLayerByNameDict autoAdded, javaName="SpatialLayerByNameDict", defaultStyle=0
	(
	)
	State javaName="State", defaultStyle=0
	(
	_exposedJavaFeatures
		(
		abbr javaName="Abbr", javaType="String";
		allCitiesByGeom javaName="AllCitiesByGeom", javaType="CityByGeomRTree";
		allCitiesByName javaName="AllCitiesByName", javaType="CityByNameDict";
		myRoot javaName="MyRoot", javaType="Root";
		name javaName="Name", javaType="String";
		)
	)
	StateByAbbrDict autoAdded, javaName="StateByAbbrDict", defaultStyle=0
	(
	)
	StateByGeomRTree autoAdded, javaName="StateByGeomRTree", defaultStyle=0
	(
	)
)
exportedPackageDefinitions
typeSources
	JadeScript (
	jadeMethodSources
deleteAllData
{
deleteAllData();

vars

begin
	beginTransaction;
	Root.deleteAllInstances();
	commitTransaction;
end;

}

	)
