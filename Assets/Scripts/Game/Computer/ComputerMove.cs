using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComputerMove : MonoBehaviour
{
    #region define
    /// <summary>
    /// �s���̎��
    /// </summary>
    public enum MOVING_STATE
    {
        /// <summary> �������Ȃ� </summary>
        NONE,
        /// <summary> ���̏�ɗ��܂� </summary>
        STAY,
        /// <summary> �ړI�n�Ɍ������ē��� </summary>
        MOVE,
        /// <summary> �ړI�n�ɓ��� </summary>
        ARRIVE,
    }

    #endregion

    #region public field
    /// <summary>
    /// �s���̎�ނ𐧌�
    /// </summary>
    public MOVING_STATE _MovingState�@= MOVING_STATE.NONE;
    /// <summary>
    /// ���e�ݒu��bool
    /// </summary>
    public bool _Bomb = false;

    /// <summary>
    /// �ړ����x
    /// </summary>
    public float _TransrateSpeed = 2.0f;
    /// <summary>
    /// ���e�̉Η�
    /// </summary>
    public float _Fire = 1;
    /// <summary>
    /// �ݒu�ł��锚�e�̌�
    /// </summary>
    public int _BombNum = 1;
    #endregion

    #region private field
    /// <summary>
    /// ���I�u�W�F�N�g�̃X�R�A���Q�Ƃ���
    /// </summary>
    private MoveScore _MoveScore;
    /// <summary>
    /// �ړI�n�̍��W
    /// </summary>
    public Vector3 _Destination;
    /// <summary>
    /// ���݂��鏰(�����^�������Ȃ�����)
    /// </summary>
    private GameObject _MyYuka;       

    /// <summary>
    /// �A�j���[�V��������p�̕ϐ�
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

    //���ɐG�ꂽ��X�R�A��ۑ�����
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
    /// �ړI�n�ɓ����������ǂ����𔻒肷��
    /// </summary>
    /// <param name="my">
    /// �����̃Q�[���I�u�W�F�N�g
    /// </param>
    /// <param name="other">
    /// �����𑪂肽������̃Q�[���I�u�W�F�N�g
    /// </param>
    /// <returns></returns>
    private bool ArriveDestination(GameObject my, Vector3 other)
    {
        //x���W��y���W���̍����Ƃ���0.1�����̎����������Ɣ��肷��
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
    /// �ړI�n��ݒ肷��
    /// </summary>
    private void DestinationSetting()
    {
        int[] minScore = new int[_MoveScore._MoveScores.Count];
        int[] minIndex = new int[_MoveScore._MoveScores.Count];
        //�l���̏��I�u�W�F�N�g�̃X�R�A���擾
        for(int i = 0; i < _MoveScore._MoveScores.Count; i++)
        {
            minScore[i] = _MoveScore._MoveScores[i]._Score;
            minIndex[i] = i;
        }
        Array.Sort(minScore, minIndex);

        for(int i = 0; i < minIndex.Length; i++)
        {
            num = 0;
            //�����K�I�u�W�F�N�g�Ɨאڂ��Ă��鎞
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
            }//�ړ���ɉ����Ȃ��Ƃ�
            else if(_MoveScore._MoveScores[minIndex[i]]._State == MoveScore.STATE_ENUM.MOVE)
            {
                num = 2;
                //�����^���͔��e�ݒu���鎞�̂ݍs��
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
            }//�ړ��悪�����ɓ�����Ƃ�
            else if(_MoveScore._MoveScores[minIndex[i]]._State == MoveScore.STATE_ENUM.FIRE)
            {
                num = 3;
                //���ݒn�������ɓ�����Ƃ��ړ�����
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
    /// ����
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
    /// ���e�ݒu�`�F�b�N
    /// </summary>
    /// <param name="fire">�Η�</param>
    /// <param name="score1">���I�u�W�F�N�g�̃X�R�A</param>
    /// <param name="score2">���I�u�W�F�N�g�̃X�R�A</param>
    /// <param name="x">���ݒn��x���W</param>
    /// <param name="z">���ݒn��z���W</param>
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
