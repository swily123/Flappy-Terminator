using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunAnimator _gunAnimator;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.LeftButtonClicked += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonClicked -= Shoot;
    }

    private void Shoot()
    {
        _gunAnimator.TrigerShootAnimator();
    }
}
