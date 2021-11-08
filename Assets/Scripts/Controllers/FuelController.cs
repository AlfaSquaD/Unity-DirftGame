using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController
{
    [SerializeField]
    private Collider2D _roadCollider;

    [SerializeField]
    private Collider2D _middleCollider;

    [SerializeField]
    private GameObject fuelTank;

    private float _minDistance;

    private float _maxDistance;

    private float _minDistanceOffSet = 0.7f;

    private float _maxDistanceOffSet = -0.7f;

    private FuelScript _fuelScript;

    private Vector2 _center;

    public bool IsFuelTankActive { 
        get{
            return fuelTank.activeInHierarchy;
        }
    }

    public FuelController(GameObject fuelTank, Collider2D roadCollider, Collider2D middleCollider)
    {
        this.fuelTank = fuelTank;
        _roadCollider = roadCollider;
        _middleCollider = middleCollider;
        _minDistance = Mathf.Abs(_middleCollider.bounds.extents.x + _minDistanceOffSet);
        _maxDistance = Mathf.Abs(_roadCollider.bounds.extents.x + _maxDistanceOffSet);
        _fuelScript = fuelTank.GetComponent<FuelScript>();
        _center = _middleCollider.transform.position;
    }

    public bool SpawnFuel()
    {
        if(!fuelTank.activeInHierarchy){
            Vector2 spawnDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            while(Mathf.Abs(Vector2.Angle(
                spawnDirection, Utils.InstanceManager.GetInstance<PlayerScript>().transform.localPosition))
                 < 30f){
                spawnDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            }
            float spawnDistance = Random.Range(_minDistance, _maxDistance);
            fuelTank.transform.position = (spawnDirection + _center) * spawnDistance;
            fuelTank.SetActive(true);
            return true;
        } 
        return false;
    }

    public void SetActive(bool active)
    {
        fuelTank.SetActive(active);
    }
}
