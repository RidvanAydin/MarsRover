using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IPosition
    {
        void StartMoving(List<int> maxPoints, string moves);
    }
}