using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    public interface IMapStorage
    {
        Map Load(string inp);
        bool Delete(string inp);
        bool Save(IMap map);
        List<Map> GetListOfMaps();
    }
}
