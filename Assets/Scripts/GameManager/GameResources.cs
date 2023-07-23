using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Tilemaps;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    public GameObject scorePrefab;

    public GameObject playerSelectionPrefab;

    public List<PlayerDetailsSO> playerDetailsList;

    public MusicTrackSO mainMenuMusic;

    public RoomNodeTypeListSO roomNodeTypeList;

    public CurrentPlayerSO currentPlayer;

    public Material dimmedMaterial;
    public Material litMaterial;

    public TileBase[] enemyUnwalkableCollisionTilesArray;
    public TileBase preferredEnemyPathTile;

    public Shader variableLitShader;

    public GameObject ammoIconPrefab;

    public AudioMixerGroup soundsMasterMixerGroup;
    public SoundEffectSO doorOpenCloseSoundEffect;
    public GameObject heartPrefab;

    public SoundEffectSO chestOpen;
    public SoundEffectSO healthPickup;
    public SoundEffectSO weaponPickup;
    public SoundEffectSO ammoPickup;

    public Shader materializeShader;

    public GameObject chestItemPrefab;
    public Sprite heartIcon;
    public Sprite bulletIcon;

    public GameObject minimapSkullPrefab;

    public AudioMixerGroup musicMasterMixerGroup;
    public AudioMixerSnapshot musicOnFullSnapshot;
    public AudioMixerSnapshot musicLowSnapshot;
    public AudioMixerSnapshot musicOffSnapshot;
}
