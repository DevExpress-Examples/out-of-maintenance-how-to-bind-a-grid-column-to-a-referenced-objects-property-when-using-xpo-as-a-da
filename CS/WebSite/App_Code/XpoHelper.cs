using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

/// <summary>
/// Summary description for XpoHelper
/// </summary>
public static class XpoHelper {
    static XpoHelper() {
        CreateDemoObjects();
    }

    public static Session GetNewSession() {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork() {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static volatile IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if (fDataLayer == null) {
                lock (lockObject) {
                    if (fDataLayer == null) {
                        fDataLayer = GetDataLayer();
                    }
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer() {
        XpoDefault.Session = null;

        // This code is for demo only! For production, take code from Knowledge Base, article K18061.
        InMemoryDataStore provider = new DevExpress.Xpo.DB.InMemoryDataStore();
        return new SimpleDataLayer(provider);
    }

    public static void CreateDemoObjects() {
        using(UnitOfWork uow = GetNewUnitOfWork()) {
            if(uow.FindObject<Person>(null) != null) return;

            // create default objects
            Person pers = new Person(uow);
            pers.Name = "John Doe";

            // Address is automatically created in Person.AfterConstruction (see Knowledge Base article A2348)
            pers.Address.City = "Las Vegas";

            // otherwise, you can explicitly create it

            //Address addr = new Address(uow);
            //addr.City = "Las Vegas";
            //pers.Address = addr;

            uow.CommitChanges();
        }
    }
}
