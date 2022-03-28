using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsCounter : MonoBehaviour
{
    #region Events

    void OnEnable()
    {
        _playerWeapons.onBulletsNumberChange += DefineNumberOfBullets;
    }

    void OnDisable()
    {
        if (_playerWeapons != null)
            _playerWeapons.onBulletsNumberChange -= DefineNumberOfBullets;
    }

    #endregion

    #region Arguments

    private Weapons _playerWeapons;
    private TextMeshProUGUI _text;

    #endregion

    #region Methods

        #region Initialisation

    void Awake()
    {
        _playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapons>();
        _text = GetComponent<TextMeshProUGUI>();
    }

        #endregion
        
    void DefineNumberOfBullets(int numberOfBullets)
    {
        _text.text = "X " + numberOfBullets.ToString();
    }

    #endregion
}