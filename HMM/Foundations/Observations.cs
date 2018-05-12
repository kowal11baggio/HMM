using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Foundations
{
    public class Observations
    {
        private int _numberOfStates;
        private enum Observation { Large, Medium, Small };

        public void setNumberOfStates(int numberOfStates)
        {
            _numberOfStates = numberOfStates;
        }

        public int setNumberOfStates()
        {
            return _numberOfStates;
        }
    }
}
