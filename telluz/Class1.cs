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
        public type  typ;
     
        public Request(int coa_id, int cat_id, int from, int to)
        {
            
            this.coa_id = coa_id;
            this.cat_id = cat_id;
            this.from = from;
            this.to = to;
            typ = type.Daten;
        }
        public Request(string coa_id, int cat_id, int year)
        {
            this.key = coa_id;
            this.cat_id = cat_id;
            this.from = year;
            this.to = year;
            typ = type.Bild;
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
      public  bool hasErrors;
        public Error(Request request)
        {
            hasErrors = false;
            errorMessage = "";
            if (request.cat_id < 0 || request.cat_id > 77)
            {
                errorMessage= "Non-existing category";
                hasErrors = true;
            }
            if (request.coa_id <0 || request.coa_id > 264 )
            {
                errorMessage = "Non-existing country or area";
                hasErrors = true;
            }
            if (request.from < 1960 || request.to < 1960)
            {
                errorMessage = "Year too early";
                hasErrors = true;
            }
            
        }
       
    }
    
    public enum type
    {
        Daten,
        Bild
    }
    [Serializable]
    public class Response
    {
        public float value;
        public bool berechnet;
        public float year;
        public string error_message;

        public Response(Error error)
        {
            this.value = -210;
            this.berechnet = false;
            this.year = -210;
            this.error_message = error.errorMessage;
        }
        public Response()
        {

        }
    }
}
