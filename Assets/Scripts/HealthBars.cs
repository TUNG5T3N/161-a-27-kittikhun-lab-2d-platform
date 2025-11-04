using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    GameObject healthBarsFill;
    GameObject healthBarsBG;
    GameObject characterObject;

    RectTransform rectTransform;

    Character character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBarsFill = transform.gameObject;
        healthBarsBG = transform.parent.gameObject;
        characterObject = healthBarsBG.transform.parent.parent.gameObject;

        rectTransform = healthBarsFill.GetComponent<RectTransform>();

        character = characterObject.GetComponent<Character>();
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
