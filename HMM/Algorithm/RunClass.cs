using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Matrices;
using HMM.Sequence;

namespace HMM.Algorithm
{
    public class RunClass
    {
        KernelHMMSence _kernelHMMSence;

        public RunClass()
        {
            _kernelHMMSence = new KernelHMMSence();
            initialization();
            HMMSenceAlgorithm();
        }

        public void initialization()
        {
            StateTransitionProbabilityMatrix.Instance.createMatrix();
            ObservationProbabilityMatrix.Instance.createMatrix();
            InitialStateDistribution.Instance.createMatrix();
            ObservationSequence.Instance.setInitialSeqeunce();
        }

        public void HMMSenceAlgorithm()
        {
            _kernelHMMSence.initialization();
            _kernelHMMSence.aflaPass();
            _kernelHMMSence.betaPass();
            _kernelHMMSence.sequenceState();
        }
    }
}
