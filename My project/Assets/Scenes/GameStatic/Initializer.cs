using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ư�� ��ü�� ���� �ְ�, �����ؾ��� Ŭ�������� �̰ɷ� ���
/// initalizerȣ�� �� update ���� ��������
/// </summary>
public interface Initializer
{
    void Init();

    void ManagerUpdate();
}
