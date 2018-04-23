Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo



	Public Class Address
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private city_Renamed As String
		Public Property City() As String
			Get
				Return city_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("City", city_Renamed, value)
			End Set
		End Property
	End Class

