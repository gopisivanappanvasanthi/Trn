Custom Field Serializer


Sitecore Templates:-
Core DB:-
/sitecore/system/Field types/Custom Types (Template: /sitecore/templates/Common/Folder )
/sitecore/system/Field types/Custom Types/Custom Droplink (Template: /sitecore/templates/System/Templates/Template field type )

Master DB:-
/sitecore/templates/Project/Trn/Custom Field Serializer (Template: 
/sitecore/templates/System/Templates/Template Folder )
/sitecore/templates/Project/Trn/Custom Field Serializer/ApiUrl
(Template: /sitecore/templates/System/Templates/Template )
 

/sitecore/templates/Project/Trn/Custom Field Serializer/ConfigSettings
Template: /sitecore/templates/System/Templates/Template
APIURL Source: {10940024-9D9F-4C45-801B-1F4BFF5206E9}
 
Renderings:-
/sitecore/layout/Renderings/Project/Trn/Custom Field Serializer
Template: 
/sitecore/templates/System/Layout/Renderings/Rendering Folder

/sitecore/layout/Renderings/Project/Trn/Custom Field Serializer/ApiUrlSettings
Template: 
/sitecore/templates/Foundation/JavaScript Services/Json Rendering 

Content Data Source Items:-
 

/sitecore/content/trn-sample-app/Data/Custom Field Serializer
Template: 
/sitecore/templates/Common/Folder

/sitecore/content/trn-sample-app/Data/Custom Field Serializer/API URLs
Template: 
/sitecore/templates/Common/Folder 

/sitecore/content/trn-sample-app/Data/Custom Field Serializer/API URLs/GetOpenQuotesAPI
Template: 
/sitecore/templates/Project/Trn/Custom Field Serializer/ApiUrl 

 

/sitecore/content/trn-sample-app/Data/Custom Field Serializer/API URLs/GetQuotesAPI
Template: /sitecore/templates/Project/Trn/Custom Field Serializer/ApiUrl 

 

/sitecore/content/trn-sample-app/Data/Custom Field Serializer/PoCDataItem
Template: 
/sitecore/templates/Project/Trn/Custom Field Serializer/ConfigSettings

 

Content Item:-
/sitecore/content/trn-sample-app/home/Test
Template: 
/sitecore/templates/Project/trn-sample-app/App Route 

 
 


 


Layout Service URLS:-
https://sxa93sc.dev.local/sitecore/api/layout/render/jss?item=/sitecore/content/anna-university/Home&sc_apikey={B190FA4D-BC36-4803-A84E-DF492B28C8D0}

https://sxa93sc.dev.local/sitecore/api/layout/render/jss?item=/sitecore/content/trn-sample-app/home/Test&sc_apikey={B190FA4D-BC36-4803-A84E-DF492B28C8D0}&sc_site=trn-sample-app
https://trn-sample-app.dev.local/sitecore/api/layout/render/jss?item=/sitecore/content/trn-sample-app/home/Test&sc_apikey={B190FA4D-BC36-4803-A84E-DF492B28C8D0}


Web.config::-
 

<add key="env:define" value="local" />

