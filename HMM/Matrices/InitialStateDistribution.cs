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
        private double[] _initailArray;

        public InitialStateDistribution()
        {
            _initailArray = new double[ States.Instance.getNumberOfStates()];
        }
    }
}
