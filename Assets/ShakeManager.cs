namespace RGSMS
{
    namespace Shake
    {
        using UnityEngine;
        using System.Collections;
        
        public enum AXIS
        {
            X_Y_Z = 0,
            X_Y,
            X_Z,
            Y_Z,
            X,
            Y,
            Z
        }
        
        public static class ShakeManager
        {
            //TO DO:
            // CRIAR METODOS BASICOS PARA ROTACAO E SCALE (PRIVATES)
            // CRIAR METODOS PUBLICOS COM DIFERENTES PARAMETROS
            // CRIAR SHAKE PARA 2D
            // CRIAR SHAKES QUE DUREM ENQUANTO UMA BOOLEANA ESTIVER TRUE
            
            #region Position
            
            // WOLRD
           
            public static IEnumerator ShakePosition(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                return ShakePosition(transform, intensity, duration, false, useFixedDeltaTime);
            }
            
            public static IEnumerator ShakePosition(this Transform transform, Vector3 intensity, float duration, bool useFixedDeltaTime)
            {
                return ShakePosition(transform, intensity, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakePosition(this Transform transform, AXIS axis, float intensity, float duration, bool useFixedDeltaTime)
            {
                return null;
            }

            public static IEnumerator ShakePosition(this Transform transform, AXIS axis, Vector3 intensity, float duration, bool useFixedDeltaTime)
            {
                return null;
            }

            public static IEnumerator ShakePositionX(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO X
                return null;
            }

            public static IEnumerator ShakePositionY(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO Y
                return null;
            }

            public static IEnumerator ShakePositionZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO Z
                return null;
            }

            public static IEnumerator ShakePositionXY(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XY
                return null;
            }

            public static IEnumerator ShakePositionXY(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XY
                return null;
            }

            public static IEnumerator ShakePositionXZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XZ
                return null;
            }

            public static IEnumerator ShakePositionXZ(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XZ
                return null;
            }

            public static IEnumerator ShakePositionYZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO YZ
                return null;
            }

            public static IEnumerator ShakePositionYZ(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO YZ
                return null;
            }

            // LOCAL

            public static IEnumerator ShakeLocalPosition(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                return ShakePosition(transform, intensity, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalPosition(this Transform transform, Vector3 intensity, float duration, bool useFixedDeltaTime)
            {
                return ShakePosition(transform, intensity, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalPosition(this Transform transform, AXIS axis, float intensity, float duration, bool useFixedDeltaTime)
            {
                return null;
            }

            public static IEnumerator ShakeLocalPosition(this Transform transform, AXIS axis, Vector3 intensity, float duration, bool useFixedDeltaTime)
            {
                return null;
            }

            public static IEnumerator ShakeLocalPositionX(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO X
                return null;
            }

            public static IEnumerator ShakeLocalPositionY(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO Y
                return null;
            }

            public static IEnumerator ShakeLocalPositionZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO Z
                return null;
            }

            public static IEnumerator ShakeLocalPositionXY(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XY
                return null;
            }

            public static IEnumerator ShakeLocalPositionXY(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XY
                return null;
            }

            public static IEnumerator ShakeLocalPositionXZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XZ
                return null;
            }

            public static IEnumerator ShakeLocalPositionXZ(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO XZ
                return null;
            }

            public static IEnumerator ShakeLocalPositionYZ(this Transform transform, float intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO YZ
                return null;
            }

            public static IEnumerator ShakeLocalPositionYZ(this Transform transform, Vector2 intensity, float duration, bool useFixedDeltaTime)
            {
                //EIXO YZ
                return null;
            }
            
            // PRIVATES
            private static IEnumerator ShakePosition (Transform transform, float intensity, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                Vector3 startPosition = isLocal ? transform.localPosition : transform.position;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    if (isLocal)
                    {
                        transform.localPosition = Random.insideUnitSphere * intensity;
                    }
                    else
                    {
                        transform.position = Random.insideUnitSphere * intensity;
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localPosition = startPosition;
                }
                else
                {
                    transform.position = startPosition;
                }
            }

            private static IEnumerator ShakePosition (Transform transform, Vector3 intensity, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                Vector3 startPosition = isLocal ? transform.localPosition : transform.position;
                Vector3 newRandomPosition = Vector3.zero;
               
                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    newRandomPosition = Random.insideUnitSphere;
                    newRandomPosition.x *= intensity.x;
                    newRandomPosition.y *= intensity.y;
                    newRandomPosition.z *= intensity.z;

                    if (isLocal)
                    {
                        transform.localPosition = newRandomPosition;
                    }
                    else
                    {
                        transform.position = newRandomPosition;
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localPosition = startPosition;
                }
                else
                {
                    transform.position = startPosition;
                }
            }

            private static IEnumerator ShakePosition (Transform transform, AXIS axis, float intensity, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                yield return null;
            }

            private static IEnumerator ShakePosition(Transform transform, AXIS axis, Vector3 intensity, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                yield return null;
            }

            #endregion

            #region Rotation

            // WORLD

            // LOCAL

            // PRIVATES

            #endregion

            #region EulerAngles

            // WORLD

            // LOCAL

            // PRIVATES

            #endregion

            #region Scale

            // WORLD

            // LOCAL

            // PRIVATES

            #endregion
        }
    }
}
