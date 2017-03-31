namespace ExploreSepa

module Tests =

  open System
  open System.Xml
  open System.Xml.Linq
  open Expecto
  open XmlBuilding

  let record = {
    Name = "john smith";
    Amount = 33.00m;
    Destination = "89333"
  }

  let channel = {
    Origin = "12345";
    BIC = "ABIC"
  }

  let output = createMsg record channel

  let tsa = (output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.TtlIntrBkSttlmAmt)
  printfn "-----------------> %A" tsa.Value

  [<Tests>]
  let isoTests =
    testList "Wrapper Header" [
      test "Doc Id" {Expect.equal output.Id "Edoc" "Fail"}
      test "Type" {Expect.equal output.Type "FFCCTRNS" "Fail"}
      test "Version" {Expect.equal output.Version "pacs.008.001.02.2016" "Fail"}
      testList "Header" [
        test "Sender" {Expect.equal output.Header.Sender "BANDLT21XXX" "Fail"}                              //Constant?
        test "System" {Expect.equal output.Header.System "LITAS-RLS" "Fail"}
        test "Date" {Expect.equal output.Header.Date (System.DateTime(2017, 2, 24, 10, 3, 24)) "Fail"}      //Variable
        test "Priority" {Expect.equal output.Header.Priority 51 "Fail"}                                     //Constant?
        test "Receiver" {Expect.equal output.Header.Receiver "LIABLT2XMSD" "Fail"}
        test "MsgId" {Expect.equal output.Header.MsgId "D1170224382279" "Fail"}                             //Variable
      ]
      testList "Doc Header" [
        test "DocId" {Expect.equal output.Doc.Header.DocId "D1170224382279" "Fail"}
        test "BusinessArea" {Expect.equal output.Doc.Header.BusinessArea "SEPASCT" "Fail"}         
      ]
      testList "Ffcctrns" [
        test "MsgId" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.MsgId "D1170224382279" "Fail"}
        test "Settlement Currency" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.TtlIntrBkSttlmAmt.Ccy "EUR" "Fail"}  
        test "TotalAmount" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.TtlIntrBkSttlmAmt.Value 0.1M "Fail"}
        test "IntrBkSttlmDt" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.IntrBkSttlmDt (System.DateTime(2017, 2, 24)) "Fail"}
      ]
      
    ] 
