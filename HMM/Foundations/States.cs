using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM.Foundations
{
    public class States
    {
        private static readonly States instance = new States();

        private int _numberOfStates;
        private enum State { Hot, Cold };

        private States()
        {
            setNumberOfStates();
        }

        public static States Instance
        {
            get
            {
                return instance;
            }   
        }

        private void setNumberOfStates()
        {
            _numberOfStates = Enum.GetNames(typeof(State)).Length;
        }

        public int getNumberOfStates()
        {
            return _numberOfStates;
        }
       
    }
}
