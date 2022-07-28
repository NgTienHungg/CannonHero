using UnityEditor;
using UnityEngine;

public class Developer
{
    //[MenuItem("Developer/Clear Saves")]
    //public static void ClearSave()
    //{
    //    PlayerPrefs.DeleteAll();

    //    Debug.Log("All saves have been cleared!");
    //}

    [MenuItem("Developer/Unlock characters")]
    public static void UnlockCharacters()
    {
        // unlock skins

        Debug.Log("All characters have been unlocked!");
    }
}