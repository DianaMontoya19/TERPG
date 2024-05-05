using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfigureFactory
{
    private readonly CharactersData _config;
    private readonly CharacterIAData _configIA;

    public ConfigureFactory(CharactersData config)
    {
        _config = config;
    }
    public ConfigureFactory(CharacterIAData configIA)
    {
        _configIA = configIA;
    }

    public Character Create(int id,Transform transform)
    {
        Character prefabToCreate = _config.GetPrefab(id);
        return UnityEngine.Object.Instantiate(prefabToCreate, transform);
    }
    public CharacterIA CreateIA(int id, Transform transform)
    {
        CharacterIA prefabToCreate = _configIA.GetPrefab(id);
        return UnityEngine.Object.Instantiate(prefabToCreate, transform);
    }
}
