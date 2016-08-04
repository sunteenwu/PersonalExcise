Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.Data.Entity
Imports Microsoft.Data.Sqlite
Namespace DataAccess
    Public Class SQLiteDb
        Inherits DbContext
        'the classes to return
        '  Public Property Categories As DbSet(Of CategoryList)
        Public Property CategoryCodes As DbSet(Of CategoryCodes)
        Public Property CategoryInformation As DbSet(Of CategoryReference)
        Private Shared _path As String = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "uiedata.db")
        Public Shared Sub Migrate()
            Dim a As New SQLiteDb
            a.Database.Migrate
        End Sub
        Public Sub Initialize()

        End Sub
        Public Sub New()
            'Database.EnsureDeleted()
            'Database.EnsureCreated()
            'Database.Migrate()
        End Sub
        ' Private Shared _path As String = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "uiedata.db")
        ' Public Shared _mycon As SQLite.Net.SQLiteConnection

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            If File.Exists(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "uiedata.db")) Then
                'File.Copy(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "uiedata.db"), Path.Combine(Windows.Storage.KnownFolders.MusicLibrary.Path, "uiedata.db"))
                optionsBuilder.UseSqlite("Filename=" + _path)

            Else
                'Dim db As New SQLiteDb
                'db.Database.EnsureCreated()
            End If
        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of CategoryCodes)(Function(e)
                                                      e.[Property](Function(c) c.CodeID).ValueGeneratedOnAdd()
                                                      e.HasKey(Function(c) c.CodeID)
                                                  End Function)
            'modelBuilder.Entity(Of CategoryReference)().HasOne(Of CategoryReference)().WithMany().HasForeignKey("CodeID")
            'HasKey(Function(cd) cd.CodeID)
            ' Make key for CategoryList temp table
            'modelBuilder.Entity(Of CategoryList)().ToTable("CategoryList")
            'modelBuilder.Entity(Of CategoryList)().HasKey(Function(cl) New With {
            '.CategoryID = cl.CategoryID,
            '.CodeID = cl.CodeID
            ' })

            'modelBuilder.Entity(Of CategoryList)().HasOne(Function(cl) cl.CategoryInfo).WithMany(Function(b) b.CategoryList).HasForeignKey(Function(cl) cl.CategoryID)
            'modelBuilder.Entity(Of CategoryList)().HasOne(Function(cl) cl.CategoryCodes).WithMany(Function(b) b.CategoryList).HasForeignKey(Function(cl) cl.CodeID)

            ' Make TimeStamp required

            ' modelBuilder.Entity(Of Ambience)().[Property](Function(b) b.AmbienceId).IsRequired()

        End Sub

    End Class
    <Table("CategoryCodes")>
    Public Class CategoryCodes 'category shortnames/codes 

        <MaxLength(100)>
        <Required>
        Public Property CategoryCode As String
            Get
                Return _CategoryCode
            End Get
            Set(value As String)
                _CategoryCode = value
            End Set
        End Property
        Private _CategoryCode As String

        '<NotNull>
        ' <PrimaryKey>
        '<Unique(Name:="UQ__CategoryCodes__0000000000000081_CategoryCodes", Order:=0)>

        <Key>
        <Required>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        <ForeignKey("CodeID")>
        Public Property CodeID As Integer
            Get
                Return _CodeID
            End Get
            Set(value As Integer)
                _CodeID = value
            End Set
        End Property
        Private _CodeID As Integer
        'Public Overridable Property CategoryList As ICollection(Of CategoryList)
        '    Get
        '        Return m_CategoryList
        '    End Get
        '    Set(value As ICollection(Of CategoryList))
        '        value = m_CategoryList
        '    End Set
        'End Property
        'Dim m_CategoryList As ICollection(Of CategoryList)
    End Class
    <Table("CategoryReference")>
    Partial Public Class CategoryReference 'table design for category data

        <MaxLength(100)>
        Public Property CategoryName As String
            Get
                Return _CategoryName
            End Get
            Set(value As String)
                _CategoryName = value
            End Set
        End Property
        Private _CategoryName As String
        <MaxLength(100)>
        Public Property CategoryDescription As String
            Get
                Return _CategoryDescription
            End Get
            Set(value As String)
                _CategoryDescription = value
            End Set
        End Property
        Private _CategoryDescription As String

        '<Unique(Name:="UQ__CatagoryReference__000000000000005F_CatagoryReference", Order:=0)>

        <ForeignKey("CodeID"), Column(Order:=2)>
        <Required>
        Public Property CodeID As Integer
            Get
                Return _CodeID
            End Get
            Set(value As Integer)
                _CodeID = value
            End Set
        End Property
        Private _CodeID As Integer

        '<Unique(Name:="UQ__CatagoryReference__000000000000005A_CatagoryReference", Order:=0)>
        <Key, Column(Order:=1)>
        <Required>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property CategoryID As Integer
            Get
                Return _CategoryID
            End Get
            Set(value As Integer)
                _CategoryID = value
            End Set
        End Property
        Private _CategoryID As Integer
        'Public Overridable Property CategoryList As ICollection(Of CategoryList)
        '    Get
        '        Return m_CategoryList
        '    End Get
        '    Set(value As ICollection(Of CategoryList))
        '        value = m_CategoryList
        '    End Set
        'End Property
        'Dim m_CategoryList As ICollection(Of CategoryList)
    End Class
    'other db classes for tables here.
End Namespace
