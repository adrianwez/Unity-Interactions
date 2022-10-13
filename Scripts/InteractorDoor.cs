using UnityEngine;

public class InteractorDoor : Interactable
{
    public enum DoorType
    {
        Single,
        Double
    }
    [Header("Door Properties")]
    [SerializeField] private DoorType _doorType;
    [SerializeField] private float _moveDistance = 3;
    [SerializeField] private float _moveTime = 2;
    [SerializeField] private Vector3 _moveDirection = new();
    [SerializeField] private AudioClip _doorAudio;
    [SerializeField] private GameObject _doorA;
    [SerializeField] private GameObject _doorB;
    [SerializeField] private string _interactiveText = "[E] to <color=green> open </color> the door";
    [SerializeField] private bool _doorOpen = false;
    public override string GetDescription() => _interactiveText;
    public override void Interact()
    {
        if(_doorOpen) return;
        // Open Door
        switch (_doorType)
        {
            case DoorType.Single:
                // open door
                iTween.MoveAdd(_doorA, Vector3.up * _moveDistance, _moveTime);
                // play audio
                AudioSource.PlayClipAtPoint(_doorAudio, _doorA.transform.position);
                break;
            case DoorType.Double:
                GetComponent<BoxCollider>().enabled = false;
                // open door
                iTween.MoveAdd(_doorA, _moveDirection * _moveDistance, _moveTime);
                // play audio
                AudioSource.PlayClipAtPoint(_doorAudio, _doorA.transform.position);
                // open door
                iTween.MoveAdd(_doorB, -_moveDirection * _moveDistance, _moveTime);
                // play audio
                AudioSource.PlayClipAtPoint(_doorAudio, _doorB.transform.position);
                break;
            
        }
    }
}