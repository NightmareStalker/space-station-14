﻿using System.Numerics;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Mapping;

[GenerateTypedNameReferences]
public sealed partial class MappingDoNotMeasure : Control
{
    public MappingDoNotMeasure()
    {
        RobustXamlLoader.Load(this);
    }

    protected override Vector2 MeasureOverride(Vector2 availableSize)
    {
        return Vector2.Zero;
    }
}

