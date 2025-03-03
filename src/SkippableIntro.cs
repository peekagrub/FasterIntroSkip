﻿using System;
using System.Collections;
using System.Reflection;
using Modding;

namespace SkippableIntro;

public class SkippableIntro : Mod
{
    private FieldInfo skipChargeDurationInfo;

    new public string GetName() => "Skippable Intro";

    public override string GetVersion() => "1.0.0.0";

    public override void Initialize()
    {
        skipChargeDurationInfo = typeof(OpeningSequence).GetField("skipChargeDuration", BindingFlags.NonPublic | BindingFlags.Instance);
        On.OpeningSequence.Start += EnableSkippableIntro;
    }

    private IEnumerator EnableSkippableIntro(On.OpeningSequence.orig_Start orig, OpeningSequence self)
    {
        skipChargeDurationInfo.SetValue(self, -1f);
        return orig(self);
    }
}
