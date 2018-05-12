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
            _matrixB = new double[Observations.Instance.getNumberOfObservations(), States.Instance.getNumberOfStates()];
        }
    }
}
