using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Controll_Type
{
    Slider,
    Left_Right
};

public static class StaticClass
{
    public static bool  pausedGame   = false;
    public static int   score;
    public static bool  isDeath      = false;
    public static Controll_Type main_Controlls = Controll_Type.Left_Right;

    public static string SensitivityKey = "Sensitivity";
}
