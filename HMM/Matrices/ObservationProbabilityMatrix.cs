using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;

namespace HMM.Matrices
{
    class ObservationProbabilityMatrix
    {
        private double[,] _matrixB;

        public ObservationProbabilityMatrix()
        {
            _matrixB = new double[States.Instance.getNumberOfStates(), Observations.Instance.getNumberOfObservations()];
        }

        public bool setMatrixB()
        {
            // something here
            return stochasticMatrix();
        }

        public double[,] getMatrixB()
        {
            return _matrixB;
        }


        private bool stochasticMatrix()
        {
            double _sum = 0;
            for (int _i = 0; _i < States.Instance.getNumberOfStates(); _i++)
            {
                for (int _j = 0; _j < Observations.Instance.getNumberOfObservations(); _j++)
                    _sum += _matrixB[_i, _j];
                if (_sum != 1.0)
                    return false;
                _sum = 0;
            }
            return true;
        }
    }
}
