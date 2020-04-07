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
        public string key;
        public type type;

        public Request(int coa_id, int cat_id, int from, int to)
        {

            this.coa_id = coa_id;
            this.cat_id = cat_id;
            this.from = from;
            this.to = to;
            type = type.Raw;
        }
        public Request(string coa_id, int cat_id, int year)
        {
            key = coa_id;
            this.cat_id = cat_id;
            from = year;
            to = year;
            type = type.Image;
        }
        /// <summary>
        /// Just for testing
        /// Never ever use this constructor in production
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public Request(int from, int to)
        {
            this.to = to;
            this.from = from;
            type = type.Everything;
        }
        public Error checkForError()
        {
            Error error = new Error(this);
            return error;
        }

    }
    public class Error
    {
        public string errorMessage;
        public bool hasErrors;
        public Error(Request request)
        {
            hasErrors = false;
            errorMessage = "";
            if (request.cat_id < 0 || request.cat_id > 77)
            {
                errorMessage = "Category does not exist";
                hasErrors = true;
            }
            if (request.coa_id < 0 || request.coa_id > 264)
            {
                errorMessage = "Country or region does not exist";
                hasErrors = true;
            }
            if (request.from < 1960 || request.to < 1960 || (request.from>request.to))
            {
                errorMessage = "Year invalid";
                hasErrors = true;
            }

        }

    }

    public enum type
    {
        Raw,
        Image,
        Everything //just for test-purposes
    }
    [Serializable]
    public class Response
    {
        public List<ValuePair> valuePairList { get; set; }
        public string errorMessage;
        public double colorVal { get; set; }
        public string coa { get; set; }
        public Response(Error error)
        {
            this.valuePairList = new List<ValuePair>() { new ValuePair(false, -210, -210) };
            this.errorMessage = error.errorMessage;
        }
        public Response()
        {

        }
        [Serializable]
        public class ValuePair
        {
            public bool berechnet;
            public float year;
            public float value;

            public ValuePair(bool calculated, float year, float value)
            {
                berechnet = calculated;
                this.year = year;
                this.value = value;
            }
        }
    }
}
