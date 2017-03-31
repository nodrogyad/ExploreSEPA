namespace ExploreSepa

[<AutoOpen>]
module XmlTemplates =

    [<Literal>]
    let FFCCTRNS_Sample =
        """<?xml version="1.0"?>
<Msg ID="Edoc" Type="FFCCTRNS" Version="pacs.008.001.02.2016">
    <Header>
        <Sender>BANDLT21XXX</Sender>
        <Receiver>LIABLT2XMSD</Receiver>
        <Priority>51</Priority>
        <MsgId>D1170224382279</MsgId>
        <Date>2017-02-24T10:03:24</Date>
        <System>LITAS-RLS</System>
    </Header>
    <Docs>
        <Doc>
            <Header>
                <DocId>D1170224382279</DocId>
                <Dates>
                    <Type>FormDoc</Type>
                    <Date>2017-02-24T10:03:24</Date>
                </Dates>
                <Type>FFCCTRNS</Type>
                <Priority>51</Priority>
                <BusinessArea>SEPASCT</BusinessArea>
            </Header>
            <Ffcctrns>
                <Document>
                    <FIToFICstmrCdtTrf>
                        <GrpHdr>
                            <MsgId>D1170224382279</MsgId>
                            <CreDtTm>2017-02-24T10:03:24</CreDtTm>
                            <NbOfTxs>1</NbOfTxs>
                            <TtlIntrBkSttlmAmt Ccy="EUR">0.1</TtlIntrBkSttlmAmt>
                            <IntrBkSttlmDt>2017-02-24</IntrBkSttlmDt>
                            <SttlmInf>
                                <SttlmMtd>CLRG</SttlmMtd>
                                <ClrSys>
                                    <Prtry>LITAS-RLS</Prtry>
                                </ClrSys>
                            </SttlmInf>
                            <InstgAgt>
                                <FinInstnId>
                                    <BIC>BANDLT21XXX</BIC>
                                </FinInstnId>
                            </InstgAgt>
                        </GrpHdr>
                        <CdtTrfTxInf>
                            <PmtId>
                                <InstrId>D1170224384664</InstrId>
                                <EndToEndId>NOTPROVIDED</EndToEndId>
                                <TxId>dov</TxId>
                            </PmtId>
                            <PmtTpInf>
                                <SvcLvl>
                                    <Cd>SEPA</Cd>
                                </SvcLvl>
                            </PmtTpInf>
                            <IntrBkSttlmAmt Ccy="EUR">0.1</IntrBkSttlmAmt>
                            <ChrgBr>SLEV</ChrgBr>
                            <Dbtr>
                                <Nm>test</Nm>
                            </Dbtr>
                            <DbtrAcct>
                                <Id>
                                    <IBAN>LT950100100000123456</IBAN>
                                </Id>
                            </DbtrAcct>
                            <DbtrAgt>
                                <FinInstnId>
                                    <BIC>BANDLT21XXX</BIC>
                                </FinInstnId>
                            </DbtrAgt>
                            <CdtrAgt>
                                <FinInstnId>
                                    <BIC>XXTSLT20XXX</BIC>
                                </FinInstnId>
                            </CdtrAgt>
                            <Cdtr>
                                <Nm>test2</Nm>
                            </Cdtr>
                            <CdtrAcct>
                                <Id>
                                    <IBAN>LT083540000000123456</IBAN>
                                </Id>
                            </CdtrAcct>
                        </CdtTrfTxInf>
                    </FIToFICstmrCdtTrf>
                </Document>
            </Ffcctrns>
        </Doc>
    </Docs>
</Msg>"""
