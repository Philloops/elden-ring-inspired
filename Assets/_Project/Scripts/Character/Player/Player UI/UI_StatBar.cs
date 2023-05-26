using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nu11ity
{
    public class UI_StatBar : MonoBehaviour
    {
        private Slider slider;
        // VARIABLE TO SCALE BAR SIZE DEPENDING ON STAT (HIGHER STAT = LONGER BAR ACROSS SCREEN)
        // SECONDARY BAR BEHIND MAIN BAR FOR POLISH EFFECTR (YELLOW BAR THAT SHOWS HOW MUCH AN ACTION/DAMAGE TAKES AWAY FROM CURRENT STAT)


        protected virtual void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public virtual void SetStat(int newValue)
        {
            slider.value = newValue;
        }

        public virtual void SetMaxStat(int maxValue)
        {
            slider.maxValue = maxValue;
            slider.value = maxValue;
        }
    }
}
