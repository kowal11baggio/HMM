using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;
using System.Globalization;

namespace HMM.Matrices
{
    class StateTransitionProbabilityMatrix : IMatrixOperations
    {
        private static readonly StateTransitionProbabilityMatrix instance = new StateTransitionProbabilityMatrix();
        private double[,] _matrixA;

        private StateTransitionProbabilityMatrix()
        {
            _matrixA = new double[States.Instance.getNumberOfStates(), States.Instance.getNumberOfStates()];
        }

        public static StateTransitionProbabilityMatrix Instance
        {
            get
            {
                return instance;
            }
        }

        public void createMatrix()
        {
            setMatrixA();
        }

        private void setMatrixA()
        {
            var fileName = @"A:/REPOS/HMM/HMM/DataFiles/StateTransitionProbabilityData.txt";
            setDataToMatrix(fileName);
            if (!stochasticMatrix())
                throw new System.Exception("Matrix is not stochastic.");
        }

        public double[,] getMatrixA()
        {
            if (!stochasticMatrix())
                return null;
            return _matrixA;
        }

        public bool stochasticMatrix()
        {
            double _sum = 0;
            for (int _i = 0; _i < States.Instance.getNumberOfStates(); _i++)
            {
                for (int _j = 0; _j < States.Instance.getNumberOfStates(); _j++)
                    _sum += _matrixA[_i, _j] * 1000;
                if (_sum / 1000 != 1.0)
                    return false;
                _sum = 0;
            }
            return true;
        }

        public void setDataToMatrix(string fileName)
        {
            int _i = 0, _j = 0;
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] lineStrings = line.Split(' ');
                foreach (string lineString in lineStrings)
                {
                    double _oneValue = double.Parse(lineString, CultureInfo.InvariantCulture.NumberFormat);
                    _matrixA[_i, _j] = _oneValue;
                    _j++;
                }
                _j = 0;
                _i++;
            }
        }
    }
}
