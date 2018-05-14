using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HMM.Foundations;

namespace HMM.Sequence
{
    class ObservationSequence
    {
        private static readonly ObservationSequence instance = new ObservationSequence();
        private int _lenghtObservation;
        private Observations.Observation[] _observationSequence;

        private ObservationSequence()
        {
            _lenghtObservation = 0;
        }

        public static ObservationSequence Instance
        {
            get
            {
                return instance;
            }
        }

        private void setObservationSequence()
        {
            var fileName = @"A:/REPOS/HMM/HMM/DataFiles/ObservationSequenceData.txt";
            setData(fileName);
        }

        private void setData(string fileName)
        {
            int _j = 0;
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] lineStrings = line.Split(' ');
                _observationSequence = new Observations.Observation[lineStrings.Length];
                foreach (string lineString in lineStrings)
                {
                    int _oneValue = int.Parse(lineString, CultureInfo.InvariantCulture.NumberFormat);
                    _observationSequence[_j] = (Observations.Observation)_oneValue;
                    _j++;
                }
            }
            _lenghtObservation = _observationSequence.Count();
        }

        public void setInitialSeqeunce()
        {
            setObservationSequence();
        }

        public Observations.Observation[] getObservationSequence()
        {
            if (_lenghtObservation == 0)
            {
                throw new Exception("Empty observation sequence.");
            }
            return _observationSequence;
        }

        public int getLenghtObservation()
        {
            return _lenghtObservation;
        }
    }
}
