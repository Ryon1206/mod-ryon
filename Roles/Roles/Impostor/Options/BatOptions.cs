using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using UnityEngine;

namespace ModRyon.Options
{
    public class BatOptions : AbstractOptionGroup
    {
        public override string GroupName => "options.batSettings";
        public override Color GroupColor => Color.white;
        public override bool ShowInMatchInfoGuide => true;

        [ModdedNumberOption("options.batSettings.count", min: 0, max: 15)]
        public int BatCount { get; set; } = 1;
    }
}
