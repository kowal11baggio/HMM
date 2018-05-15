using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Matrices;
using HMM.Foundations;
using HMM.Sequence;

namespace HMM.Algorithm
{
    class Kernel
    {
        private int _lenghtSequenceT;
        private int _numberOfStatesN;
        private int _numberOfObservationsM;

        private double[,] _matrixA;
        private double[,] _matrixB;
        private double[] _matrixPi;
        private double[] _sequenceObservationsO;

        private int maxIters;
        private int iters;
        private double oldLogProb;

        private double[] _sequenceC;
        private double[,] _matrixAlpha;
        private double[,] _matrixBeta;
        private double[,] _matrixGamma;

        Observations.Observation[] _obs;

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
            ObservationSequence.Instance.setInitialSeqeunce();
            _numberOfObservationsM = ObservationSequence.Instance.getLenghtObservation();
            StateSequence.Instance.setLenghtStatesSequence(_numberOfObservationsM);
            _numberOfStatesN = States.Instance.getNumberOfStates();
            _lenghtSequenceT = ObservationSequence.Instance.getLenghtObservation();
        }

        public void aflaPass()
        {
            // compute alpha_zero(i)
            _sequenceC = new double[_numberOfObservationsM];
            _matrixAlpha = new double[_lenghtSequenceT, _numberOfStatesN];
            for (int i = 0; i < _numberOfStatesN; i++)
            {
                _matrixAlpha[0, i] = _matrixPi[i] * _matrixB[i, (int)ObservationSequence.Instance.getObservationSequence()[0]];
                _sequenceC[0] += _matrixAlpha[0, i];
            }
            // scale the alpha_zero(i)
            _sequenceC[0] = 1 / _sequenceC[0];
            for (int i = 0; i < States.Instance.getNumberOfStates(); i++)
                _matrixAlpha[0, i] *= _sequenceC[0];
            // compute alpha_t(i)
            for (int t = 1; t < _lenghtSequenceT; t++)
            {
                _sequenceC[t] = 0;
                for (int i = 0; i < _numberOfStatesN; i++)
                {
                    _matrixAlpha[t, i] = 0;
                    for (int j = 0; j < _numberOfStatesN; j++)
                    {
                        _matrixAlpha[t, i] += _matrixAlpha[t - 1, j] * _matrixA[j, i];
                    }
                    _matrixAlpha[t, i] *= _matrixB[i, (int)ObservationSequence.Instance.getObservationSequence()[t]];
                    _sequenceC[t] += _matrixAlpha[t, i];
                }
                // scale alpha_t(i)
                _sequenceC[t] = 1 / _sequenceC[t];
                for (int i = 0; i < _numberOfStatesN; i++)
                {
                    _matrixAlpha[t, i] *= _sequenceC[t];
                }
            }
        }

        private void betaPass()
        {

        }


    }
}
