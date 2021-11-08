using System.Collections.Generic;
using UnityEngine;

namespace Simulation
{
    public class SimulationTimer
    {
        List<Delay> delays = new List<Delay>();

        public void AddDelay(Delay delay)
        {
            delays.Add(delay);
        }

        public void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0; i < delays.Count; i++)
            {
                delays[i].time -= deltaTime;
            }
        }
    }

    public class Delay{
        public float time {get; set;}

        public Delay(float time)
        {
            this.time = time;
        }
    }
}