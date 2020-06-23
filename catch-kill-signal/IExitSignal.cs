using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catch_kill_signal
{
    public interface IExitSignal
    {
        event EventHandler Exit;
    }
}
