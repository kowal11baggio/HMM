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

        public bool setMatrixA()
        {
            // something here
            return stochasticMatrix();
        }

        public double[,] getMatrixA()
        {
            return _matrixA;
        }

        private bool stochasticMatrix()
        {
            double _sum = 0;
            for(int _i = 0; _i< States.Instance.getNumberOfStates(); _i++)
            {
                for (int _j = 0; _j < States.Instance.getNumberOfStates(); _j++)
                    _sum += _matrixA[_i, _j];
                if(_sum != 1.0)
                    return false;
                _sum = 0;
            }
            return true;
        }
    }
}
