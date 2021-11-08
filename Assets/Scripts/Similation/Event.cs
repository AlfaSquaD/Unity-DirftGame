using UnityEngine;
namespace Simulation
{
    
    public abstract class IEvent{

        private bool active = true;

        internal Delay delay;

        public bool isExecutedCalled { get; private set; }

        public bool isExecuted { get; private set; }

        public IEvent(float delay){
            this.delay = new Delay(delay);
            isExecutedCalled = false;
            isExecuted = false;
        }
        
        internal abstract void Command();

        internal virtual bool Precondition(){
            return true;
        }

        public bool Execute(){
            isExecutedCalled = true;
            if (Precondition() && delay.time <= 0 && active){
                isExecuted = true;
                Command();
                return true;
            }
            return !active;
        }

        public void SetActive(bool active){
            this.active = active;
        }
    }
}