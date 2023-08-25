using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private const string _ANIMATOR_MOVE_X = "AnimMoveX";
    private const string _ANIMATOR_MOVE_Y = "AnimMoveY";

    public void ResetParam()
    {
        _playerAnimator.SetFloat(_ANIMATOR_MOVE_X, 0);
        _playerAnimator.SetFloat(_ANIMATOR_MOVE_Y, 0);
    }

    public void AnimationMove()
    {
        Vector2 direction = Player.Instance.Movement.TargetPosition - (Vector2)transform.position;
        direction.Normalize();
        direction.x = Mathf.RoundToInt(direction.x);
        direction.y = Mathf.RoundToInt(direction.y);

        _playerAnimator.SetFloat(_ANIMATOR_MOVE_X, direction.x);
        _playerAnimator.SetFloat(_ANIMATOR_MOVE_Y, direction.y);
    }
}