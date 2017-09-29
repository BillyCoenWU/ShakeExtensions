namespace RGSMS
{
    namespace SHAKE
    {
        using UnityEngine;
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine.SceneManagement;
        
        public class ShakesManager : MonoBehaviour
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

                    public SHAKE_TYPE type = SHAKE_TYPE.MOVE;

                    public Vector3 v3Intensity = Vector3.zero;
                    public Vector2 v2Intensity = Vector2.zero;
                }

                private readonly Data m_data = null;

                public delegate void StartEvent();
                public StartEvent onStart;

                public delegate void FinishEvent();
                public FinishEvent onFinish;

                public Shake(IEnumerator coroutine)
                {
                    m_shake = coroutine;
                }
                
                public Shake(IEnumerator coroutine, bool start = true)
                {
                    m_shake = coroutine;

                    if (start)
                    {
                        Start();
                    }
                }

                public Shake(IEnumerable coroutine, Transform _transform, SHAKE_TYPE type)
                {
                    m_data = new Data();
                    m_data.type = type;
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
                    Instance.StartCoroutine(ShakeCoroutine());
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

                    Instance.m_shakes.Add(this);

                    if (onStart != null)
                    {
                        onStart();
                    }
                    
                    /*
                    if(m_shake != null && !m_shake.MoveNext())
                    {
                        m_shake.Reset();
                    }
                    */
                    
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

                    Instance.m_shakes.Remove(this);
                }
            }

            private List<Shake> m_shakes = null;

            private static ShakesManager s_instance = null;
            public static ShakesManager Instance
            {
                get
                {
                    return s_instance;
                }
            }

            private void Awake ()
            {
                s_instance = this;
                m_shakes = new List<Shake>();
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += SceneUnloaded;
            }

            private void SceneUnloaded (Scene oldScene, LoadSceneMode mode)
            {
                StopAll();
            }

            public Shake CreateShake (IEnumerator coroutine)
            {
                return new Shake(coroutine);
            }

            public void StopAll ()
            {
                StopAllCoroutines();
                m_shakes.Clear();
            }

            public void PauseAll ()
            {
                int count = m_shakes.Count;
                for (int i = 0; i < count; i++)
                {
                    m_shakes[i].Pause();
                }
            }

            public void ResumeAll ()
            {
                int count = m_shakes.Count;
                for (int i = 0; i < count; i++)
                {
                    m_shakes[i].Resume();
                }
            }
        }
    }
}