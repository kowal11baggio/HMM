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
        private enum Observation { Large, Medium, Small };

        private Observations()
        {
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
