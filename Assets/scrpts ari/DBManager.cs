using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string usuario;
    public static float record;
    public static float record1;
    public static float record2;
    public static float record3;
    //public static string level;
    public static bool LoggedIn {get { return usuario != null; } }

    public static void LogOut()
    {
        usuario = null;
    }

}
