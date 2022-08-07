using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class DataResult2:Result,IDataResult2
    {
        

        public DataResult2(Object data,string message,bool success):base(success,message)
        {
            Data = data;
        }

        public DataResult2(Object data, bool success) : base(success)
        {
            Data = data;
        }
        public Object Data { get; }

        
    }
}
