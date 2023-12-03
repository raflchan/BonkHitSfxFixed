using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BonkHitSfxFixed.Patches
{
    [HarmonyPatch(typeof(Shovel))]
    internal class ShovelPatch
    {
        [HarmonyPatch("HitShovel")]
        [HarmonyPrefix]
        static void hitSFXPatch(ref AudioClip[] ___hitSFX)
        {
            ___hitSFX = BonkHitSfxFixedBase.newHitSfx;
        }
    }
}
