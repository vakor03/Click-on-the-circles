﻿using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Configs/TimerConfig", fileName = "TimerConfigSO", order = 0)]
    public class TimerConfigSO : ScriptableObject
    {   
        [field:SerializeField] public float MaxTimer { get; private set; }
    }
}