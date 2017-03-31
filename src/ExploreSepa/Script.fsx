#r "System.Xml.Linq.dll"
#r "System.Xml.XDocument"
#r "../../packages/FSharp.Data/lib/portable-net45+netcore45/FSharp.Data.dll"
#r "System.Globalization"

#load "XmlTemplates.fs"
#load "XmlBuilding.fs"

let x = ExploreSepa.XmlBuilding.FFCCTRNS.Parse(ExploreSepa.XmlTemplates.FFCCTRNS_Sample)

x