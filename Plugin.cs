using BepInEx;
using BepInEx.Logging;
using BonkHitSfxFixed.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BonkHitSfxFixed
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BonkHitSfxFixedBase : BaseUnityPlugin
    {
        private const string modGUID = "rafl.BonkHitSfxFixed";
        private const string modName = "Bonk Hit SFX (Fixed)";
        private const string modVersion = "1.0.1";


        private readonly Harmony harmony = new Harmony(modGUID);
        private static BonkHitSfxFixedBase instance;

        internal static ManualLogSource mls;
        internal static AudioClip[] newHitSfx;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo(String.Format("Initializing {0}", modName));

            string assetPath = instance.Info.Location.Replace("BonkHitSfxFixed.dll", "bonkhitsfxfixed");
            AssetBundle assetBundle = AssetBundle.LoadFromFile(assetPath);
            newHitSfx = assetBundle.LoadAssetWithSubAssets<AudioClip>("Assets/bonkhitsfx.mp3");

            List<System.Type> patches = new List<System.Type>
            {
                typeof(BonkHitSfxFixedBase),
                typeof(ShovelPatch)
            };

            foreach(System.Type patch in patches)
            {
                harmony.PatchAll(patch);
                mls.LogInfo(String.Format("Executed Patch '{0}'", patch.Name));
            }
        }
    }
}
