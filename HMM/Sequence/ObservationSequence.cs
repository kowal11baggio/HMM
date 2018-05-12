using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Foundations;

namespace HMM.Sequence
{
    class ObservationSequence
    {
        private int _lenghtObservation;
        private Observations.Observation[] _observationSequence;

        public ObservationSequence()
        {
            _lenghtObservation = _observationSequence.Count();
        }

        public void setObservationSequence()
        {
            // something here
        }

        public Observations.Observation[] getObservationSequence()
        {
            return _observationSequence;
        }


        public int getLenghtObservation()
        {
            return _lenghtObservation;
        }
    }
}
