using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    [SerializeField]private Spawner spawner;
    [SerializeField]private KeySpriteMapping[] keySpriteMappings;
    private SpriteRenderer[] sprites;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        foreach(SpriteRenderer spriteRend in sprites)
        {
            spriteRend.sprite = null;
        }
        if (spawner.TeddyTobuild.isInArea)
        {
            if (spawner.PartIndex >= 3)
            {
                return;
            }
            InputCombinaison currentCombinaison = spawner.InputCombinaisons[spawner.PartIndex];
            for (int i = 0; i < currentCombinaison.InputCombinaisonAxis.Count; i++)
            {

                KeyInput keyInput = currentCombinaison.InputCombinaisonAxis[i].InputAxis;
                sprites[i].sprite = SpriteMatch(keyInput);
            }
        }
    }
    private Sprite SpriteMatch(KeyInput keyInput)
    {
        foreach(KeySpriteMapping keySpriteMapping in keySpriteMappings)
        {
            if (keyInput == keySpriteMapping.key)
            {
                return keySpriteMapping.sprite;
            }
        }
        return null;
    }
    [System.Serializable]
    public class KeySpriteMapping
    {
        public KeyInput key;
        public Sprite sprite;
    }
}
