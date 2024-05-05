using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureFactory
{
    private readonly CharactersData _config;


    public ConfigureFactory(CharactersData config)
    {
        _config = config;
    }


    public Character Create(int id)
    {
        Character prefabToCreate = _config.GetPrefab(id);
        return UnityEngine.Object.Instantiate(prefabToCreate);
    }
    public CharacterIA CreateIA(int id)
    {
        CharacterIA prefabToCreate = _config.GetPrefabIA(id);
        return UnityEngine.Object.Instantiate(prefabToCreate);
    }
}
