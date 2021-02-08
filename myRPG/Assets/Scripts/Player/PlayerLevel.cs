﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; set; }
    public int CurrentExperience { get; set; }
    public int RequiredExperience { get { return Level * 25; } }


    void Start()
    {
        CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;
    }

    public void EnemyToExperience(Enemy enemy)
    {
        GrantExperience(enemy.Experience);
    }

    public void GrantExperience(int amount)
    {
        CurrentExperience += amount;
        while (CurrentExperience >= RequiredExperience)
        {
            CurrentExperience -= RequiredExperience;
            Level++;
        }

        UIEventHandler.PlayerLevelChanged();
    }
}
