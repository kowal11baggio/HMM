using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Algorithm;
using HMM.Matrices;
using HMM.Sequence;

namespace HMM
{
    class ProgramRunClass
    {
        static void Main(string[] args)
        {
            StateTransitionProbabilityMatrix.Instance.createMatrix();
            ObservationProbabilityMatrix.Instance.createMatrix();
            InitialStateDistribution.Instance.createMatrix();
            ObservationSequence.Instance.setInitialSeqeunce();

            var kernelHMMSence = new KernelHMMSence();
            kernelHMMSence.initialization();
            kernelHMMSence.aflaPass();
            kernelHMMSence.betaPass();
            kernelHMMSence.sequenceState();
        }
    }
}
