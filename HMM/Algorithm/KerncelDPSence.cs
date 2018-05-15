using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Matrices;
using HMM.Sequence;
using HMM.Foundations;

namespace HMM.Algorithm
{
    class KerncelDPSence
    {
        private int _lenghtSequenceT;
        private int _numberOfStatesN;
        private int _numberOfObservationsM;

        private double[,] _matrixA;
        private double[,] _matrixB;
        private double[] _matrixPi;

        private double[,] _delta;
        private string[] _paths;
        private string[] _prec;

        StateSequence _stateSequence;

        public KerncelDPSence()
        {
            _matrixA = null;
            _matrixB = null;
            _matrixPi = null;
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
            _paths = new string[_numberOfStatesN];
            _prec = new string[_numberOfStatesN];
            _delta = new double[_lenghtSequenceT, _numberOfStatesN];
        }
        public void algorithm()
        {
            for (int i = 0; i < _numberOfStatesN; i++)
            {
                if (_matrixPi[i] == 0.0)
                    _matrixPi[i] = double.Epsilon;
                _delta[0, i] = Math.Log(_matrixPi[i] * _matrixB[i, (int)ObservationSequence.Instance.getObservationSequence()[0]]);
                _paths[i] = i.ToString();
                _prec[i] = "";
            }
            for (int t = 1; t < _lenghtSequenceT; t++)
            {
                for (int i = 0; i < _numberOfStatesN; i++)
                {
                    double _maximum = double.NegativeInfinity;
                    for (int j = 0; j < _numberOfStatesN; j++)
                    {
                        double result = _delta[t - 1, j] + Math.Log(_matrixA[j, i]) + Math.Log(_matrixB[i, (int)ObservationSequence.Instance.getObservationSequence()[t]]);
                        if (result > _maximum)
                        {
                            _maximum = result;
                            _delta[t, i] = result;
                            _prec[i] = _paths[j];
                        }
                    }
                }
                for (int i = 0; i < _numberOfStatesN; i++)
                    _paths[i] = _prec[i] + i.ToString();
            }
            double best_path = double.NegativeInfinity;
            int last_state = 0;
            for (int i = 0; i < _numberOfStatesN; i++)
            {
                double result = _delta[_lenghtSequenceT - 1, i];
                if (result > best_path)
                {
                    best_path = result;
                    last_state = i;
                }
            }
            statesSequence(_paths[last_state]);
        }
        private void statesSequence(string statesSequence)
        {
            for (int t = 0; t < _lenghtSequenceT; t++)
            {
                _stateSequence.setValueToStatesSequence(statesSequence[t] - '0');
            }
            _stateSequence.printStateSequence("(DP sense)");
        }
    }
}
