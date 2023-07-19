using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Units
{
  public class UnitStatDisplay : MonoBehaviour
  {
    public float maxHealth, armor, currentHealth;

    [SerializeField] private Image healthBarAmount;

    private bool isPlayerUnit = false;

    private void Start()
    {
      if (gameObject.GetComponentInParent<Player.PlayerUnit>())
      {
        maxHealth = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.health;
        armor = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.armor;
        isPlayerUnit = true;
      }
      else if (gameObject.GetComponentInParent<Enemy.EnemyUnit>())
      {
        maxHealth = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.health;
        armor = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.armor;
        isPlayerUnit = false;
      }
      else
      {
        Debug.LogError("No Unit Scripts found!");
      }

      currentHealth = maxHealth;
    }

    private void Update()
    {
      HandleHealth();
    }

    public void TakeDamage(float damage)
    {
      float totalDamage = damage - armor;
      currentHealth -= totalDamage;
    }

    private void HandleHealth()
    {
      Quaternion cameraRotation = Camera.main.transform.rotation;
      gameObject.transform.LookAt(gameObject.transform.position + cameraRotation * Vector3.forward, cameraRotation * Vector3.up);

      healthBarAmount.fillAmount = currentHealth / maxHealth;

      if (currentHealth <= 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (isPlayerUnit)
      {
        InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent);
        Destroy(gameObject.transform.parent.gameObject);
      }
      else
      {
        Destroy(gameObject.transform.parent.gameObject);
      }
    }
  }
}

