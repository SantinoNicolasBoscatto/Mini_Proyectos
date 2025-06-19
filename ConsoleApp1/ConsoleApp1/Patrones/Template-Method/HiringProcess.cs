using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Template_Method
{
    // Este es basicamente este es el patron 
    public abstract class HiringProcess
    {
        // Si quiero que alguno de estos metodos sea opcional en la implementacion los vuelvo
        // virtuales
        public abstract void ReceiveCV();
        public abstract void ConductInterview();
        public virtual void ConductSkillTest() { }
        public virtual void IssueOffer() { }

        public void HireCandidate()
        {
            ReceiveCV();
            ConductInterview();
            ConductSkillTest();
            IssueOffer();
        }
    }
}
