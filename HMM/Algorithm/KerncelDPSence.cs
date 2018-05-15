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

        private double[] _delta;
        private double[,] _paths;
        private double[,] _prec;

        StateSequence _stateSequence;

        public KerncelDPSence()
        {

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
            _delta = new double[_numberOfObservationsM];
            _paths = new double[_lenghtSequenceT, _numberOfStatesN];
            _prec = new double[_lenghtSequenceT, _numberOfStatesN];
        }
    }
}
