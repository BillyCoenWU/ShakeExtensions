namespace RGSMS
{
    namespace SHAKE
    {
        #region Namespaces

        using UnityEngine;
        using System.Collections;

        #endregion

        #region Enumerators

        public enum VARIATION
        {
            RANDOM = 0,
            CRESCENT,
            DECRESCENT
        }

        public enum SHAKE_TYPE
        {
            MOVE = 0,
            ROTATION,
            SCALE
        }

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

        #endregion

        public static class ShakeExtensiton
        {
            // TO DO:
            // FAZER O SHAKE SER REUTILIZAVEL
            // RECTTRANSFORM 
            // QUANDO SHAKES SAO INTERROMPIDOS NAO VOLTAM PRA POSICAO INICIAL
            // CRIAR SHAKES QUE TENHAM VARIACOES NA INTENSIDADE
            // - [RANDOM DENTRO DE PARAMETROS / CRESCENTE DENTRO DE PARAMETROS / DECRESCENTE DENTRO DE PARAMETROS]
            // CRIAR SHAKES QUE DUREM ENQUANTO UM PARAMETRO FOR VERDADEIRO

            #region RectTransform


            #endregion

            #region Rigidbody

            #region 2D

            #region Position

            #region PUBLIC

            public static IEnumerator ShakePositon (this Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody2D, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositon (this Rigidbody2D rigidbody2D, Vector2 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody2D, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionX(this Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody2D, AXIS.X, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionY(this Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody2D, AXIS.Y, intensity, speed, duration, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATE

            private static IEnumerator ShakingPosition (Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDuration)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector2 startPosition = rigidbody2D.position;

                while (time < duration)
                {
                    time += Time.deltaTime;
                    step = speed * Time.deltaTime;
                    
                    rigidbody2D.MovePosition(Vector2.MoveTowards(startPosition, startPosition + (Random.insideUnitCircle * intensity), step));

                    yield return null;
                }

                rigidbody2D.MovePosition(startPosition);
            }

            private static IEnumerator ShakingPosition(Rigidbody2D rigidbody2D, Vector2 intensity, float speed, float duration, bool useFixedDuration)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector2 newRandomPosition = Vector2.zero;
                Vector2 startPosition = rigidbody2D.position;

                while (time < duration)
                {
                    time += Time.deltaTime;
                    step = speed * Time.deltaTime;
                    
                    newRandomPosition = Random.insideUnitCircle;
                    newRandomPosition.x *= intensity.x;
                    newRandomPosition.y *= intensity.y;

                    rigidbody2D.MovePosition(Vector2.MoveTowards(startPosition, startPosition + newRandomPosition, step));

                    yield return null;
                }

                rigidbody2D.MovePosition(startPosition);
            }

            private static IEnumerator ShakingPosition(Rigidbody2D rigidbody2D, AXIS axis, float intensity, float speed, float duration, bool useFixedDuration)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector2 newRandomPosition = Vector2.zero;
                Vector2 startPosition = rigidbody2D.position;

                while (time < duration)
                {
                    time += Time.deltaTime;
                    step = speed * Time.deltaTime;

                    newRandomPosition = Random.insideUnitCircle;
                    newRandomPosition.x *= intensity;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomPosition.y = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomPosition.x = 0.0f;
                            break;
                    }
                    
                    rigidbody2D.MovePosition(Vector2.MoveTowards(startPosition, startPosition + newRandomPosition, step));

                    yield return null;
                }

                rigidbody2D.MovePosition(startPosition);
            }
            
            #endregion

            #endregion

            #region Rotation

            #region PUBLIC
            
            public static IEnumerator ShakeRotationZ (this Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody2D, intensity, speed, duration, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATE

            private static IEnumerator ShakeRotation (Rigidbody2D rigidbody2D, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                float startRotation = rigidbody2D.rotation;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * Time.deltaTime;

                    rigidbody2D.MoveRotation(Mathf.MoveTowards(startRotation, startRotation + (Random.Range(-1.0f, 1.0f) * intensity), step));
                    
                    yield return null;
                }

                rigidbody2D.MoveRotation(startRotation);
            }

            #endregion

            #endregion

            #endregion

            #region 3D

            #region Position

            #region PUBLIC
            
            public static IEnumerator ShakePosition(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePosition(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(rigidbody, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionX(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.X, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionY(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXY(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXY(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXZ(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionYZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionYZ(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(rigidbody, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATE
            
            private static IEnumerator ShakingPosition(Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startPosition = rigidbody.position;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    rigidbody.MovePosition(Vector3.MoveTowards(startPosition, startPosition + (Random.insideUnitSphere * intensity), step));
                    
                    yield return null;
                }

                rigidbody.MovePosition(startPosition);
            }

            private static IEnumerator ShakingPosition(Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomPosition = Vector3.zero;
                Vector3 startPosition = rigidbody.position;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomPosition = Random.insideUnitSphere;
                    newRandomPosition.x *= intensity.x;
                    newRandomPosition.y *= intensity.y;
                    newRandomPosition.z *= intensity.z;

                    rigidbody.MovePosition(Vector3.MoveTowards(startPosition, startPosition + newRandomPosition, step));
                    
                    yield return null;
                }

                rigidbody.MovePosition(startPosition);
            }

            private static IEnumerator ShakePosition(Rigidbody rigidbody, AXIS axis, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomPosition = Vector3.zero;
                Vector3 startPosition = rigidbody.position;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomPosition = Random.insideUnitSphere;
                    newRandomPosition *= intensity;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomPosition.y = 0.0f;
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomPosition.x = 0.0f;
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomPosition.x = 0.0f;
                            newRandomPosition.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomPosition.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomPosition.x = 0.0f;
                            break;
                    }

                    rigidbody.MovePosition(Vector3.MoveTowards(startPosition, startPosition + newRandomPosition, step));

                    yield return null;
                }

                rigidbody.MovePosition(startPosition);
            }

            private static IEnumerator ShakePosition(Rigidbody rigidbody, AXIS axis, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomPosition = Vector3.zero;
                Vector3 startPosition = rigidbody.position;
                
                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomPosition = Random.insideUnitSphere;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomPosition.x *= intensity.x;
                            newRandomPosition.y = 0.0f;
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomPosition.y *= intensity.y;
                            newRandomPosition.x = 0.0f;
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomPosition.z *= intensity.z;
                            newRandomPosition.x = 0.0f;
                            newRandomPosition.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomPosition.x *= intensity.x;
                            newRandomPosition.y *= intensity.y;
                            newRandomPosition.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomPosition.x *= intensity.x;
                            newRandomPosition.z *= intensity.z;
                            newRandomPosition.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomPosition.y *= intensity.y;
                            newRandomPosition.z *= intensity.z;
                            newRandomPosition.x = 0.0f;
                            break;
                    }

                    rigidbody.MovePosition(Vector3.MoveTowards(startPosition, startPosition + newRandomPosition, step));

                    yield return null;
                }

                rigidbody.MovePosition(startPosition);
            }

            #endregion

            #endregion

            #region Rotation

            #region PUBLIC

            public static IEnumerator ShakeRotation(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingRotation(rigidbody, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotation(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingRotation(rigidbody, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationX(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.X, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationY(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXY(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXY(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXZ(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationYZ(this Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationYZ(this Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(rigidbody, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATE

            private static IEnumerator ShakingRotation(Rigidbody rigidbody, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Quaternion startRotation = rigidbody.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    rigidbody.MoveRotation(Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + (Random.insideUnitSphere * intensity)), step));
                    
                    yield return null;
                }

                rigidbody.MoveRotation(startRotation);
            }

            private static IEnumerator ShakingRotation(Rigidbody rigidbody, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = rigidbody.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;
                    newRandomRotation.x *= intensity.x;
                    newRandomRotation.y *= intensity.y;
                    newRandomRotation.z *= intensity.z;

                    rigidbody.MoveRotation(Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step));
                    
                    yield return null;
                }

                rigidbody.MoveRotation(startRotation);
            }

            private static IEnumerator ShakeRotation(Rigidbody rigidbody, AXIS axis, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = rigidbody.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;
                    newRandomRotation *= intensity;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomRotation.y = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomRotation.x = 0.0f;
                            break;
                    }

                    rigidbody.MoveRotation(Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step));

                    yield return null;
                }

                rigidbody.MoveRotation(startRotation);
            }

            private static IEnumerator ShakeRotation(Rigidbody rigidbody, AXIS axis, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = rigidbody.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.y = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.x = 0.0f;
                            break;
                    }

                    rigidbody.MoveRotation(Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step));

                    yield return null;
                }

                rigidbody.MoveRotation(startRotation);
            }

            #endregion

            #endregion

            #endregion

            #endregion

            #region Transform

            #region Position

            #region PUBLIC

            public static IEnumerator ShakePosition(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(transform, intensity, speed, duration, useFixedDeltaTime);
            }
            
            public static IEnumerator ShakePosition(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakingPosition(transform, intensity, speed, duration, useFixedDeltaTime);
            }
            
            public static IEnumerator ShakePositionX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.X, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakePositionYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakePosition(transform, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            #endregion
            
            #region PRIVATES
            
            private static IEnumerator ShakingPosition (Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startPosition = transform.localPosition;
                Vector3 newRandomPosition = startPosition;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    if (Vector3.Distance(transform.localPosition, newRandomPosition) <= 0.5f)
                    {
                        newRandomPosition = Random.insideUnitSphere;
                        newRandomPosition *= intensity;
                        newRandomPosition += startPosition;

                        while(step >= 1.0f)
                        {
                            step -= 1.0f;
                        }
                    }

                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    transform.localPosition = Vector3.Lerp(transform.localPosition, newRandomPosition, step);

                    yield return null;
                }

                transform.localPosition = startPosition;
            }

            private static IEnumerator ShakingPosition(Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startPosition = transform.localPosition;
                Vector3 newRandomPosition = startPosition;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    if (Vector3.Distance(transform.localPosition, newRandomPosition) <= 0.5f)
                    {
                        newRandomPosition = Random.insideUnitSphere;
                        newRandomPosition.x *= intensity.x;
                        newRandomPosition.y *= intensity.y;
                        newRandomPosition.z *= intensity.z;

                        newRandomPosition += startPosition;
                        while (step >= 1.0f)
                        {
                            step -= 1.0f;
                        }
                    }

                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime) * 10.0f;

                    transform.localPosition = Vector3.Lerp(transform.localPosition, newRandomPosition, step);

                    yield return null;
                }

                transform.localPosition = startPosition;
            }

            private static IEnumerator ShakePosition (Transform transform, AXIS axis, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startPosition = transform.localPosition;
                Vector3 newRandomPosition = startPosition;
                
                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    if (Vector3.Distance(transform.localPosition, newRandomPosition) <= 0.5f)
                    {
                        newRandomPosition = Random.insideUnitSphere;
                        newRandomPosition *= intensity;

                        switch (axis)
                        {
                            case AXIS.X:
                                newRandomPosition.y = 0.0f;
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.Y:
                                newRandomPosition.x = 0.0f;
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.Z:
                                newRandomPosition.x = 0.0f;
                                newRandomPosition.y = 0.0f;
                                break;

                            case AXIS.X_Y:
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.X_Z:
                                newRandomPosition.y = 0.0f;
                                break;

                            case AXIS.Y_Z:
                                newRandomPosition.x = 0.0f;
                                break;
                        }

                        newRandomPosition += startPosition;
                        while (step >= 1.0f)
                        {
                            step -= 1.0f;
                        }
                    }

                    step += speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime) * 10.0f;

                    transform.localPosition = Vector3.Lerp(transform.localPosition, newRandomPosition, step);

                    yield return null;
                }
                
                transform.localPosition = startPosition;
            }

            private static IEnumerator ShakePosition(Transform transform, AXIS axis, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startPosition = transform.localPosition;
                Vector3 newRandomPosition = startPosition;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;

                    if (Vector3.Distance(transform.localPosition, newRandomPosition) <= 0.5f)
                    {
                        newRandomPosition = Random.insideUnitSphere;

                        switch (axis)
                        {
                            case AXIS.X:
                                newRandomPosition.x *= intensity.x;
                                newRandomPosition.y = 0.0f;
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.Y:
                                newRandomPosition.y *= intensity.y;
                                newRandomPosition.x = 0.0f;
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.Z:
                                newRandomPosition.z *= intensity.z;
                                newRandomPosition.x = 0.0f;
                                newRandomPosition.y = 0.0f;
                                break;

                            case AXIS.X_Y:
                                newRandomPosition.x *= intensity.x;
                                newRandomPosition.y *= intensity.y;
                                newRandomPosition.z = 0.0f;
                                break;

                            case AXIS.X_Z:
                                newRandomPosition.x *= intensity.x;
                                newRandomPosition.z *= intensity.z;
                                newRandomPosition.y = 0.0f;
                                break;

                            case AXIS.Y_Z:
                                newRandomPosition.y *= intensity.y;
                                newRandomPosition.z *= intensity.z;
                                newRandomPosition.x = 0.0f;
                                break;
                        }

                        newRandomPosition += startPosition;
                        while (step >= 1.0f)
                        {
                            step -= 1.0f;
                        }
                    }

                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime) * 10.0f;

                    transform.localPosition = Vector3.Lerp(transform.localPosition, newRandomPosition, step);

                    yield return null;
                }

                transform.localPosition = startPosition;
            }

            #endregion

            #endregion

            #region Rotation

            #region WORLD

            public static IEnumerator ShakeRotation(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotation(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeRotationYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            #endregion

            #region LOCAL

            public static IEnumerator ShakeLocalRotation(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotation(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.X_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalRotationYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeRotation(transform, AXIS.Y_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATES

            private static IEnumerator ShakeRotation(Transform transform, float intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Quaternion startRotation = isLocal ? transform.localRotation : transform.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);
                    
                    if (isLocal)
                    {
                        transform.localRotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + (Random.insideUnitSphere * intensity)), step);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + (Random.insideUnitSphere * intensity)), step);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localRotation = startRotation;
                }
                else
                {
                    transform.rotation = startRotation;
                }
            }

            private static IEnumerator ShakeRotation(Transform transform, Vector3 intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = isLocal ? transform.localRotation : transform.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;
                    newRandomRotation.x *= intensity.x;
                    newRandomRotation.y *= intensity.y;
                    newRandomRotation.z *= intensity.z;
                    
                    if (isLocal)
                    {
                        transform.localRotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }
                    
                    yield return null;
                }

                if (isLocal)
                {
                    transform.localRotation = startRotation;
                }
                else
                {
                    transform.rotation = startRotation;
                }
            }

            private static IEnumerator ShakeRotation(Transform transform, AXIS axis, float intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = isLocal ? transform.localRotation : transform.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;
                    newRandomRotation *= intensity;
                    
                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomRotation.y = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomRotation.x = 0.0f;
                            break;
                    }

                    if (isLocal)
                    {
                        transform.localRotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localRotation = startRotation;
                }
                else
                {
                    transform.rotation = startRotation;
                }
            }

            private static IEnumerator ShakeRotation(Transform transform, AXIS axis, Vector3 intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomRotation = Vector3.zero;
                Quaternion startRotation = isLocal ? transform.localRotation : transform.rotation;
                Vector3 startEuLerAngles = startRotation.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomRotation = Random.insideUnitSphere;
                    
                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.y = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.x = 0.0f;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomRotation.x *= intensity.x;
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomRotation.y *= intensity.y;
                            newRandomRotation.z *= intensity.z;
                            newRandomRotation.x = 0.0f;
                            break;
                    }

                    if (isLocal)
                    {
                        transform.localRotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }
                    else
                    {
                        transform.rotation = Quaternion.RotateTowards(startRotation, Quaternion.Euler(startEuLerAngles + newRandomRotation), step);
                    }
                    
                    yield return null;
                }

                if (isLocal)
                {
                    transform.localRotation = startRotation;
                }
                else
                {
                    transform.rotation = startRotation;
                }
            }

            #endregion

            #endregion

            #region EulerAngles

            #region WORLD

            public static IEnumerator ShakeEuLerAngles(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAngles(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Y, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            public static IEnumerator ShakeEuLerAnglesYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y_Z, intensity, speed, duration, false, useFixedDeltaTime);
            }

            #endregion

            #region LOCAL

            public static IEnumerator ShakeLocalEuLerAngles(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAngles(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Y, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.X_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            public static IEnumerator ShakeLocalEuLerAnglesYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeEuLerAngles(transform, AXIS.Y_Z, intensity, speed, duration, true, useFixedDeltaTime);
            }

            #endregion

            #region PRIVATES

            private static IEnumerator ShakeEuLerAngles(Transform transform, float intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startEuLerAngles = isLocal ? transform.localEulerAngles : transform.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    if (isLocal)
                    {
                        transform.localEulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + (Random.insideUnitSphere * intensity), step, 360.0f);
                    }
                    else
                    {
                        transform.eulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + (Random.insideUnitSphere * intensity), step, 360.0f);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localEulerAngles = startEuLerAngles;
                }
                else
                {
                    transform.eulerAngles = startEuLerAngles;
                }
            }

            private static IEnumerator ShakeEuLerAngles(Transform transform, Vector3 intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomEuLerAngles = Vector3.zero;
                Vector3 startEuLerAngles = isLocal ? transform.localEulerAngles : transform.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomEuLerAngles = Random.insideUnitSphere;
                    newRandomEuLerAngles.x *= intensity.x;
                    newRandomEuLerAngles.y *= intensity.y;
                    newRandomEuLerAngles.z *= intensity.z;

                    if (isLocal)
                    {
                        transform.localEulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }
                    else
                    {
                        transform.eulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localEulerAngles = startEuLerAngles;
                }
                else
                {
                    transform.eulerAngles = startEuLerAngles;
                }
            }

            private static IEnumerator ShakeEuLerAngles(Transform transform, AXIS axis, float intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomEuLerAngles = Vector3.zero;
                Vector3 startEuLerAngles = isLocal ? transform.localEulerAngles : transform.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomEuLerAngles = Random.insideUnitSphere;
                    newRandomEuLerAngles *= intensity;
                    
                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomEuLerAngles.y = 0.0f;
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomEuLerAngles.x = 0.0f;
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomEuLerAngles.x = 0.0f;
                            newRandomEuLerAngles.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomEuLerAngles.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomEuLerAngles.x = 0.0f;
                            break;
                    }

                    if (isLocal)
                    {

                        transform.localEulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }
                    else
                    {
                        transform.eulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localEulerAngles = startEuLerAngles;
                }
                else
                {
                    transform.eulerAngles = startEuLerAngles;
                }
            }

            private static IEnumerator ShakeEuLerAngles(Transform transform, AXIS axis, Vector3 intensity, float speed, float duration, bool isLocal, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomEuLerAngles = Vector3.zero;
                Vector3 startEuLerAngles = isLocal ? transform.localEulerAngles : transform.eulerAngles;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomEuLerAngles = Random.insideUnitSphere;
                    
                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomEuLerAngles.x *= intensity.x;
                            newRandomEuLerAngles.y = 0.0f;
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomEuLerAngles.y *= intensity.y;
                            newRandomEuLerAngles.x = 0.0f;
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomEuLerAngles.z *= intensity.z;
                            newRandomEuLerAngles.x = 0.0f;
                            newRandomEuLerAngles.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomEuLerAngles.x *= intensity.x;
                            newRandomEuLerAngles.y *= intensity.y;
                            newRandomEuLerAngles.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomEuLerAngles.x *= intensity.x;
                            newRandomEuLerAngles.z *= intensity.z;
                            newRandomEuLerAngles.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomEuLerAngles.y *= intensity.y;
                            newRandomEuLerAngles.z *= intensity.z;
                            newRandomEuLerAngles.x = 0.0f;
                            break;
                    }

                    if (isLocal)
                    {
                        transform.localEulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }
                    else
                    {
                        transform.eulerAngles = Vector3.RotateTowards(startEuLerAngles, startEuLerAngles + newRandomEuLerAngles, step, 360.0f);
                    }

                    yield return null;
                }

                if (isLocal)
                {
                    transform.localEulerAngles = startEuLerAngles;
                }
                else
                {
                    transform.eulerAngles = startEuLerAngles;
                }
            }

            #endregion
            
            #endregion

            #region Scale

            #region PUBLIC

            public static IEnumerator ShakeScale(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return BaseShakeScale(transform, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScale(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return BaseShakeScale(transform, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleX(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.X, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleXY(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleXY(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.X_Y, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleXZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleXZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.X_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleYZ(this Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }

            public static IEnumerator ShakeScaleYZ(this Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime = false)
            {
                return ShakeScale(transform, AXIS.Y_Z, intensity, speed, duration, useFixedDeltaTime);
            }
            
            #endregion
            
            #region PRIVATES

            private static IEnumerator BaseShakeScale(Transform transform, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 startScale = transform.localScale;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    transform.localScale = Vector3.MoveTowards(startScale, startScale + (Random.insideUnitSphere * intensity), step);

                    yield return null;
                }

                transform.localScale = startScale;
            }

            private static IEnumerator BaseShakeScale(Transform transform, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomScale = Vector3.zero;
                Vector3 startScale = transform.localScale;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomScale = Random.insideUnitSphere;
                    newRandomScale.x *= intensity.x;
                    newRandomScale.y *= intensity.y;
                    newRandomScale.z *= intensity.z;
                    
                    transform.localScale = Vector3.MoveTowards(startScale, startScale + newRandomScale, step);

                    yield return null;
                }

                transform.localScale = startScale;
            }

            private static IEnumerator ShakeScale(Transform transform, AXIS axis, float intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomScale = Vector3.zero;
                Vector3 startScale = transform.localScale;
                
                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomScale = Random.insideUnitSphere;
                    newRandomScale *= intensity;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomScale.y = 0.0f;
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomScale.x = 0.0f;
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomScale.x = 0.0f;
                            newRandomScale.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomScale.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomScale.x = 0.0f;
                            break;
                    }
                    
                    newRandomScale += startScale;

                    transform.localScale = Vector3.MoveTowards(startScale, newRandomScale, step);

                    yield return null;
                }

                transform.localScale = startScale;
            }

            private static IEnumerator ShakeScale(Transform transform, AXIS axis, Vector3 intensity, float speed, float duration, bool useFixedDeltaTime)
            {
                float time = 0.0f;
                float step = 0.0f;
                Vector3 newRandomScale = Vector3.zero;
                Vector3 startScale = transform.lossyScale;

                while (time < duration)
                {
                    time += useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime;
                    step = speed * (useFixedDeltaTime ? Time.fixedDeltaTime : Time.deltaTime);

                    newRandomScale = Random.insideUnitSphere;

                    switch (axis)
                    {
                        case AXIS.X:
                            newRandomScale.x *= intensity.x;
                            newRandomScale.y = 0.0f;
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.Y:
                            newRandomScale.y *= intensity.y;
                            newRandomScale.x = 0.0f;
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.Z:
                            newRandomScale.z *= intensity.z;
                            newRandomScale.x = 0.0f;
                            newRandomScale.y = 0.0f;
                            break;

                        case AXIS.X_Y:
                            newRandomScale.x *= intensity.x;
                            newRandomScale.y *= intensity.y;
                            newRandomScale.z = 0.0f;
                            break;

                        case AXIS.X_Z:
                            newRandomScale.x *= intensity.x;
                            newRandomScale.z *= intensity.z;
                            newRandomScale.y = 0.0f;
                            break;

                        case AXIS.Y_Z:
                            newRandomScale.y *= intensity.y;
                            newRandomScale.z *= intensity.z;
                            newRandomScale.x = 0.0f;
                            break;
                    }

                    newRandomScale += startScale;
                    
                    transform.localScale = Vector3.MoveTowards(startScale, newRandomScale, step);

                    yield return null;
                }

                transform.localScale = startScale;
            }

            #endregion

            #endregion

            #endregion
        }
    }
}
