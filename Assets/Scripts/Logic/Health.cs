using System;
using UnityEngine;

namespace Logic
{
    public class Health : MonoBehaviour
    {
        private int maxHelath = 100;
        public int currentHealth = 0;
        public Action onHealthChange;
        public Action onKill;

        public void Add(int value)
        {
            currentHealth += value;
            if (currentHealth > maxHelath)
            {
                currentHealth = maxHelath;
            }
            onHealthChange?.Invoke();
        }

        public int TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                onKill?.Invoke();
            }

            onHealthChange?.Invoke();
            return currentHealth;
        }

        [ContextMenu("AddSample")]
        public void AddSample()
        {
            Add(20);
        }

        [ContextMenu("TakeDamageSample")]
        public void TakeDamageSample()
        {
            TakeDamage(20);
        }
    }
}