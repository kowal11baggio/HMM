using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;
using System.Globalization;

namespace HMM.Matrices
{
    class InitialStateDistribution : IMatrixOperations
    {
        private static readonly InitialStateDistribution instance = new InitialStateDistribution();
        private double[] _initailMatrix;

        private InitialStateDistribution()
        {
            _initailMatrix = new double[States.Instance.getNumberOfStates()];
            setInitiallMatrix();
        }

        public static InitialStateDistribution Instance
        {
            get
            {
                return instance;
            }
        }

        private void setInitiallMatrix()
        {
            var fileName = @"A:/REPOS/HMM/HMM/DataFiles/InitialStateData.txt";
            setDataToMatrix(fileName);
            if (!stochasticMatrix())
                throw new System.Exception("Matrix is not stochastic.");
        }

        public double[] getInitailMatrix()
        {
            return _initailMatrix;
        }

        public bool stochasticMatrix()
        {
            double _sum = 0;
            for (int _j = 0; _j < States.Instance.getNumberOfStates(); _j++)
                _sum += _initailMatrix[_j] * 1000;
            if (_sum / 1000 != 1.0)
                return false;
            return true;
        }

        public void setDataToMatrix(string fileName)
        {
            int _j = 0;
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] lineStrings = line.Split(' ');
                foreach (string lineString in lineStrings)
                {
                    double _oneValue = double.Parse(lineString, CultureInfo.InvariantCulture.NumberFormat);
                    _initailMatrix[_j] = _oneValue;
                    _j++;
                }
            }
        }
    }
}
