
USE [character_creator]
GO

INSERT INTO [dbo].[Country]
		([CountryID],[CountryNationality])
	VALUES
	('Afghanistan','Afghan'),('Albania','Albanian'),('Algeria','Algerian'),('Andorra','Andorran'),('Angola','Angolan'),('Antigua and Barbuda','Antiguan and Barbudan'),
	('Argentina','Argentine'),('Armenia','Armenian'),('Australia','Australian'),('Austria','Austrian'),('Azerbaijan','Azerbaijani'),
	('Bahamas','Bahamian'),('Bahrain','Bahraini'),('Bangledesh','Bangledeshi'),('Barbados','Barbadian'),('Belarus','Belarusian'),('Belgium','Belgian'),
	('Belize','Belizean'),('Benin','Beninese'),('Bhutan','Bhutanese'),('Bolivia','Bolivian'),('Bosnia and Herzegovina','Bosnian'),
	('Botswana','Motswana'),('Brazil','Brazilian'),('Brunei','Bruneian'),('Bulgaria','Bulgarian'),('Burkina Faso','Burkinabe'),('Burundi','Burundian'),
	('Cambodia','Cambodian'),('Cameroon','Cameroonian'),('Canada','Canadian'),('Central African Republic','Central African'),
	('Chad','Chadian'),('Chile','Chilean'),('China','Chinese'),('Colombia','Colombian'),('Comoros','Comorian'),('Costa Rica','Costa Rican'),
	('Croatia','Croatian'),('Cuba','Cuban'),('Cyprus','Cypriot'),
	('Democratic Republic of the Congo','Congolese'),('Denmark','Danish'),('Djibouti','Djiboutian'),('Dominica','Dominican'),
	('Dominican Republic','Dominican'),
	('Ecuador','Ecuadorian'),('Egypt','Egyptian'),('El Salvador','Salvadoran'),('Equatorial Guinea','Equatoguinean'),('Eritrea','Eritrean'),
	('Estonia','Estonian'),('Eswatini','Swazi'),('Ethiopia','Ethiopian'),
	('Federated States of Micronesia','Micronesian'),('Fiji','Fijan'),('Finland','Finnish'),('France','French'),
	('Gabon','Gabonese'),('Gambia','Gambian'),('Georgia','Georgian'),('Germany','German'),('Ghana','Ghanaian'),('Greece','Greek'),
	('Grenada','Grenadian'),('Guatemala','Guatemalan'),('Guinea','Guinean'),('Guinea-Bissau','Bissau-Guinean'),('Guyana','Guyanese'),
	('Haiti','Haitian'),('Honduras','Honduran'),('Hungary','Hungarian'),
	('Iceland','Icelander'),('India','Indian'),('Indonesia','Indonesian'),('Iran','Iranian'),('Iraq','Iraqi'),('Ireland','Irish'),('Israel','Israeli'),('Italy','Italian'),
	('Jamaica','Jamaican'),('Japan','Japanese'),('Jordan','Jordanian'),
	('Kazakhstan','Kazakh'),('Kenya','Kenyan'),('Kiribati','Kiribati'),('Kosovo','Kosovan'),('Kuwait','Kuwaiti'),('Kyrgyzstan','Kyrgz'),
	('Laos','Laotian'),('Latvia','Latvian'),('Lebanon','Lebanese'),('Lesotho','Mosotho'),('Liberia','Liberian'),('Libya','Libyan'),
	('Liechtenstein','Liechtensteiner'),('Lithuania','Lithuanian'),('Luxembourg','Luxembourger'),
	('Madagascar','Malagasy'),('Malawi','Malawian'),('Malaysia','Malayasian'),('Maldives','Maldivian'),('Mali','Malian'),('Malta','Maltese'),
	('Marshall Islands','Marshallese'),('Mauritania','Mauritanian'),('Mauritus','Mauritian'),('Mexico','Mexican'),('Moldova','Moldovan'),
	('Monaco','Monacan'), ('Mongolia','Mongolian'),('Montenegro','Montenegrin'),('Morocco','Moroccan'),('Mozambique','Mozambican'),
	('Namibia','Namibian'),('Nauru','Nauruan'),('Nepal','Nepali'),('Netherlands','Dutch'),('New Zealand','New Zealander'),('Nicaragua','Nicaraguan'),
	('Niger','Nigerien'),('Nigeria','Nigerian'),('North Korea','North Korean'),('North Macedonia','Macedonian'),('Norway','Norwegian'),
	('Oman','Omani'),
	('Pakistan','Pakistani'),('Palau','Palauan'),('Palestine','Palestinian'),('Panama','Panamanian'),('Papaua New Guinea','Papua New Guinean'),
	('Paraguay','Paraguayan'),('Peru','Peruvian'),('Philippines','Filipino'),('Poland','Polish'),('Portugal','Portuguese'),
	('Qatar','Qatari'),
	('Republic of the Congo','Congese'),('Romania','Romanian'),('Russia','Russian'),('Rwanda','Rwandan'),
	('Saint Kitts and Nevis','Kittitian'),('Saint Lucia','Saint Lucian'),('Saint Vincent and the Grenadines','Vincentian and Grenadinian'),('Samoa','Samoan'),
	('San Marino','Sammarinese'),('Sao Tome and Principe','Sao Tomean'),('Saudi Arabia','Saudi Arabian'),('Senegal','Senegalese'),('Serbia','Serbian'),
	('Seychelles','Seychellois'),('Sierra Leone','Sierra Leonean'),('Singapore','Singaporean'),('Slovakia','Slovakian'),('Slovenia','Slovenian'),('Solomon Islands','Solomon Islander'),
	('Somalia','Somali'),('South Africa','South African'),('South Korea','South Korean'),('South Sudan','South Sudanese'),('Spain','Spaniard'),('Sri Lanka','Sri Lankan'),
	('Sudan','Sudanese'),('Suriname','Surinamese'),('Sweden','Swedish'),('Switzerland','Swiss'),('Syria','Syrian'),
	('Taiwan','Taiwanese'),('Tajikistan','Tajikistani'),('Tanzania','Tanzanian'),('Thailand','Thai'),('Togo','Togolese'),('Tonga','Tongan'),
	('Trinidad and Tobago','Trinidadian and Tobagonian'),('Tunisia','Tunisian'),('Turkmenistan','Turkmenistani'),('Tuvalu','Tuvaluan'),
	('Uganda','Ugandan'),('Ukraine','Ukrainian'),('United Arab Emirates','Emirati'),('United States of America','American'),('Uruguay','Uruguayan'),('Uzbekistan','Uzbekistani'),
	('Vanuatu','Vanuatuan'),('Venezuala','Venezuelan'),('Vietnam','Vietnamese'),
	('Yemen','Yemeni'),
	('Zambia','Zambian'),('Zimbabwe','Zimbabwean')
GO
INSERT INTO [dbo].[Country]
		([CountryID],[CountryNationality],[CountryDescription])
	VALUES
	('Cabo Verde','Cabo Verdean','Also known as Cape Verde.'),
	('Czechia','Czech','Also known as the Czech Republic.'),
	('Timor-Leste','Timor-Lesteese','Also known as East Timor.'),
	('Ivory Coast','Ivorian',"Also known as Cote d'Ivoire."),
	('Myanmar','Burmese','Also known as Burma.'),
	('Turkey','Turkish','Also known as Turkiye.'),
	('United Kingdom','British','Includes England, Wales, Scotland, and Northern Ireland.'),
	('Vatican City','Vatican','Also known as Holy See.'),
	('Unspecified','Unspecified','The country is unspecified.')
GO

