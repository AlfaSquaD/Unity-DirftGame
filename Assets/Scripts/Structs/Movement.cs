using UnityEngine;

namespace Structs{
    class Movement
    {
        public Vector2 direction {get; set;}
        public float speed{get; set;}  

        public float maxSpeed{get; set;} 

        public float drag{get; set;}
    }
}