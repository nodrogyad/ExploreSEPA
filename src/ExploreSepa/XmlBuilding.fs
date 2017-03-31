namespace ExploreSepa

module XmlBuilding =

  open FSharp.Data

  type PaymentRecord = {
    Name : string
    Amount : decimal
    Destination : string
  }

  type SEPAChannel = {
    Origin : string
    BIC : string
  }

  type FFCCTRNS = XmlProvider<FFCCTRNS_Sample, Global=true>

  let createMsg payment channel =
    FFCCTRNS.Parse(FFCCTRNS_Sample)

