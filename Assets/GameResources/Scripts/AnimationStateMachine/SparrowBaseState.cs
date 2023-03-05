using UnityEngine;

/// <summary>
/// Основное состояние
/// </summary>
public abstract class SparrowBaseState
{
    protected Animator _animator = default;
    protected Movement _movement = default;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    /// <param name="sparrow"></param>
    public virtual void EnterState(SparrowStateManager sparrow)
    {
        _animator = sparrow.GetComponent<Animator>();
        _movement = sparrow.GetComponent<Movement>();
    }
}
