using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Destroyable
{
    void Destroy();
}

public interface Pickable
{
    void onPick();
}

public interface Movable
{
    void move();
}