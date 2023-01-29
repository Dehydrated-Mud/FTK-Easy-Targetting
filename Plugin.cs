using BepInEx;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;

namespace FTK_Easy_Targetting
{
    [BepInPlugin("FTK_Easy_Targetting", "FTK_Easy_Targetting", "0.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static BaseUnityPlugin Instance;
        private void Awake()
        {
            // Plugin startup logic
            Instance = this;
            Logger.LogInfo($"Plugin {Info.Metadata.GUID} is loaded!");

            IL.EncounterSessionMC.StartNextCombatRound2 += (il) =>
            {
                ILCursor c = new ILCursor(il);
                c.GotoNext(
                    x => x.MatchLdloc(10),
                    x => x.MatchLdfld<EnemyAttackDecision>("m_Prof"),
                    x => x.MatchCall<GridEditor.FTK_proficiencyTableDB>("Get"),
                    x => x.MatchLdfld<GridEditor.FTK_proficiencyTable>("m_Tendency"),
                    x => x.MatchStloc(9)
                    );
                c.Index += 11;
                c.Emit(OpCodes.Ldloc_S, (byte)9);
                c.EmitDelegate<Func<CharacterStats.EnemyTendency, CharacterStats.EnemyTendency>>((et) =>
                {
                    Logger.LogWarning(String.Format("We have entered the Delegate with tendency " + et.ToString()));
                    if (et == CharacterStats.EnemyTendency.AttackLeastHealth || et == CharacterStats.EnemyTendency.AttackLeastResist || et == CharacterStats.EnemyTendency.AttackLeastArmor || et == CharacterStats.EnemyTendency.AttackLeastEvade || et == CharacterStats.EnemyTendency.AttackHasNoSanctum)
                    {
                        if (UnityEngine.Random.Range(0f, 1f) < 1.1f)
                        {
                            Logger.LogWarning("Setting tendency to none!");
                            return CharacterStats.EnemyTendency.None;
                        }
                    }
                    return et;
                });
                c.Emit(OpCodes.Stloc_S, (byte)9);

            };
        }
    }
}
