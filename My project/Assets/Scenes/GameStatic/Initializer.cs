using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 특정 객체가 갖고 있고, 관리해야할 클래스들은 이걸로 묶어서
/// initalizer호출 후 update 직접 돌릴거임
/// </summary>
public interface Initializer
{
    void Init();

    void ManagerUpdate();
}
