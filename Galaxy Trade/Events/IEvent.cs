using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    interface IEvent
    {
        List<string> Message { get; }

        bool isActive();
        void clearMessage();
        void chooseEvent();
    }

    //new Random((int) DateTime.Now.Ticks)
}
