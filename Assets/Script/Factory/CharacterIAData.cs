using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterIA", menuName = "CharacterIA Data")]
public class CharacterIAData : ScriptableObject
{
    public List<CharacterIA> prefabs;
    [HideInInspector] public int id;

    public CharacterIA GetPrefab(int id)
    {
        this.id = id;
        return prefabs.Find(enemy => enemy.id == id);
    }
}
