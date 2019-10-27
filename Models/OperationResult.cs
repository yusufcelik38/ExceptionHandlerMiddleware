using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSuccessful = true;
            ReturnMessage = "İşlem Başarılı";
            ReturnCode = 100;
        }
        public bool IsSuccessful { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
