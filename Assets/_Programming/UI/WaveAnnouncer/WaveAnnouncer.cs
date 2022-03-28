using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveAnnouncer : MonoBehaviour
{
    #region Events

    void OnEnable()
    {
        GenerateEnemyState.onBeginNewWave += LaunchAnimation;
    }

    void OnDisable()
    {
        GenerateEnemyState.onBeginNewWave -= LaunchAnimation;
    }

    #endregion

    private Animator _animator;
    private TextMeshProUGUI _text;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void LaunchAnimation(int nbrOfWare)
    {
        _text.text = "Wave " + nbrOfWare + 1 + " begin !";
        _animator.Play("Announcement");
    }
}