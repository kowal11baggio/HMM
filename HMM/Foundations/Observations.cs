using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Foundations
{
    public class Observations
    {
        private static readonly Observations instance = new Observations();

        private int _numberOfObservations;
        public enum Observation { Washing, Biting, Standing, Yawning  };

        private Observations()
        {
            _numberOfObservations = 0;
            setNumberOfObservations();
        }

        public static Observations Instance
        {
            get
            {
                return instance;
            }
        }

        private void setNumberOfObservations()
        {
            _numberOfObservations = Enum.GetNames(typeof(Observation)).Length;
        }

        public int getNumberOfObservations()
        {
            return _numberOfObservations;
        }
    
    }
}
