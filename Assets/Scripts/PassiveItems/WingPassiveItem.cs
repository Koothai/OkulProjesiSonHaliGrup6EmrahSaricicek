using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        base.ApplyModifier();
        player.CurrentMoveSpeed += (passiveItemData.Multiplier/100f);
    }
}
