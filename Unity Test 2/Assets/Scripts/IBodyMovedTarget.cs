using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    interface IBodyMovedTarget : IEventSystemHandler
    {
        void UpdatePosition(string sender);
    }
}
