using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Matrices;

namespace HMM.Algorithm
{
    class Kernel
    {
        private double[,] _matrixA;
        private double[,] _matrixB;
        private double[] _matrixPi;

        private int maxIters;
        private int iters;
        private double oldLogProb;

        public Kernel()
        {
            _matrixA = null;
            _matrixB = null;
            _matrixPi = null;

            maxIters = int.MaxValue;        //maximum number of re-estimation iterations
            iters = 0;
            oldLogProb = double.NegativeInfinity;
        }

        public void initialization()
        {
            StateTransitionProbabilityMatrix.Instance.createMatrix();
            _matrixA = StateTransitionProbabilityMatrix.Instance.getMatrixA();
            ObservationProbabilityMatrix.Instance.createMatrix();
            _matrixB = ObservationProbabilityMatrix.Instance.getMatrixB();
            InitialStateDistribution.Instance.createMatrix();
            _matrixPi = InitialStateDistribution.Instance.getInitailMatrix();
        }

        private void aflaPass()
        {

        }

        private void betaPass()
        {

        }


    }
}
