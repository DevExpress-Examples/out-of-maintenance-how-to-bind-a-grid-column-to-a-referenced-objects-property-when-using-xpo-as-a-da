Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public NotInheritable Class XpoHelper
	Private Sub New()
	End Sub
	Shared Sub New()
		CreateDemoObjects()
	End Sub

	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

    Private Shared fDataLayer As IDataLayer
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    If System.Threading.Thread.VolatileRead(fDataLayer) Is Nothing Then
                        System.Threading.Thread.VolatileWrite(fDataLayer, GetDataLayer())
                    End If
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property

	Private Shared Function GetDataLayer() As IDataLayer
		XpoDefault.Session = Nothing

		' This code is for demo only! For production, take code from Knowledge Base, article K18061.
		Dim provider As InMemoryDataStore = New DevExpress.Xpo.DB.InMemoryDataStore()
		Return New SimpleDataLayer(provider)
	End Function

	Public Shared Sub CreateDemoObjects()
		Using uow As UnitOfWork = GetNewUnitOfWork()
			If uow.FindObject(Of Person)(Nothing) IsNot Nothing Then
				Return
			End If

			' create default objects
			Dim pers As New Person(uow)
			pers.Name = "John Doe"

			' Address is automatically created in Person.AfterConstruction (see Knowledge Base article A2348)
			pers.Address.City = "Las Vegas"

			' otherwise, you can explicitly create it

			'Address addr = new Address(uow);
			'addr.City = "Las Vegas";
			'pers.Address = addr;

			uow.CommitChanges()
		End Using
	End Sub
End Class
