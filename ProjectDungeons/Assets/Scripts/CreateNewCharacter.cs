using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateNewCharacter : MonoBehaviour
{
    private BasePlayer basePlayer;

    public Toggle mage, warrior;
    public TMP_InputField characterNameInputField;
    public Button createCharacter;

    public void CreateANewCharacter()
    {
        if (mage.isOn)
        {
            basePlayer = new BasePlayer(new MageClass());
        }
        else if (warrior.isOn)
        {
            basePlayer = new BasePlayer(new WarriorClass());
        }

        basePlayer.CharacterName = characterNameInputField.text;

        Debug.Log(basePlayer.CharacterName);
        Debug.Log(basePlayer.Class);
        Debug.Log(basePlayer.Armor);
        Debug.Log(basePlayer.Resist);
        Debug.Log(basePlayer.MaxHealth);
        Debug.Log(basePlayer.Perseverance);
        Debug.Log(basePlayer.Power);
        Debug.Log(basePlayer.CriticalChance);
        Debug.Log(basePlayer.Haste);
        Debug.Log(basePlayer.AttackPotency);
    }
}
