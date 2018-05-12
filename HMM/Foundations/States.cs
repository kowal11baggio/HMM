using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Foundations
{
    public class States
    {
        private int _numberOfStates;
        private enum State { Hot, Cold };

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
