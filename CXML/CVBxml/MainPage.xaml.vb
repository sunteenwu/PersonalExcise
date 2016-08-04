' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub Readxml_Click(sender As Object, e As RoutedEventArgs)
        Dim srcTree As XDocument =
         <?xml version="1.0" encoding="utf-8" standalone="yes"?>
         <!--This is a comment-->
         <root>
             <hotels>
                 <hotel>
                     <location>location1</location>
                     <name>name1</name>
                 </hotel>
                 <hotel>
                     <location>location2</location>
                     <name>name2</name>
                 </hotel>
                 <hotel>
                     <location>location3</location>
                     <name>name3</name>
                 </hotel>
             </hotels>
         </root>
        'Dim doc As XDocument =
        '    <?xml version="1.0" encoding="utf-8" standalone="yes"?>
        '    <!--This is a comment-->
        '    <Root>
        '        <%= From el In srcTree.<Root>.Elements
        '            Where CStr(el).StartsWith("data")
        '            Select el %>
        '    </Root>
        'Txtshow.Text = doc.ToString

        Dim root As XElement = srcTree.Root
        Dim hotelnodes = root.Element("hotels").Elements("hotel").ToList





        'Dim childnode As XElement = root.Element("Father")
        'Dim xmlstring = childnode.ToString
        'xmlstring = xmlstring + childnode.Element("Child1").ToString

        'Txtshow.Text = Txtshow.Text + xmlstring
        'Txtshow.Text = Txtshow.Text + root.Element("Father").Element("Child1").Value



    End Sub
End Class
