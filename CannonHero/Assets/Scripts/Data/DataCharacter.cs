using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterElement
{
    public string name;
    public int cost;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "NewDataCharacter", menuName = "Data/Character")]
public class DataCharacter : ScriptableObject
{
    public List<CharacterElement> list;
}