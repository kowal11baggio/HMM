using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;

namespace HMM.Matrices
{
    class InitialStateDistribution
    {
        private double[] _initailMatrix;

        public InitialStateDistribution()
        {
            _initailMatrix = new double[States.Instance.getNumberOfStates()];
        }

        public bool setInitailMatrix()
        {
            // something here
            return stochasticMatrix();
        }

        public double[] getInitailMatrix()
        {
            return _initailMatrix;
        }

        private bool stochasticMatrix()
        {
            double _sum = 0;
            for (int _i = 0; _i < Observations.Instance.getNumberOfObservations(); _i++)
                _sum += _initailMatrix[_i];
            if (_sum != 1.0)
                return false;
            _sum = 0;
            return true;
        }
    }
}
