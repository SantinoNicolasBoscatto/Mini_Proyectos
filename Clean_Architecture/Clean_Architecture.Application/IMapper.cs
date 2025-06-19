using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public interface IMapper<TDTO, TOut>
    {
        public TOut ToEntity(TDTO dto);
    }
}
