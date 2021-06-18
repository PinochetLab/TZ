using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] Image image;
    BounceEffect bounceEffect;

    private void Start()
    {
        bounceEffect = GetComponentInChildren<BounceEffect>();
    }

    public void SetUp(Sprite _sprite)
    {
        print(_sprite.name);
        image.sprite = _sprite;
    }

    public void TryTap()
    {
        Sprite mySprite = image.sprite;
        Sprite correctSprite = LevelLoader.correctSprite;
        if (mySprite != correctSprite)
        {
            bounceEffect.IncorrectAnswer();
        }
        else
        {
            bounceEffect.CorrectAnswer();
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        LevelLoader.instance.CreateLevel();
    }
}
