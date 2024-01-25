using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValuesManager : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    int _currentHealth;

    int _points;

    public delegate void OnHealthChanged(float healthPercentage);
    public static event OnHealthChanged onHealthChanged;

    public delegate void OnPointsChanged(int points);
    public static event OnPointsChanged onPointsChanged;


    private void OnEnable()
    {
        PointPickup.onPointPickup += ChangePoints;
        _currentHealth = _maxHealth;
    }
    private void OnDisable()
    {
        PointPickup.onPointPickup -= ChangePoints;

    }

    void ChangePoints(int points)
    {
        _points += points;
        onPointsChanged?.Invoke(_points);
    }

    void SetHealth(int health)
    {
        _currentHealth = health;
        onHealthChanged?.Invoke(_currentHealth/_maxHealth);
    }

    public void SubtractHealth(int damage)
    {
        if (damage <= 0) return;
        Debug.Log(_currentHealth);
        _currentHealth -= damage;
        onHealthChanged?.Invoke((float)_currentHealth / (float)_maxHealth);
    }
}
