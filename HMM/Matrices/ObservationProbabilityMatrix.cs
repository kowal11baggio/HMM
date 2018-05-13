using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;
using System.Globalization;

namespace HMM.Matrices
{
    class ObservationProbabilityMatrix : IMatrixOperations
    {
        private static readonly ObservationProbabilityMatrix instance = new ObservationProbabilityMatrix();
        private double[,] _matrixB;

        private ObservationProbabilityMatrix()
        {
            _matrixB = new double[States.Instance.getNumberOfStates(), Observations.Instance.getNumberOfObservations()];
            setMatrixB();
        }

        public static ObservationProbabilityMatrix Instance
        {
            get
            {
                return instance;
            }
        }

        public void createMatrix()
        {
            setMatrixB();
        }

        private void setMatrixB()
        {
            var fileName = @"A:/REPOS/HMM/HMM/DataFiles/ObservationProbabilityData.txt";
            setDataToMatrix(fileName);
            if (!stochasticMatrix())
                throw new System.Exception("Matrix is not stochastic.");
        }

        public double[,] getMatrixB()
        {
            if (!stochasticMatrix())
                return null;
            return _matrixB;
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
                    _matrixB[_i, _j] = _oneValue;
                    _j++;
                }
                _j = 0;
                _i++;
            }
        }

        public bool stochasticMatrix()
        {
            double _sum = 0;
            for (int _i = 0; _i < States.Instance.getNumberOfStates(); _i++)
            {
                for (int _j = 0; _j < Observations.Instance.getNumberOfObservations(); _j++)
                    _sum += _matrixB[_i, _j] * 1000;
                if (_sum / 1000 != 1.0)
                    return false;
                _sum = 0;
            }
            return true;
        }
    }
}



