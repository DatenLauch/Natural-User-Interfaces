using UnityEngine;

public class VirtualButtonController : MonoBehaviour
{
    public Player player; // Reference to the Player script

    public void OnButtonPressUp()
    {
        player.movement.SetDirection(Vector2.up); // Set the player's direction to up when the button is pressed
    }

        public void OnButtonPressDown()
    {
        player.movement.SetDirection(Vector2.down); // Set the player's direction to up when the button is pressed
    }

        public void OnButtonPressLeft()
    {
        player.movement.SetDirection(Vector2.left); // Set the player's direction to up when the button is pressed
    }

        public void OnButtonPressRight()
    {
        player.movement.SetDirection(Vector2.right); // Set the player's direction to up when the button is pressed
    }

    public void OnButtonRelease()
    {
        player.movement.SetDirection(Vector2.zero); // Set the player's direction to zero (no movement) when the button is released
    }
}
