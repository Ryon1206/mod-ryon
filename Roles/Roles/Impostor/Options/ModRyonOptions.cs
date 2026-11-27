using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using UnityEngine;

namespace ModRyon.Options
{
    public class ModRyonOptions : AbstractOptionGroup
    {
        public override string GroupName => "Mod-Ryon";
        public override Color GroupColor => Color.white;
        public override uint GroupPriority => 0;

        [ModdedNumberOption("こうもりの人数", 0, 15)]
        public float BatCount { get; set; } = 1f;

        [ModdedNumberOption("こうもりの発光時間", 3, 30)]
        public float BatGlowDuration { get; set; } = 5f;

        [ModdedNumberOption("爆弾魔の人数", 0, 15)]
        public float BombardierCount { get; set; } = 1f;

        [ModdedNumberOption("タスク通知時間", 1, 30)]
        public float TaskNoticeDuration { get; set; } = 5f;
    }
}
