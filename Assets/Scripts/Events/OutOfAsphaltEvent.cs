using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulation;
using Utils;

namespace Events
{
    public class OutOfAsphaltEvent : IEvent
    {
        private GameObject _player;

        public OutOfAsphaltEvent(GameObject player, float delay) : base(delay)
        {
            this._player = player;
        }

        internal override void Command()
        {
            _player.GetComponent<PlayerScript>().DisableControl();
            InstanceManager.GetInstance<GameController>().GameOver();
        }
    }
}