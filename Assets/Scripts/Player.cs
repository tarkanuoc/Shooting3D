using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Transform _playerFoot;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Camera _mainCamera;

    public PlayerUI PlayerUI { get => _playerUI;}
    public Transform PlayerFoot { get => _playerFoot;}
    public PlayerHealth PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public Camera MainCamera { get => _mainCamera; }
}
