using UnityEngine;
using Simulation;
using Utils;
namespace Events
{
    public class OutOfFuelEvent : IEvent
    {

        private GameObject _player;
        public OutOfFuelEvent(GameObject player, float delay) : base(delay)
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