namespace BookStore.Data.Abstractions
{
    public interface IDatabase
    {//TCollection?-return type TCollection or null(because of the ?)
     //GetCollection- name of the method
     //TCollection, TItem-params
     //Name-name of the collection 
     //where TCollection : class-it has to be reference type, can't be int, string etc.
        TCollection? GetCollection<TCollection, TItem>(string Name) where TCollection : class;
    }
}
