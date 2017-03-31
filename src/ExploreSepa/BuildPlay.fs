namespace ExploreSepa

module BuildPlay =

    open System
    open System.Xml
    open System.Text
    open System.IO

// XElement
    type XElement (name:string, [<ParamArray>] values:obj []) = 
        inherit System.Xml.Linq.XElement
            (System.Xml.Linq.XName.op_Implicit(name), values) 

    let build title link description = 
        XElement("item", 
            XElement("title", title),
            XElement("link", link),
            XElement("description", description))

/// F# Element Tree
    type Xml = 
        | Element of string * string * Xml seq    
        member this.WriteContentTo(writer:XmlWriter) =
            let rec Write element =
                match element with
                | Element (name, value, children) -> 
                    writer.WriteStartElement(name)
                    writer.WriteString(value)
                    children |> Seq.iter (fun child -> Write child)
                    writer.WriteEndElement()
            Write this   

        override this.ToString() =
            let output = StringBuilder()             
            using (new XmlTextWriter(new StringWriter(output), 
                    Formatting=Formatting.Indented))
                this.WriteContentTo        
            output.ToString()



