using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Simulation;
using Events;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private Button _upgradeFuelTank, _upgradeFuels, _upgradeMultiplier;

    [SerializeField]
    private GameObject _fuelTank;

    [SerializeField]
    private Collider2D _roadCollider;

    [SerializeField]
    private Collider2D _middleCollider;

    [SerializeField]
    private float _fuelTankSpawnInterval;

    [SerializeField]
    private float _fuelTankSpawnIntervalRatio;

    [SerializeField]
    private float _fuelTankDeactivateInterval = 6f;

    [SerializeField]
    private Text _scoreText;

    private int money;

    private float earnedMoney;

    private float _fuelTankSpawnCurrent;

    private float _fuelTankSpawnIntervalRatioCurrent;

    private PlayerScript _player;

    private ProgressBar _fuelSlider;

    private ScoreText _scoreTextController;

    private SimulationQueue _simulationQueue;

    private FuelController _fuelController;

    private bool _isGameOver = false;

    private bool _isGameStarted = false;

    private DeactivateFuelEvent _deactivateFuelEvent;

    [RuntimeInitializeOnLoadMethod]

    private void Awake() {
        Debug.Log(Application.persistentDataPath);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _fuelSlider = GameObject.FindGameObjectWithTag("FuelSlider").GetComponent<ProgressBar>();
        _simulationQueue = new SimulationQueue();
        _fuelController =  new FuelController(_fuelTank, _roadCollider, _middleCollider);
        InstanceManager.AddInstance(this._simulationQueue);
        InstanceManager.AddInstance(this);
        InstanceManager.AddInstance(_player);
        _fuelTankSpawnIntervalRatioCurrent = 1;
        _fuelTankSpawnCurrent = _fuelTankSpawnInterval * _fuelTankSpawnIntervalRatioCurrent;
        _player.DisableControl();
        money = SaveController.GetSaveData().money;
        earnedMoney = 0;
        _scoreTextController = new ScoreText(_scoreText);
    }
    private void Update() {
        if(!_isGameStarted && Input.GetMouseButtonDown(0)){
            _isGameStarted = true;
            _player.EnableControl();
        }
        _simulationQueue.Simulate();
        _fuelSlider.SetProgress(_player.GetFuel());
        if(!_fuelController.IsFuelTankActive && _deactivateFuelEvent != null){
            _deactivateFuelEvent.SetActive(false);
            _deactivateFuelEvent = null;
        }
        if(!_isGameOver){
            SpawnFuelTank();
            earnedMoney += _player.CalculateScore();
           _scoreTextController.SetScore((int)earnedMoney);     
        } 
    }

    private void SpawnFuelTank() {
        _fuelTankSpawnCurrent -= Time.deltaTime;
        if (_fuelTankSpawnCurrent <= 0 && !_fuelController.IsFuelTankActive) {
            _fuelTankSpawnIntervalRatioCurrent += _fuelTankSpawnIntervalRatio;
            _fuelTankSpawnCurrent = _fuelTankSpawnInterval * _fuelTankSpawnIntervalRatioCurrent;
            if(_fuelController.SpawnFuel()){
                _deactivateFuelEvent = new DeactivateFuelEvent(_fuelTank ,_fuelTankDeactivateInterval);
                _simulationQueue.AddEvent(_deactivateFuelEvent);
            }
                
        }
    }

    public void GameOver(){
        _isGameOver = true;
    }
}
