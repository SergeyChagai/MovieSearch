using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models.Interfaces
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
