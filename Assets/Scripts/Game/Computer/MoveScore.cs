using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//������G���A�ŉ󂹂�u���b�N�܂ł̍ŏ��������v�Z����N���X
public class MoveScore : MonoBehaviour
{
    #region define
    /// <summary>
    /// ���u���b�N�̏��
    /// </summary>
    public enum STATE_ENUM
    {
        /// <summary> �������� </summary>
        MOVE,
        /// <summary> �ǃu���b�N�����蓮���Ȃ���� </summary>
        NO_MOVE,
        /// <summary> ���e�������� </summary>
        BOMB,
        /// <summary> �������������� </summary>
        FIRE,
        /// <summary> �󂹂�u���b�N����ɂ����� </summary>
        DESTINATION,
    }

    /// <summary>
    /// �����ɓ�����Ƃ��̃X�R�A
    /// </summary>
    private const int BOMBSCORE = 100;

    #endregion

    #region public field
    /// <summary>
    /// ���u���b�N�̏��
    /// </summary>
    public STATE_ENUM _State = STATE_ENUM.MOVE;

    /// <summary>
    /// �l���̏��I�u�W�F�N�g���i�[����
    /// </summary>
    public List<GameObject> _YukaObjects = new List<GameObject>();
    /// <summary>
    /// �l���̏��I�u�W�F�N�g�̃X�R�A���i�[����
    /// </summary>
    public List<MoveScore> _MoveScores = new List<MoveScore>();

    /// <summary>
    /// �ړI�n�܂ł̍ŒZ����
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
        //�l���̏���YukaObjects�ɕۊ�
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

        //�����K����ɂ��鎞�̓X�R�A��0��
        if (other.gameObject.tag == "Renga")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
            {
                _State = STATE_ENUM.DESTINATION;
                _Score = 0;
            }
        }

        //�ǂ���ɂ��鎞�͐i�߂Ȃ���Ԃ�
        if (other.gameObject.tag == "Kabe")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
                _State = STATE_ENUM.NO_MOVE;
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// ���t���[���Ă΂��X�R�A�̍X�V
    /// </summary>
    private void UpdateScore()
    {
        //�ړ��\�ȃG���A�̓X�R�A���X�V
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
    /// ��Ԃ��X�V���郁�\�b�h
    /// </summary>
    /// <param name="num">�X�V�����</param>
    /// <param name="x">���x���W</param>
    /// <param name="z">���z���W</param>
    /// <param name="state">�ύX������</param>
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
