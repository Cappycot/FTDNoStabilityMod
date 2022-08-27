using BrilliantSkies.Modding;
using HarmonyLib;
using System;
using System.Reflection;

namespace FTDNoStabilityMod
{
    [HarmonyPatch(typeof(StabilityModule))]
    public class Main : GamePlugin
    {
        public string name { get; } = "No Stability";
        public Version version { get; } = new Version(1, 0, 0);

        public void OnLoad()
        {
            Harmony harmony = new Harmony("cappycot.nostability");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnSave() { }

        [HarmonyPatch("Perform")]
        [HarmonyPostfix]
        public static void NoStability(StabilityModule __instance)
        {
            __instance._construct.Main.ExtraInaccuracy = 0f;
        }
    }
}
