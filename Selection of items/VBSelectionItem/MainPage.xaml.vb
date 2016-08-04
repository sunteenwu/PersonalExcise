' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub CategoryName_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        'Or CategoryName.SelectedValue.ToString = p.CategoryName And d.CodeID = p.CodeID, 
        CategoryCodeN = (From d In CategoryCode2.ToList Join p In CategoryInfo.ToList On d.CodeID Equals p.CodeID Where d.CodeID = p.CodeID And p.CategoryID = CategoryName.SelectedIndex + 1 Select d.CategoryCode).ToList
        Dim codename As String = ""
        For Each a As String In CategoryCodeN
            codename = a + " , " + codename
        Next

        CategoryC.Text = codename.Remove(codename.Length - 3, 3)
    End Sub

    Private Sub CategoryDetails_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        'CategoryDetails.DataContext = "{Binding Source={StaticResource CategoryCD}}"
        ' Dim testdatamodel As Data.TempCatData = New Data.TempCatData
        Using categories As New UIELLUWP.DataAccess.SQLiteDb
            categories.Database.EnsureDeleted()
            categories.Database.EnsureCreated()
            Dim c As DataAccess.CategoryCodes = New DataAccess.CategoryCodes With {
              .CategoryCode = "CBM1"
              }
            categories.CategoryCodes.Add(c)
            categories.SaveChanges(True)

            Dim b As New DataAccess.CategoryReference
            b.CategoryDescription = "who is this?"
            b.CategoryName = "Cool Beans"
            b.CodeID = c.CodeID
            categories.CategoryInformation.Add(b)
            categories.SaveChanges(True)

            Dim c2 As New UIELLUWP.DataAccess.CategoryCodes
            c2.CategoryCode = "DBM1"
            'c2.CodeID = 2
            categories.CategoryCodes.Add(c2)
            categories.SaveChanges()

            'second category info
            Dim b2 As New UIELLUWP.DataAccess.CategoryReference
            b2.CategoryDescription = "Disc media such as cds, dvd's, and blurays"
            b2.CategoryName = "Disc Based Media"
            b2.CodeID = c2.CodeID
            'b2.CategoryID = 2
            categories.CategoryInformation.Add(b2)
            categories.SaveChanges()

            Dim b4 As New UIELLUWP.DataAccess.CategoryReference
            b4.CategoryDescription = "Disc media such as cds, dvd's, and blurays"
            b4.CategoryName = "Disc Based Media"
            b4.CodeID = c.CodeID
            'b2.CategoryID = 2
            categories.CategoryInformation.Add(b4)
            categories.SaveChanges()

            Dim b3 As New UIELLUWP.DataAccess.CategoryReference
            b3.CategoryDescription = "Other Disc media such as HD DVD's, Mini discs, Video Game Discs, etc."
            b3.CategoryName = "Disc Based Media 2"
            b3.CodeID = c2.CodeID
            'b2.CategoryID = 2
            categories.CategoryInformation.Add(b3)
            categories.SaveChanges()
            'put into the display list
            CategoryCode2 = categories.CategoryCodes.AsNoTracking.ToList
            CategoryInfo = categories.CategoryInformation.AsNoTracking.ToList

            CategoryCodeN = From e In categories.CategoryCodes Join p In categories.CategoryInformation On e.CodeID Equals p.CodeID Where e.CodeID = p.CodeID Select e.CategoryCode Distinct.ToList

        End Using
        'second category info

        CategoryName.ItemsSource = From ci In CategoryInfo Join cd2 In CategoryCode2 On ci.CodeID Equals cd2.CodeID Where ci.CodeID = cd2.CodeID Select ci.CategoryName, ci.CategoryDescription Distinct.ToList
        'Dim test As IEnumerable(Of Object)
        'test = 

    End Sub
End Class
