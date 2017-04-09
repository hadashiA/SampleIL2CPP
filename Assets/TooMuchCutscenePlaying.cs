using System.Collections;
using System.Linq;
using UnityEngine;
using Slate;

public class TooMuchCutscenePlaying : MonoBehaviour
{
    [SerializeField]
    GameObject CutscenePrefab;

    [SerializeField]
    GameObject ActorPrefab;

    [SerializeField]
    bool CutsceneEachTimeDestroy;

    [SerializeField]
    int Concurrency = 1;

    Cutscene[] _cutscenes;

    void Start()
    {
        _cutscenes = Enumerable.Range(0, Concurrency)
            .Select(_ => InstantiateCutscene())
            .ToArray();

        // StartCoroutine(StartPlayingCoroutine());
        foreach (var cutscene in _cutscenes)
        {
            PlayCutscene(cutscene);
        }
    }

    IEnumerator StartPlayingCoroutine()
    {
        foreach (var cutscene in _cutscenes)
        {
            PlayCutscene(cutscene);
            yield return new WaitForSeconds(0.25f);
        }
    }

    Cutscene InstantiateCutscene()
    {
        var cutscene = Instantiate(CutscenePrefab).GetComponent<Cutscene>();
        cutscene.SetGroupActorOfName("Actor1", Instantiate(ActorPrefab));
        return cutscene;
    }

    void PlayCutscene(Cutscene cutscene)
    {
        cutscene.Play(() =>
        {
            if (CutsceneEachTimeDestroy)
            {
                Destroy(cutscene.gameObject);
                PlayCutscene(InstantiateCutscene());
            }
            else
            {
                PlayCutscene(cutscene);
            }
        });
    }
}
