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

        public void setNumberOfStates()
        {
            _numberOfStates = Enum.GetNames(typeof(Observation)).Length;
        }

        public int getNumberOfStates()
        {
            return _numberOfStates;
        }
    }
}
