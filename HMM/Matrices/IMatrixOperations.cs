﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Matrices
{
    interface IMatrixOperations
    {
        bool stochasticMatrix();
        void setDataToMatrix(string fileName);
        void createMatrix();
    }
}
