using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using UnityEngine;

namespace ModRyon.Options
{
    public class BatOptions : AbstractOptionGroup
    {
        public override string GroupName => "こうもり";
        public override Color GroupColor => Color.white;
        public override bool ShowInMatchInfoGuide => true;

        [ModdedNumberOption("こうもりの人数", 0, 15)]
        public int BatCount { get; set; } = 1;
    }
}
