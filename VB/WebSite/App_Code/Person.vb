Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

	Public Class Person
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private name_Renamed As String
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Renamed, value)
			End Set
		End Property

		Private address_Renamed As Address
		' If a reference property (Address) is aggregated, its subproperties 
		' can be editted along with the parent object's properties.
		<Aggregated> _
		Public Property Address() As Address
			Get
				Return address_Renamed
			End Get
			Set(ByVal value As Address)
				SetPropertyValue("Address", address_Renamed, value)
			End Set
		End Property

		' if a Person is supposed to have an address by default, 
		' you can create it within the AfterConstruction method
		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()
			Address = New Address(Session)
		End Sub
	End Class

