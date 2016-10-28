using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A15_Ex03
{
     public class Context
    {
        private IStrategy m_SecectedStrategy;

        public void setSimpleCalculationStrategy()
        {
            m_SecectedStrategy = new SimpleCalculationStrategy();
        }

        public void setAccuratCalculatiinStrategy()
        {
            m_SecectedStrategy = new AccurateCalculationStrategy();
        }

        public IStrategy getStrategy()
        {
            return m_SecectedStrategy;
        }
    }
}
