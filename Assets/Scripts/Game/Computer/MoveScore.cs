using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//動けるエリアで壊せるブロックまでの最小距離を計算するクラス
public class MoveScore : MonoBehaviour
{
    #region define
    /// <summary>
    /// 床ブロックの状態
    /// </summary>
    public enum STATE_ENUM
    {
        /// <summary> 動ける状態 </summary>
        MOVE,
        /// <summary> 壁ブロックがあり動けない状態 </summary>
        NO_MOVE,
        /// <summary> 爆弾がある状態 </summary>
        BOMB,
        /// <summary> 爆風が当たる状態 </summary>
        FIRE,
        /// <summary> 壊せるブロックが上にある状態 </summary>
        DESTINATION,
    }

    /// <summary>
    /// 爆風に当たるときのスコア
    /// </summary>
    private const int BOMBSCORE = 100;

    #endregion

    #region public field
    /// <summary>
    /// 床ブロックの状態
    /// </summary>
    public STATE_ENUM _State = STATE_ENUM.MOVE;

    /// <summary>
    /// 四方の床オブジェクトを格納する
    /// </summary>
    public List<GameObject> _YukaObjects = new List<GameObject>();
    /// <summary>
    /// 四方の床オブジェクトのスコアを格納する
    /// </summary>
    public List<MoveScore> _MoveScores = new List<MoveScore>();

    /// <summary>
    /// 目的地までの最短距離
    /// </summary>
    public int _Score;
    #endregion

    #region Unity function

    void Update()
    {
        UpdateScore();
    }

    private void OnCollisionEnter(Collision other)
    {
        //四方の床をYukaObjectsに保管
        if (other.gameObject.tag == "Yuka")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x || other.gameObject.transform.position.z == this.gameObject.transform.position.z)
            {
                if(other.gameObject.GetComponent<MoveScore>()._State != STATE_ENUM.NO_MOVE)
                {
                    _YukaObjects.Add(other.gameObject);
                    _MoveScores.Add(other.gameObject.GetComponent<MoveScore>());
                }
            }
        }

        //レンガが上にある時はスコアを0に
        if (other.gameObject.tag == "Renga")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
            {
                _State = STATE_ENUM.DESTINATION;
                _Score = 0;
            }
        }

        //壁が上にある時は進めない状態に
        if (other.gameObject.tag == "Kabe")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
                _State = STATE_ENUM.NO_MOVE;
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// 毎フレーム呼ばれるスコアの更新
    /// </summary>
    private void UpdateScore()
    {
        //移動可能なエリアはスコアを更新
        if(_State == STATE_ENUM.MOVE)
        {
            int min = _MoveScores[0]._Score;
            for (int i = 1; i < _MoveScores.Count; i++)
            {
                if(min > _MoveScores[i]._Score)
                {
                    min = _MoveScores[i]._Score;
                }
            }
            _Score = min + 1;
        }
        else if(_State == STATE_ENUM.BOMB || _State == STATE_ENUM.FIRE)
        {
            _Score = BOMBSCORE;
        }
    }

    /// <summary>
    /// 状態を更新するメソッド
    /// </summary>
    /// <param name="num">更新する回数</param>
    /// <param name="x">基準のx座標</param>
    /// <param name="z">基準のz座標</param>
    /// <param name="state">変更する状態</param>
    public void StateChange(float num, float x, float z, STATE_ENUM state)
    {
        for(int i = 0; i < _MoveScores.Count; i++)
        {
            if(_MoveScores[i]._State != state && _MoveScores[i]._State != STATE_ENUM.BOMB && _MoveScores[i]._State != STATE_ENUM.DESTINATION && (_MoveScores[i].gameObject.transform.position.x == x || _MoveScores[i].gameObject.transform.position.z == z))
            {
                _MoveScores[i]._State = state;
                if (num - 1 != 0)
                {
                    MoveScore moveScore = _MoveScores[i].gameObject.GetComponent<MoveScore>();
                    moveScore.StateChange(num - 1, x, z, state);
                }
            }
        }
    }
    #endregion
}
