using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //各操作のキーコードを保存する
    public KeyCode Zensin;
    public KeyCode Koutai;
    public KeyCode Migi;
    public KeyCode Hidari;
    public KeyCode Jamp;
    public KeyCode Setti;

    //音量を保存する
    public float SystemSound;
    public float BGMSound;
}
