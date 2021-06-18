using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelLoader : MonoBehaviour
{
    public static int currentLevel = 1;
    [SerializeField] Transform cellField;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Image correctImage;
    public static Sprite correctSprite;
    public static LevelLoader instance;

    private void Start()
    {
        instance = this;
        CreateLevel();
    }

    public void CreateLevel()
    {
        if (currentLevel > 3)
        {
            RestartManager.instance.StartRestart();
            return;
        }
        int cellNumber = 3 * currentLevel;
        foreach (Transform child in cellField)
        {
            Destroy(child.gameObject);
        }

        string resourcesPath = "";
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/");
        DirectoryInfo[] dirs = dir.GetDirectories();
        DirectoryInfo currentDir = dirs[Random.Range(0, dirs.Length)];
        resourcesPath += currentDir.Name + "/";
        Sprite[] _sprites = Resources.LoadAll<Sprite>(resourcesPath);
        List<Sprite> sprites = new List<Sprite>();
        List<Sprite> usedSprites = new List<Sprite>();
        sprites.AddRange(_sprites);

        for (int i = 0; i < cellNumber; i++)
        {
            Cell cell = Instantiate(cellPrefab, cellField).GetComponent<Cell>();
            Sprite sprite = sprites[Random.Range(0, sprites.Count)];
            sprites.Remove(sprite);
            usedSprites.Add(sprite);
            cell.SetUp(sprite);
        }

        correctSprite = usedSprites[Random.Range(0, usedSprites.Count)];
        correctImage.sprite = correctSprite;
        currentLevel++;
    }
}
