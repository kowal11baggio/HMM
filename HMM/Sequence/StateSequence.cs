using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HMM.Foundations;

namespace HMM.Sequence
{
    class StateSequence
    {
        private static readonly StateSequence instance = new StateSequence();
        private int _lenghtStatesSequence;
        private States.State[] _statesSequence;

        private StateSequence()
        {
            _lenghtStatesSequence = 0;
        }

        public static StateSequence Instance
        {
            get
            {
                return instance;
            }
        }

        public void setLenghtStatesSequence(int lenghtStatesSequence)
        {
            _lenghtStatesSequence = lenghtStatesSequence;
            _statesSequence = new States.State[_lenghtStatesSequence];
        }

    }
}
