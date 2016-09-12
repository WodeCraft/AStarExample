using System;

namespace AStarExample.Interfaces
{
    public interface IIteratable<T> where T : EventArgs
    {
        event EventHandler<T> IterationComplete;
    }
}
