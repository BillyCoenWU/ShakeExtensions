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

                private readonly IEnumerator m_shake;

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
                    m_running = true;
                    s_instance.StartCoroutine(ShakeCoroutine());
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

                    s_instance.RemoveShake(this);
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
                SceneManager.sceneUnloaded += SceneUnloaded;
            }

            private void SceneUnloaded (Scene oldScene)
            {
                StopAll();
            }

            public Shake CreateShake (IEnumerator coroutine)
            {
                Shake s = new Shake(coroutine);
                m_shakes.Add(s);
                return s;
            }

            public void RemoveShake (Shake shake)
            {
                m_shakes.Remove(shake);
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