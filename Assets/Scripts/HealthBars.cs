using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    [field: SerializeField] GameObject healthBarsFill;
    [field: SerializeField] GameObject healthBarsBG;
    [field: SerializeField] GameObject characterObject;

    [field: SerializeField] RectTransform rectTransform;

    [field: SerializeField] Character character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBars();
    }

    void updateHealthBars()
    {
        float percentHP = character.Health / character.maxHealth;
        Debug.Log(percentHP);
        Debug.Log(character.Health);
        Debug.Log(character.maxHealth);
        rectTransform.localScale = new Vector2(percentHP, rectTransform.localScale.y);

        healthBarsBG.transform.localScale = new Vector2(characterObject.transform.localScale.x, healthBarsBG.transform.localScale.y);
    }
}
