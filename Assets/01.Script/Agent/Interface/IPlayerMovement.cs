

public interface IPlayerMovement
{
    public bool IsOnDash { get; set; }
    public bool IsDash { get; set; }
    public void Jump(float power);
    public void Dash(float dashPower);
}
