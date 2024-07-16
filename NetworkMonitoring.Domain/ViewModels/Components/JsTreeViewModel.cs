using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.Components
{
    public class JsTreeViewModel
    {
        //public Environments Environments { get; set; }
        public string id { get; set; }

        public string parent { get; set; }

        public string text { get; set; }

        public State state { get; set; }

        public string type { get; set; }

        public string icon { get; set; }
    }

    public class State
    {
        public bool selected { get; set; }
        public bool opened { get; set; }
        public bool disabled { get; set; }


    }
}
