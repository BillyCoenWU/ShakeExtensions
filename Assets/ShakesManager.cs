namespace RGSMS
{
    namespace SHAKE
    {
        using UnityEngine;
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine.SceneManagement;
        
        public static class ShakesManager
        {
            public class Shake
            {
                public class Data
                {
                    public float speed = 0.0f;
                    public float duration = 0.0f;
                    public float intensity = 0.0f;

                    public Transform transform = null;
                    public Rigidbody rigidbody = null;
                    public Rigidbody2D rigidbody2D = null;

                    public Vector3 v3Intensity = Vector3.zero;
                    public Vector2 v2Intensity = Vector2.zero;
                }

                private readonly Data m_data = null;

                public delegate void StartEvent();
                public StartEvent onStart;

                public delegate void FinishEvent();
                public FinishEvent onFinish;

                public Shake (IEnumerator coroutine)
                {
                    m_shake = coroutine;
                }
                
                public Shake (IEnumerator coroutine, bool start = true)
                {
                    m_shake = coroutine;

                    if (start)
                    {
                        Start();
                    }
                }

                public Shake (IEnumerator coroutine, Transform _transform)
                {
                    m_shake = coroutine;

                    m_data = new Data();
                    m_data.transform = _transform;
                }

                private IEnumerator m_shake;

                private bool m_stopped = false;

                private bool m_running = false;
                public bool running
                {
                    get
                    {
                        return m_running;
                    }
                }

                private bool m_paused = false;
                public bool paused
                {
                    get
                    {
                        return m_paused;
                    }
                }

                public void Start()
                {
                    Resume();
                    m_running = true;
                    m_stopped = false;
                    //StartCoroutine(ShakeCoroutine());
                }

                public void Stop()
                {
                    m_stopped = true;
                    m_running = false;
                }

                public void Pause()
                {
                    m_paused = true;
                }

                public void Resume()
                {
                    m_paused = false;
                }

                private IEnumerator ShakeCoroutine()
                {
                    yield return null;

                    ShakesManager.shakes.Add(this);

                    if (onStart != null)
                    {
                        onStart();
                    }
                    
                    while (m_running)
                    {
                        if (m_paused)
                        {
                            yield return null;
                        }
                        else
                        {
                            if (m_shake != null && m_shake.MoveNext())
                            {
                                yield return m_shake.Current;
                            }
                            else
                            {
                                m_running = false;
                            }
                        }
                    }

                    if (!m_stopped)
                    {
                        if (onFinish != null)
                        {
                            onFinish();
                        }
                    }

                    ShakesManager.shakes.Remove(this);
                }
            }

            public static List<Shake> shakes = null;

            [RuntimeInitializeOnLoadMethod]
            private static void Awake ()
            {
                shakes = new List<Shake>();

                SceneManager.sceneLoaded += SceneUnloaded;
            }

            private static void SceneUnloaded (Scene oldScene, LoadSceneMode mode)
            {
                StopAll();
            }

            public static Shake CreateShake (IEnumerator coroutine)
            {
                return new Shake(coroutine);
            }

            public static void StopAll ()
            {
                shakes.Clear();
            }

            public static void PauseAll ()
            {
                int count = shakes.Count;
                for (int i = 0; i < count; i++)
                {
                    shakes[i].Pause();
                }
            }

            public static void ResumeAll ()
            {
                int count = shakes.Count;
                for (int i = 0; i < count; i++)
                {
                    shakes[i].Resume();
                }
            }
        }
    }
}