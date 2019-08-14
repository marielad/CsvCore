using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPNET.Services
{
    public interface ICsvManager<T>
    {
        List<T> readCsv(string csvPath);
        void writeCsv(T tObject, string csvPath);
        void writeListToCsv(List<T> objectList, string csvPath);
    }
}
