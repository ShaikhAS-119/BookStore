using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Model
{
    public class ResponseModel<T>
    {
        public bool success {  get; set; } 
        public string message { get; set; } = "";
        public T data { get; set; } = default(T);
    }
}
