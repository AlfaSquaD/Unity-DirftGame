using System.Collections.Generic;

namespace Simulation
{
    
    class SimulationQueue {
        public SimulationQueue() {
        }

        private SimulationTimer simulationTimer = new SimulationTimer();
        private Queue<IEvent> eventQueue = new Queue<IEvent>();
        private Queue<IEvent> dequeued = new Queue<IEvent>();

        public void AddEvent(IEvent e) {
            eventQueue.Enqueue(e);
            simulationTimer.AddDelay(e.delay);
        }

        public int GetSize() {
            return eventQueue.Count;
        }

        public void Clear() {
            eventQueue.Clear();
        }

        public void Simulate(){
            simulationTimer.Update();
            while (eventQueue.Count > 0) {
                IEvent e = eventQueue.Dequeue();
                if(!e.Execute()) {
                    dequeued.Enqueue(e);
                }
            }
            foreach (IEvent e in dequeued) {
                eventQueue.Enqueue(e);
            }
            dequeued.Clear();
        }
    }
}