using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WP14;
using WP16;
using WP17;
using WP18;
using GenericPS;

namespace PerfectScriptFactory
{
    public static class MakePerfectScriptObject
    {

        public static GenericPerfectScript getPS(int version)
        {
            switch (version)
            {
                case 14:
                    {
                        return new WP14PS();
                    }
                case 15:
                    {
                        return null;
                    }
                case 16:
                    {
                        return new WP16PS();
                    }
                case 17:
                    {
                        return new WP17PS();
                    }
                case 18:
                    {
                        return new WP18PS();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
