#load "XmlBuilding.fs"
#load "XmlTemplates.fs"
#load "System.Xml.Linq"

  open System.Xml
  open System.Xml.Linq
  open System.IO
  open FSharp.Data
  open XmlTemplates

    let record = {
    Name = "john smith";
    Amount = 33.00m;
    Destination = "89333"
  }

  let channel = {
    Origin = "12345";
    BIC = "ABIC"
  }

