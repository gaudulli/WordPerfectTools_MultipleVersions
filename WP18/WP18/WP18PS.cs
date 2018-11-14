using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericPS;
using WordPerfect;
//using PerfectScript;
//using PerfectFit;


namespace WP18
{
    public class WP18PS: GenericPerfectScript
    {
        public WP18PS()
        {

            //script = new PerfectScript.Script();
            perfectScript = new WordPerfect.PerfectScript();
           // perfectFit = new PerfectFit.PerfectScript();
            version = 18;
            
  
        }

    }
}
