using HarmonyLib;
using UnityEngine;

namespace BonkHitSfxFixed.Patches
{
    [HarmonyPatch(typeof(Shovel))]
    internal class ShovelPatch
    {
        [HarmonyPatch("HitShovelClientRpc")]
        [HarmonyPatch("HitShovel")]
        [HarmonyPrefix]
        static void hitSFXPatch(ref AudioClip[] ___hitSFX)
        {
            ___hitSFX = BonkHitSfxFixedBase.newHitSfx;
        }
    }
}
