using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ytdownload
{
    public interface ICommand
    {
        Task ExecuteAsync(string[] args);
    }
}
