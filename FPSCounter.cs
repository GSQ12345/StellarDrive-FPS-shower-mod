using MelonLoader;
using System;
using UnityEngine;

[assembly: MelonInfo(typeof(FPSCounter), "FPS Counter", "1.0.0", "GSQ123")]

public class FPSCounter : MelonMod
{
    private float fps;
    private float fpsTimer;

    private GUIStyle style;

    public override void OnInitializeMelon()
    {
        MelonLogger.Msg("FPS Counter loaded!");
    }

    public override void OnUpdate()
    {
        fpsTimer += Time.unscaledDeltaTime;

        if (fpsTimer >= 0.25f)
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsTimer = 0f;
        }
    }

    public override void OnGUI()
    {
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.fontSize = 20;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.UpperLeft;
            style.normal.textColor = Color.white;
        }

        GUI.Label(
            new Rect(10, 10, 150, 30),
            "FPS: " + Mathf.RoundToInt(fps),
            style
        );
    }
}