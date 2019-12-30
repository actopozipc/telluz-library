using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telluz
{
    [Serializable]
    public class Request
    {
       public int coa_id;
        public int cat_id;
        public int from;
        public int to;

    }
    public class Respond
    {
        public float value;
        public bool berechnet;
        public float year;

    }
}