/* ======================================================
	print '' print '*** inserting pre-made subdivisions ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[Subdivision]
		([SubdivisionName],[SubdivisionCountry],[SubdivisionType])
	VALUES
	-- United States of America States
	('Alabama','United States of America','State'),('Alaska','United States of America','State'),('Arizona','United States of America','State'),('Arkansas','United States of America','State'),
	('California','United States of America','State'),('Colorado','United States of America','State'),('Connecticut','United States of America','State'),
	('Delaware','United States of America','State'),
	('Florida','United States of America','State'),
	('Georgia','United States of America','State'),
	('Hawaii','United States of America','State'),
	('Idaho','United States of America','State'),('Illinois','United States of America','State'),('Indiana','United States of America','State'),('Iowa','United States of America','State'),
	('Kansas','United States of America','State'),('Kentucky','United States of America','State'),
	('Louisiana','United States of America','State'),
	('Maine','United States of America','State'),('Maryland','United States of America','State'),('Massachusetts','United States of America','State'),('Michigan','United States of America','State'),('Minnesota','United States of America','State'),('Mississippi','United States of America','State'),('Missouri','United States of America','State'),('Montana','United States of America','State'),
	('Nebraska','United States of America','State'),('Nevada','United States of America','State'),('New Hampshire','United States of America','State'),('New Jersey','United States of America','State'),('New Mexico','United States of America','State'),('New York','United States of America','State'),('Norh Carolina','United States of America','State'),('North Dakota','United States of America','State'),
	('Ohio','United States of America','State'),('Oklahoma','United States of America','State'),('Oregon','United States of America','State'),
	('Pennsylvania','United States of America','State'),
	('Rhode Island','United States of America','State'),
	('South Carolina','United States of America','State'),('South Dakota', 'United States of America','State'),
	('Tennessee','United States of America','State'),('Texas','United States of America','State'),
	('Utah','United States of America','State'),
	('Vermont','United States of America','State'),('Virginia','United States of America','State'),
	('Washington','United States of America','State'),('West Virginia','United States of America','State'),
	('Wisconsin','United States of America','State'),('Wyoming','United States of America','State'),
	('Puerto Rico','United States of America','Territory'),('Guam','United States of America','Territory'),
	('District of Columbia','United States of America','Capital City'),
	('American Samoa','United States of America','Territory'),('Northern Mariana Islands','United States of America','Territory'),('Virgin Islands, US','United States of America','Territory'),
	-- Canada Provinces
	('Ontario','Canada','Province'),('Quebec','Canada','Province'),('Nova Scotia','Canada','Province'),('New Brunswick','Canada','Province'),('Manitoba','Canada','Province'),('British Columbia','Canada','Province'),('Prince Edward Island','Canada','Province'),('Saskatchewan','Canada','Province'),('Alberta','Canada','Province'),('Newfoundland and Labrador','Canada','Province'),
	('Canadian Northwest Territories','Canada','Territory'),('Yukon','Canada','Territory'),('Nunavut','Canada','Territory'),
	-- Mexico States
	('Aguascalientes','Mexico','State'),
	('Baja California','Mexico','State'),('Baja California Sur','Mexico','State'),
	('Campeche','Mexico','State'),('Chiapas','Mexico','State'),('Chihuahua','Mexico','State'),('Coahuila','Mexico','State'),('Colima','Mexico','State'),
	('Durango','Mexico','State'),
	('Guanajuato','Mexico','State'),('Guerrero','Mexico','State'),
	('Hidalgo','Mexico','State'),
	('Jalisco','Mexico','State'),
	('Mexico','Mexico','State'),('Mexico City','Mexico','State'),('Michoacan','Mexico','State'),('Morelos','Mexico','State'),
	('Nayarit','Mexico','State'),('Nuevo Leon','Mexico','State'),
	('Oaxaca','Mexico','State'),
	('Puebla','Mexico','State'),
	('Queretaro','Mexico','State'),('Quintana Roo','Mexico','State'),
	('San Luis Potosi','Mexico','State'),('Sinaloa','Mexico','State'),('Sonora','Mexico','State'),
	('Tabasco','Mexico','State'),('Tamaulipas','Mexico','State'),('Tlaxcala','Mexico','State'),
	('Veracruz','Mexico','State'),
	('Yucatan','Mexico','State'),
	('Zacatecas','Mexico','State'),
	-- Brazil Federative Units
	('Acre','Brazil','Federative Unit'),('Alagoas','Brazil','Federative Unit'),('Ampapa','Brazil','Federative Unit'),('Amazonas','Brazil','Federative Unit'),
	('Bahia','Brazil','Federative Unit'),
	('Ceara','Brazil','Federative Unit'),
	('Distrito Federal','Brazil','Federative Unit'),
	('Espirito Santo','Brazil','Federative Unit'),
	('Goias','Brazil','Federative Unit'),
	('Maranhao','Brazil','Federative Unit'),('Mato Grosso','Brazil','Federative Unit'),('Mato Grosso do Sul','Brazil','Federative Unit'),('Minas Gerais','Brazil','Federative Unit'),
	('Para','Brazil','Federative Unit'),('Paraiba','Brazil','Federative Unit'),('Parana','Brazil','Federative Unit'),('Pernambuco','Brazil','Federative Unit'),('Piaui','Brazil','Federative Unit'),
	('Rio de Janeiro','Brazil','Federative Unit'),('Rio Grande do Norte','Brazil','Federative Unit'),('Rio Grande do Sul','Brazil','Federative Unit'),('Rondonia','Brazil','Federative Unit'),('Roraima','Brazil','Federative Unit'),
	('Santa Catarina','Brazil','Federative Unit'),('Sao Paulo','Brazil','Federative Unit'),('Sergipe','Brazil','Federative Unit'),
	('Tocantins','Brazil','Federative Unit'),
	-- United Kingdom Countries
	('England','United Kingdom','Country'),('Northern Ireland','United Kingdom','Country'),('Scotland','United Kingdom','Country'),('Wales','United Kingdom','Country'),
	('Anguilla','United Kingdom','Territory'),('Ascension','United Kingdom','Territory'),('Bermuda','United Kingdom','Territory'),('British Antarctic Territory','United Kingdom','Territory'),('British Indian Ocean Territory','United Kingdom','Territory'),('British Virgin Islands','United Kingdom','Territory'),('Cayman Islands','United Kingdom','Territory'),('Falkland Islands','United Kingdom','Territory'),('Gibraltar','United Kingdom','Territory'),('Montserrat','United Kingdom','Territory'),('Pitcairn','United Kingdom','Territory'),('Saint Helena','United Kingdom','Territory'),('Tristan da Cunha','United Kingdom','Territory'),('Turks and Caicos Islands','United Kingdom','Territory'),
	-- France Administrative Divisions
	('Auvergne-Rhone-Alpes','France','Administrative Division'),
	('Bourgogne-Franche-Comte','France','Administrative Division'),('Brittany','France','Administrative Division'),
	('Centre-Val de Loire','France','Administrative Division'),('Corsica','France','Administrative Division'),
	('Grand Est','France','Administrative Division'),
	('Hauts-de-France','France','Administrative Division'),
	('Normandie','France','Administrative Division'),('Nouvelle-Aquitaine','France','Administrative Division'),
	('Occitanie','France','Administrative Division'),
	('Paris Region','France','Administrative Division'),('Pays de la Loire','France','Administrative Division'),('Provence Alpes Cote d’Azur','France','Administrative Division'),
	('French Guiana','France','Territory'),('French Polynesia','France','Territory'),('Guadeloupe','France','Territory'),('Martinique','France','Territory'),('Mayotte','France','Territory'),('New Caledonia','France','Territory'),('Reunion','France','Territory'),('Saint Barthelemy','France','Territory'),('Saint Martin','France','Territory'),('Saint Pierre and Miquelon','France','Territory'),('Wallis and Futuna','France','Territory'),
	-- Spain Autonomous Communities
	('Andalusia','Spain','Autonomous Community'),('Aragon','Spain','Autonomous Community'),('Asturias','Spain','Autonomous Community'),
	('Balearic Islands','Spain','Autonomous Community'),('Basque Country','Spain','Autonomous Community'),
	('Canary Islands','Spain','Autonomous Community'),('Cantabria','Spain','Autonomous Community'),('Castile and Leon','Spain','Autonomous Community'),('Castilla-La Mancha','Spain','Autonomous Community'),('Catalonia','Spain','Autonomous Community'),
	('Extremadura','Spain','Autonomous Community'),
	('Galicia','Spain','Autonomous Community'),
	('Extremadura','Spain','Autonomous Community'),
	('Galicia','Spain','Autonomous Community'),
	('La Rioja','Spain','Autonomous Community'),
	('Madrid','Spain','Autonomous Community'),('Murcia','Spain','Autonomous Community'),
	('Navarre','Spain','Autonomous Community'),
	('Valencia','Spain','Autonomous Community'),
	-- Germany States
	('Baden-Wurttemberg','Germany','State'),('Bavaria','Germany','State'),('Berlin','Germany','State'),('Brandenburg','Germany','State'),('Bremen','Germany','State'),
	('Hamburg','Germany','State'),('Hesse','Germany','State'),
	('Lower Saxony','Germany','State'),
	('Mecklenburg-Vorpommern','Germany','State'),
	('North Rhine-Westphalia','Germany','State'),
	('Rhineland-Palatinate','Germany','State'),
	('Saarland','Germany','State'),('Saxony','Germany','State'),('Saxony-Anhalt','Germany','State'),('Schleswig-Holstein','Germany','State'),
	('Thuringia','Germany','State'),
	-- Italy Administrative Divisions
	('Abruzzo','Italy','Administrative Division'),('Aosta Valley','Italy','Administrative Division'),('Apulia','Italy','Administrative Division'),
	('Basilicata','Italy','Administrative Division'),
	('Calabria','Italy','Administrative Division'),('Campania','Italy','Administrative Division'),
	('Emilia-Romagna','Italy','Administrative Division'),
	('Fruiuli-Venezia Giulia','Italy','Administrative Division'),
	('Lazio','Italy','Administrative Division'),('Liguria','Italy','Administrative Division'),('Lombardy','Italy','Administrative Division'),
	('Marche','Italy','Administrative Division'),('Molise','Italy','Administrative Division'),
	('Piedmont','Italy','Administrative Division'),
	('Sardinia','Italy','Administrative Division'),
	('Sicily','Italy','Administrative Division'),
	('Trentino-South Tyrol','Italy','Administrative Division'),('Tuscany','Italy','Administrative Division'),
	('Umbria','Italy','Administrative Division'),
	('Veneto','Italy','Administrative Division'),
	-- China Administrative Divisions
	('Anhui','China','Province'),
	('Fujian','China','Province'),
	('Gansu','China','Province'),('Guangdong','China','Province'),('Guizhou','China','Province'),
	('Hainan','China','Province'),('Hebei','China','Province'),('Heilongjiang','China','Province'),('Henan','China','Province'),('Hubei','China','Province'),('Hunan','China','Province'),
	('Jiangsu','China','Province'),('Jiangxi','China','Province'),('Jilin','China','Province'),
	('Liaoning','China','Province'),
	('Qinghai','China','Province'),
	('Shaanxi','China','Province'),('Shandong','China','Province'),('Shanxi','China','Province'),('Sichuan','China','Province'),
	('Yunnan','China','Province'),
	('Zhejiang','China','Province'),
	('Inner Mongolia','China','Autonomous Region'),('Guangxi','China','Autonomous Region'),('Tibet Autonomous Region','China','Autonomous Region'),('Ningxia','China','Autonomous Region'),('Xinjiang','China','Autonomous Region'),
	('Beijing','China','Municipality'),('Chongqing','China','Municipality'),('Shanghai','China','Municipality'),('Tianjin','China','Municipality'),
	('Hong Kong','China','Special Administrative Region'),('Macau','China','Special Administrative Region'),
	-- India Administrative Divisions
	('Andhra Pradesh','India','State'),('Arunachal Pradesh','India','State'),('Assam','India','State'),
	('Bihar','India','State'),
	('Chhattisgarh','India','State'),
	('Goa','India','State'),('Gujarat','India','State'),
	('Haryana','India','State'),('Himachal Pradesh','India','State'),
	('Jharkhand','India','State'),
	('Karnataka','India','State'),('Kerala','India','State'),
	('Madhya Pradesh','India','State'),('Maharashtra','India','State'),('Manipur','India','State'),('Meghalaya','India','State'),('Mizoram','India','State'),
	('Nagaland','India','State'),
	('Odisha','India','State'),
	('Punjab','India','State'),
	('Rarasthan','India','State'),
	('Sikkim','India','State'),
	('Tamil Nadu','India','State'),('Telangana','India','State'),('Tripura','India','State'),
	('Uttar Pradesh','India','State'),('Uttarakhand','India','State'),
	('West Bengal','India','State'),
	('Andaman and Nicobar Islands','India','Union Territory'),
	('Chandigarh','India','Union Territory'),
	('Dadra and Nagar Haveli and Daman and Diu','India','Union Territory'),('Delhi','India','Union Territory'),
	('Jammu and Kashmir','India','Union Territory'),
	('Ladakh','India','Union Territory'),('Lakshadweep','India','Union Territory'),
	('Puducherry','India','Union Territory'),
	-- Australia States
	('New South Wales','Australia','State'),('Victoria','Australia','State'),('Queensland','Australia','State'),('Western Australia','Australia','State'),('South Australia','Australia','State'),('Tasmania','Australia','State'),
	('Australian Capital Territory','Australia','Territory'),('Australia Northern Territory','Australia','Territory'),('Jervis Bay Territory','Australia','Territory'),('Norfolk Island','Australia','Territory'),('Christmas Island','Australia','Territory'),('Cocos Islands','Australia','Territory'),('Australian Antarctic Territory','Australia','Territory'),('Coral Sea Islands','Australia','Territory'),('Ashmore and Cartier Islands','Australia','Territory'),('Heard Island and McDonald Islands','Australia','Territory'),
	-- New Zealand Regional Councils
	('Auckland','New Zealand','Regional Council'),
	('Bay of Plenty','New Zealand','Regional Council'),
	('Canterbury','New Zealand','Regional Council'),
	('Gisborne','New Zealand','Regional Council'),
	('Hawkes Bay','New Zealand','Regional Council'),
	('Manawatū-Whanganui','New Zealand','Regional Council'),('Marlborough','New Zealand','Regional Council'),
	('Nelson','New Zealand','Regional Council'),('Northland','New Zealand','Regional Council'),
	('Otago','New Zealand','Regional Council'),
	('Southland','New Zealand','Regional Council'),
	('Taranaki','New Zealand','Regional Council'),('Tasman','New Zealand','Regional Council'),
	('Waikato','New Zealand','Regional Council'),('Wellington','New Zealand','Regional Council'),('West Coast','New Zealand','Regional Council'),
	-- ('','New Zealand','Territory'),
	('Cook Islands','New Zealand','Associated State'),('Niue','New Zealand','Associated State'),
	-- Unspecified
	('Unspecified','Unspecified','Unspecified')
GO

/* ======================================================
	print '' print '*** inserting pre-made cities ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Kabul','Afghanistan'),('Herat','Afghanistan'),('Mazar-i-Sharif','Afghanistan'),('Kandahar','Afghanistan'),('Jalalabad','Afghanistan'),('Lashkargah','Afghanistan'),('Kunduz','Afghanistan'),('Taloqan','Afghanistan'),('Puli Khumri','Afghanistan'),('Sheberghan','Afghanistan'),('Zaranj','Afghanistan'),('Maymana','Afghanistan'),('Ghazni','Afghanistan'),('Khost','Afghanistan'),
	('Tirana','Albania'),('Durres','Albania'),('Vlore','Albania'),('Elbasan','Albania'),('Shkoder','Albania'),('Kamez','Albania'),('Fier','Albania'),('Korçe','Albania'),
	('Algiers','Algeria'),('Oran','Algeria'),('Constantine','Algeria'),('Annaba','Algeria'),('Blida','Algeria'),('Batna','Algeria'),('Djelfa','Algeria'),('Setif','Algeria'),('Sidi bel Abbes','Algeria'),('Biskra','Algeria'),('Tebessa','Algeria'),('Skikda','Algeria'),('Tiaret','Algeria'),('Bejaïa','Algeria'),('Tlemcen','Algeria'),('Bechar','Algeria'),('Mostaganem','Algeria'),('Bordj Bou Arreridj','Algeria'),('Chlef','Algeria'),('Souk Ahras','Algeria'),
	('Andorra la Vella','Andorra'),('Escaldes-Engordany','Andorra'),('Encamp','Andorra'),('Sant Julià de Loria','Andorra'),('La Massana','Andorra'),
	('Luanda','Angola'),('Cabinda','Angola'),('Huambo','Angola'),('Bailundo','Angola'),('Andulo','Angola'),('Lubango','Angola'),('Kuito','Angola'),('Malanje','Angola'),('Lobito','Angola'),('Benguela','Angola'),('Uige','Angola'),('Luau','Angola'),('Balombo','Angola'),('Baia Farta','Angola'),('Alto Caule','Angola'),
	('Saint Johns','Antigua and Barbuda'),('All Saints','Antigua and Barbuda'),('Libera','Antigua and Barbuda'),
	('Buenos Aires','Argentina'),('Cordoba','Argentina'),('Rosario','Argentina'),('La Plata','Argentina'),('Mar del Plata','Argentina'),('San Miguel de Tucuman','Argentina'),('Salta','Argentina'),('Santa Fe de la Vera Cruz','Argentina'),('Vicente Lopez Partido','Argentina'),('Corrientes','Argentina'),('Pilar','Argentina'),('Bahia Blanca','Argentina'),('Resistencia','Argentina'),('Posadas','Argentina'),('San Salvador de Jujuy','Argentina'),('Santiago del Estero','Argentina'),('Parana','Argentina'),('Merlo','Argentina'),('Neuquen','Argentina'),('Quilmes','Argentina'),
	('Yerevan','Armenia'),('Gyumri','Armenia'),('Vanadzor','Armenia'),('Vagharshapat','Armenia'),('Hrazdan','Armenia'),('Kapan','Armenia'),('Abovyan','Armenia'),
	('Vienna','Austria'),('Graz','Austria'),('Linz','Austria'),('Salzburg','Austria'),('Innsbruck','Austria'),('Klagenfurt','Austria'),('Wels','Austria'),('Villach','Austria'),('Sankt Pölten','Austria'),('Dorbirn','Austria'),
	('Baku','Azerbaijan'),('Sumgait','Azerbaijan'),('Ganja','Azerbaijan'),('Xırdalan','Azerbaijan'),('Mingachevir','Azerbaijan'),('Nakhchivan','Azerbaijan'),('Lankaran','Azerbaijan'),('Shirvan','Azerbaijan'),('Shaki','Azerbaijan'),('Yevlakh','Azerbaijan')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Nassau','Bahamas'),('Lucaya','Bahamas'),('Freeport','Bahamas'),('West End','Bahamas'),
	('Manama','Bahrain'),('Muharraq','Bahrain'),('Hamad Town','Bahrain'),('Riffa','Bahrain'),('Aali','Bahrain'),('Sitra','Bahrain'),('Jidhafs','Bahrain'),('Isa Town','Bahrain'),('Budaiya','Bahrain'),('Diraz','Bahrain'),
	('Dhaka','Bangledesh'),('Chattogram','Bangledesh'),('Khulna','Bangledesh'),('Comilla','Bangledesh'),('Rajshahi','Bangledesh'),('Sylhet','Bangledesh'),('Barisal','Bangledesh'),('Rangpur','Bangledesh'),('Bogura','Bangledesh'),('Sirajganj','Bangledesh'),('Savar','Bangledesh'),('Brahmanbaria','Bangledesh'),('Sreepur','Bangledesh'),('Kaliakair','Bangledesh'),('Faridpur','Bangledesh'),('Feni','Bangledesh'),('Kushtia','Bangledesh'),('Tangail','Bangledesh'),('Dinajpur','Bangledesh'),('Jashore','Bangledesh'),('Chandpur','Bangledesh'),('Chapai Nawabganj','Bangledesh'),
	('Bridgetown','Barbados'),('Speightstown','Barbados'),('Oistins','Barbados'),('Bathsheba','Barbados'),('Holetown','Barbados'),
	('Minsk','Belarus'),('Homyel','Belarus'),('Mahilyow','Belarus'),('Vitsyebsk','Belarus'),('Hrodna','Belarus'),('Brest','Belarus'),('Babruysk','Belarus'),('Baranavichy','Belarus'),('Barysaw','Belarus'),('Pinsk','Belarus'),('Orsha','Belarus'),('Mazyr','Belarus'),('Salihorsk','Belarus'),
	('Antwerp','Belgium'),('Ghent','Belgium'),('Charleroi','Belgium'),('Liege','Belgium'),('Brussels','Belgium'),('Schaerbeek','Belgium'),('Anderlecht','Belgium'),('Bruges','Belgium'),('Namur','Belgium'),('Leuven','Belgium'),
	('Belize City','Belize'),('Belmopan','Belize'),('Orange Walk Town','Belize'),('San Pedro','Belize'),('San Ignacio','Belize'),('Corozal Town','Belize'),
	('Cotonou','Benin'),('Porto-Novo','Benin'),('Parakou','Benin'),('Abomey','Benin'),('Djougou','Benin'),('Bohicon','Benin'),('Kandi','Benin'),('Natitingou','Benin'),('Ouidah','Benin'),('Lokossa','Benin'),
	('Thimphu','Bhutan'),('Phuntsholing','Bhutan'),('Paro','Bhutan'),('Gelephu','Bhutan'),('Samdrup Jongkhar','Bhutan'),('Wangdue Phodrang','Bhutan'),('Punahka','Bhutan'),('Jakar','Bhutan'),('Nganglam','Bhutan'),('Samtse','Bhutan'),
	('Santa Cruz de la Sierra','Bolivia'),('El Alto','Bolivia'),('La Paz','Bolivia'),('Cochabamba','Bolivia'),('Oruro','Bolivia'),('Sucre','Bolivia'),('Tarija','Bolivia'),('Potosi','Bolivia'),('Sacaba','Bolivia'),('Quillacollo','Bolivia'),('Montero','Bolivia'),('Trinidad','Bolivia'),('Riberalta','Bolivia'),('Warnes','Bolivia'),('La Guardia','Bolivia'),
	('Sarajevo','Bosnia and Herzegovina'),('Banja Luka','Bosnia and Herzegovina'),('Tuzla','Bosnia and Herzegovina'),('Zenica','Bosnia and Herzegovina'),('Bijelina','Bosnia and Herzegovina'),('Mostar','Bosnia and Herzegovina'),
	('Gaborone','Botswana'),('Francistown','Botswana'),('Mogoditshane','Botswana'),('Maun','Botswana'),('Molepolole','Botswana'),('Serowe','Botswana'),('Tlokweng','Botswana'),('Palapye','Botswana'),('Mochudi','Botswana'),('Mahalapye','Botswana'),
	('Bandar Seri Begawan','Brunei'),('Kuala Belait','Brunei'),('Seria','Brunei'),
	('Sofia','Bulgaria'),('Plovdiv','Bulgaria'),('Varna','Bulgaria'),('Burgas','Bulgaria'),('Ruse','Bulgaria'),('Stara Zagora','Bulgaria'),('Pleven','Bulgaria'),('Sliven','Bulgaria'),('Dobrich','Bulgaria'),('Shumen','Bulgaria'),
	('Ouagadougou','Burkina Faso'),('Bobo-Dioulasso','Burkina Faso'),('Koudougou','Burkina Faso'),('Ouahigouya','Burkina Faso'),('Kaya','Burkina Faso'),('Banfora','Burkina Faso'),('Pouytenga','Burkina Faso'),('Hounde','Burkina Faso'),('Fada NGourma','Burkina Faso'),('Dedougou','Burkina Faso'),
	('Bujumbura','Burundi'),('Gitega','Burundi'),('Muyinga','Burundi'),('Ngozi','Burundi'),('Ruyigi','Burundi'),('Kayanza','Burundi'),('Bururi','Burundi'),('Muramvya','Burundi'),('Makamba','Burundi'),('Rumonge','Burundi')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Phnom Penh','Cambodia'),('Takeo','Cambodia'),('Sinhanoukville','Cambodia'),('Battambang','Cambodia'),('Siem Reap','Cambodia'),('Paoy Paet','Cambodia'),('Kampong Chhnang','Cambodia'),('Kanpong Cham','Cambodia'),('Pursat','Cambodia'),('Ta Khmau','Cambodia'),
	('Douala','Cameroon'),('Yaounde','Cameroon'),('Garoura','Cameroon'),('Kousseri','Cameroon'),('Bamenda','Cameroon'),('Maroura','Cameroon'),('Bafoussam','Cameroon'),('Mokolo','Cameroon'),('Ngaoundere','Cameroon'),('Bertoua','Cameroon'),
	('Praia','Cabo Verde'),('Mindelo','Cabo Verde'),('Espargos','Cabo Verde'),('Assomada','Cabo Verde'),('Pedra Badejo','Cabo Verde'),
	('Bangui','Central African Republic'),('Bimbo','Central African Republic'),('Berberati','Central African Republic'),('Carnot','Central African Republic'),('Bambari','Central African Republic'),('Bouar','Central African Republic'),('Bossangoa','Central African Republic'),('Bria','Central African Republic'),('Bangassou','Central African Republic'),('Nola','Central African Republic'),
	('NDjamena','Chad'),('Moundou','Chad'),('Sarh','Chad'),('Abeche','Chad'),('Kelo','Chad'),('Koumra','Chad'),('Pala','Chad'),('Am Timan','Chad'),('Mongo','Chad'),('Bongor','Chad'),
	('Santaigo','Chile'),('Puente Alto','Chile'),('Antofagasta','Chile'),('Vina del Mar','Chile'),('Valparaiso','Chile'),('Talcahuano','Chile'),('San Bernardo','Chile'),('Temuco','Chile'),('Iquique','Chile'),('Concepcion','Chile'),
	('Bogota','Colombia'),('Medellin','Colombia'),('Cali','Colombia'),('Barranquilla','Colombia'),('Cartagena','Colombia'),('Cucuta','Colombia'),('Soledad','Colombia'),('Ibague','Colombia'),('Soacha','Colombia'),('Bucaramanga','Colombia'),('Villavicencio','Colombia'),('Santa Maria','Colombia'),
	('Moroni','Comoros'),('Moutsamoudou','Comoros'),('Fomboni','Comoros'),('Domoni','Comoros'),('Tsimbeo','Comoros'),
	('San Jose','Costa Rica'),('Limon','Costa Rica'),('San Francisco','Costa Rica'),('Alajuela','Costa Rica'),('Liberia','Costa Rica'),('Paraiso','Costa Rica'),('Puntarenas','Costa Rica'),('San Isidro','Costa Rica'),('Curridabat','Costa Rica'),('San Vincente','Costa Rica'),
	('Zagreb','Croatia'),('Split','Croatia'),('Rijeka','Croatia'),('Osijek','Croatia'),('Zadar','Croatia'),('Velika Gorica','Croatia'),('Pula','Croatia'),('Slavonski Brod','Croatia'),('Karlovac','Croatia'),('Varaždin','Croatia'),
	('Havana','Cuba'),('Santiago de Cuba','Cuba'),('Camaguey','Cuba'),('Holguin','Cuba'),('Santa Clara','Cuba'),('Guantanamo','Cuba'),('Las Tunas','Cuba'),('Bayamo','Cuba'),('Cienfuegos','Cuba'),('Matanzas','Cuba'),
	('Nicosia','Cyprus'),('Limassol','Cyprus'),('Larnaca','Cyprus'),('Famagusta','Cyprus'),('Paphos','Cyprus'),('Kyrenia','Cyprus'),('Protaras','Cyprus'),('Pergamos','Cyprus'),('Morfou','Cyprus'),('Aradippou','Cyprus'),
	('Prague','Czechia'),('Brno','Czechia'),('Ostrava','Czechia'),('Plzeň','Czechia'),('Liberec','Czechia'),('Olomouc','Czechia'),('Česke Budějovice','Czechia'),('Hradec Kralove','Czechia'),('Pardubice','Czechia'),('Ústi nad Labem','Czechia')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Kinshasa','Democratic Republic of the Congo'),('Lubumbashi','Democratic Republic of the Congo'),('Mbuji-Mayi','Democratic Republic of the Congo'),('Kisangani','Democratic Republic of the Congo'),('Masina','Democratic Republic of the Congo'),('Kananga','Democratic Republic of the Congo'),('Likasi','Democratic Republic of the Congo'),('Kolwezi','Democratic Republic of the Congo'),('Tshikapa','Democratic Republic of the Congo'),('Beni','Democratic Republic of the Congo'),('Bukavu','Democratic Republic of the Congo'),('Mwene-Ditu','Democratic Republic of the Congo'),('Kikwit','Democratic Republic of the Congo'),('Mbandaka','Democratic Republic of the Congo'),('Matadi','Democratic Republic of the Congo'),('Uvira','Democratic Republic of the Congo'),('Boma','Democratic Republic of the Congo'),('Butembo','Democratic Republic of the Congo'),('Gandajika','Democratic Republic of the Congo'),('Kalemie','Democratic Republic of the Congo'),
	('Copenhagen','Denmark'),('Arhus','Denmark'),('Odense','Denmark'),('Aalborg','Denmark'),('Frederiksberg','Denmark'),('Esbjerg','Denmark'),('Randers','Denmark'),('Kolding','Denmark'),('Vejle','Denmark'),('Horsens','Denmark'),
	('Djibouti City','Djibouti'),('Ali Sabieh','Djibouti'),('Dikhil','Djibouti'),('Tadjoura','Djibouti'),('Arta','Djibouti'),('Obock','Djibouti'),
	('Roseau','Dominica'),('Portsmouth','Dominica'),('Berekua','Dominica'),('Saint Joseph','Dominica'),('Wesley','Dominica'),
	('Santo Domingo','Dominican Republic'),('Santiago de los Caballeros','Dominican Republic'),('Santo Domingo Oeste','Dominican Republic'),('Santo Domingo Este','Dominican Republic'),('San Pedro de Macoris','Dominican Republic'),('La Romana','Dominican Republic'),('Bella Vista','Dominican Republic'),('San Cristobal','Dominican Republic'),('Peurto Plata','Dominican Republic')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Dili','Timor-Leste'),('Maliana','Timor-Leste'),('Suai','Timor-Leste'),('Likisa','Timor-Leste'),('Aileu','Timor-Leste'),
	('Guayaquil','Ecuador'),('Quito','Ecuador'),('Cuenca','Ecuador'),('Santo Domingo de los Colorados','Ecuador'),('Machala','Ecuador'),('Manta','Ecuador'),('Portoviejo','Ecuador'),('Eloy Alfaro','Ecuador'),('Esmeraldas','Ecuador'),('Ambata','Ecuador'),
	('Cairo','Egypt'),('Alexandria','Egypt'),('Giza','Egypt'),('Port Said','Egypt'),('Suez','Egypt'),('Al Mahallah al Kubra','Egypt'),('Luxor','Egypt'),('Asyut','Egypt'),('Al Mansurah','Egypt'),('Tanda','Egypt'),('Al Fayyum','Egypt'),('Zagazig','Egypt'),('Ismailia','Egypt'),('Kafr ad Dawwar','Egypt'),('Aswan','Egypt'),
	('San Salvador','El Salvador'),('Soyapango','El Salvador'),('Santa Ana','El Salvador'),('San Miguel','El Salvador'),('Mejicanos','El Salvador'),('Santa Tecla','El Salvador'),('Apopa','El Salvador'),('Delgado','El Salvador'),('Sonsonate','El Salvador'),('San Marcos','El Salvador'),
	('Bata','Equatorial Guinea'),('Malabo','Equatorial Guinea'),('Ebebiyin','Equatorial Guinea'),('Aconibe','Equatorial Guinea'),('Anisoc','Equatorial Guinea'),
	('Asmara','Eritrea'),('Keren','Eritrea'),('Massawa','Eritrea'),('Assab','Eritrea'),('Mendefera','Eritrea'),('Barentu','Eritrea'),('Adi Keyh','Eritrea'),('Edd','Eritrea'),('Dekemhare','Eritrea'),('Akordat','Eritrea'),
	('Tallinn','Estonia'),('Tartu','Estonia'),('Narva','Estonia'),('Kohtla-Jaerve','Estonia'),('Paernu','Estonia'),('Viljandi','Estonia'),('Rakvere','Estonia'),('Sillamaee','Estonia'),('Maardu','Estonia'),('Kuressaare','Estonia'),
	('Manzini','Eswatini'),('Mbabane','Eswatini'),('Big Bend','Eswatini'),('Malkerns','Eswatini'),('Nhlangano','Eswatini'),
	('Addis Ababa','Ethiopia'),('Dire Dawa','Ethiopia'),('Mekele','Ethiopia'),('Nazret','Ethiopia'),('Bahir Dar','Ethiopia'),('Gondar','Ethiopia'),('Dese','Ethiopia'),('Hawassa','Ethiopia'),('Jimma','Ethiopia'),('Bishoftu','Ethiopia'),('Kombolcha','Ethiopia'),('Harar','Ethiopia'),('Sodo','Ethiopia'),('Shashemene','Ethiopia'),('Hosaina','Ethiopia')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Weno','Federated States of Micronesia'),('Tofol','Federated States of Micronesia'),('Colonia','Federated States of Micronesia'),('Kolonia','Federated States of Micronesia'),('Kolonia Town','Federated States of Micronesia'),
	('Suva','Fiji'),('Lautoka','Fiji'),('Nadi','Fiji'),('Labasa','Fiji'),('Ba','Fiji'),('Levuka','Fiji'),
	('Helsinki','Finland'),('Espoo','Finland'),('Tampere','Finland'),('Vantaa','Finland'),('Turku','Finland'),('Oulu','Finland'),('Lahti','Finland'),('Kuopio','Finland'),('Jyvaeskylae','Finland'),('Pori','Finland')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Libreville','Gabon'),('Port-Gentil','Gabon'),('Franceville','Gabon'),('Oyem','Gabon'),('Moanda','Gabon'),('Mouila','Gabon'),('Lambarene','Gabon'),('Tchibanga','Gabon'),('Koulamoutou','Gabon'),('Makokou','Gabon'),
	('Serekunda','Gambia'),('Brikama','Gambia'),('Bakau','Gambia'),('Banjul','Gambia'),('Farafenni','Gambia'),('Lamin','Gambia'),('Sukuta','Gambia'),('Bassee Santa Su','Gambia'),('Gunjur','Gambia'),('Soma','Gambia'),
	('Tbilisi','Georgia'),('Kutaisi','Georgia'),('Batumi','Georgia'),('Rustavi','Georgia'),('Sukhumi','Georgia'),('Zugdidi','Georgia'),('Gori','Georgia'),('Poti','Georgia'),('Tskhinvali','Georgia'),('Samtredia','Georgia'),
	('Accra','Ghana'),('Kumasi','Ghana'),('Tamale','Ghana'),('Takoradi','Ghana'),('Atsiaman','Ghana'),('Tema','Ghana'),('Teshi Old Town','Ghana'),('Cape Coast','Ghana'),('Sekondi-Takoradi','Ghana'),('Obuase','Ghana'),
	('Athens','Greece'),('Thessaloniki','Greece'),('Patra','Greece'),('Piraeus','Greece'),('Larisa','Greece'),('Peristeri','Greece'),('Irakleion','Greece'),('Kallithea','Greece'),('Acharnes','Greece'),('Kalamaria','Greece'),
	('Saint Georges','Grenada'),('Gouyave','Grenada'),('Grenville','Grenada'),('Victoria','Grenada'),('Saint Davids','Grenada'),('Sauteurs','Grenada'),('Hillsborough','Grenada'),
	('Guatemala City','Guatemala'),('Mixco','Guatemala'),('Villa Nueva','Guatemala'),('Petapa','Guatemala'),('San Juan Sacatepequez','Guatemala'),('Quetzaltenango','Guatemala'),('Villa Canales','Guatemala'),('Escuintla','Guatemala'),('Chinautla','Guatemala'),('Chimaltenango','Guatemala'),
	('Camayenne','Guinea'),('Conakry','Guinea'),('Nzerekore','Guinea'),('Kindia','Guinea'),('Kankan','Guinea'),('Gueckedou','Guinea'),('Coyah','Guinea'),('Labe','Guinea'),('Kissidougou','Guinea'),('Fria','Guinea'),
	('Bissau','Guinea-Bissau'),('Bafata','Guinea-Bissau'),('Gabu','Guinea-Bissau'),('Bissora','Guinea-Bissau'),('Bolama','Guinea-Bissau'),('Cacheu','Guinea-Bissau'),('Catio','Guinea-Bissau'),('Bubaque','Guinea-Bissau'),('Mansoa','Guinea-Bissau'),('Buba','Guinea-Bissau'),
	('Georgetown','Guyana'),('Linden','Guyana'),('New Amsterdam','Guyana'),('Anna Regina','Guyana'),('Bartica','Guyana'),('Skeldon','Guyana'),('Rosignol','Guyana'),('Mahdia','Guyana'),('Vreed-en-Hoop','Guyana')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Port-au-Prince','Haiti'),('Carrefour','Haiti'),('Delmas 73','Haiti'),('Port-de-Paix','Haiti'),('Croix-des-Bouquets','Haiti'),('Jacmel','Haiti'),('Okap','Haiti'),('Leogane','Haiti'),('Les Cayes','Haiti'),('Tigwav','Haiti'),
	('Tegucigalpa','Honduras'),('San Pedro Sula','Honduras'),('Choloma','Honduras'),('La Ceiba','Honduras'),('El Progreso','Honduras'),('Ciudad Choluteca','Honduras'),('Comayagua','Honduras'),('Puerto Cortez','Honduras'),('La Lima','Honduras'),('Danli','Honduras'),('Siguatepeque','Honduras'),
	('Budapest','Hungary'),('Debrecen','Hungary'),('Miskolc','Hungary'),('Szeged','Hungary'),('Pecs','Hungary'),('Budapest XI. keruelet','Hungary'),('Zuglo','Hungary'),('Gyor','Hungary'),('Budapest III. keruelet','Hungary'),('Nyiregyhaza','Hungary')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Reykjavik','Iceland'),('Kopavogur','Iceland'),('Hafnarfjoerdur','Iceland'),('Akureyri','Iceland'),('Gardabaer','Iceland'),('Mosfellsbaer','Iceland'),('Akranes','Iceland'),('Selfoss','Iceland'),
	('Jakarta','Indonesia'),('Surabaya','Indonesia'),('Medan','Indonesia'),('Bandung','Indonesia'),('Bekasi','Indonesia'),('Palembang','Indonesia'),('Tangerang','Indonesia'),('Makassar','Indonesia'),('South tangerang','Indonesia'),('Semarang','Indonesia'),('Depok','Indonesia'),('Batam','Indonesia'),('Padang','Indonesia'),('Denpasar','Indonesia'),('Bandar Lampung','Indonesia'),('Bogor','Indonesia'),('Malang','Indonesia'),('Pekanbaru','Indonesia'),('City of Balikpapan','Indonesia'),('Yogyakarta','Indonesia'),
	('Tehran','Iran'),('Isfahan','Iran'),('Mashhad','Iran'),('Karaj','Iran'),('Shiraz','Iran'),('Tabriz','Iran'),('Qom','Iran'),('Ahvaz','Iran'),('Kermanshah','Iran'),('Urmia','Iran'),('Rasht','Iran'),('Zahedan','Iran'),('Hamadan','Iran'),('Kerman','Iran'),('Yazd','Iran'),
	('Baghdad','Iraq'),('Basrah','Iraq'),('Al Mawsil al Jadidah','Iraq'),('Al Basrah al Qadimah','Iraq'),('Mosul','Iraq'),('Erbil','Iraq'),('Abu Ghurayb','Iraq'),('As Sulaymaniyah','Iraq'),('Kirkuk','Iraq'),('Najaf','Iraq'),
	('Dublin','Ireland'),('Cork','Ireland'),('Dun Laoghaire','Ireland'),('Luimneach','Ireland'),('Gailimh','Ireland'),('Tallaght','Ireland'),('Waterford','Ireland'),('Swords','Ireland'),('Drogheda','Ireland'),('Dundalk','Ireland'),
	('Jerusalem','Israel'),('Tel Aviv','Israel'),('West Jerusalem','Israel'),('Haifa','Israel'),('Ashdod','Israel'),('Rishon LeZiyyon','Israel'),('Petah Tiqwa','Israel'),('Beersheba','Israel'),('Netanya','Israel'),('Holon','Israel'),
	('Abidjan','Ivory Coast'),('Abobo','Ivory Coast'),('Bouake','Ivory Coast'),('Daloa','Ivory Coast'),('San-Pedro','Ivory Coast'),('Yamoussoukro','Ivory Coast'),('Korhogo','Ivory Coast'),('Man','Ivory Coast'),('Divo','Ivory Coast'),('Gagnoa','Ivory Coast')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Kingston','Jamaica'),('New Kingston','Jamaica'),('Spanish Town','Jamaica'),('Portmore','Jamaica'),('Montego Bay','Jamaica'),('Mandeville','Jamaica'),('May Pen','Jamaica'),('Old Harbour','Jamaica'),('Linstead','Jamaica'),
	('Tokyo','Japan'),('Yokohama','Japan'),('Osaka','Japan'),('Nagoya','Japan'),('Sapporo','Japan'),('Kobe','Japan'),('Kyoto','Japan'),('Fukuoka','Japan'),('Kawasaki','Japan'),('Hiroshima','Japan'),('Yono','Japan'),('Sendai','Japan'),('Kitakyushu','Japan'),('Chiba','Japan'),('Sakai','Japan'),('Shizuoka','Japan'),('Kumamoto','Japan'),('Okayama','Japan'),('Hamamatsu','Japan'),('Hachioji','Japan'),('Honcho','Japan'),('Kagoshima','Japan'),('Niigata','Japan'),
	('Amman','Jordan'),('Zarqa','Jordan'),('Irbid','Jordan'),('Russeifa','Jordan'),('Wadi as Sir','Jordan'),('Ajlun','Jordan'),('Aqaba','Jordan'),('Rukban','Jordan'),('Madaba','Jordan'),('As Salt','Jordan')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Almaty','Kazakhstan'),('Karagandy','Kazakhstan'),('Shymkent','Kazakhstan'),('Taraz','Kazakhstan'),('Astana','Kazakhstan'),('Pavlodar','Kazakhstan'),('Ust-Kamenogorsk','Kazakhstan'),('Kyzylorda','Kazakhstan'),('Semey','Kazakhstan'),('Aktobe','Kazakhstan'),
	('Nairobi','Kenya'),('Mombasa','Kenya'),('Nakuru','Kenya'),('Eldoret','Kenya'),('Kisumu','Kenya'),('Thika','Kenya'),('Malindi','Kenya'),('Kitale','Kenya'),('Garissa','Kenya'),('Kakamega','Kenya'),
	('Tarawa','Kiribati'),('Betio Village','Kiribati'),('Bikenibeu Village','Kiribati'),
	('Pristina','Kosovo'),('Prizren','Kosovo'),('Gjilan','Kosovo'),('Peja','Kosovo'),('Mitrovica','Kosovo'),
	('Al Ahmadi','Kuwait'),('Hawalli','Kuwait'),('As Salimiyah','Kuwait'),('Sabah as Salim','Kuwait'),('Al Farwaniyah','Kuwait'),('Al Fahahil','Kuwait'),('Kuwait City','Kuwait'),('Ar Rumaythiyah','Kuwait'),('Ar Riqqah','Kuwait'),('Salwa','Kuwait'),
	('Bishkek','Kyrgyzstan'),('Osh','Kyrgyzstan'),('Jalal-Abad','Kyrgyzstan'),('Karakol','Kyrgyzstan'),('Tokmok','Kyrgyzstan'),('Kara-Balta','Kyrgyzstan'),('Naryn','Kyrgyzstan'),('Uzgen','Kyrgyzstan'),('Balykchy','Kyrgyzstan'),('Talas','Kyrgyzstan')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Vientiane','Laos'),('Pakse','Laos'),('Thakhek','Laos'),('Savannakhet','Laos'),('Luang Prabang','Laos'),('Xam Nua','Laos'),('Muang Phonsavan','Laos'),('Muang Xay','Laos'),('Vangviang','Laos'),('Muang Pakxan','Laos'),
	('Riga','Latvia'),('Daugavpils','Latvia'),('Liepaja','Latvia'),('Jelgava','Latvia'),('Jurmala','Latvia'),('Ventspils','Latvia'),('Rezekne','Latvia'),('Jekabpils','Latvia'),('Valmiera','Latvia'),('Ogre','Latvia'),
	('Beirut','Lebanon'),('Ras Bayrut','Lebanon'),('Tripoli','Lebanon'),('Sidon','Lebanon'),('Tyre','Lebanon'),('Nabatiye et Tahta','Lebanon'),('Habbouch','Lebanon'),('Jounieh','Lebanon'),('Zahle','Lebanon'),('Baalbek','Lebanon'),
	('Maseru','Lesotho'),('Mafeteng','Lesotho'),('Leribe','Lesotho'),('Maputsoe','Lesotho'),('Mohales Hoek','Lesotho'),('Qachas Nek','Lesotho'),('Quthing','Lesotho'),('Butha-Buthe','Lesotho'),
	('Monrovia','Liberia'),('Gbarnga','Liberia'),('Kakata','Liberia'),('Bensonville','Liberia'),('Harper','Liberia'),('Voinjama','Liberia'),('Buchanan','Liberia'),('Zwedru','Liberia'),('New Yekepa','Liberia'),('Greenville','Liberia'),
	('Tripoli','Libya'),('Benghazi','Libya'),('Misratah','Libya'),('Tarhuna','Libya'),('Al Khums','Libya'),('Az Zawiyah','Libya'),('Zawiya','Libya'),('Ajdabiya','Libya'),('Al Ajaylat','Libya'),('Sabha','Libya'),('Sirte','Libya'),('Al Jadid','Libya'),
	('Schaan','Liechtenstein'),('Vaduz','Liechtenstein'),('Triesen','Liechtenstein'),('Balzers','Liechtenstein'),('Eschen','Liechtenstein'),
	('Vilnius','Lithuania'),('Kaunas','Lithuania'),('Klaipeda','Lithuania'),('Siauliai','Lithuania'),('Panevezys','Lithuania'),('Alytus','Lithuania'),('Dainava','Lithuania'),('Eiguliai','Lithuania'),('Mazeikiai','Lithuania'),('Silainiai','Lithuania'),
	('Luxembourg','Luxembourg'),('Esch-sur-Alzette','Luxembourg'),('Dudelange','Luxembourg'),('Schifflange','Luxembourg'),('Bettembourg','Luxembourg')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Antananarivo','Madagascar'),('Toamasina','Madagascar'),('Antsirabe','Madagascar'),('Fianarantsoa','Madagascar'),('Mahajanga','Madagascar'),('Toliara','Madagascar'),('Antsiranana','Madagascar'),('Antanifotsy','Madagascar'),('Ambovombe','Madagascar'),('Ambilobe','Madagascar'),
	('Lilongwe','Malawi'),('Blantyre','Malawi'),('Mzuzu','Malawi'),('Zomba','Malawi'),('Kasungu','Malawi'),('Mangochi','Malawi'),('Salima','Malawi'),('Nkhotakota','Malawi'),('Liwonde','Malawi'),('Nsanje','Malawi'),
	('Kota Bharu','Malaysia'),('Kuala Lumpur','Malaysia'),('Klang','Malaysia'),('Kampung Baru Subang','Malaysia'),('Johor Bahru','Malaysia'),('Subang Jaya','Malaysia'),('Ipoh','Malaysia'),('Kuching','Malaysia'),('Petaling Jaya','Malaysia'),('Shah Alam','Malaysia'),
	('Male','Maldives'),('Fuvahmulah','Maldives'),('Hithadhoo','Maldives'),('Kulhudhuffushi','Maldives'),('Thinadhoo','Maldives'),
	('Bamako','Mali'),('Sikasso','Mali'),('Mopti','Mali'),('Koutiala','Mali'),('Segou','Mali'),('Gao','Mali'),('Kayes','Mali'),('Markala','Mali'),('Kolokani','Mali'),('Kati','Mali'),
	('Birkirkara','Malta'),('Qormi','Malta'),('Mosta','Malta'),('Zabbar','Malta'),('San Pawl il-Bahar','Malta'),
	('Majuro','Marshall Islands'),('Ebaye','Marshall Islands'),('Arno','Marshall Islands'),('Jabor','Marshall Islands'),
	('Nouakchott','Mauritania'),('Nouadhibou','Mauritania'),('Nema','Mauritania'),('Kaedi','Mauritania'),('Rosso','Mauritania'),('Kiffa','Mauritania'),('Zouerate','Mauritania'),('Atar','Mauritania'),('Tekane','Mauritania'),('Selibaby','Mauritania'),
	('Port Louis','Mauritus'),('Beau Bassin-Rose Hill','Mauritus'),('Vacoas','Mauritus'),('Curepipe','Mauritus'),('Quatre Bornes','Mauritus'),('Triolet','Mauritus'),('Goodlands','Mauritus'),('Centre de Flacq','Mauritus'),('Bel Air Riviere Seche','Mauritus'),('Mahebourg','Mauritus'),
	('Chisinau','Moldova'),('Tiraspol','Moldova'),('Balti','Moldova'),('Bender','Moldova'),('Ribnita','Moldova'),('Cahul','Moldova'),('Ungheni','Moldova'),('Soroca','Moldova'),('Orhei','Moldova'),('Dubasari','Moldova'),
	('Monaco','Monaco'),('Monte-Carlo','Monaco'),('La Condamine','Monaco'),
	('Ulaanbaatar','Mongolia'),('Erdenet','Mongolia'),('Darkhan','Mongolia'),('Choibalsan','Mongolia'),('Mörön','Mongolia'),('Nalaikh','Mongolia'),('Bayankhongor','Mongolia'),('Ölgii','Mongolia'),('Khovd','Mongolia'),('Arvaikheer','Mongolia'),
	('Podgorica','Montenegro'),('Niksic','Montenegro'),('Herceg-Novi','Montenegro'),('Pljevlja','Montenegro'),('Budva','Montenegro'),('Bar','Montenegro'),('Bijelo Polje','Montenegro'),('Cetinje','Montenegro'),('Berane','Montenegro'),('Ulcinj','Montenegro'),
	('Casablanca','Morocco'),('Rabat','Morocco'),('Fes','Morocco'),('Sale','Morocco'),('Marrakesh','Morocco'),('Agadir','Morocco'),('Tangier','Morocco'),('Meknes','Morocco'),('Oujda-Angad','Morocco'),('Al Hoceima','Morocco'),
	('Maputo','Mozambique'),('Matola','Mozambique'),('Beira','Mozambique'),('Nampula','Mozambique'),('Chimoio','Mozambique'),('Nacala','Mozambique'),('Quelimane','Mozambique'),('Tete','Mozambique'),('Xai-Xai','Mozambique'),('Maxixe','Mozambique')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Windhoek','Namibia'),('Rundu','Namibia'),('Walvis Bay','Namibia'),('Oshakati','Namibia'),('Swakopmund','Namibia'),('Katima Mulilo','Namibia'),('Grootfontein','Namibia'),('Rehoboth','Namibia'),('Katutura','Namibia'),('Otjiwarongo','Namibia'),
	('Yaren','Nauru'),('Baiti','Nauru'),('Anabar','Nauru'),('Uaboe','Nauru'),('Ijuw','Nauru'),
	('Kathmandu','Nepal'),('Pokhara','Nepal'),('Patan','Nepal'),('Biratnagar','Nepal'),('Birganj','Nepal'),('Dharan','Nepal'),('Bharatpur','Nepal'),('Janakpur','Nepal'),('Dhangadhi','Nepal'),('Butwal','Nepal'),
	('Amsterdam','Netherlands'),('Rotterdam','Netherlands'),('The Hague','Netherlands'),('Utrecht','Netherlands'),('Eindhoven','Netherlands'),('Tilburg','Netherlands'),('Groningen','Netherlands'),('Almere Stad','Netherlands'),('Breda','Netherlands'),('Nijmegen','Netherlands'),('Enschede','Netherlands'),('Haarlem','Netherlands'),('Arnhem','Netherlands'),('Zaanstad','Netherlands'),('Amersfoort','Netherlands'),
	('Managua','Nicaragua'),('Leon','Nicaragua'),('Masaya','Nicaragua'),('Chinandega','Nicaragua'),('Matagalpa','Nicaragua'),('Esteli','Nicaragua'),('Granada','Nicaragua'),('Jinotega','Nicaragua'),('El Viejo','Nicaragua'),('Nueva Guinea','Nicaragua'),
	('Niamey','Niger'),('Zinder','Niger'),('Maradi','Niger'),('Agadez','Niger'),('Alaghsas','Niger'),('Tahoua','Niger'),('Dosso','Niger'),('Birni N Konni','Niger'),('Tessaoua','Niger'),('Gaya','Niger'),
	('Lagos','Nigeria'),('Kano','Nigeria'),('Ibadan','Nigeria'),('Kaduna','Nigeria'),('Port Harcourt','Nigeria'),('Benin City','Nigeria'),('Maiduguri','Nigeria'),('Zaria','Nigeria'),('Aba','Nigeria'),('Jos','Nigeria'),('Ilorin','Nigeria'),('Oyo','Nigeria'),('Enugu','Nigeria'),('Abeokuta','Nigeria'),('Abuja','Nigeria'),('Sokoto','Nigeria'),('Onitsha','Nigeria'),('Warri','Nigeria'),('Ebute Ikorodu','Nigeria'),
	('Pyongyang','North Korea'),('Hamhung','North Korea'),('Nampo','North Korea'),('Sunchon','North Korea'),('Hungnam','North Korea'),('Kaesong','North Korea'),('Wonsan','North Korea'),('Chongjin','North Korea'),('Sariwon','North Korea'),('Sinuiju','North Korea'),
	('Skopje','North Macedonia'),('Bitola','North Macedonia'),('Kumanovo','North Macedonia'),('Prilep','North Macedonia'),('Tetovo','North Macedonia'),('Cair','North Macedonia'),('Kisela Voda','North Macedonia'),('Veles','North Macedonia'),('Ohrid','North Macedonia'),('Gostivar','North Macedonia'),
	('Oslo','Norway'),('Bergen','Norway'),('Trondheim','Norway'),('Stavanger','Norway'),('Drammen','Norway'),('Fredrikstad','Norway'),('Kristiansand','Norway'),('Sandnes','Norway'),('Tromso','Norway'),('Sarpsborg','Norway')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Muscat','Oman'),('Seeb','Oman'),('Salalah','Oman'),('Bawshar','Oman'),('Sohar','Oman'),('As Suwayq','Oman'),('`Ibri','Oman'),('Saham','Oman'),('Barka','Oman'),('Rustaq','Oman')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Karachi','Pakistan'),('Lahore','Pakistan'),('Faisalabad','Pakistan'),('Rawalpindi','Pakistan'),('Multan','Pakistan'),('Hyderabad','Pakistan'),('Gujranwala','Pakistan'),('Peshawar','Pakistan'),('Rahim Yar Khan','Pakistan'),('Quetta','Pakistan'),('Muzaffarabad','Pakistan'),('Battagram','Pakistan'),('Kotli','Pakistan'),('Islamabad','Pakistan'),('Bahawalpur','Pakistan'),('Sargodha','Pakistan'),('Sialkot','Pakistan'),('Sukkur','Pakistan'),('Larkana','Pakistan'),
	('Koror','Palau'),('Koror Town','Palau'),('Kloulkubed','Palau'),('Ulimang','Palau'),('Mengellang','Palau'),
	('East Jerusalem','Palestine'),('Gaza','Palestine'),('Khan Yunis','Palestine'),('Jabalya','Palestine'),('Hebron','Palestine'),('Nablus','Palestine'),('Rafah','Palestine'),
	('Panama City','Panama'),('San Miguelito','Panama'),('Juan Diaz','Panama'),('David','Panama'),('Arraijan','Panama'),('Colon','Panama'),('Las Cumbres','Panama'),('La Chorrera','Panama'),('Pedregal','Panama'),('Tocumen','Panama'),
	('Port Moresby','Papaua New Guinea'),('Lae','Papaua New Guinea'),('Arawa','Papaua New Guinea'),('Mount Hagen','Papaua New Guinea'),('Popondetta','Papaua New Guinea'),('Madang','Papaua New Guinea'),('Kokopo','Papaua New Guinea'),('Mendi','Papaua New Guinea'),('Kimbe','Papaua New Guinea'),('Goroka','Papaua New Guinea'),
	('Asuncion','Paraguay'),('Ciudad del Este','Paraguay'),('San Lorenzo','Paraguay'),('Capiata','Paraguay'),('Lambare','Paraguay'),('Fernando de la Mora','Paraguay'),('Limpio','Paraguay'),('Nemby','Paraguay'),('Pedro Juan Cabellero','Paraguay'),('Encarnacion','Paraguay'),('Mariano Roque Alonso','Paraguay'),
	('Lima','Peru'),('Arequipa','Peru'),('Callao','Peru'),('Trujillo','Peru'),('Chiclayo','Peru'),('Iquitos','Peru'),('Huancayo','Peru'),('Piura','Peru'),('Chimbote','Peru'),('Cusco','Peru'),('Pucallpa','Peru'),('Tacna','Peru'),
	('Quezon City','Philippines'),('Manila','Philippines'),('Caloocan City','Philippines'),('Budta','Philippines'),('Davao','Philippines'),('Malingao','Philippines'),('Cebu City','Philippines'),('General Santos','Philippines'),('Taguig','Philippines'),('Pasig City','Philippines'),('Las Pinas','Philippines'),('Antipolo','Philippines'),('Makati City','Philippines'),('Zamboanga','Philippines'),('Bacolod City','Philippines'),
	('Warsaw','Poland'),('Lodz','Poland'),('Krakow','Poland'),('Wroclaw','Poland'),('Poznan','Poland'),('Gdansk','Poland'),('Szczecin','Poland'),('Bydgoszcz','Poland'),('Lublin','Poland'),('Katowice','Poland'),('Bialystok','Poland'),('Gdynia','Poland'),('Czestochowa','Poland'),('Sosnowiec','Poland'),('Radom','Poland'),('Mokotow','Poland'),
	('Lisbon','Portugal'),('Porto','Portugal'),('Amadora','Portugal'),('Braga','Portugal'),('Setubal','Portugal'),('Coimbra','Portugal'),('Queluz','Portugal'),('Funchal','Portugal'),('Cacem','Portugal'),('Vila Nova de Gaia','Portugal')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Doha','Qatar'),('Ar Rayyan','Qatar'),('Umm Salal Muhammad','Qatar'),('Al Wakrah','Qatar'),('Al Khawr','Qatar'),('Ash Shihaniyah','Qatar'),('Dukhan','Qatar'),('Musay`id','Qatar'),('Madinat ash Shamal','Qatar'),('Al Wukayr','Qatar')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Brazzaville','Republic of the Congo'),('Pointe-Noire','Republic of the Congo'),('Dolisie','Republic of the Congo'),('Kayes','Republic of the Congo'),('Owando','Republic of the Congo'),('Ouesso','Republic of the Congo'),('Loandjili','Republic of the Congo'),('Madingou','Republic of the Congo'),('Gamboma','Republic of the Congo'),('Impfondo','Republic of the Congo'),
	('Bucharest','Romania'),('Sector 3','Romania'),('Sector 6','Romania'),('Sector 2','Romania'),('Iasi','Romania'),('Cluj-Napoca','Romania'),('Timisoara','Romania'),('Craiova','Romania'),('Constanta','Romania'),('Galati','Romania'),('Section 4','Romania'),
	('Moscow','Russia'),('Saint Petersburg','Russia'),('Novosibirsk','Russia'),('Yekaterinburg','Russia'),('Nizhniy Novgorod','Russia'),('Samara','Russia'),('Omsk','Russia'),('Kazan','Russia'),('Rostov-na-Donu','Russia'),('Chelyabinsk','Russia'),('Ufa','Russia'),('Volgograd','Russia'),('Perm','Russia'),('Krasnoyarsk','Russia'),('Saratov','Russia'),('Voronezh','Russia'),('Tolyatti','Russia'),('Krasnodar','Russia'),('Ulyanovsk','Russia'),('Izhevsk','Russia'),('Yaroslavl','Russia'),('Barnaul','Russia'),('Vladivostok','Russia'),('Irkutsk','Russia'),('Khabarovsk','Russia'),('Khabarovsk','Russia'),('Khabarovsk Vtoroy','Russia'),('Orenburg','Russia'),('Novokuznetsk','Russia'),('Ryazan','Russia'),
	('Kigali','Rwanda'),('Butare','Rwanda'),('Gitarama','Rwanda'),('Musanze','Rwanda'),('Gisenyi','Rwanda'),('Byumba','Rwanda'),('Cyangugu','Rwanda'),('Kibuye','Rwanda'),('Rwamagana','Rwanda'),('Kibungo','Rwanda')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Basseterre','Saint Kitts and Nevis'),('Fig Tree','Saint Kitts and Nevis'),('Market Shop','Saint Kitts and Nevis'),('Saint Pauls','Saint Kitts and Nevis'),('Middle Island','Saint Kitts and Nevis'),
	('Castries','Saint Lucia'),('Bisee','Saint Lucia'),('Vieux Fort','Saint Lucia'),('Micoud','Saint Lucia'),('Soufriere','Saint Lucia'),
	('Kingston','Saint Vincent and the Grenadines'),('Kingston Park','Saint Vincent and the Grenadines'),('Georgetown','Saint Vincent and the Grenadines'),('Barrouallie','Saint Vincent and the Grenadines'),('Port Elizabeth','Saint Vincent and the Grenadines'),
	('Apia','Samoa'),('Asau','Samoa'),('Mulifanua','Samoa'),('Afega','Samoa'),('Leulumoega','Samoa'),
	('Serravalle','San Marino'),('Borgo Maggiore','San Marino'),('San Marino','San Marino'),('Domagnano','San Marino'),('Fiorentino','San Marino'),
	('Sao Tome','Sao Tome and Principe'),('Santo Antonio','Sao Tome and Principe'),('Neves','Sao Tome and Principe'),('Santana','Sao Tome and Principe'),('Trindade','Sao Tome and Principe'),
	('Riyadh','Saudi Arabia'),('Jeddah','Saudi Arabia'),('Mecca','Saudi Arabia'),('Medina','Saudi Arabia'),('Sultanah','Saudi Arabia'),('Dammam','Saudi Arabia'),('Taif','Saudi Arabia'),('Tabuk','Saudi Arabia'),('Al Kharj','Saudi Arabia'),('Buraydah','Saudi Arabia'),('Khamis Mushait','Saudi Arabia'),('Al Hufuf','Saudi Arabia'),('Al Mubarraz','Saudi Arabia'),('Hafar Al-Batin','Saudi Arabia'),('Hail','Saudi Arabia'),('Najran','Saudi Arabia'),('Al Jubayl','Saudi Arabia'),('Abha','Saudi Arabia'),('Yanbu','Saudi Arabia'),('Khobar','Saudi Arabia'),
	('Dakar','Senegal'),('Pikine','Senegal'),('Touba','Senegal'),('Thies','Senegal'),('Thies Nones','Senegal'),('Saint-Louis','Senegal'),('Kaoloack','Senegal'),('Ziguinchor','Senegal'),('Tiebo','Senegal'),('Tambacounda','Senegal'),
	('Belgrade','Serbia'),('Nis','Serbia'),('Novi Sad','Serbia'),('Zemun','Serbia'),('Kragujevac','Serbia'),('Cacak','Serbia'),('Subotica','Serbia'),('Leskovac','Serbia'),('Novi Pazar','Serbia'),
	('Victoria','Seychelles'),('Anse Boileau','Seychelles'),('Bel Ombre','Seychelles'),('Beau Vallon','Seychelles'),('Cascade','Seychelles'),
	('Freetown','Sierra Leone'),('Bo','Sierra Leone'),('Kenema','Sierra Leone'),('Koidu','Sierra Leone'),('Makeni','Sierra Leone'),('Lunsar','Sierra Leone'),('Port Loko','Sierra Leone'),('Waterloo','Sierra Leone'),('Kabala','Sierra Leone'),('Segbwema','Sierra Leone'),
	('Singapore','Singapore'),
	('Bratislava','Slovakia'),('Kosice','Slovakia'),('Presov','Slovakia'),('Nitra','Slovakia'),('Zilina','Slovakia'),('Banska Bystrica','Slovakia'),('Trnava','Slovakia'),('Martin','Slovakia'),('Trencin','Slovakia'),('Poprad','Slovakia'),
	('Ljubljana','Slovenia'),('Maribor','Slovenia'),('Celje','Slovenia'),('Kranj','Slovenia'),('Velenje','Slovenia'),('Koper','Slovenia'),('Novo Mesto','Slovenia'),('Ptuj','Slovenia'),('Trbovlje','Slovenia'),('Kamnik','Slovenia'),
	('Honiara','Solomon Islands'),('Auki','Solomon Islands'),('Gizo','Solomon Islands'),('Buala','Solomon Islands'),('Tulagi','Solomon Islands'),
	('Mogadishu','Somalia'),('Hargeysa','Somalia'),('Berbera','Somalia'),('Kismayo','Somalia'),('Marka','Somalia'),('Jamaame','Somalia'),('Baidoa','Somalia'),('Burao','Somalia'),('Bosaso','Somalia'),('Afgooye','Somalia'),
	('Cape Town','South Africa'),('Durban','South Africa'),('Johannesburg','South Africa'),('Soweto','South Africa'),('Pretoria','South Africa'),('Port Elizabeth','South Africa'),('Pietermaritzburg','South Africa'),('Benoni','South Africa'),('Tembisa','South Africa'),('East London','South Africa'),('Vereeniging','South Africa'),('Bloemfontein','South Africa'),('Boksburg','South Africa'),('Welkom','South Africa'),('Newcastle','South Africa'),('Krugersdorp','South Africa'),('Diepsloot','South Africa'),('Randburg','South Africa'),('Botshabelo','South Africa'),('Brakpan','South Africa'),
	('Seoul','South Korea'),('Busan','South Korea'),('Incheon','South Korea'),('Baegu','South Korea'),('Daejeon','South Korea'),('Gwangju','South Korea'),('Suwon','South Korea'),('Goyang-si','South Korea'),('Seongnam-si','South Korea'),('Ulsan','South Korea'),('Bucheon-si','South Korea'),('Jeonju','South Korea'),('Ansan-si','South Korea'),('Cheongju-si','South Korea'),('Anyang-si','South Korea'),('Changwon','South Korea'),('Pohang','South Korea'),
	('Juba','South Sudan'),('Winejok','South Sudan'),('Malakal','South Sudan'),('Wau','South Sudan'),('Pajok','South Sudan'),('Yei','South Sudan'),('Yambio','South Sudan'),('Aweil','South Sudan'),('Gogrial','South Sudan'),('Rumbek','South Sudan'),
	('Colombo','Sri Lanka'),('Dehiwala-Mount Lavinia','Sri Lanka'),('Moratuwa','Sri Lanka'),('Jaffna','Sri Lanka'),('Negombo','Sri Lanka'),('Pita Kotte','Sri Lanka'),('Sri Jayewardenepura Kotte','Sri Lanka'),('Kandy','Sri Lanka'),('Trincomalee','Sri Lanka'),('Kalmunai','Sri Lanka'),
	('Khartoum','Sudan'),('Omdurman','Sudan'),('Nyala','Sudan'),('Port Sudan','Sudan'),('Kassala','Sudan'),('El Obeid','Sudan'),('Al Qadarif','Sudan'),('Kosti','Sudan'),('Wad Medani','Sudan'),('El Daein','Sudan'),
	('Paramaribo','Suriname'),('Lelydorp','Suriname'),('Brokopondo','Suriname'),('Nieuw Nickerie','Suriname'),('Moengo','Suriname'),('Nieuw Amsterdam','Suriname'),('Albina','Suriname'),
	('Stockholm','Sweden'),('Gothenburg','Sweden'),('Malmoe','Sweden'),('Uppsala','Sweden'),('Sollentuna','Sweden'),('Soedermalm','Sweden'),('Vaesteras','Sweden'),('OErebro','Sweden'),('Linkoeping','Sweden'),('Helsingborg','Sweden'),
	('Zurich','Switzerland'),('Geneve','Switzerland'),('Basel','Switzerland'),('Bern','Switzerland'),('Lausanne','Switzerland'),('Winterthur','Switzerland'),('Sankt Gallen','Switzerland'),('Lugano','Switzerland'),('Luzern','Switzerland'),('Biel','Switzerland'),
	('Aleppo','Syria'),('Damascus','Syria'),('Homs','Syria'),('Hamah','Syria'),('Latakia','Syria'),('Deir ez-Zor','Syria'),('Ar Raqqah','Syria'),('Al Bab','Syria'),('Idlib','Syria'),('Douma','Syria')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Taipei','Taiwan'),('Kaohsiung','Taiwan'),('Taichung','Taiwan'),('Tainan','Taiwan'),('Banqiao','Taiwan'),('Hsinchu','Taiwan'),('Taoyuan City','Taiwan'),('Keelung','Taiwan'),('Hualien City','Taiwan'),
	('Dushanbe','Tajikistan'),('Khujand','Tajikistan'),('Kulob','Tajikistan'),('Qurghonteppa','Tajikistan'),('Istaravshan','Tajikistan'),('Konibodom','Tajikistan'),('Vahdat','Tajikistan'),('Isfara','Tajikistan'),('Tursunzoda','Tajikistan'),('Panjakent','Tajikistan'),
	('Dar es Salaam','Tanzania'),('Mwanza','Tanzania'),('Zanzibar','Tanzania'),('Arusha','Tanzania'),('Mbeya','Tanzania'),('Morogoro','Tanzania'),('Tanga','Tanzania'),('Dodoma','Tanzania'),('Kigoma','Tanzania'),('Moshi','Tanzania'),
	('Bangkok','Thailand'),('Samut Prakan','Thailand'),('Mueang Nonthaburi','Thailand'),('Udon Thani','Thailand'),('Chon Buri','Thailand'),('Nakhon Ratchasima','Thailand'),('Chiang Mai','Thailand'),('Hat Yai','Thailand'),('Pak Kret','Thailand'),('Si Racha','Thailand'),
	('Lome','Togo'),('Sokode','Togo'),('Kara','Togo'),('Kpalime','Togo'),('Atakpame','Togo'),('Bassar','Togo'),('Tsevie','Togo'),('Aneho','Togo'),('Mango','Togo'),('Dapaong','Togo'),
	('Nukualofa','Tonga'),('Neiafu','Tonga'),('Pangai','Tonga'),('Ohonua','Tonga'),('Hihifo','Tonga'),
	('Chaguanas','Trinidad and Tobago'),('Mon Repos','Trinidad and Tobago'),('San Fernando','Trinidad and Tobago'),('Port of Spain','Trinidad and Tobago'),('Rio Claro','Trinidad and Tobago'),('Arima','Trinidad and Tobago'),('Marabella','Trinidad and Tobago'),
	('Tunis','Tunisia'),('Sfax','Tunisia'),('Sousse','Tunisia'),('Ettadhamen','Tunisia'),('Kairouan','Tunisia'),('Gabes','Tunisia'),('Bizerte','Tunisia'),('Aryanah','Tunisia'),('Gafsa','Tunisia'),('El Mourouj','Tunisia'),
	('Istanbul','Turkey'),('Ankara','Turkey'),('Izmir','Turkey'),('Bursa','Turkey'),('Antalya','Turkey'),('Konya','Turkey'),('Adana','Turkey'),('Şanlıurfa','Turkey'),('Gaziantep','Turkey'),('Kocaeli','Turkey'),('Mersin','Turkey'),('Diyarbakır','Turkey'),('Hatay','Turkey'),('Manisa','Turkey'),('Kayseri','Turkey'),
	('Balkanabat','Turkmenistan'),('Ashgabat','Turkmenistan'),('Turkmenabat','Turkmenistan'),('Daşoguz','Turkmenistan'),('Mary','Turkmenistan'),('Gyzylarbat','Turkmenistan'),('Baýramaly','Turkmenistan'),('Tejen','Turkmenistan'),('Turkmenbaşy','Turkmenistan'),
	('Funafuti','Tuvalu'),('Savave Village','Tuvalu'),('Tanrake Village','Tuvalu'),('Toga Village','Tuvalu'),('Asau Village','Tuvalu'),('Kulia Village','Tuvalu')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Kampala','Uganda'),('Nansana','Uganda'),('Kira','Uganda'),('Ssabagabo','Uganda'),('Mbarara','Uganda'),('Mukono','Uganda'),('Njeru','Uganda'),('Gulu','Uganda'),('Lugazi','Uganda'),('Masaka','Uganda'),
	('Kyiv','Ukraine'),('Kharkiv','Ukraine'),('Odesa','Ukraine'),('Dnipro','Ukraine'),('Donetsk','Ukraine'),('Lviv','Ukraine'),('Zaporizhzhia','Ukraine'),('Kryvyi Rih','Ukraine'),('Mykolaiv','Ukraine'),('Mariupol','Ukraine'),
	('Dubai','United Arab Emirates'),('Abu Dhabi','United Arab Emirates'),('Sharjah','United Arab Emirates'),('Al Ain','United Arab Emirates'),('Ajman','United Arab Emirates'),('Ras Al Khaimah','United Arab Emirates'),('Fujairah','United Arab Emirates'),('Umm Al Quwain','United Arab Emirates'),('Kalba','United Arab Emirates'),('Madinat Zayed','United Arab Emirates'),
	('Montevideo','Uruguay'),('Salto','Uruguay'),('Ciudad de la Costa','Uruguay'),('Paysandu','Uruguay'),('Las Piedras','Uruguay'),('Rivera','Uruguay'),('Maldonado','Uruguay'),('Tacuarembo','Uruguay'),('Melo','Uruguay'),('Mercedes','Uruguay'),
	('Tashkent','Uzbekistan'),('Namangan','Uzbekistan'),('Samarkand','Uzbekistan'),('Andijan','Uzbekistan'),('Nukus','Uzbekistan'),('Fergana','Uzbekistan'),('Kokand','Uzbekistan'),('Qarshi','Uzbekistan'),('Bukhara','Uzbekistan'),('Margilan','Uzbekistan')
GO

INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Port-Vila','Vanuatu'),('Luganville','Vanuatu'),('Isangel','Vanuatu'),('Sola','Vanuatu'),('Lakatoro','Vanuatu'),
	('Vatican City','Vatican City'),
	('Caracas','Venezuala'),('Maracaibo','Venezuala'),('Valencia','Venezuala'),('Barquisimeto','Venezuala'),('Maracay','Venezuala'),('Ciudad Guayana','Venezuala'),('Barcelona','Venezuala'),('Maturin','Venezuala'),('Cumana','Venezuala'),('Petare','Venezuala'),
	('Ho Chi Minh City','Vietnam'),('Hanoi','Vietnam'),('Haiphong','Vietnam'),('Can Thơ','Vietnam'),('Da Nang','Vietnam'),('Bien Hoa','Vietnam'),('Thu Duc','Vietnam'),('Hue','Vietnam'),('Thuan An','Vietnam'),('Hai Duong','Vietnam')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Sanaa','Yemen'),('Taizz','Yemen'),('Al Hudaydah','Yemen'),('Aden','Yemen'),('Ibb','Yemen'),('Dhamar','Yemen'),('Mukalla','Yemen'),('Seiyun','Yemen'),('Zinjibar','Yemen'),('Sayyan','Yemen')
GO
INSERT INTO [dbo].[City]
	([CityName],[CityCountry])
	VALUES
	('Lusaka','Zambia'),('Kitwe','Zambia'),('Ndola','Zambia'),('Kabwe','Zambia'),('Chingola','Zambia'),('Mufulira','Zambia'),('Luanshya','Zambia'),('Livingstone','Zambia'),('Kasama','Zambia'),('Chipata','Zambia'),
	('Harare','Zimbabwe'),('Bulawayo','Zimbabwe'),('Chitungwiza','Zimbabwe'),('Mutare','Zimbabwe'),('Gweru','Zimbabwe'),('Kwekwe','Zimbabwe'),('Kadoma','Zimbabwe'),('Chinhoyi','Zimbabwe'),('Ruwa','Zimbabwe'),('Masvingo','Zimbabwe')
GO


INSERT INTO [dbo].[City]
	([CityName],[CityCountry],[CitySubdivision])
	VALUES
	('Huntsville','United States of America',1000000),('Birmingham','United States of America',1000000),('Montgomery','United States of America',1000000),('Mobile','United States of America',1000000),('Tuscaloosa','United States of America',1000000),
	('Anchorage','United States of America',1000001),('Fairbanks','United States of America',1000001),('Juneau','United States of America',1000001),
	('Phoenix','United States of America',1000002),('Tuscon','United States of America',1000002),('Mesa','United States of America',1000002),('Chandler','United States of America',1000002),('Gilbert','United States of America',1000002),('Scottsdale','United States of America',1000002),('Peoria','United States of America',1000002),('Tempe','United States of America',1000002),('Surprise','United States of America',1000002),
	('Little Rock','United States of America',1000003),('Fayetteville','United States of America',1000003),('Fort Smith','United States of America',1000003),
	('Los Angeles','United States of America',1000004),('San Diego','United States of America',1000004),('San Jose','United States of America',1000004),('San Francisco','United States of America',1000004),('Fresno','United States of America',1000004),('Sacramento','United States of America',1000004),('Long Beach','United States of America',1000004),('Oakland','United States of America',1000004),('Bakersfield','United States of America',1000004),('Anaheim','United States of America',1000004),('Stockton','United States of America',1000004),('Riverside','United States of America',1000004),('Irvine','United States of America',1000004),('Santa Ana','United States of America',1000004),('Chula Vista','United States of America',1000004),
	('Denver','United States of America',1000005),('Colorado Springs','United States of America',1000005),('Aurora','United States of America',1000005),('Fort Collins','United States of America',1000005),('Lakewood','United States of America',1000005),('Thornton','United States of America',1000005),('Arvada','United States of America',1000005),('Westminster','United States of America',1000005),('Greely','United States of America',1000005),('Pueblo','United States of America',1000005),
	('Bridgeport','United States of America',1000006),('Stamford','United States of America',1000006),('New Haven','United States of America',1000006),('Hartford','United States of America',1000006),('Waterbury','United States of America',1000006),
	('Wilmington','United States of America',1000007),('Dover','United States of America',1000007),
	('Jacksonville','United States of America',1000008),('Miami','United States of America',1000008),('Tampa','United States of America',1000008),('Orlando','United States of America',1000008),('St. Petersburg','United States of America',1000008),('Port St. Lucie','United States of America',1000008),('Cape Coral','United States of America',1000008),('Hialeah','United States of America',1000008),('Tallahassee','United States of America',1000008),('Fort Lauderdale','United States of America',1000008),
	('Atlanta','United States of America',1000009),('Columbus','United States of America',1000009),('Augusta','United States of America',1000009),('Macon','United States of America',1000009),('Savannah','United States of America',1000009),('Athens','United States of America',1000009),
	('Honolulu','United States of America',1000010),('East Honolulu','United States of America',1000010),('Hilo','United States of America',1000010),
	('Boise City','United States of America',1000011),('Meridian','United States of America',1000011),('Nampa','United States of America',1000011),('Caldwell','United States of America',1000011),('Idaho Falls','United States of America',1000011),
	('Chicago','United States of America',1000012),('Aurora','United States of America',1000012),('Joliet','United States of America',1000012),('Naperville','United States of America',1000012),('Rockford','United States of America',1000012),
	('Indianapolis','United States of America',1000013),('Fort Wayne','United States of America',1000013),('Evansville','United States of America',1000013),('South Bend','United States of America',1000013),
	('Des Moines','United States of America',1000014),('Cedar Rapids','United States of America',1000014),('Davenport','United States of America',1000014),('Sioux City','United States of America',1000014),('Iowa City','United States of America',1000014),('West Des Moines','United States of America',1000014),('Ankeny','United States of America',1000014),('Waterloo','United States of America',1000014),('Ames','United States of America',1000014),('Council Bluffs','United States of America',1000014),('Dubuque','United States of America',1000014),
	('Wichita','United States of America',1000015),('Overland Park','United States of America',1000015),('Kansas City','United States of America',1000015),('Olathe','United States of America',1000015),('Topeka','United States of America',1000015),('Lawrence','United States of America',1000015),
	('Louisville','United States of America',1000016),('Lexington','United States of America',1000016),('Bowling Green','United States of America',1000016),('Owensboro','United States of America',1000016),('Covington','United States of America',1000016),
	('New Orleans','United States of America',1000017),('Baton Rouge','United States of America',1000017),('Shreveport','United States of America',1000017),('Lafayette','United States of America',1000017),('Lake Charles','United States of America',1000017),
	('Portland','United States of America',1000018),('Augusta','United States of America',1000018),
	('Baltimore','United States of America',1000019),('Frederick','United States of America',1000019),('Gaithersburg','United States of America',1000019),
	('Boston','United States of America',1000020),('Worcester','United States of America',1000020),('Springfield','United States of America',1000020),('Cambridge','United States of America',1000020),('Lowell','United States of America',1000020),
	('Detroit','United States of America',1000021),('Grand Rapids','United States of America',1000021),('Warren','United States of America',1000021),('Sterling Heights','United States of America',1000021),('Ann Arbor','United States of America',1000021),('Lansing','United States of America',1000021),
	('Minneapolis','United States of America',1000022),('Saint Paul','United States of America',1000022),('Rochester','United States of America',1000022),('Duluth','United States of America',1000022),
	('Jackson','United States of America',1000023),('Gulfport','United States of America',1000023),('Southaven','United States of America',1000023),
	('Kansas City','United States of America',1000024),('St. Louis','United States of America',1000024),('Springfield','United States of America',1000024),('Columbia','United States of America',1000024),('Independence','United States of America',1000024),
	('Billings','United States of America',1000025),('Missoula','United States of America',1000025),('Helena','United States of America',1000025),
	('Omaha','United States of America',1000026),('Lincoln','United States of America',1000026),('Bellevue','United States of America',1000026),('Grand Island','United States of America',1000026),
	('Las Vegas','United States of America',1000027),('Henderson','United States of America',1000027),('Reno','United States of America',1000027),('North Las Vegas','United States of America',1000027),('Sparks','United States of America',1000027),('Carson City','United States of America',1000027),
	('Manchester','United States of America',1000028),('Nashua','United States of America',1000028),('Concord','United States of America',1000028),
	('Newark','United States of America',1000029),('Jersey City','United States of America',1000029),('Paterson','United States of America',1000029),('Elizabeth','United States of America',1000029),('Lakewood Township','United States of America',1000029),('Edison','United States of America',1000029),('Woodbridge Township','United States of America',1000029),
	('Albuquerque','United States of America',1000030),('Las Cruces','United States of America',1000030),('Rio Rancho','United States of America',1000030),('Santa Fe','United States of America',1000030),
	('New York City','United States of America',1000031),('Buffalo','United States of America',1000031),('Yonkers','United States of America',1000031),('Rochester','United States of America',1000031),('Syracuse','United States of America',1000031),('Albany','United States of America',1000031),
	('Charlotte','United States of America',1000032),('Raleigh','United States of America',1000032),('Greensboro','United States of America',1000032),('Durham','United States of America',1000032),('Winston-Salem','United States of America',1000032),('Fayetteville','United States of America',1000032),('Cary','United States of America',1000032),('Wilmington','United States of America',1000032),('High Point','United States of America',1000032),('Concord','United States of America',1000032),
	('Fargo','United States of America',1000033),('Bismarck','United States of America',1000033),('Grand Forks','United States of America',1000033),
	('Columbus','United States of America',1000034),('Cleveland','United States of America',1000034),('Cincinnati','United States of America',1000034),('Toledo','United States of America',1000034),('Akron','United States of America',1000034),('Dayton','United States of America',1000034),
	('Oklahoma City','United States of America',1000035),('Tulsa','United States of America',1000035),('Norman','United States of America',1000035),('Broken Arrow','United States of America',1000035),('Edmond','United States of America',1000035),
	('Portland','United States of America',1000036),('Eugene','United States of America',1000036),('Salem','United States of America',1000036),('Gresham','United States of America',1000036),('Hillsboro','United States of America',1000036),
	('Philadelphia','United States of America',1000037),('Pittsburgh','United States of America',1000037),('Allentown','United States of America',1000037),('Reading','United States of America',1000037),('Erie','United States of America',1000037),
	('Providence','United States of America',1000038),('Cranston','United States of America',1000038),('Warwick','United States of America',1000038),('Pawtucket','United States of America',1000038),
	('Columbia','United States of America',1000039),('Charleston','United States of America',1000039),('North Charleston','United States of America',1000039),('Mount Pleasant','United States of America',1000039),
	('Sioux Falls','United States of America',1000040),('Rapid City','United States of America',1000040),
	('Nashville','United States of America',1000041),('Memphis','United States of America',1000041),('Knoxville','United States of America',1000041),('Chattanooga','United States of America',1000041),('Clarksville','United States of America',1000041),('Murfreesboro','United States of America',1000041),
	('Houston','United States of America',1000042),('San Antonio','United States of America',1000042),('Dallas','United States of America',1000042),('Austin','United States of America',1000042),('Fort Worth','United States of America',1000042),('El Paso','United States of America',1000042),('Arlington','United States of America',1000042),('Corpus Christi','United States of America',1000042),('Plano','United States of America',1000042),('Lubbock','United States of America',1000042),('Laredo','United States of America',1000042),('Irving','United States of America',1000042),('Garland','United States of America',1000042),('Frisco','United States of America',1000042),('McKinney','United States of America',1000042),('Amarillo','United States of America',1000042),('Grand Prairie','United States of America',1000042),('Brownsville','United States of America',1000042),('Killeen','United States of America',1000042),
	('Salt Lake City','United States of America',1000043),('West Valley City','United States of America',1000043),('West Jordan','United States of America',1000043),('Provo','United States of America',1000043),('Orem','United States of America',1000043),
	('Burlington','United States of America',1000044),('Souht Burlington','United States of America',1000044),
	('Virginia Beach','United States of America',1000045),('Chesapeake','United States of America',1000045),('Norfolk','United States of America',1000045),('Richmond','United States of America',1000045),('Newport News','United States of America',1000045),('Alexandria','United States of America',1000045),('Hampton','United States of America',1000045),('Suffolk','United States of America',1000045),
	('Seattle','United States of America',1000046),('Spokane','United States of America',1000046),('Tacoma','United States of America',1000046),('Vancouver','United States of America',1000046),('Bellevue','United States of America',1000046),('Kent','United States of America',1000046),('Everett','United States of America',1000046),('Renton','United States of America',1000046),('Spokane Valley','United States of America',1000046),('Federal Way','United States of America',1000046),
	('Charleston','United States of America',1000047),('Huntington','United States of America',1000047),
	('Milwaukee','United States of America',1000048),('Madison','United States of America',1000048),('Green Bay','United States of America',1000048),('Kenosha','United States of America',1000048),
	('Cheyenne','United States of America',1000049),('Casper','United States of America',1000049),
	('San Juan','United States of America',1000050),('Bayamon','United States of America',1000050),('Carolina','United States of America',1000050),('Ponce','United States of America',1000050),
	('Dededo Village','United States of America',1000051),
	('Washington DC','United States of America',1000052)
GO
print '' print '*** inserting pre-made cities with subdivisions ***'
	GO


INSERT INTO [dbo].[City]
	([CityName],[CityCountry],[CitySubdivision])
	VALUES
	('Toronto','Canada',1000056),('Montreal','Canada',1000057),('Vancouver','Canada',1000061),('Calgary','Canada',1000064),('Edmonton','Canada',1000064),('Ottawa','Canada',1000056),('Winnipeg','Canada',1000060),('Quebec City','Canada',1000057),('Hamilton','Canada',1000056),('Kitchener','Canada',1000056),('London','Canada',1000056),('Victoria','Canada',1000061),('Halifax','Canada',1000058),('Oshawa','Canada',1000056),('Windsor','Canada',1000056),('Saskatoon','Canada',1000063),('Saint Catharines','Canada',1000056),('Regina','Canada',1000063),('Saint John','Canada',1000059),('Kelowna','Canada',1000061),('Barrie','Canada',1000056),('Sherbrooke','Canada',1000057),('Guelph','Canada',1000056),('Kanata','Canada',1000056),('Abbotsford','Canada',1000061),
	('Mexico City','Mexico',1000083),('Iztapalapa','Mexico',1000083),('Ecatepec de Morelos','Mexico',1000083),('Guadalajara','Mexico',1000081),('Puebla','Mexico',1000089),('Juarez','Mexico',1000074),('Tijuana','Mexico',1000070),('Leon','Mexico',1000078),('Gustavo Adolfo Madero','Mexico',1000083),('Zapopan','Mexico',1000081),('Monterrey','Mexico',1000087),('Ciudad Nezahualcoyotl','Mexico',1000083),('Chihuahua','Mexico',1000074),('Naucalpan de Juarez','Mexico',1000083),('Merida','Mexico',1000099),('Alvaro Obregon','Mexico',1000083),('San Luis Potosi','Mexico',1000092),('Aguascalientes','Mexico',1000069),('Hermosillo','Mexico',1000094),('Saltillo','Mexico',1000075),('Mexicali','Mexico',1000070),('Culiacan','Mexico',1000093),('Guadalupe','Mexico',1000087),('Acapulco de Juarez','Mexico',1000079),('Tlanlnepantla','Mexico',1000083),('Cancun','Mexico',1000091),
	('Sao Paulo','Brazil',1000125),('Rio de Janeiro','Brazil',1000119),('Brasilia','Brazil',1000109),('Fortaleza','Brazil',1000106),('Salvador','Brazil',1000105),('Belo Horizonte','Brazil',1000113),('Manaus','Brazil',1000104),('Curitiba','Brazil',1000116),('Recife','Brazil',1000117),('Goiania','Brazil',1000109),('Porto Alegre','Brazil',1000121),('Belem','Brazil',1000114),('Guarulhos','Brazil',1000125),('Campinas','Brazil',1000125),('Sao Luis','Brazil',1000110),('Maceio','Brazil',1000102),('Campo Grande','Brazil',1000112),('Sao Gonçalo','Brazil',1000119),('Teresina','Brazil',1000118),('Joao Pessoa','Brazil',1000115),('Sao Bernardo do Campo','Brazil',1000125),('Duque de Caxias','Brazil',1000119),('Nova Iguaçu','Brazil',1000119),('Natal','Brazil',1000120),('Santo Andre','Brazil',1000125),('Osasco','Brazil',1000125),('Sorocaba','Brazil',1000125),('Uberlandia','Brazil',1000113),('Ribeirao Preto','Brazil',1000125),('Sao Jose dos Campos','Brazil',1000125),('Cuiaba','Brazil',1000111),('Jaboatao dos Guararapes','Brazil',1000117),('Contagem','Brazil',1000113),('Joinville','Brazil',1000124),('Feira de Santana','Brazil',1000105),('Aracaju','Brazil',1000126),('Londrina','Brazil',1000116),('Juiz de Fora','Brazil',1000113),('Florianopolis','Brazil',1000124),('Aparecida de Goiania','Brazil',1000109),('Serra','Brazil',1000125),('Campos dos Goytacazes','Brazil',1000119),('Belford Roxo','Brazil',1000119),('Niteroi','Brazil',1000119),('Sao Jose do Rio Preto','Brazil',1000125),('Ananindeua','Brazil',1000114),('Vila Velha','Brazil',1000108),('Caxias do Sul','Brazil',1000121),('Porto Velho','Brazil',1000122),('Mogi das Cruzes','Brazil',1000125),
	
	('London','United Kingdom',1000128),('Birmingham','United Kingdom',1000128),('Manchester','United Kingdom',1000128),('Liverpool','United Kingdom',1000128),('Leeds','United Kingdom',1000128),('Sheffield','United Kingdom',1000128),('Teesside','United Kingdom',1000128),('Bristol','United Kingdom',1000128),('Bournemouth and Poole','United Kingdom',1000128),('Stoke-on-Trent','United Kingdom',1000128),('Leicesster','United Kingdom',1000128),('Wirral','United Kingdom',1000128),('Coventry','United Kingdom',1000128),('Nottingham','United Kingdom',1000128),('Bradford','United Kingdom',1000128),('Newcastle','United Kingdom',1000128),('Bolton','United Kingdom',1000128),('Brighton and Hove','United Kingdom',1000128),('Plymouth','United Kingdom',1000128),('Hull','United Kingdom',1000128),
	('Belfast','United Kingdom',1000129),('Derry','United Kingdom',1000129),('Bangor','United Kingdom',1000129),('Lisburn','United Kingdom',1000129),('Ballymena','United Kingdom',1000129),
	('Glasgow','United Kingdom',1000130),('Edinburgh','United Kingdom',1000130),('Aberdeen','United Kingdom',1000130),('Dundee','United Kingdom',1000130),('Paisley','United Kingdom',1000130),
	('Cardiff','United Kingdom',1000131),('Swansea','United Kingdom',1000131),('Newport','United Kingdom',1000131),('Wrexham','United Kingdom',1000131),('Bangor','United Kingdom',1000131),
	
	('Paris','France',1000156),('Marseille','France',1000147),('Lyon','France',1000145),('Toulouse','France',1000155),('Nice','France',1000158),('Nantes','France',1000157),('Strasbourg','France',1000147),('Montpellier','France',1000155),('Bordeaux','France',1000154),('Lille','France',1000152),('Rennes','France',1000148),('Reims','France',1000145),('Le Havre','France',1000153),('Cergy-Pontoise','France',1000157),('Saint-Etienne','France',1000146),('Toulon','France',1000158),('Angers','France',1000157),('Grenoble','France',1000146),('Dijon','France',1000147),('Nimes','France',1000155),
	('Madrid','Spain',1000185),('Barcelona','Spain',1000179),('Valencia','Spain',1000188),('Sevilla','Spain',1000170),('Zaragoza','Spain',1000171),('Malaga','Spain',1000170),('Murcia','Spain',1000186),('Palma','Spain',1000173),('Las Palmas de Gran Canaria','Spain',1000175),('Bilbao','Spain',1000174),('Alicante','Spain',1000188),('Cordoba','Spain',1000170),('Valladolid','Spain',1000177),('Vigo','Spain',1000181),('Gijon','Spain',1000172),('Eixample','Spain',1000179),('LHospitalet de Llobregat','Spain',1000179),('Carabanchel','Spain',1000185),('A Coruna','Spain',1000181),
	('Berlin','Germany',1000191),('Hamburg','Germany',1000194),('Munich','Germany',1000190),('Koeln','Germany',1000198),('Frankfurt am Main','Germany',1000195),('Essen','Germany',1000198),('Stuttgart','Germany',1000189),('Dortmund','Germany',1000198),('Dusseldorf','Germany',1000198),('Bremen','Germany',1000193),('Hannover','Germany',1000196),('Leipzig','Germany',1000201),('Duisburg','Germany',1000198),('Nuernberg','Germany',1000190),('Dresden','Germany',1000201),('Wandsbek','Germany',1000194),('Bochum','Germany',1000198),('Bochum-Hordel','Germany',1000198),('Wuppertal','Germany',1000198),('Bielefeld','Germany',1000198),('Bonn','Germany',1000198),('Mannheim','Germany',1000189),('Marienthal','Germany',1000196),('Karlsruhe','Germany',1000189),('Hamburg-Nord','Germany',1000194),('Wiesbaden','Germany',1000195),('Muenster','Germany',1000198),('Gelsenkirchen','Germany',1000198),('Aachen','Germany',1000198),('Moenchengladbach','Germany',1000198),

	('Rome','Italy',1000213),('Milan','Italy',1000215),('Naples','Italy',1000210),('Turin','Italy',1000218),('Palermo','Italy',1000220),('Genoa','Italy',1000214),('Bologna','Italy',1000211),('Florence','Italy',1000222),('Catania','Italy',1000220),('Bari','Italy',1000207),('Messina','Italy',1000220),('Verona','Italy',1000224),('Padova','Italy',1000224),('Trieste','Italy',1000212),('Brescia','Italy',1000215),


	('Hong Kong','China',1000256),('Shanghai','China',1000254),('Beijing','China',1000252),('Tianjin','China',1000231),('Guangzhou','China',1000228),('Shenzhen','China',1000228),('Wuhan','China',1000234),('Dongguan','China',1000228),('Chongqing','China',1000253),('Chengdu','China',1000244),('Nanjing','China',1000236),('Nanchong','China',1000244),('Xian','China',1000241),('Shenyang','China',1000239),('Hangzhou','China',1000246),('Harbin','China',1000232),('Taian','China',1000242),('Suzhou','China',1000236),('Shantou','China',1000228),('Jinan','China',1000242),('Zhengzhou','China',1000233),('Changchun','China',1000238),('Dalian','China',1000239),('Kunming','China',1000245),('Qingdao','China',1000242),('Foshan','China',1000228),('Puyang','China',1000235),('Wuxi','China',1000236),('Xiamen','China',1000226),('Tianshui','China',1000227),('Ningbo','China',1000246),('Shiyan','China',1000234),('Taiyuan','China',1000243),('Tangshan','China',1000234),('Hefei','China',1000225),('Zibo','China',1000242),('Zhongshan','China',1000228),('Changsha','China',1000235),('Urumqi','China',1000251),('Shijiazhuang','China',1000231),('Lanzhou','China',1000227),('Yunfu','China',1000228),('Nanchang','China',1000237),('Dadonghai','China',1000231),('Ordos','China',1000247),('Jilin','China',1000238),('Bayannur','China',1000247),('Kunshan','China',1000236),('Xinyang','China',1000233),('Fushun','China',1000239),('Luoyang','China',1000230),('Guankou','China',1000235),('Handan','China',1000231),('Baotou','China',1000247),('Xuchang','China',1000233),('Yueyang','China',1000235),('Anshan','China',1000239),('Tongshan','China',1000234),('Fuzhou','China',1000226),('Guiyang','China',1000226),('Lijiang','China',1000245),('Datong','China',1000241),('Changshu','China',1000236),('Xianyang','China',1000241),('Huainan','China',1000225),('Jieyang','China',1000228),('Zhu Cheng City','China',1000242),
	('Mumbai','India',1000271),('Delhi','India',1000289),('Bengaluru','India',1000268),('Kolkata','India',1000285),('Chennai','India',1000280),('Ahmedabad','India',1000264),('Hyderabad','India',1000281),('Pune','India',1000271),('Surat','India',1000264),('Kanpur','India',1000284),('Jaipur','India',1000278),('Navi Mumbai','India',1000271),('Lucknow','India',1000283),('Nagpur','India',1000271),('Indore','India',1000270),('Patna','India',1000261),('Bhopal','India',1000270),('Ludhiana','India',1000277),('Tirunelveli','India',1000280),('Agra','India',1000283),('Vadodara','India',1000264),('Gorakhpur','India',1000283),('Nashik','India',1000271),('Pimpri','India',1000271),('Kalyan','India',1000271),('Thane','India',1000271),('Meerut','India',1000283),('Faridabad','India',1000289),('Ghaziabad','India',1000283),('Dombivli','India',1000271),('Rajkot','India',1000264),('Varanasi','India',1000283),('Amritsar','India',1000277),('Prayagraj','India',1000283),('Visakhapatnam','India',1000258),('Teni','India',1000280),('Jabalpur','India',1000270),('Haora','India',1000289),('Aurangabad','India',1000271),('Shivaji Nagar','India',1000271),('Solapur','India',1000271),('Srinagar','India',1000290),('Chandigarh','India',1000277),('Coimbatore','India',1000280),



	('Melbourne','Australia',1000295),('Sydney','Australia',1000294),('Brisbane','Australia',1000296),('Perth','Australia',1000297),('Adelaide','Australia',1000298),('Gold Coast','Australia',1000296),('Tweed Heads','Australia',1000294),('Newcastle','Australia',1000294),('Maitland','Australia',1000294),('Canberra','Australia',1000300),('Queanbeyan','Australia',1000294),('Sunshine Coast','Australia',1000296),('Central Coast','Australia',1000294),('Wollongong','Australia',1000294),('Geelong','Australia',1000295),('Hobart','Australia',1000299),('Townsville','Australia',1000296),('Cairns','Australia',1000296),('Toowoomba','Australia',1000296),('Darwin','Australia',1000301),('Ballarat','Australia',1000295),('Bendigo','Australia',1000295),('Albury','Australia',1000294),('Wodonga','Australia',1000295),
	('Auckland','New Zealand',1000310),('Wellington','New Zealand',1000324),('Christchurch','New Zealand',1000312),('Manukau City','New Zealand',1000310),('Waitakere','New Zealand',1000310),('North Shore','New Zealand',1000310),('Hamilton','New Zealand',1000323),('Tauranga','New Zealand',1000311),('Lower Hutt','New Zealand',1000324)

GO
