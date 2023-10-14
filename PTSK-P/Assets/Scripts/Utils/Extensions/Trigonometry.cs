using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static partial class Extensions
    {
        public static float DirectionAngle(this Vector3 self)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 targetPos = Camera.main.WorldToScreenPoint(self);

            mousePos.x -= targetPos.x;
            mousePos.y -= targetPos.y;

            return Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        }

        public static float DirectionAngle(this Vector3 self, Vector3 target)
        {
            Vector3 dir = target - self;

            return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }

        public static Vector3 DirectionAngle(this Vector3 target, bool returnVector3)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 targetPos = Camera.main.WorldToScreenPoint(target);

            mousePos.x -= targetPos.x;
            mousePos.y -= targetPos.y;

            return mousePos;
        }

        public static Vector3 DirectionAngle(this Vector3 self, Vector3 target, bool returnVector2) => target - self;

        public static Vector3 GetAngleDirection(this float angle)
        {
            return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Tan(angle * Mathf.Deg2Rad));
        }

        public static Vector3 AngleAxisToVector3(float angle, float rotationDistance) => Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * rotationDistance);
    }
}