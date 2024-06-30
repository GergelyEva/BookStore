using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Abstractions
{
  public interface IDatabaseConfiguration
  {
    string ConnectionString { get; set; }

    string DatabaseName { get; set; }
  }
}
