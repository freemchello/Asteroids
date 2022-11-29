using System;

namespace Iterator.Scripts
{
    [Flags]
    public enum Target
    {
        None = 0,
        Unit = 1,
        Autocast = 2,
        Passive = 3
    }
}