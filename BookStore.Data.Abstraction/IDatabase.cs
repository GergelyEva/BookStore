using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstraction
{
  public interface IDatabase
  {
    public TCollection GetCollection<TCollection, TItem>(string Name)
      where TCollection : class;
  }
}
