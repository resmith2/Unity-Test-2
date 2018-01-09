using UnityEngine.EventSystems;

namespace UnityTest2
{
    interface IBodyMovedTarget : IEventSystemHandler
    {
        void UpdatePosition();
    }
}