using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulation;
using Structs;
using Events;
using Utils;

using GenericScripts;

public class PlayerScript : MovementScript
{

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _rotationSpeed = .1f;

    [SerializeField]
    private float _maxSpeed = 10f;

    [SerializeField]
    private float _normalDrag = 0;

    [SerializeField]
    private float _brakeDrag = .1f;

    public Fuel fuel { get; set; }

    private bool _controlEnabled = false;

    internal override void init()
    {
        this.movement.direction = Vector2.down;
        this.movement.speed = _speed;
        this.movement.maxSpeed = _maxSpeed;
        this.movement.drag = _normalDrag;
        this.fuel = new Fuel(SaveController.GetSaveData().fuelCapacity, SaveController.GetSaveData().fuelConsumption);
        base.init();
    }

    private void Update() {
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
         Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.down, movement.direction)),
         _rotationSpeed);
         DecreaseFuel();
    }
    

    private void Rotate(){
        if(Input.GetMouseButton(0) && _controlEnabled){
            this.movement.speed = _speed;
            this.movement.drag = _normalDrag;
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            this.movement.direction = Vector2.Lerp(movement.direction, direction, _rotationSpeed);
        }
        else{
            this.movement.drag = _brakeDrag;
            this.movement.speed = 0f;
        }
    }

    internal override void CalculateMovement()
    {
        Rotate();
    }

    public void EnableControl(){
        _controlEnabled = true;
    }

    public void DisableControl(){
        _controlEnabled = false;
    }

    public bool IsControlEnabled(){
        return _controlEnabled;
    }

    public float GetDriftAngle(){
        return Vector2.Angle(rb.velocity, VectorHelper.DegreeToVector2(transform.rotation.eulerAngles.z));
    }

    public float GetSpeed(){
        return rb.velocity.magnitude;
    }
    

    #region Triggers
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Asphalt"){
            Utils.InstanceManager.GetInstance<SimulationQueue>().AddEvent(new OutOfAsphaltEvent(this.gameObject, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "NotAsphalt"){
            Utils.InstanceManager.GetInstance<SimulationQueue>().AddEvent(new OutOfAsphaltEvent(this.gameObject, 0));
        }
    }

    #endregion

    #region Fuel
    public float GetFuel(){
        return fuel.fuel / fuel.maxFuel;
    }

    private void DecreaseFuel(){
        if(_controlEnabled){
            fuel -= Time.deltaTime * fuel.fuelConsumption;
            if(fuel <= 0){
                InstanceManager.GetInstance<SimulationQueue>().AddEvent(new OutOfFuelEvent(this.gameObject, 0));
            }
        }
    }

    public void IncreaseFuel(float amount){
        fuel += amount;
        if(fuel > fuel.maxFuel){
            fuel.fuel = fuel.maxFuel;
        }
    }

    #endregion


    public float CalculateScore(){
        return GetDriftAngle() > 15 ? (GetSpeed() * GetDriftAngle() * SaveController.GetSaveData().multiplier * 0.005f) : 0;
    }

    public void Restart(){
        this.fuel = new Fuel(SaveController.GetSaveData().fuelCapacity, SaveController.GetSaveData().fuelConsumption);
    }
}
    
    
