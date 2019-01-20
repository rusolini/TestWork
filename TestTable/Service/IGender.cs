using Dropdownlistmvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropdownlistmvc.Service
{
   public interface IGender
    {
        IEnumerable<Gender> GetGenders { get; }
        void Save(Gender gender);
        void Delete(int? Id);

        Gender GetGender(int? Id);

    }
}
