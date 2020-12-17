using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb.Exceptions
{
    public class JETechException:Exception
    {
        private readonly string _appMessage;

        public JETechException():base()
        {            
        }
        public JETechException(string message) : base()
        {
            _appMessage = message;
        }
        public JETechException(int code) : base()
        {
            //_appMessage = message;
        }

        public JETechException(string message,params string[] args) : base()
        {
            _appMessage = string.Format(message,args);
        }

        public JETechException(int code, params string[] args) : base()
        {
            //_appMessage = string.Format(message, args);
        }

        public int ErrorCode { get; set; }

        public string AppMessage => _appMessage;

        public static JETechException Parse(Exception ex) 
        {
            if (ex.GetType() == typeof(JETechException)) 
            {
                return (JETechException)ex;
            }
            else
            {
                return new JETechException("");
            }
        }
    }
}
