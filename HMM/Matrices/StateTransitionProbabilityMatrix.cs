using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;

namespace HMM.Matrices
{
    class StateTransitionProbabilityMatrix
    {
        private States _states;
        private double[,] _matrixA;

        public StateTransitionProbabilityMatrix()
        {
            _states = new States();
            _matrixA = new double[_states.getNumberOfStates(), _states.getNumberOfStates()];
        }
    }
}
