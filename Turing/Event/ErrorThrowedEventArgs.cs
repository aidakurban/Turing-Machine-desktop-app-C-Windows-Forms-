using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing.Event
{
    public class ErrorThrowedEventArgs
    {
        public string ErrorMessage { get; set; }

        public ErrorThrowedEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
}
