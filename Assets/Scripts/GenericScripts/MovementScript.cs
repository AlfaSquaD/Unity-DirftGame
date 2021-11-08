using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;

namespace GenericScripts
{
        
    public class MovementScript : MonoBehaviour
    {
        internal Movement movement = new Movement();

        internal Rigidbody2D rb;
        internal void Awake() {
            rb = gameObject.GetComponent<Rigidbody2D>();
            movement.direction = Vector2.zero;
            movement.speed = 0;
            movement.maxSpeed = 0;
            movement.drag = rb.drag;
            init();
        }

        internal virtual void CalculateMovement() {
            
        }

        internal void FixedUpdate() {
            CalculateMovement();
            rb.drag = movement.drag;
            rb.AddForce(movement.direction * movement.speed);
            if(rb.velocity.magnitude > movement.maxSpeed) {
                rb.velocity = rb.velocity.normalized * movement.maxSpeed;
            }
        }

        internal virtual void init(){

        }

    }

}
