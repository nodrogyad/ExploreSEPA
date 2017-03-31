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

  let printProperties x =
    let t = x.GetType()
    let properties = t.GetProperties()
    printfn "-----------"
    printfn "%s" t.FullName
    properties |> Array.iter (fun prop ->
        if prop.CanRead then
            let value = prop.GetValue(x, null)
            printfn "readable %s: %O" prop.Name value
        else
            printfn "other %s: ?" prop.Name)

  let output = createMsg record channel

//  let tsa = (output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.CdtrAgt.FinInstnId.BIC)
//  let tsa = (output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.CdtrAgt.FinInstnId.XElement)
//  printfn "-----------------> %A" tsa 
//  printProperties tsa

  [<Tests>]
  let isoTests =
    testList "Envelope Header" [
      test "Doc Id" {Expect.equal output.Id "Edoc" "Fail"}
      test "Type" {Expect.equal output.Type "FFCCTRNS" "Fail"}
      test "Version" {Expect.equal output.Version "pacs.008.001.02.2016" "Fail"}
      testList "Header" [
        test "Sender" {Expect.equal output.Header.Sender (Some "BANDLT21XXX") "Fail"}                             //Constant?
        test "System" {Expect.equal output.Header.System (Some "LITAS-RLS") "Fail"}
        test "Date" {Expect.equal output.Header.Date (Some (System.DateTime(2017, 2, 24, 10, 3, 24))) "Fail"}     //Variable
        test "Priority" {Expect.equal output.Header.Priority 51 "Fail"}                                           //Constant?
        test "Receiver" {Expect.equal output.Header.Receiver (Some "LIABLT2XMSD") "Fail"}
        test "MsgId" {Expect.equal output.Header.MsgId (Some "D1170224382279") "Fail"}                            //Variable
      ]
      testList "PAS(Msg Exchange Sys) to EDoc(Document Storage Sys) Header" [
        test "DocId" {Expect.equal output.Doc.Header.DocId (Some "D1170224382279") "Fail"}
        test "Type" {Expect.equal output.Doc.Header.Type (Some "FFCCTRNS") "Fail"}
        test "Priority" {Expect.equal output.Doc.Header.Priority 51 "Fail"}
        test "BusinessArea" {Expect.equal output.Doc.Header.BusinessArea (Some "SEPASCT") "Fail"}         
      ]
      testList "Ffcctrns" [
        testList "Group Header max 500 txns" [
          test "MsgId" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.MsgId "D1170224382279" "Fail"}
          test "Settlement Currency" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.TtlIntrBkSttlmAmt.Ccy "EUR" "Fail"}  
          test "TotalAmount" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.TtlIntrBkSttlmAmt.Value 0.1M "Fail"}
          test "IntrBkSttlmDt" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.IntrBkSttlmDt (System.DateTime(2017, 2, 24)) "Fail"}
          test "SttlmMtd" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.SttlmInf.SttlmMtd "CLRG" "Fail"}
          test "ClrSys" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.GrpHdr.SttlmInf.ClrSys.XElement.Value "LITAS-RLS" "Fail"}

        ]
        testList "pacs.008.001.02.2016" [
          test "Instruction Id" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.PmtId.InstrId "D1170224384664" "Fail"}
          test "Tax Id" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.PmtId.TxId "dov" "Fail"}
          test "Debitor Acct" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.DbtrAcct.Id.Iban "LT950100100000123456" "Fail"}
          test "Bank Id(BIC)" {Expect.equal output.Doc.Ffcctrns.Document.FiToFiCstmrCdtTrf.CdtTrfTxInf.CdtrAgt.FinInstnId.XElement.Value "XXTSLT20XXX" "Fail"}
         

          
          
        ]

      ]
      
    ] 

