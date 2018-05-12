using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Sequence
{
    class ObservationSequence
    {
        private int _lenghtObservation;

        public void setLenghtObservation(int lenghtObservation)
        {
            _lenghtObservation = lenghtObservation;
        }

        public int getLenghtObservation()
        {
            return _lenghtObservation;
        }
    }
}
