using System;
using Core.Entities;

namespace API.Models
{
    public class Envelope
    {
        public object Result { get; }
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public string InvalidField { get; }
        public DateTime TimeGenerated { get; }

        private Envelope(object result, BulkError error, string invalidField)
        {
            Result = result;
            ErrorCode = error?.Code;
            ErrorMessage = error?.Message;
            InvalidField = invalidField;
            TimeGenerated = DateTime.UtcNow;
        }

        public static Envelope Ok(object result = null)
        {
            return new Envelope(result, null, null);
        }

        public static Envelope Error(BulkError error, string invalidField)
        {
            return new Envelope(null, error, invalidField);
        }
    }
}

