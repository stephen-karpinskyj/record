using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <remarks>Based on: http://answers.unity3d.com/questions/820311/ugui-multi-image-button-transition.html</remarks>
public class MultiImageButton : Button
{
    public List<Graphic> additionalTargetGraphics;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (transition == Transition.ColorTint)
        {
            Color color;
            switch (state)
            {
                case SelectionState.Normal: color = colors.normalColor; break;
                case SelectionState.Highlighted: color = colors.highlightedColor; break;
                case SelectionState.Pressed: color = colors.pressedColor; break;
                case SelectionState.Disabled: color = colors.disabledColor; break;
                default: color = Color.black; break;
            }

            switch (transition)
            {
                case Transition.ColorTint: ColorTween(color * colors.colorMultiplier, instant); break;
                default: throw new NotSupportedException();
            }
        }
    }

    void ColorTween(Color targetColor, bool instant)
    {
        if (additionalTargetGraphics == null)
        {
            additionalTargetGraphics = new List<Graphic>();
            foreach (Transform t in transform)
            {
                t.GetComponentsInChildren(additionalTargetGraphics);
            }
        }

        foreach (var g in additionalTargetGraphics)
        {
            if (!g)
            {
                continue;
            }
            
            g.CrossFadeColor(targetColor, !instant ? colors.fadeDuration : 0f, true, true);
        }
    }
}