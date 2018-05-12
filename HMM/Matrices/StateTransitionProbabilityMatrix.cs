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
        private double[,] _matrixA;

        public StateTransitionProbabilityMatrix()
        {
            _matrixA = new double[States.Instance.getNumberOfStates(), States.Instance.getNumberOfStates()];
        }
    }
}
