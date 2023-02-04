using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComputerMove : MonoBehaviour
{
    #region define
    /// <summary>
    /// 行動の種類
    /// </summary>
    public enum MOVING_STATE
    {
        /// <summary> 何もしない </summary>
        NONE,
        /// <summary> その場に留まる </summary>
        STAY,
        /// <summary> 目的地に向かって動く </summary>
        MOVE,
        /// <summary> 目的地に到着 </summary>
        ARRIVE,
    }

    #endregion

    #region public field
    /// <summary>
    /// 行動の種類を制御
    /// </summary>
    public MOVING_STATE _MovingState　= MOVING_STATE.NONE;
    /// <summary>
    /// 爆弾設置のbool
    /// </summary>
    public bool _Bomb = false;

    /// <summary>
    /// 移動速度
    /// </summary>
    public float _TransrateSpeed = 2.0f;
    /// <summary>
    /// 爆弾の火力
    /// </summary>
    public float _Fire = 1;
    /// <summary>
    /// 設置できる爆弾の個数
    /// </summary>
    public int _BombNum = 1;
    #endregion

    #region private field
    /// <summary>
    /// 床オブジェクトのスコアを参照する
    /// </summary>
    private MoveScore _MoveScore;
    /// <summary>
    /// 目的地の座標
    /// </summary>
    public Vector3 _Destination;
    /// <summary>
    /// 現在いる床(往復運動させないため)
    /// </summary>
    private GameObject _MyYuka;       

    /// <summary>
    /// アニメーション制御用の変数
    /// </summary>
    private int trans;
    private Animator animator;
    public int num;

    #endregion

    #region Unity function
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_MovingState == MOVING_STATE.MOVE)
        {
            Move();
        }
        else if(_MovingState == MOVING_STATE.ARRIVE || _MovingState == MOVING_STATE.STAY)
        {
            DestinationSetting();
        }
    }

    //床に触れたらスコアを保存する
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Yuka")
        {
            _MoveScore = other.gameObject.GetComponent<MoveScore>();
            if(_MovingState == MOVING_STATE.NONE)
            {
                _Destination = new Vector3(other.transform.position.x, this.transform.position.y, other.transform.position.z);
            }
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// 目的地に到着したかどうかを判定する
    /// </summary>
    /// <param name="my">
    /// 自分のゲームオブジェクト
    /// </param>
    /// <param name="other">
    /// 距離を測りたい相手のゲームオブジェクト
    /// </param>
    /// <returns></returns>
    private bool ArriveDestination(GameObject my, Vector3 other)
    {
        //x座標とy座標がの差がともに0.1未満の時到着したと判定する
        if (Mathf.Abs(my.transform.position.x - other.x) < 0.1 && Mathf.Abs(my.transform.position.z - other.z) < 0.1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /// <summary>
    /// 目的地を設定する
    /// </summary>
    private void DestinationSetting()
    {
        int[] minScore = new int[_MoveScore._MoveScores.Count];
        int[] minIndex = new int[_MoveScore._MoveScores.Count];
        //四方の床オブジェクトのスコアを取得
        for(int i = 0; i < _MoveScore._MoveScores.Count; i++)
        {
            minScore[i] = _MoveScore._MoveScores[i]._Score;
            minIndex[i] = i;
        }
        Array.Sort(minScore, minIndex);

        for(int i = 0; i < minIndex.Length; i++)
        {
            num = 0;
            //レンガオブジェクトと隣接している時
            if (_MoveScore._MoveScores[minIndex[i]]._State == MoveScore.STATE_ENUM.DESTINATION)
            {
                num = 1;
                bool check = BombCheck(_Fire + 1, _MoveScore, _MoveScore, _MoveScore.gameObject.transform.position.x, _MoveScore.gameObject.transform.position.z);
                if (_BombNum > 0 && check)
                {
                    _Bomb = true;
                    break;
                }
                else if(_BombNum == 0)
                {
                    _MovingState = MOVING_STATE.STAY;
                    break;
                }
            }//移動先に何もないとき
            else if(_MoveScore._MoveScores[minIndex[i]]._State == MoveScore.STATE_ENUM.MOVE)
            {
                num = 2;
                //往復運動は爆弾設置する時のみ行う
                if(_MoveScore._YukaObjects[minIndex[i]] == _MyYuka)
                {
                    if (_Bomb)
                    {
                        _Destination = new Vector3(_MoveScore._YukaObjects[minIndex[i]].transform.position.x, this.transform.position.y, _MoveScore._YukaObjects[minIndex[i]].transform.position.z);
                        _MovingState = MOVING_STATE.MOVE;
                        _MyYuka = _MoveScore.gameObject;
                        break;
                    }
                }
                else
                {
                    _Destination = new Vector3(_MoveScore._YukaObjects[minIndex[i]].transform.position.x, this.transform.position.y, _MoveScore._YukaObjects[minIndex[i]].transform.position.z);
                    _MovingState = MOVING_STATE.MOVE;
                    _MyYuka = _MoveScore.gameObject;
                    break;
                }
            }//移動先が爆風に当たるとき
            else if(_MoveScore._MoveScores[minIndex[i]]._State == MoveScore.STATE_ENUM.FIRE)
            {
                num = 3;
                //現在地も爆風に当たるとき移動する
                if(_MoveScore._State == MoveScore.STATE_ENUM.FIRE)
                {
                    if (_MoveScore._YukaObjects[minIndex[i]] != _MyYuka)
                    {
                        _Destination = new Vector3(_MoveScore._YukaObjects[minIndex[i]].transform.position.x, this.transform.position.y, _MoveScore._YukaObjects[minIndex[i]].transform.position.z);
                        _MovingState = MOVING_STATE.MOVE;
                        _MyYuka = _MoveScore.gameObject;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 動く
    /// </summary>
    private void Move()
    {
        animator = GetComponent<Animator>();
        this.transform.LookAt(_Destination);
        this.transform.position += transform.forward * _TransrateSpeed * Time.deltaTime;
        if (ArriveDestination(this.gameObject, _Destination))
        {
            _MovingState = MOVING_STATE.ARRIVE;
        }
    }

    /// <summary>
    /// 爆弾設置チェック
    /// </summary>
    /// <param name="fire">火力</param>
    /// <param name="score1">床オブジェクトのスコア</param>
    /// <param name="score2">床オブジェクトのスコア</param>
    /// <param name="x">現在地のx座標</param>
    /// <param name="z">現在地のz座標</param>
    /// <returns></returns>
    private bool BombCheck(float fire, MoveScore score1, MoveScore score2, float x, float z)
    {
        bool checks = false;
        for(int i = 0; i < score2._MoveScores.Count; i++)
        {
            if(score2._MoveScores[i]._State == MoveScore.STATE_ENUM.MOVE && score2._MoveScores[i] != score1)
            {
                if(fire - 1 == 0 || (score2._MoveScores[i].gameObject.transform.position.x != x && score2._MoveScores[i].gameObject.transform.position.z != z))
                {
                    _Destination = new Vector3(score2._YukaObjects[i].transform.position.x, this.transform.position.y, score2._YukaObjects[i].transform.position.z);
                    _MovingState = MOVING_STATE.MOVE;
                    _MyYuka = _MoveScore.gameObject;
                    return true;
                }
                checks = BombCheck(fire - 1, score2, score2._MoveScores[i], x, z);
                if (checks)
                {
                    _Destination = new Vector3(score2._YukaObjects[i].transform.position.x, this.transform.position.y, score2._YukaObjects[i].transform.position.z);
                    _MovingState = MOVING_STATE.MOVE;
                    _MyYuka = _MoveScore.gameObject;
                    return true;
                }
            }
        }
        return checks;
    }

    #endregion
}
