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
    class KernelHMMSence
    {
        private int _lenghtSequenceT;
        private int _numberOfStatesN;
        private int _numberOfObservationsM;

        private double[,] _matrixA;
        private double[,] _matrixB;
        private double[] _matrixPi;

        private int maxIters;
        private int iters;
        private double oldLogProb;

        private double[] _sequenceC;
        private double[,] _matrixAlpha;
        private double[,] _matrixBeta;
        private double[,] _matrixGamma;

        StateSequence _stateSequence;

        public KernelHMMSence()
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
            _matrixA = StateTransitionProbabilityMatrix.Instance.getMatrixA();
            _matrixB = ObservationProbabilityMatrix.Instance.getMatrixB();  
            _matrixPi = InitialStateDistribution.Instance.getInitailMatrix();  
            _numberOfObservationsM = ObservationSequence.Instance.getLenghtObservation();
            _stateSequence = new StateSequence();
            _stateSequence.setLenghtStatesSequence(_numberOfObservationsM);
            _numberOfStatesN = States.Instance.getNumberOfStates();
            _lenghtSequenceT = ObservationSequence.Instance.getLenghtObservation();
            _sequenceC = new double[_numberOfObservationsM];
            _matrixAlpha = new double[_lenghtSequenceT, _numberOfStatesN];
            _matrixBeta = new double[_lenghtSequenceT, _numberOfStatesN];
        }

        public void aflaPass()
        {
            // compute alpha0(i)
            for (int i = 0; i < _numberOfStatesN; i++)
            {
                _matrixAlpha[0, i] = _matrixPi[i] * _matrixB[i, (int)ObservationSequence.Instance.getObservationSequence()[0]];
                _sequenceC[0] += _matrixAlpha[0, i];
            }

            // scale the alpha0(i)
            _sequenceC[0] = 1 / _sequenceC[0];
            for (int i = 0; i < States.Instance.getNumberOfStates(); i++)
                _matrixAlpha[0, i] *= _sequenceC[0];

            // compute alphaT(i)
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

                // scale alphaT(i)
                _sequenceC[t] = 1 / _sequenceC[t];
                for (int i = 0; i < _numberOfStatesN; i++)
                    _matrixAlpha[t, i] *= _sequenceC[t];
            }
        }

        public void betaPass()
        {
            // betaT-1(i) = 1 scaled by cT-1
            for (int i = 0; i < _numberOfStatesN; i++)
                _matrixBeta[_lenghtSequenceT - 1, i] = _sequenceC[_lenghtSequenceT - 1];
            // beta-pass
            for (int t = _lenghtSequenceT - 2; t > -1; t--)
            {
                for (int i = 0; i < _numberOfStatesN; i++)
                {
                    _matrixBeta[t, i] = 0;
                    for (int j = 0; j < _numberOfStatesN; j++)
                    {
                        _matrixBeta[t, i] += _matrixA[i, j] * _matrixB[j, (int)ObservationSequence.Instance.getObservationSequence()[t + 1]] * _matrixBeta[t + 1, j];
                    }
                    // scale betaT(i) with same scale factor as alpha(i)
                    _matrixBeta[t, i] *= _sequenceC[t];
                }
            }
        }

        public void computeGamma()
        {

        }

        public void re_estimate()
        {

        }

        public void computer_log()
        {

        }
 
        public void sequenceState()
        {
            for (int t = 0; t < _lenghtSequenceT; t++)
            {
                double _maximum = double.NegativeInfinity;
                int _state = 0;
                for (int i = 0; i < _numberOfStatesN; i++)
                {
                    double _result = _matrixAlpha[t, i] * _matrixBeta[t, i];
                    if(_result > _maximum)
                    {
                        _maximum = _result;
                        _state = i;
                    }
                }
                _stateSequence.setValueToStatesSequence(_state);
            }
            _stateSequence.printStateSequence("(HMM sense)");
        }
    }
}
