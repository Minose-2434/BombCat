using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sound : MonoBehaviour
{
    private float volume;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //保存してある音量設定を適用する
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            volume = data.BGMSound;
        }
        else
        {
            volume = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = 0.01f * volume;
    }
}
