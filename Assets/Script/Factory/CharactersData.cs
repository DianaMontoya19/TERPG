
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data")]
public class CharactersData : ScriptableObject
{
    [HideInInspector] public int id;

    public List<Character> prefabs;
 
    public Character GetPrefab(int id)
    {
        this.id = id;
        return prefabs.Find(player => player.id == id);

    }

}
