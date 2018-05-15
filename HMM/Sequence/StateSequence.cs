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
        private int _lenghtStatesSequence;
        private States.State[] _statesSequence;
        private int _iter;

        public StateSequence()
        {
            _lenghtStatesSequence = 0;
            _iter = 0;
        }

        public void setLenghtStatesSequence(int lenghtStatesSequence)
        {
            _lenghtStatesSequence = lenghtStatesSequence;
            _statesSequence = new States.State[_lenghtStatesSequence];
        }

        public void setValueToStatesSequence(int value)
        {
            _statesSequence[_iter] = (States.State)value;
            _iter++;
            if (_iter == _lenghtStatesSequence)
                _iter = 0;
        }
        public void printStateSequence(string message)
        {
            for(int i=0; i < _lenghtStatesSequence; i++)
            {
                Console.Write(_statesSequence[i] + " ");
            }
            Console.Write(message);
        }
    }
}
